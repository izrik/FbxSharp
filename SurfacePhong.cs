using System;

namespace FbxSharp
{
    public class SurfacePhong : SurfaceLambert
    {
        public SurfacePhong(string name="")
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

        public readonly FbxPropertyT<Vector3>  Specular            = new FbxPropertyT<Vector3>("SpecularColor");
        public readonly FbxPropertyT<double>   SpecularFactor      = new FbxPropertyT<double>("SpecularFactor");
        public readonly FbxPropertyT<double>   Shininess           = new FbxPropertyT<double>("ShininessExponent");
        public readonly FbxPropertyT<Vector3>  Reflection          = new FbxPropertyT<Vector3>("ReflectionColor");
        public readonly FbxPropertyT<double>   ReflectionFactor    = new FbxPropertyT<double>("ReflectionFactor");

        #endregion
    }
}

