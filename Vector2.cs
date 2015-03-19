using System;

namespace FbxSharp
{
    public struct Vector2
    {
        public Vector2(double pX, double pY)
        {
            X = pX;
            Y = pY;
        }
        public Vector2(double[] pValue)
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

