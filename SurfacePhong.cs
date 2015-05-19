using System;

namespace FbxSharp
{
    public class SurfacePhong : SurfaceLambert
    {
        public SurfacePhong(string name="")
            : base(name)
        {
            this.Properties.AddRange(
                new Property[] {
                    Specular,
                    SpecularFactor,
                    Shininess,
                    Reflection,
                    ReflectionFactor,
                });
        }

        #region Material properties

        public readonly PropertyT<Vector3>  Specular            = new PropertyT<Vector3>("SpecularColor");
        public readonly PropertyT<double>   SpecularFactor      = new PropertyT<double>("SpecularFactor");
        public readonly PropertyT<double>   Shininess           = new PropertyT<double>("ShininessExponent");
        public readonly PropertyT<Vector3>  Reflection          = new PropertyT<Vector3>("ReflectionColor");
        public readonly PropertyT<double>   ReflectionFactor    = new PropertyT<double>("ReflectionFactor");

        #endregion
    }
}

