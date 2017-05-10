using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayer
    {
        public FbxLayer()
        {
            normals = new ObjectView<FbxLayerElementNormal, FbxLayerElement>(elements, eh => elements.CollectionChanged += eh);
            materials = new ObjectView<FbxLayerElementMaterial, FbxLayerElement>(elements, eh => elements.CollectionChanged += eh);
            uvs = new ObjectView<FbxLayerElementUV, FbxLayerElement>(elements, eh => elements.CollectionChanged += eh);
            visibility = new ObjectView<FbxLayerElementVisibility, FbxLayerElement>(elements, eh => elements.CollectionChanged += eh);
        }

        readonly ChangeNotifyList<FbxLayerElement> elements = new ChangeNotifyList<FbxLayerElement>();

        #region Layer Element Management

        readonly ObjectView<FbxLayerElementNormal, FbxLayerElement> normals;
        public FbxLayerElementNormal GetNormals()
        {
            return normals.Get();
        }
        public void SetNormals(FbxLayerElementNormal pNormals)
        {
            if (normals.Get() != null)
            {
                elements.Remove(normals.Get());
            }

            elements.Add(pNormals);
        }

        public FbxLayerElementTangent GetTangents()
        {
            throw new NotImplementedException();
        }
        public void SetTangents(FbxLayerElementTangent pTangents)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementBinormal GetBinormals()
        {
            throw new NotImplementedException();
        }
        public void SetBinormals(FbxLayerElementBinormal pBinormals)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<FbxLayerElementMaterial, FbxLayerElement> materials;
        public FbxLayerElementMaterial GetMaterials()
        {
            return materials.Get();
        }
        public void SetMaterials(FbxLayerElementMaterial pMaterials)
        {
            if (materials.Get() != null)
            {
                elements.Remove(materials.Get());
            }

            elements.Add(pMaterials);
        }

        public FbxLayerElementPolygonGroup GetPolygonGroups()
        {
            throw new NotImplementedException();
        }
        public void SetPolygonGroups(FbxLayerElementPolygonGroup pPolygonGroups)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<FbxLayerElementUV, FbxLayerElement> uvs;
        public FbxLayerElementUV GetUVs(/*LayerElement.EType pTypeIdentifier=LayerElement.EType.eTextureDiffuse*/)
        {
            return uvs.Get();
        }
        public void SetUVs(FbxLayerElementUV pUVs, FbxLayerElement.EType pTypeIdentifier=FbxLayerElement.EType.eTextureDiffuse)
        {
            if (uvs.Get() != null)
            {
                elements.Remove(uvs.Get());
            }

            elements.Add(pUVs);
        }
        public int GetUVSetCount()
        {
            throw new NotImplementedException();
        }
        public FbxLayerElement.EType[] GetUVSetChannels()
        {
            throw new NotImplementedException();
        }
        public FbxLayerElementUV[] GetUVSets()
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementVertexColor GetVertexColors()
        {
            throw new NotImplementedException();
        }
        public void SetVertexColors(FbxLayerElementVertexColor pVertexColors)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementSmoothing GetSmoothing()
        {
            throw new NotImplementedException();
        }
        public void SetSmoothing(FbxLayerElementSmoothing pSmoothing)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementCrease GetVertexCrease()
        {
            throw new NotImplementedException();
        }
        public void SetVertexCrease(FbxLayerElementCrease pCrease)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementCrease GetEdgeCrease()
        {
            throw new NotImplementedException();
        }
        public void SetEdgeCrease(FbxLayerElementCrease pCrease)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementHole GetHole()
        {
            throw new NotImplementedException();
        }
        public void SetHole(FbxLayerElementHole pHole)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElementUserData GetUserData()
        {
            throw new NotImplementedException();
        }
        public void SetUserData(FbxLayerElementUserData pUserData)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<FbxLayerElementVisibility, FbxLayerElement> visibility;
        public FbxLayerElementVisibility GetVisibility()
        {
            return visibility.Get();
        }
        public void SetVisibility(FbxLayerElementVisibility pVisibility)
        {
            if (visibility.Get() != null)
            {
                elements.Remove(uvs.Get());
            }

            elements.Add(pVisibility);
        }

        public FbxLayerElementTexture GetTextures(FbxLayerElement.EType pType)
        {
            throw new NotImplementedException();
        }
        public void SetTextures(FbxLayerElement.EType pType, FbxLayerElementTexture pTextures)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElement GetLayerElementOfType(FbxLayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }
        public void SetLayerElementOfType(FbxLayerElement pLayerElement, FbxLayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }

        public FbxLayerElement CreateLayerElementOfType(FbxLayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }

        public T CreateLayerElementOfType<T>(bool isUV=false)
            where T : FbxLayerElement, new()
        {
            var element = new T();

            elements.Add(element);

            return element;
        }

        public void Clone(FbxLayer pSrcLayer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

