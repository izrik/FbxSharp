using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public abstract class FbxSurfaceMaterial : FbxObject
	{
        protected FbxSurfaceMaterial(string name = "")
            : base(name)
        {
            ShadingModel = FbxPropertyT<string>.StaticInit(this,
                "ShadingModel", "", false);
            MultiLayer = FbxPropertyT<bool>.StaticInit(this, "MultiLayer",
                false, false);
        }

        #region Material Properties

        public readonly FbxPropertyT<string> ShadingModel;
        public readonly FbxPropertyT<bool> MultiLayer;

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "Material::";
        }
    }
}

