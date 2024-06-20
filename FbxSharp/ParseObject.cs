using System;
using System.Collections.Generic;
using System.Text;

namespace FbxSharp
{
    [NotSdk]
    public class ParseObject
    {
        public string Name;
        public List<object> Values = new List<object>();
        public List<ParseObject> Properties = new List<ParseObject>();
        public bool HasEmptyBlock = true;
        public InputLocation Location;

        public BinaryParseInfo Extra = null;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(":");
            if (Values != null)
            {
                sb.Append(" ");
                if (Values.Count == 0)
                {
                }
                else if (Values.Count == 1)
                {
                    sb.Append(Values[0].ToString());
                }
                else
                {
                    sb.AppendFormat("{0} values", Values.Count);
                }
            }

            if ((Properties != null && Properties.Count > 0) || HasEmptyBlock)
            {
                sb.Append(" { ");
                if (!HasEmptyBlock && Properties.Count > 0)
                {
                    sb.AppendFormat("{0} properties", Properties.Count);
                }

                sb.Append(" }");
            }

            return sb.ToString();
        }

        public ParseObject FindPropertyByName(string name)
        {
            // Returns the first property found with the given name, or null if
            // no such property was found.
            return this.Properties.Find(p => p.Name == name);
        }

        public string GetStringValue(int index = 0)
        {
            // TODO: various checks
            return (string)Values[index];
        }

        public int GetIntValue(int index = 0)
        {
            // TODO: various checks
            var value = Values[index];
            switch (value)
            {
                case int i:
                    return i;
                case Number n:
                {
                    if (n.AsLong != null)
                        return (int)n.AsLong.Value;
                    throw new NotImplementedException();
                }
                default:
                {
                    var s = value.ToString();
                    if (!int.TryParse(s, out var x))
                        throw new ArgumentException(
                            $"Could not parse " +
                            $"value \"{s}\" as int");
                    return x;
                }
            }

            throw new NotImplementedException();
        }

        public class BinaryParseInfo
        {
            public int nextItemOffset = 0;
            public uint reserved0 = 0;
            public uint numValues = 0;
            public uint reserved2 = 0;
            public uint numValuesBytes = 0;
            public uint reserved4 = 0;
            public byte namelen = 0;
            public readonly List<byte> valuesTypes = [];
            public readonly List<uint?> valuesLengths = [];
        }
    }
}
