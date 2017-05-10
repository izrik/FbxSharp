using System;

namespace FbxSharp
{
    public class FbxSurfaceLambert : FbxSurfaceMaterial
    {
        public FbxSurfaceLambert(string name="")
            : base(name)
        {
            this.Properties.AddRange(
                new FbxProperty[] {
                    Emissive,
                    EmissiveFactor,
                    Ambient,
                    AmbientFactor,
                    Diffuse,
                    DiffuseFactor,
                    NormalMap,
                    Bump,
                    BumpFactor,
                    TransparentColor,
                    TransparencyFactor,
                    DisplacementColor,
                    DisplacementFactor,
                    VectorDisplacementColor,
                    VectorDisplacementFactor,
                });
        }

        #region Material properties

        public readonly FbxPropertyT<FbxVector3>  Emissive                    = new FbxPropertyT<FbxVector3>("EmissiveColor");
        public readonly FbxPropertyT<double>   EmissiveFactor              = new FbxPropertyT<double>("EmissiveFactor");
        public readonly FbxPropertyT<FbxVector3>  Ambient                     = new FbxPropertyT<FbxVector3>("AmbientColor");
        public readonly FbxPropertyT<double>   AmbientFactor               = new FbxPropertyT<double>("AmbientFactor");
        public readonly FbxPropertyT<FbxVector3>  Diffuse                     = new FbxPropertyT<FbxVector3>("DiffuseColor");
        public readonly FbxPropertyT<double>   DiffuseFactor               = new FbxPropertyT<double>("DiffuseFactor");
        public readonly FbxPropertyT<FbxVector3>  NormalMap                   = new FbxPropertyT<FbxVector3>("NormalMap");
        public readonly FbxPropertyT<FbxVector3>  Bump                        = new FbxPropertyT<FbxVector3>("Bump");
        public readonly FbxPropertyT<double>   BumpFactor                  = new FbxPropertyT<double>("BumpFactor");
        public readonly FbxPropertyT<FbxVector3>  TransparentColor            = new FbxPropertyT<FbxVector3>("TransparentColor");
        public readonly FbxPropertyT<double>   TransparencyFactor          = new FbxPropertyT<double>("TransparencyFactor");
        public readonly FbxPropertyT<FbxVector3>  DisplacementColor           = new FbxPropertyT<FbxVector3>("DisplacementColor");
        public readonly FbxPropertyT<double>   DisplacementFactor          = new FbxPropertyT<double>("DisplacementFactor");
        public readonly FbxPropertyT<FbxVector3>  VectorDisplacementColor     = new FbxPropertyT<FbxVector3>("VectorDisplacementColor");
        public readonly FbxPropertyT<double>   VectorDisplacementFactor    = new FbxPropertyT<double>("VectorDisplacementFactor");

        #endregion
    }
}

