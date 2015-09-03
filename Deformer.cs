using System;

namespace FbxSharp
{
    public abstract class Deformer : FbxObject
    {
        protected Deformer(string name="")
            : base(name)
        {
        }

        public enum    EDeformerType
        {
            eUnknown,
            eSkin,
            eBlendShape,
            eVertexCache,
        }

        public abstract EDeformerType GetDeformerType();

        public override string GetNameSpacePrefix()
        {
            return "Deformer::";
        }
    }
}

