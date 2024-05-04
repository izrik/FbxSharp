using System;

namespace FbxSharp
{
    public struct FbxVector2
    {
        public FbxVector2(double pX, double pY)
        {
            X = pX;
            Y = pY;
        }
        public FbxVector2(double[] pValue)
        {
            X = pValue[0];
            Y = pValue[1];
        }

        public readonly double X;
        public readonly double Y;

        public override string ToString()
        {
            return string.Format("{{X:{0} Y:{1}}}", X, Y);
        }
    }
}

