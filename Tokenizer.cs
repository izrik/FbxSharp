using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FbxSharp
{
    public class Tokenizer
    {
        public Tokenizer(string input)
        {
            if (input == null) throw new ArgumentNullException("input");

            Input = input;
        }

        public readonly string Input;

        int index = 0;
        TokenType currentTokenType = TokenType.None;
        int tokenStart = -1;

        public Token? GetNextToken()
        {
            if (index >= Input.Length)
            {
                return null;
            }

            for (; index < Input.Length; index++)
            {
                char ch = Input[index];
                bool startString = false;

                if (currentTokenType == TokenType.None)
                {
                    currentTokenType = GetNewTokenType(ch);
                    if (currentTokenType == TokenType.Unknown) 
                        throw new InvalidOperationException(
                            string.Format("Unknown character '{0}' at index {1}", ch.ToString(), index));
                    tokenStart = index;
                    if (currentTokenType == TokenType.String) startString = true;
                }

                if (IsValidChar(currentTokenType, ch))
                {
                    if (!startString && IsForceEndChar(currentTokenType, ch))
                    {
                        var value = Input.Substring(tokenStart, index - tokenStart + 1);
                        var token = new Token(currentTokenType, value);
                        currentTokenType = TokenType.None;
                        index++;
                        return token;
                    }
                    else
                    {
                    }
                }
                else if (IsEndingChar(currentTokenType, Input[index - 1]))
                {
                    var value = Input.Substring(tokenStart, index - tokenStart);
                    var token = new Token(currentTokenType, value);

                    currentTokenType = GetNewTokenType(ch);
                    if (currentTokenType == TokenType.Unknown) 
                        throw new InvalidOperationException(
                            string.Format("Unknown character '{0}' at index {1}", ch.ToString(), index));
                    tokenStart = index;
                    index++;
                    return token;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            if (currentTokenType != TokenType.None)
            {
                char ch = Input[Input.Length-1];
                if (!IsEndingChar(currentTokenType, ch))
                {
                    throw new InvalidOperationException("Bad ending char");
                }

                var token = new Token(currentTokenType, Input.Substring(tokenStart));
                return token;
            }

            return null;
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

            throw new InvalidOperationException();
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
