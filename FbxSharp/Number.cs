using System;
using System.Globalization;

namespace FbxSharp
{
    public struct Number
    {
        public Number(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("s");

            StringRepresentation = str;

            double d;
            if (double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out d))
                AsDouble = d;
            else
                AsDouble = null;

            long l;
            if (long.TryParse(str, out l))
                AsLong = l;
            else
                AsLong = null;

            if (!AsLong.HasValue && !AsDouble.HasValue)
            {
                throw new ArgumentException("The string cannot be interpreted as a number", "str");
            }
        }

        public readonly string StringRepresentation;
        public readonly double? AsDouble;
        public readonly long? AsLong;

        public override string ToString()
        {
            if (AsLong.HasValue)
            {
                return AsLong.Value.ToString();
            }
            else
            {
                return AsDouble.Value.ToString();
            }
        }
    }
}

