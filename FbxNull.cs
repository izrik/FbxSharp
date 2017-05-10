using System;

namespace FbxSharp
{
    public class FbxNull : FbxNodeAttribute
    {
        public FbxNull(string name="")
        {
        }

        public override EAttributeType AttributeType { get { return EAttributeType.Null; } }
    }
}

