using System;

namespace FbxSharp
{
    public class FbxTexture : FbxObject
    {
        public FbxTexture(string name="")
            : base(name)
        {
        }

        public string Type;

        public string Media;

        public string Filename;
        public string RelativeFilename;

        public FbxVector2 ModelUVTranslation;
        public FbxVector2 ModelUVScaling;

        public enum EAlphaSource
        {
            None,
            RGBIntensity,
            Black
        };

        public FbxTexture.EAlphaSource AlphaSource;
        public FbxVector4 Cropping;
    }
}

