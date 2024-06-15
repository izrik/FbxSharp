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

        public Number(long value)
        {
            StringRepresentation = value.ToString();
            AsDouble = (double)value;
            AsLong = value;
        }

        public Number(double value)
        {
            StringRepresentation = value.ToString();
            AsDouble = value;
            AsLong = (long)value;
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

        public override bool Equals(object obj)
        {
            return obj switch
            {
                sbyte or byte or short or ushort or int or uint or long =>
                    AsLong.HasValue && AsLong.Value.Equals(obj),
                ulong ul => AsLong.HasValue && ul <= long.MaxValue &&
                            AsLong.Value.Equals((long)ul),
                float f => AsDouble.HasValue && AsDouble.Equals((double)f),
                double d => AsDouble.HasValue && AsDouble.Equals(d),
                string s => StringRepresentation != null &&
                            StringRepresentation == s,
                _ => false
            };
        }

        public override int GetHashCode() =>
            HashCode.Combine(StringRepresentation, AsLong, AsDouble);
    }
}
