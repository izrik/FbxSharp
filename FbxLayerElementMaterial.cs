using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayerElementMaterial : FbxLayerElementTemplate<FbxSurfaceMaterial>
	{
        public readonly LayerElementArrayT<int> MaterialIndexes = new LayerElementArrayT<int>();
	}
}

