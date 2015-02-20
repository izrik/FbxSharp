using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class LayerElement
    {
        public enum EType
        {
            eUnknown,
            eNormal,
            eBiNormal,
            eTangent,
            eMaterial,
            ePolygonGroup,
            eUV,
            eVertexColor,
            eSmoothing,
            eVertexCrease,
            eEdgeCrease,
            eHole,
            eUserData,
            eVisibility,
            eTextureDiffuse,
            eTextureDiffuseFactor,
            eTextureEmissive,
            eTextureEmissiveFactor,
            eTextureAmbient,
            eTextureAmbientFactor,
            eTextureSpecular,
            eTextureSpecularFactor,
            eTextureShininess,
            eTextureNormalMap,
            eTextureBump,
            eTextureTransparency,
            eTextureTransparencyFactor,
            eTextureReflection,
            eTextureReflectionFactor,
            eTextureDisplacement,
            eTextureDisplacementVector,
            eTypeCount,
        }

        public enum EMappingMode
        {
            None,
            ByControlPoint,
            ByPolygonVertex,
            ByPolygon,
            ByEdge,
            AllSame,
        }
        public EMappingMode MappingMode;

        public enum EReferenceMode
        {
            Direct,
            Index,
            IndexToDirect,
        }
        public EReferenceMode ReferenceMode;

        public string Name;
    }
}

