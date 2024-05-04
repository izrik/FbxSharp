using System;

namespace FbxSharp
{
    public class FbxSurfacePhong : FbxSurfaceLambert
    {
        public FbxSurfacePhong(string name="")
            : base(name)
        {
            this.Properties.AddRange(
                new FbxProperty[] {
                    Specular,
                    SpecularFactor,
                    Shininess,
                    Reflection,
                    ReflectionFactor,
                });
        }

        #region Material properties

        public readonly FbxPropertyT<FbxVector3>  Specular            = new FbxPropertyT<FbxVector3>("SpecularColor");
        public readonly FbxPropertyT<double>   SpecularFactor      = new FbxPropertyT<double>("SpecularFactor");
        public readonly FbxPropertyT<double>   Shininess           = new FbxPropertyT<double>("ShininessExponent");
        public readonly FbxPropertyT<FbxVector3>  Reflection          = new FbxPropertyT<FbxVector3>("ReflectionColor");
        public readonly FbxPropertyT<double>   ReflectionFactor    = new FbxPropertyT<double>("ReflectionFactor");

        #endregion
    }
}

