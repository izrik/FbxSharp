using System;

namespace FbxSharp
{
    public class ParseException : Exception
    {
        public ParseException(InputLocation location, string message)
            : this(FormatMessage(location, message))
        {
        }

        public ParseException(InputLocation location, string message, Exception inner)
            : this(FormatMessage(location, message), inner)
        {
        }

	static string FormatMessage(InputLocation location, string message)
	{
            return string.Format("at {0}:{1},{2}: {3}", location.Filename, location.Line, location.Column, message);
        }

        public ParseException(string message)
            : base(message)
        {
        }

        public ParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
