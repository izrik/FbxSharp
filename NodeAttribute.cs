using System;

namespace FbxSharp
{
    public abstract class NodeAttribute : FbxObject
    {
        protected NodeAttribute()
        {
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


        public abstract EAttributeType AttributeType { get; }

        #region Public Member Functions

        public EAttributeType GetAttributeType()
        {
            return AttributeType;
        }

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
    }
}

