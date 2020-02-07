using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayerElementVisibility : FbxLayerElementTemplate<bool>
	{
        public static FbxLayerElementVisibility Create(FbxLayerContainer container, string name)
        {
            return new FbxLayerElementVisibility(name);
        }

        public FbxLayerElementVisibility(string name="")
        {
            // TODO: this constructor not present in the sdk
            SetName(name);
        }
	}
}

