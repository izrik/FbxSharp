using System;

namespace FbxSharp
{
    public class FbxSurfaceLambert : FbxSurfaceMaterial
    {
        public FbxSurfaceLambert(string name = "")
            : base(name)
        {
            Emissive = FbxPropertyT<FbxVector3>.StaticInit(this,
                "EmissiveColor", FbxVector3.Zero, false);
            EmissiveFactor = FbxPropertyT<double>.StaticInit(this,
                "EmissiveFactor", 0.0, false);
            Ambient = FbxPropertyT<FbxVector3>.StaticInit(this,
                "AmbientColor", FbxVector3.Zero, false);
            AmbientFactor = FbxPropertyT<double>.StaticInit(this,
                "AmbientFactor", 0.0, false);
            Diffuse = FbxPropertyT<FbxVector3>.StaticInit(this,
                "DiffuseColor", FbxVector3.Zero, false);
            DiffuseFactor = FbxPropertyT<double>.StaticInit(this,
                "DiffuseFactor", 0.0, false);
            NormalMap = FbxPropertyT<FbxVector3>.StaticInit(this, "NormalMap",
                FbxVector3.Zero, false);
            Bump = FbxPropertyT<FbxVector3>.StaticInit(this, "Bump",
                FbxVector3.Zero, false);
            BumpFactor = FbxPropertyT<double>.StaticInit(this, "BumpFactor",
                0.0, false);
            TransparentColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "TransparentColor", FbxVector3.Zero, false);
            TransparencyFactor = FbxPropertyT<double>.StaticInit(this,
                "TransparencyFactor", 0.0, false);
            DisplacementColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "DisplacementColor", FbxVector3.Zero, false);
            DisplacementFactor = FbxPropertyT<double>.StaticInit(this,
                "DisplacementFactor", 0.0, false);
            VectorDisplacementColor = FbxPropertyT<FbxVector3>.StaticInit(
                this, "VectorDisplacementColor", FbxVector3.Zero, false);
            VectorDisplacementFactor = FbxPropertyT<double>.StaticInit(this,
                "VectorDisplacementFactor", 0.0, false);
        }

        #region Material properties

        public readonly FbxPropertyT<FbxVector3> Emissive;
        public readonly FbxPropertyT<double> EmissiveFactor;
        public readonly FbxPropertyT<FbxVector3> Ambient;
        public readonly FbxPropertyT<double> AmbientFactor;
        public readonly FbxPropertyT<FbxVector3> Diffuse;
        public readonly FbxPropertyT<double> DiffuseFactor;
        public readonly FbxPropertyT<FbxVector3> NormalMap;
        public readonly FbxPropertyT<FbxVector3> Bump;
        public readonly FbxPropertyT<double> BumpFactor;
        public readonly FbxPropertyT<FbxVector3> TransparentColor;
        public readonly FbxPropertyT<double> TransparencyFactor;
        public readonly FbxPropertyT<FbxVector3> DisplacementColor;
        public readonly FbxPropertyT<double> DisplacementFactor;
        public readonly FbxPropertyT<FbxVector3> VectorDisplacementColor;
        public readonly FbxPropertyT<double> VectorDisplacementFactor;

        #endregion
    }
}

