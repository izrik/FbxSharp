using System;

namespace FbxSharp
{
    public abstract class FbxNodeAttribute : FbxObject
    {
        protected FbxNodeAttribute(string name="")
            : base(name)
        {
            this.Properties.Add(Color);
        }

        public enum EAttributeType
        {
            Unknown,
            Null,
            Marker,
            Skeleton,
            Mesh,
            Nurbs,
            Patch,
            Camera,
            CameraStereo,
            CameraSwitcher,
            Light,
            OpticalReference,
            OpticalMarker,
            NurbsCurve,
            TrimNurbsSurface,
            Boundary,
            NurbsSurface,
            Shape,
            LODGroup,
            SubDiv,
            CachedEffect,
            Line,
        }


        public abstract EAttributeType AttributeType { get; }

        #region Public Member Functions

        public EAttributeType GetAttributeType()
        {
            return AttributeType;
        }

        public int GetNodeCount()
        {
            return GetDstObjectCount<FbxNode>();
        }

        public FbxNode GetNode(int pIndex=0)
        {
            return GetDstObject<FbxNode>(pIndex);
        }

        #endregion

        #region Public Attributes

        public readonly FbxPropertyT<FbxVector3> Color = new FbxPropertyT<FbxVector3>("Color");

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "NodeAttribute::";
        }
    }
}

