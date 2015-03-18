using System;

namespace FbxSharp
{
    public class SurfaceLambert : SurfaceMaterial
    {
        public SurfaceLambert(string name="")
            : base(name)
        {
            this.Properties.AddRange(
                new Property[] {
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

        public readonly PropertyT<Vector3>  Emissive                    = new PropertyT<Vector3>("Emissive");
        public readonly PropertyT<double>   EmissiveFactor              = new PropertyT<double>("EmissiveFactor");
        public readonly PropertyT<Vector3>  Ambient                     = new PropertyT<Vector3>("Ambient");
        public readonly PropertyT<double>   AmbientFactor               = new PropertyT<double>("AmbientFactor");
        public readonly PropertyT<Vector3>  Diffuse                     = new PropertyT<Vector3>("Diffuse");
        public readonly PropertyT<double>   DiffuseFactor               = new PropertyT<double>("DiffuseFactor");
        public readonly PropertyT<Vector3>  NormalMap                   = new PropertyT<Vector3>("NormalMap");
        public readonly PropertyT<Vector3>  Bump                        = new PropertyT<Vector3>("Bump");
        public readonly PropertyT<double>   BumpFactor                  = new PropertyT<double>("BumpFactor");
        public readonly PropertyT<Vector3>  TransparentColor            = new PropertyT<Vector3>("TransparentColor");
        public readonly PropertyT<double>   TransparencyFactor          = new PropertyT<double>("TransparencyFactor");
        public readonly PropertyT<Vector3>  DisplacementColor           = new PropertyT<Vector3>("DisplacementColor");
        public readonly PropertyT<double>   DisplacementFactor          = new PropertyT<double>("DisplacementFactor");
        public readonly PropertyT<Vector3>  VectorDisplacementColor     = new PropertyT<Vector3>("VectorDisplacementColor");
        public readonly PropertyT<double>   VectorDisplacementFactor    = new PropertyT<double>("VectorDisplacementFactor");

        #endregion
    }
}

