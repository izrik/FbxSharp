using System;

namespace FbxSharp
{
    public struct FbxColor
    {
        public FbxColor(FbxColor pValue)
        {
            Red = pValue.Red;
            Green = pValue.Green;
            Blue = pValue.Blue;
            Alpha = pValue.Alpha;
        }
        public FbxColor(double pRed, double pGreen, double pBlue, double pAlpha=1.0)
        {
            Red = pRed;
            Green = pGreen;
            Blue = pBlue;
            Alpha = pAlpha;
        }
        public FbxColor(FbxVector3 pRGB, double pAlpha=1.0)
        {
            Red = pRGB.X;
            Green = pRGB.Y;
            Blue = pRGB.Z;
            Alpha = pAlpha;
        }
        public FbxColor(FbxVector4 pRGBA)
        {
            Red = pRGBA.X;
            Green = pRGBA.Y;
            Blue = pRGBA.Z;
            Alpha = pRGBA.W;
        }

        public readonly double Red;
        public readonly double Green;
        public readonly double Blue;
        public readonly double Alpha;

        public override string ToString()
        {
            return string.Format("{{R:{0} G:{1} B:{2} A:{3}}}", Red, Green, Blue, Alpha);
        }

        public FbxVector4 ToVector4()
        {
            return new FbxVector4(Red, Green, Blue, Alpha);
        }

        public FbxVector3 ToVector3()
        {
            return new FbxVector3(Red, Green, Blue);
        }
    }
}

