using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayerElement
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

        public enum EReferenceMode
        {
            Direct,
            Index,
            IndexToDirect,
        }

        public string Name;
        public EMappingMode MappingMode;
        public EReferenceMode ReferenceMode;

        public string GetName()
        {
            return Name;
        }
        public void SetName(string pName)
        {
            Name = pName;
        }

        public EMappingMode GetMappingMode()
        {
            return MappingMode;
        }
        public void SetMappingMode(EMappingMode pMappingMode)
        {
            MappingMode = pMappingMode;
        }

        public EReferenceMode GetReferenceMode()
        {
            return ReferenceMode;
        }
        public void SetReferenceMode(EReferenceMode pReferenceMode)
        {
            ReferenceMode = pReferenceMode;
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public virtual bool Clear()
        {
            throw new NotImplementedException();
        }
    }
}

