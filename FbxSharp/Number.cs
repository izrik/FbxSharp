using System;
using System.Globalization;

namespace FbxSharp
{
    public readonly struct Number : IEquatable<Number>
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
            var n = new Number(1);
            if (obj is Number number)
                n = number;
            return obj switch
            {
                Number => Equals(n),
                sbyte sb => AsLong.HasValue && AsLong.Value.Equals(sb),
                byte b => AsLong.HasValue && AsLong.Value.Equals(b),
                short s => AsLong.HasValue && AsLong.Value.Equals(s),
                ushort us => AsLong.HasValue && AsLong.Value.Equals(us),
                int i => AsLong.HasValue && AsLong.Value.Equals(i),
                uint ui => AsLong.HasValue && AsLong.Value.Equals(ui),
                long l => AsLong.HasValue && AsLong.Value.Equals(l),
                ulong ul => AsLong.HasValue && ul <= long.MaxValue &&
                            AsLong.Value.Equals((long)ul),
                float f => AsDouble.HasValue && AsDouble.Equals((double)f),
                double d => AsDouble.HasValue && AsDouble.Equals(d),
                string s => StringRepresentation != null &&
                            StringRepresentation == s,
                _ => false
            };
        }

        public bool Equals(Number n)
        {
            if (AsDouble.HasValue && n.AsDouble.HasValue)
                return AsDouble.Value.Equals(n.AsDouble.Value) &&
                       StringRepresentation == n.StringRepresentation;
            if (AsLong.HasValue && n.AsLong.HasValue)
                return AsLong.Value.Equals(n.AsLong.Value) &&
                       StringRepresentation == n.StringRepresentation;
            if (!AsDouble.HasValue && !n.AsDouble.HasValue &&
                !AsLong.HasValue && !n.AsLong.HasValue)
                return StringRepresentation == n.StringRepresentation;
            return false;
        }

        public override int GetHashCode() =>
            HashCode.Combine(StringRepresentation, AsLong, AsDouble);
    }
}
