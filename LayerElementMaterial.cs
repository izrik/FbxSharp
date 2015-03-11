using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class LayerElementMaterial : LayerElementT<SurfaceMaterial>
	{
        public List<long> MaterialIndexes = new List<long>();
	}
}

