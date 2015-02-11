using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Parser
    {
        public Parser(Tokenizer tokenizer)
        {
            if (tokenizer == null) throw new ArgumentNullException("tokenizer");

            this.tokenizer = tokenizer;

            GetNextToken();
        }

        readonly Tokenizer tokenizer;

        public List<ParseObject> ReadFile()
        {
            var properties = new List<ParseObject>();
            while (PeekNextToken().HasValue)
            {
                var item = ReadObject();
                properties.Add(item);
            }

            return properties;
        }

        enum ObjectState
        {
            Start,
            Name,
            Colon,
            PreValue,
            Array,
            String,
            Number,
            NameValue,
            PostValue,
            Comma,
            Block,
            End,
        }

        public ParseObject ReadObject()
        {
            var state = ObjectState.Start;

            string name = null;
            var values = new List<object>();
            bool hasEmptyBlock = false;
            List<ParseObject> subobjects = null;

            while (PeekNextToken().HasValue)
            {
                Token token;
                Token? peek;

                if (state == ObjectState.End) break;

                // when in state S, given token T, we will do X and transition to S2

                switch (state)
                {
                case ObjectState.Start:
                    state = ObjectState.Name;
                    break;
                case ObjectState.Name:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.Name)
                        throw new InvalidOperationException();
                    name = UnescapeString(token.Value);
                    state = ObjectState.Colon;
                    break;
                case ObjectState.Colon:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.Colon)
                        throw new InvalidOperationException();

                    peek = PeekNextToken();
                    if (peek == null)
                        throw new InvalidOperationException();
                    switch (peek.Value.Type)
                    {
                    case TokenType.OpenBrace:
                        state = ObjectState.Block;
                        break;
                    case TokenType.Star:
                        state = ObjectState.Array;
                        break;
                    default:
                        state = ObjectState.PreValue;
                        break;
                    }
                    break;
                case ObjectState.PreValue:
                    peek = PeekNextToken();
                    if (peek == null)
                        throw new InvalidOperationException();
                    switch (peek.Value.Type)
                    {
                    case TokenType.String:
                        state = ObjectState.String;
                        break;
                    case TokenType.Number:
                        state = ObjectState.Number;
                        break;
                    case TokenType.Name:
                        state = ObjectState.NameValue;
                        break;
                    default:
                        throw new InvalidOperationException();
                    }
                    break;
                case ObjectState.Array:
                    hasEmptyBlock = true;
                    subobjects = ReadArray();
                    if (subobjects.Count > 0)
                    {
                        hasEmptyBlock = false;
                    }
                    state = ObjectState.End;
                    break;
                case ObjectState.String:
                case ObjectState.NameValue:
                    token = GetNextToken().Value;
                    values.Add(UnescapeString(token.Value));
                    state = ObjectState.PostValue;
                    break;
                case ObjectState.Number:
                    token = GetNextToken().Value;
                    values.Add(new Number(token.Value));
                    state = ObjectState.PostValue;
                    break;
                case ObjectState.PostValue:
                    peek = PeekNextToken();
                    if (peek == null)
                    {
                        state = ObjectState.End;
                        break;
                    }
                    switch (peek.Value.Type)
                    {
                    case TokenType.Comma: // go to comma
                        state = ObjectState.Comma;
                        break;
                    case TokenType.OpenBrace: // go to block
                        state = ObjectState.Block;
                        break;
                    default: // go to end
                        state = ObjectState.End;
                        break;
                    }
                    break;
                case ObjectState.Comma:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.Comma)
                        throw new InvalidOperationException();
                    state = ObjectState.PreValue;
                    break;
                case ObjectState.Block:
                    hasEmptyBlock = true;
                    subobjects = ReadBlock();
                    if (subobjects.Count > 0)
                    {
                        hasEmptyBlock = false;
                    }
                    state = ObjectState.End;
                    break;
                case ObjectState.End:
                    // assemble parse object and return
                    break;
                default:
                    throw new InvalidOperationException();
                }
            }

            return new ParseObject {
                Name = name,
                Values = values,
                Properties = subobjects,
                HasEmptyBlock = hasEmptyBlock,
            };
        }

        enum ArrayState
        {
            Start,
            Star,
            Number,
            Block,
            End,
        }

        public List<ParseObject> ReadArray()
        {
            var state = ArrayState.Start;
            List<ParseObject> subobjects = null;
            int count = -1;

            while (PeekNextToken().HasValue)
            {
                Token token;

                if (state == ArrayState.End) break;

                switch (state)
                {
                case ArrayState.Start:
                    state = ArrayState.Star;
                    break;
                case ArrayState.Star:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.Star)
                        throw new InvalidOperationException();
                    state = ArrayState.Number;
                    break;
                case ArrayState.Number:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.Number)
                        throw new InvalidOperationException();
                    count = int.Parse(token.Value);
                    state = ArrayState.Block;
                    break;
                case ArrayState.Block:
                    subobjects = ReadBlock();
                    if (subobjects.Count != 1)
                    {
                        throw new InvalidOperationException("Malformed array");
                    }
                    if (subobjects[0].Values.Count != count)
                    {
                        throw new InvalidOperationException("Array size mismatch");
                    }
                    state = ArrayState.End;
                    break;
                case ArrayState.End:
                    break;
                }
            }

            return subobjects;
        }

        enum BlockState
        {
            Start,
            OpenBrace,
            Object,
            CloseBrace,
            End,
        }

        public List<ParseObject> ReadBlock()
        {
            var state = BlockState.Start;
            var objects = new List<ParseObject>();

            while (PeekNextToken().HasValue)
            {
                Token token;
                Token? peek;

                if (state == BlockState.End) break;

                switch (state)
                {
                case BlockState.Start:
                    state = BlockState.OpenBrace;
                    break;
                case BlockState.OpenBrace:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.OpenBrace)
                        throw new InvalidOperationException();
                    peek = PeekNextToken();
                    if (peek == null)
                        throw new InvalidOperationException();
                    state = (peek.Value.Type == TokenType.CloseBrace) ? BlockState.CloseBrace : BlockState.Object;
                    break;
                case BlockState.Object:
                    var obj = ReadObject();
                    objects.Add(obj);
                    peek = PeekNextToken();
                    if (peek == null)
                        throw new InvalidOperationException();
                    if (peek.Value.Type == TokenType.CloseBrace)
                    {
                        state = BlockState.CloseBrace;
                    }
                    // otherwise, stay on Object state
                    break;
                case BlockState.CloseBrace:
                    token = GetNextToken().Value;
                    if (token.Type != TokenType.CloseBrace)
                        throw new InvalidOperationException();
                    state = BlockState.End;
                    break;
                }
            }

            return objects;
        }

        public static string UnescapeString(string value)
        {
            if (value[0] == '"')
                return value.Substring(1, value.Length - 2);
            return value;
        }

        Token? nextToken;
        public Token? GetNextToken()
        {
            var next = nextToken;
            nextToken = tokenizer.GetNextToken();
            return next;
        }

        public Token? PeekNextToken()
        {
            return nextToken;
        }
    }
}

