using System;

namespace FbxSharp
{
    public struct FbxVector3
    {
        public static readonly FbxVector3 Zero = new FbxVector3(0, 0, 0);
        public static readonly FbxVector3 One = new FbxVector3(1, 1, 1);

        public FbxVector3(FbxVector3 pValue)
        {
            X = pValue.X;
            Y = pValue.Y;
            Z = pValue.Z;
        }
        public FbxVector3(double pX, double pY, double pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }

        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public override string ToString()
        {
            return string.Format("{{X:{0} Y:{1} Z:{2}}}", X, Y, Z);
        }

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

        public static bool operator ==(FbxVector3 u, FbxVector3 v)
        {
            return u.Equals(v);
        }
        public static bool operator !=(FbxVector3 u, FbxVector3 v)
        {
            return !u.Equals(v);
        }

        public bool Equals(FbxVector3 other)
        {
            return (this.X == other.X &&
                this.Y == other.Y &&
                this.Z == other.Z);
        }
        public override bool Equals(object obj)
        {
            if (obj is FbxVector3)
            {
                return Equals((FbxVector3)obj);
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

        public FbxVector4 ToVector4(double w=0)
        {
            return new FbxVector4(X, Y, Z, w);
        }
    }
}

