using System;

namespace FbxSharp
{
    public class TokenizationException : Exception
    {
        public TokenizationException(InputLocation location, string message)
            : this(FormatMessage(location, message))
        {
        }

        public TokenizationException(InputLocation location, string message, Exception inner)
            : this(FormatMessage(location, message), inner)
        {
        }

	static string FormatMessage(InputLocation location, string message)
	{
            return string.Format("at {0}:{1},{2}: {3}", location.Filename, location.Line, location.Column, message);
        }

        public TokenizationException(string message)
            : base(message)
        {
        }

        public TokenizationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
