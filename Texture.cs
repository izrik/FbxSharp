using System;

namespace FbxSharp
{
    public class Texture : FbxObject
    {
        public Texture(string name="")
            : base(name)
        {
        }

        public string Type;

        public string Media;

        public string Filename;
        public string RelativeFilename;

        public Vector2 ModelUVTranslation;
        public Vector2 ModelUVScaling;

        public enum EAlphaSource
        {
            None,
            RGBIntensity,
            Black
        };

        public Texture.EAlphaSource AlphaSource;
        public Vector4 Cropping;
    }
}

