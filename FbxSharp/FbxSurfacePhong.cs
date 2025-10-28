using System;

namespace FbxSharp
{
    public class FbxSurfacePhong : FbxSurfaceLambert
    {
        public FbxSurfacePhong(string name = "")
            : base(name)
        {
            Specular = FbxPropertyT<FbxVector3>.StaticInit(this,
                "SpecularColor", FbxVector3.Zero, false);
            SpecularFactor = FbxPropertyT<double>.StaticInit(this,
                "SpecularFactor", 0.0, false);
            Shininess = FbxPropertyT<double>.StaticInit(this,
                "ShininessExponent", 0.0, false);
            Reflection = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ReflectionColor", FbxVector3.Zero, false);
            ReflectionFactor = FbxPropertyT<double>.StaticInit(this,
                "ReflectionFactor", 0.0, false);
        }

        #region Material properties

        public readonly FbxPropertyT<FbxVector3> Specular;
        public readonly FbxPropertyT<double> SpecularFactor;
        public readonly FbxPropertyT<double> Shininess;
        public readonly FbxPropertyT<FbxVector3> Reflection;
        public readonly FbxPropertyT<double> ReflectionFactor;

        #endregion
    }
}

