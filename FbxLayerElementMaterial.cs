using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayerElementMaterial : FbxLayerElementTemplate<SurfaceMaterial>
	{
        public readonly LayerElementArrayT<int> MaterialIndexes = new LayerElementArrayT<int>();
	}
}

