using System;

namespace FbxSharp
{
    public class ConversionException : Exception
    {
        public ConversionException(InputLocation location, string message)
            : this(FormatMessage(location, message))
        {
        }

        public ConversionException(InputLocation location, string message, Exception inner)
            : this(FormatMessage(location, message), inner)
        {
        }

        static string FormatMessage(InputLocation location, string message)
        {
            return string.Format("at {0}:{1},{2}: {3}", location.Filename, location.Line, location.Column, message);
        }

        public ConversionException(string message)
            : base(message)
        {
        }

        public ConversionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
