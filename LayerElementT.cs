using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class LayerElementT<T> : LayerElement
    {

        public List<T> Values = new List<T>();
    }
}

