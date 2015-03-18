using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Layer
    {
        public Layer()
        {
            normals = new ObjectView<LayerElementNormal, LayerElement>(elements, eh => elements.CollectionChanged += eh);
            materials = new ObjectView<LayerElementMaterial, LayerElement>(elements, eh => elements.CollectionChanged += eh);
            uvs = new ObjectView<LayerElementUV, LayerElement>(elements, eh => elements.CollectionChanged += eh);
            visibility = new ObjectView<LayerElementVisibility, LayerElement>(elements, eh => elements.CollectionChanged += eh);
        }

        readonly ChangeNotifyList<LayerElement> elements = new ChangeNotifyList<LayerElement>();

        #region Layer Element Management

        readonly ObjectView<LayerElementNormal, LayerElement> normals;
        public LayerElementNormal GetNormals()
        {
            return normals.Get();
        }
        public void SetNormals(LayerElementNormal pNormals)
        {
            if (normals.Get() != null)
            {
                elements.Remove(normals.Get());
            }

            elements.Add(pNormals);
        }

        public LayerElementTangent GetTangents()
        {
            throw new NotImplementedException();
        }
        public void SetTangents(LayerElementTangent pTangents)
        {
            throw new NotImplementedException();
        }

        public LayerElementBinormal GetBinormals()
        {
            throw new NotImplementedException();
        }
        public void SetBinormals(LayerElementBinormal pBinormals)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<LayerElementMaterial, LayerElement> materials;
        public LayerElementMaterial GetMaterials()
        {
            return materials.Get();
        }
        public void SetMaterials(LayerElementMaterial pMaterials)
        {
            if (materials.Get() != null)
            {
                elements.Remove(materials.Get());
            }

            elements.Add(pMaterials);
        }

        public LayerElementPolygonGroup GetPolygonGroups()
        {
            throw new NotImplementedException();
        }
        public void SetPolygonGroups(LayerElementPolygonGroup pPolygonGroups)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<LayerElementUV, LayerElement> uvs;
        public LayerElementUV GetUVs(/*LayerElement.EType pTypeIdentifier=LayerElement.EType.eTextureDiffuse*/)
        {
            return uvs.Get();
        }
        public void SetUVs(LayerElementUV pUVs, LayerElement.EType pTypeIdentifier=LayerElement.EType.eTextureDiffuse)
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
        public LayerElement.EType[] GetUVSetChannels()
        {
            throw new NotImplementedException();
        }
        public LayerElementUV[] GetUVSets()
        {
            throw new NotImplementedException();
        }

        public LayerElementVertexColor GetVertexColors()
        {
            throw new NotImplementedException();
        }
        public void SetVertexColors(LayerElementVertexColor pVertexColors)
        {
            throw new NotImplementedException();
        }

        public LayerElementSmoothing GetSmoothing()
        {
            throw new NotImplementedException();
        }
        public void SetSmoothing(LayerElementSmoothing pSmoothing)
        {
            throw new NotImplementedException();
        }

        public LayerElementCrease GetVertexCrease()
        {
            throw new NotImplementedException();
        }
        public void SetVertexCrease(LayerElementCrease pCrease)
        {
            throw new NotImplementedException();
        }

        public LayerElementCrease GetEdgeCrease()
        {
            throw new NotImplementedException();
        }
        public void SetEdgeCrease(LayerElementCrease pCrease)
        {
            throw new NotImplementedException();
        }

        public LayerElementHole GetHole()
        {
            throw new NotImplementedException();
        }
        public void SetHole(LayerElementHole pHole)
        {
            throw new NotImplementedException();
        }

        public LayerElementUserData GetUserData()
        {
            throw new NotImplementedException();
        }
        public void SetUserData(LayerElementUserData pUserData)
        {
            throw new NotImplementedException();
        }

        readonly ObjectView<LayerElementVisibility, LayerElement> visibility;
        public LayerElementVisibility GetVisibility()
        {
            return visibility.Get();
        }
        public void SetVisibility(LayerElementVisibility pVisibility)
        {
            if (visibility.Get() != null)
            {
                elements.Remove(uvs.Get());
            }

            elements.Add(pVisibility);
        }

        public LayerElementTexture GetTextures(LayerElement.EType pType)
        {
            throw new NotImplementedException();
        }
        public void SetTextures(LayerElement.EType pType, LayerElementTexture pTextures)
        {
            throw new NotImplementedException();
        }

        public LayerElement GetLayerElementOfType(LayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }
        public void SetLayerElementOfType(LayerElement pLayerElement, LayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }

        public LayerElement CreateLayerElementOfType(LayerElement.EType pType, bool pIsUV=false)
        {
            throw new NotImplementedException();
        }

        public T CreateLayerElementOfType<T>(bool isUV=false)
            where T : LayerElement, new()
        {
            var element = new T();

            elements.Add(element);

            return element;
        }

        public void Clone(Layer pSrcLayer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

