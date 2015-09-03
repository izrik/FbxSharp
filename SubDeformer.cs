using System;

namespace FbxSharp
{
    public abstract class SubDeformer : FbxObject
    {
        protected SubDeformer(string name="")
            : base(name)
        {
        }

        public enum EType
        {
            eUnknown,
            eCluster,
            eBlendShapeChannel
        }

        public bool IsMultiLayer = false;

        public void SetMultiLayer(bool pMultiLayer)
        {
            IsMultiLayer = pMultiLayer;
        }

        public bool GetMultiLayer()
        {
            return IsMultiLayer;
        }

        public abstract EType GetSubDeformerType();

        public override string GetNameSpacePrefix()
        {
            return "SubDeformer::";
        }
    }
}

