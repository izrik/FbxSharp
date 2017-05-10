using System;

namespace FbxSharp
{
    public partial class FbxVideo : FbxObject
    {
        public FbxVideo(string name="")
            : base(name)
        {
        }

        public string Type;

        public bool UseMipMap;

        public string Filename;
        public string RelativeFilename;
    }
}

