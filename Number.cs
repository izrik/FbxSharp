using System;

namespace FbxSharp
{
    public struct Number
    {
        public Number(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException("s");

            StringRepresentation = s;

            double d;
            if (double.TryParse(s, out d))
                AsDouble = d;
            else
                AsDouble = null;

            long l;
            if (long.TryParse(s, out l))
                AsLong = l;
            else
                AsLong = null;
        }

        public readonly string StringRepresentation;
        public readonly double? AsDouble;
        public readonly long? AsLong;
    }
}

