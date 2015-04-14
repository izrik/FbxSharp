using System;

namespace FbxSharp
{
    public class Video : FbxObject
    {
        public Video(string name="")
            : base(name)
        {
        }

        public string Type;

        public bool UseMipMap;

        public string Filename;
        public string RelativeFilename;
    }
}

