using System;

namespace FbxSharp
{
    public class TokenizationException : Exception
    {
        public TokenizationException()
            : base()
        {
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
