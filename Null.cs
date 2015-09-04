using System;

namespace FbxSharp
{
    public class Null : NodeAttribute
    {
        public Null(string name="")
        {
        }

        public override EAttributeType GetAttributeType()
        {
            return EAttributeType.Null;
        }
    }
}

