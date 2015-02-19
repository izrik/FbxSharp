using System;
using System.Collections.Generic;
using System.Text;

namespace FbxSharp
{
    public class ParseObject
    {
        public string Name;
        public List<object> Values = new List<object>();
        public List<ParseObject> Properties = new List<ParseObject>();
        public bool HasEmptyBlock = true;

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
            if (Properties != null || HasEmptyBlock)
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
            return this.Properties.Find(p => p.Name == name);
        }
    }
}

