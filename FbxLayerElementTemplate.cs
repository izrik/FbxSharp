using System;

namespace FbxSharp
{
    public class FbxLayerElementTemplate<T> : FbxLayerElement
    {
        readonly LayerElementArrayT<T> direct = new LayerElementArrayT<T>();
        public LayerElementArrayT<T> GetDirectArray()
        {
            return direct;
        }

        readonly LayerElementArrayT<int> indexes = new LayerElementArrayT<int>();
        public LayerElementArrayT<int> GetIndexArray()
        {
            return indexes;
        }

        public override bool Clear()
        {
            direct.List.Clear();
            indexes.List.Clear();
            return true;
        }

        public int RemapIndexTo(FbxLayerElement.EMappingMode pNewMapping)
        {
            throw new NotImplementedException();
        }
    }
}

