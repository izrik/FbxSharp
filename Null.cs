using System;

namespace FbxSharp
{
    public class Null : NodeAttribute
    {
        public override EAttributeType AttributeType { get { return EAttributeType.Null; } }
    }
}

