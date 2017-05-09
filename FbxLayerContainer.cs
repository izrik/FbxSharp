using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public abstract class FbxLayerContainer : FbxNodeAttribute
    {
        protected FbxLayerContainer(string name="")
            : base(name)
        {
            Layers = new CollectionView<FbxLayer, FbxLayer>(layers, eh => layers.CollectionChanged += eh);
        }

        readonly ChangeNotifyList<FbxLayer> layers = new ChangeNotifyList<FbxLayer>();
        public readonly CollectionView<FbxLayer, FbxLayer> Layers;

        public int CreateLayer()
        {
            layers.Add(new FbxLayer());
            return layers.Count - 1;
        }

        public void ClearLayers()
        {
            throw new NotImplementedException();
        }

        public int GetLayerCount()
        {
            return layers.Count;
        }

        public int GetLayerCount(FbxLayerElement.EType pType, bool pUVCount = false)
        {
            throw new NotImplementedException();
        }

        public FbxLayer GetLayer(int pIndex)
        {
            return layers[pIndex];
        }

        public FbxLayer GetLayer(int pIndex, FbxLayerElement.EType pType, bool pIsUV = false)
        {
            throw new NotImplementedException();
        }

        public int GetLayerIndex(int pIndex, FbxLayerElement.EType pType, bool pIsUV = false)
        {
            throw new NotImplementedException();
        }

        public int GetLayerTypedIndex(int pGlobalIndex, FbxLayerElement.EType pType, bool pIsUV = false)
        {
            throw new NotImplementedException();
        }
    }
}

