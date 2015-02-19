using System;

namespace FbxSharp
{
    public abstract class NodeAttribute : FbxObject
    {


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

    }
}

