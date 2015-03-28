using System;

namespace FbxSharp
{
    public class Skin : Deformer
    {
        public Skin(string name="")
            : base(name)
        {
        }

        public double DeformAccuracy;
    }
}

