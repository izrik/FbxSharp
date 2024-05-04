using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public abstract class FbxSurfaceMaterial : FbxObject
	{
        protected FbxSurfaceMaterial(string name="")
            : base(name)
        {
            this.Properties.Add(ShadingModel);
            this.Properties.Add(MultiLayer);
        }

        #region Material Properties

        public readonly FbxPropertyT<string> ShadingModel = new FbxPropertyT<string>("ShadingModel");
        public readonly FbxPropertyT<bool>   MultiLayer   = new FbxPropertyT<bool>("MultiLayer");

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "Material::";
        }
    }
}

