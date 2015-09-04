using System;

namespace FbxSharp
{
    public abstract class NodeAttribute : FbxObject
    {
        protected NodeAttribute(string name="")
            : base(name)
        {
            this.Properties.Add(Color);
            nodes = DstObjects.CreateCollectionView<Node>();
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

        #region Public Member Functions

        public EAttributeType AttributeType
        {
            get { return GetAttributeType(); }
        }

        public abstract EAttributeType GetAttributeType();

        readonly CollectionView<Node> nodes;
        public int GetNodeCount()
        {
            return nodes.Count;
        }

        public Node GetNode(int pIndex=0)
        {
            return nodes[pIndex];
        }

        #endregion

        #region Public Attributes

        public readonly PropertyT<Vector3> Color = new PropertyT<Vector3>("Color");

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "NodeAttribute::";
        }
    }
}

