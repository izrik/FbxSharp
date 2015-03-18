using System;

namespace FbxSharp
{
    public struct Vector3
    {
        public Vector3(Vector3 pValue)
        {
            X = pValue.X;
            Y = pValue.Y;
            Z = pValue.Z;
        }
        public Vector3(double pX, double pY, double pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }

        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public double this [ int pIndex ]
        {
            get
            {
                switch (pIndex)
                {
                case 0: return X;
                case 1: return Y;
                case 2: return Z;
                default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static bool operator ==(Vector3 u, Vector3 v)
        {
            return u.Equals(v);
        }
        public static bool operator !=(Vector3 u, Vector3 v)
        {
            return !u.Equals(v);
        }

        public bool Equals(Vector3 other)
        {
            return (this.X == other.X &&
                this.Y == other.Y &&
                this.Z == other.Z);
        }
        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return Equals((Vector3)obj);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public Vector4 ToVector4(double w=0)
        {
            return new Vector4(X, Y, Z, w);
        }
    }
}

