using System;

namespace FbxSharp
{
    public partial class FbxNull : FbxNodeAttribute
    {
        public FbxNull(string name="")
        {
        }

        public override EAttributeType AttributeType { get { return EAttributeType.Null; } }
    }
}

