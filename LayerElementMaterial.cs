using System;
using System.Linq;
using System.Collections.Generic;
using ChamberLib;

namespace FbxSharp
{
    public class LayerElementMaterial : LayerElementT<SurfaceMaterial>
	{
        public List<long> MaterialIndexes = new List<long>();
	}
}

