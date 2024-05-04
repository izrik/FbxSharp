using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FbxSharp
{
    public class Tokenizer
    {
        public Tokenizer(string input, bool ignoreWhitespace=true, string filename="<unknown>")
            : this(new StringReader(input), ignoreWhitespace, filename)
        {
        }
        public Tokenizer(TextReader input, bool ignoreWhitespace=true, string filename="<unknown>")
        {
            if (input == null) throw new ArgumentNullException("input");

            Input = input;
            IgnoreWhitespace = ignoreWhitespace;
            Filename = filename;
        }

        public readonly TextReader Input;
        public readonly bool IgnoreWhitespace;
        public readonly string Filename;

        int index = 0;
        int line = 1;
        int column = 0;
	public InputLocation CurrentLocation
	{
		get { return new InputLocation(index, line, column, Filename); }
	}
        TokenType currentTokenType = TokenType.None;
        readonly List<char> newTokenChars = new List<char>();
        InputLocation tokenLocation;
        char lastChar = '\0';

        public Token? GetNextToken()
        {
            if (Input.Peek() == -1)
            {
                return null;
            }

            char ch = '\0';
            for (; ; index++, lastChar = ch)
            {
                if (Input.Peek() == -1)
                    break;

                ch = (char)Input.Read();
                column++;
                if (ch == '\n')
                {
                    line++;
                    column = 0;
                }
                bool startString = false;

                if (currentTokenType == TokenType.None)
                {
                    currentTokenType = GetNewTokenType(ch);
                    if (currentTokenType == TokenType.Unknown) 
                        throw new TokenizationException(

                            CurrentLocation,
                            string.Format("Unknown character '{0}'", ch.ToString()));
                    newTokenChars.Clear();
                    tokenLocation = new InputLocation(line, column, index, Filename);
                    if (currentTokenType == TokenType.String) startString = true;
                }


                if (IsValidChar(currentTokenType, ch))
                {
                    newTokenChars.Add(ch);
                    if (!startString && IsForceEndChar(currentTokenType, ch))
                    {
                        var value = new string(newTokenChars.ToArray());
                        var token = new Token(currentTokenType, value, tokenLocation);
                        currentTokenType = TokenType.None;
                        if (!ShouldIgnoreToken(token))
                        {
                            index++;
                            lastChar = ch;
                            return token;
                        }
                    }
                    else
                    {
                    }
                }
                else if (IsEndingChar(currentTokenType, lastChar))
                {
                    var value = new string(newTokenChars.ToArray());
                    var token = new Token(currentTokenType, value, tokenLocation);

                    currentTokenType = GetNewTokenType(ch);
                    if (currentTokenType == TokenType.Unknown) 
                        throw new TokenizationException(
                            CurrentLocation,
                            string.Format("Unknown character '{0}'", ch.ToString()));
                    newTokenChars.Clear();
                    newTokenChars.Add(ch);
                    tokenLocation = new InputLocation(line, column, index, Filename);
                    if (!ShouldIgnoreToken(token))
                    {
                        index++;
                        lastChar = ch;
                        return token;
                    }
                }
                else
                {
                    throw new TokenizationException(
                        CurrentLocation,
                        string.Format("Invalid character '{0}' at index {1}", ch.ToString(), index));
                }
            }

            if (currentTokenType != TokenType.None)
            {
                if (!IsEndingChar(currentTokenType, ch))
                {
                    throw new TokenizationException(
                        CurrentLocation,
                        "Bad ending char");
                }

                var value = new string(newTokenChars.ToArray());
                var token = new Token(currentTokenType, value, tokenLocation);
                if (!ShouldIgnoreToken(token))
                {
                    return token;
                }
            }

            return null;
        }

        bool ShouldIgnoreToken(Token token)
        {
            if (!IgnoreWhitespace) return false;

            if (token.Type == TokenType.Whitespace) return true;
            if (token.Type == TokenType.Comment) return true;

            return false;
        }

        // start token type x
        static TokenType GetNewTokenType(char ch)
        {
            if (ch == ';')
            {
                return TokenType.Comment;
            }
            else if (ch == '*')
            {
                return TokenType.Star;
            }
            else if (ch == '{')
            {
                return TokenType.OpenBrace;
            }
            else if (ch == '}')
            {
                return TokenType.CloseBrace;
            }
            else if (char.IsLetter(ch) || ch == '_')
            {
                return TokenType.Name;
            }
            else if (ch == '-' || ch == '+' || ch == '.' || char.IsDigit(ch))
            {
                return TokenType.Number;
            }
            else if (ch == ':')
            {
                return TokenType.Colon;
            }
            else if (ch == ',')
            {
                return TokenType.Comma;
            }
            else if (ch == '"')
            {
                return TokenType.String;
            }
            else if (char.IsWhiteSpace(ch))
            {
                return TokenType.Whitespace;
            }
            else
            {
                return TokenType.Unknown;
            }
        }


        static bool IsForceEndChar(TokenType tokenType, char ch)
        {
            // forces token type x to end
            switch (tokenType)
            {
            case TokenType.Comment:
                return (ch == '\n');
            case TokenType.String:
                return (ch == '"');
            case TokenType.Star:
                return (ch == '*');
            case TokenType.OpenBrace:
                return (ch == '{');
            case TokenType.CloseBrace:
                return (ch == '}');
            case TokenType.Colon:
                return (ch == ':');
            case TokenType.Comma:
                return (ch == ',');
            }

            return false;
        }

        // can be in token type x
        static bool IsValidChar(TokenType tokenType, char ch)
        {
            switch (tokenType)
            {
            case TokenType.Comment:
                return true;
            case TokenType.Name:
                return (char.IsLetterOrDigit(ch) || ch == '_');
            case TokenType.Number:
                return (char.IsLetterOrDigit(ch) || ch == 'e' || ch == 'E' || ch == '.' || ch == '-' || ch == '+');
            case TokenType.String:
                return true;
            case TokenType.Whitespace:
                return char.IsWhiteSpace(ch);
            case TokenType.Star:
                return (ch == '*');
            case TokenType.OpenBrace:
                return (ch == '{');
            case TokenType.CloseBrace:
                return (ch == '}');
            case TokenType.Colon:
                return (ch == ':');
            case TokenType.Comma:
                return (ch == ',');
            }

            throw new TokenizationException(
                string.Format("Not a valid token type: '{0}'", tokenType.ToString()));
        }

        // can be at end of token type x
        static bool IsEndingChar(TokenType tokenType, char ch)
        {
            switch (tokenType)
            {
            case TokenType.Comment:
                return (ch == '\n');
            case TokenType.Number:
                return (char.IsLetterOrDigit(ch) || ch == '.');
            case TokenType.String:
                return (ch == '"');
            }

            return IsValidChar(tokenType, ch);
        }

        public IEnumerable<Token> EnumerateTokens()
        {
            while (true)
            {
                var token = GetNextToken();
                if (token == null)
                    yield break;
                yield return token.Value;
            }
        }
    }
}
