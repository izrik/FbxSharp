using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public abstract class SurfaceMaterial : FbxObject
	{
        protected SurfaceMaterial(string name="")
            : base(name)
        {
            this.Properties.Add(ShadingModel);
            this.Properties.Add(MultiLayer);
        }

        #region Material Properties

        public readonly PropertyT<string> ShadingModel = new PropertyT<string>("ShadingModel");
        public readonly PropertyT<bool>   MultiLayer   = new PropertyT<bool>("MultiLayer");

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "Material::";
        }
    }
}

