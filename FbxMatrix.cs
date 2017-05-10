using System;

namespace FbxSharp
{
    public struct FbxMatrix
    {
        public static readonly FbxMatrix Identity = new FbxMatrix(1,0,0,0,
                                                            0,1,0,0,
                                                            0,0,1,0,
                                                            0,0,0,1);

        public FbxMatrix(FbxMatrix pM)
        {
            M00 = pM.M00;
            M10 = pM.M10;
            M20 = pM.M20;
            M30 = pM.M30;
            M01 = pM.M01;
            M11 = pM.M11;
            M21 = pM.M21;
            M31 = pM.M31;
            M02 = pM.M02;
            M12 = pM.M12;
            M22 = pM.M22;
            M32 = pM.M32;
            M03 = pM.M03;
            M13 = pM.M13;
            M23 = pM.M23;
            M33 = pM.M33;
        }
        //public Matrix(AMatrix pM)
        //{
        //    throw new NotImplementedException();
        //}
        public FbxMatrix(FbxVector4 pT, FbxVector4 pR, FbxVector4 pS)
        {
            var s = CreateScale(pS);
            var x = FbxMatrix.CreateRotationX(pR.X);
            var y = FbxMatrix.CreateRotationY(pR.Y);
            var z = FbxMatrix.CreateRotationZ(pR.Z);
            var t = FbxMatrix.CreateTranslation(pT);

            var r = z * y * x;
            var m = t * r * s;

            M00 = m.M00;
            M10 = m.M10;
            M20 = m.M20;
            M30 = m.M30;
            M01 = m.M01;
            M11 = m.M11;
            M21 = m.M21;
            M31 = m.M31;
            M02 = m.M02;
            M12 = m.M12;
            M22 = m.M22;
            M32 = m.M32;
            M03 = m.M03;
            M13 = m.M13;
            M23 = m.M23;
            M33 = m.M33;
        }
        //public Matrix(Vector4 pT, Quaternion pQ, Vector4 pS)
        //{
        //    throw new NotImplementedException();
        //}
        public FbxMatrix(double p00, double p10, double p20, double p30,
               double p01, double p11, double p21, double p31,
               double p02, double p12, double p22, double p32,
               double p03, double p13, double p23, double p33)
        {
            M00 = p00;
            M10 = p10;
            M20 = p20;
            M30 = p30;
            M01 = p01;
            M11 = p11;
            M21 = p21;
            M31 = p31;
            M02 = p02;
            M12 = p12;
            M22 = p22;
            M32 = p32;
            M03 = p03;
            M13 = p13;
            M23 = p23;
            M33 = p33;
        }

        public readonly double M00;
        public readonly double M10;
        public readonly double M20;
        public readonly double M30;
        public readonly double M01;
        public readonly double M11;
        public readonly double M21;
        public readonly double M31;
        public readonly double M02;
        public readonly double M12;
        public readonly double M22;
        public readonly double M32;
        public readonly double M03;
        public readonly double M13;
        public readonly double M23;
        public readonly double M33;

        public override bool Equals(object obj)
        {
            if (!(obj is FbxMatrix))
                return false;

            var m = (FbxMatrix)obj;

            return this.Equals(m);
        }

        public bool Equals(FbxMatrix m, double epsilon=0)
        {
            return
                Math.Abs(this.M00 - m.M00) <= epsilon &&
                Math.Abs(this.M01 - m.M01) <= epsilon &&
                Math.Abs(this.M02 - m.M02) <= epsilon &&
                Math.Abs(this.M03 - m.M03) <= epsilon &&
                Math.Abs(this.M10 - m.M10) <= epsilon &&
                Math.Abs(this.M11 - m.M11) <= epsilon &&
                Math.Abs(this.M12 - m.M12) <= epsilon &&
                Math.Abs(this.M13 - m.M13) <= epsilon &&
                Math.Abs(this.M20 - m.M20) <= epsilon &&
                Math.Abs(this.M21 - m.M21) <= epsilon &&
                Math.Abs(this.M22 - m.M22) <= epsilon &&
                Math.Abs(this.M23 - m.M23) <= epsilon &&
                Math.Abs(this.M30 - m.M30) <= epsilon &&
                Math.Abs(this.M31 - m.M31) <= epsilon &&
                Math.Abs(this.M32 - m.M32) <= epsilon &&
                Math.Abs(this.M33 - m.M33) <= epsilon;
        }

        public override int GetHashCode()
        {
            return
                M00.GetHashCode() ^
                M01.GetHashCode() ^
                M02.GetHashCode() ^
                M03.GetHashCode() ^
                M10.GetHashCode() ^
                M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M20.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M30.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode();
        }

        public static bool operator == (FbxMatrix a, FbxMatrix b)
        {
            return a.Equals(b);
        }

        public static bool operator != (FbxMatrix a, FbxMatrix b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return string.Format("[" +
                "{{M00 = {0}, M01 = {1}, M02 = {2}, M03 = {3}}} " +
                "{{M10 = {4}, M11 = {5}, M12 = {6}, M13 = {7}}} " +
                "{{M20 = {8}, M21 = {9}, M22 = {10}, M23 = {10}}} " +
                "{{M30 = {11}, M31 = {12}, M32 = {13}, M33 = {15}}}]",
                M00, M01, M02, M03,
                M10, M11, M12, M13,
                M20, M21, M22, M23,
                M30, M31, M32, M33);
        }

        public double Get(int pY, int pX)
        {
            if (pY < 0 || pY > 3) throw new ArgumentOutOfRangeException("pY");
            if (pX < 0 || pX > 3) throw new ArgumentOutOfRangeException("pX");

            switch (pX)
            {
            case 0:
                if (pY == 0) return M00;
                if (pY == 1) return M01;
                if (pY == 2) return M02;
                if (pY == 3) return M03;
                break;
            case 1:
                if (pY == 0) return M10;
                if (pY == 1) return M11;
                if (pY == 2) return M12;
                if (pY == 3) return M13;
                break;
            case 2:
                if (pY == 0) return M20;
                if (pY == 1) return M21;
                if (pY == 2) return M22;
                if (pY == 3) return M23;
                break;
            case 3:
                if (pY == 0) return M30;
                if (pY == 1) return M31;
                if (pY == 2) return M32;
                if (pY == 3) return M33;
                break;
            }

            throw new ArgumentOutOfRangeException("pY, pX");
        }

        public static FbxMatrix CreateTranslation(FbxVector3 t)
        {
            return CreateTranslation(t.X, t.Y, t.Z);
        }
        public static FbxMatrix CreateTranslation(FbxVector4 t)
        {
            return CreateTranslation(t.X, t.Y, t.Z);
        }
        public static FbxMatrix CreateTranslation(double x, double y, double z)
        {
            return new FbxMatrix(1, 0, 0, 0,
                              0, 1, 0, 0,
                              0, 0, 1, 0,
                              x, y, z, 1);
        }

        public static FbxMatrix CreateRotationX(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;
            double c = Math.Cos(radians);
            double s = Math.Sin(radians);
            return new FbxMatrix(
                1, 0, 0, 0,
                0, c, s, 0,
                0, -s, c, 0,
                0, 0, 0, 1);
        }

        public static FbxMatrix CreateRotationY(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;
            double c = Math.Cos(radians);
            double s = Math.Sin(radians);
            return new FbxMatrix(
                c, 0, -s, 0,
                0, 1, 0, 0,
                s, 0, c, 0,
                0, 0, 0, 1);
        }

        public static FbxMatrix CreateRotationZ(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;
            double c = Math.Cos(radians);
            double s = Math.Sin(radians);
            return new FbxMatrix(
                c, s, 0, 0,
                -s, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        public static FbxMatrix CreateScale(double s)
        {
            return CreateScale(s, s, s);
        }
        public static FbxMatrix CreateScale(FbxVector3 s)
        {
            return CreateScale(s.X, s.Y, s.Z);
        }
        public static FbxMatrix CreateScale(FbxVector4 s)
        {
            return CreateScale(s.X, s.Y, s.Z);
        }
        public static FbxMatrix CreateScale(double x, double y, double z)
        {
            return new FbxMatrix(
                x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1);
        }

        public static FbxMatrix operator * (FbxMatrix a, FbxMatrix b)
        {
            return Multiply(a, b);
        }
        public static FbxMatrix Multiply(FbxMatrix a, FbxMatrix b)
        {
            return new FbxMatrix(
                a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20 + a.M03 * b.M30,
                a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20 + a.M13 * b.M30,
                a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20 + a.M23 * b.M30,
                a.M30 * b.M00 + a.M31 * b.M10 + a.M32 * b.M20 + a.M33 * b.M30,

                a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21 + a.M03 * b.M31,
                a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                a.M30 * b.M01 + a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,

                a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22 + a.M03 * b.M32,
                a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                a.M30 * b.M02 + a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,

                a.M00 * b.M03 + a.M01 * b.M13 + a.M02 * b.M23 + a.M03 * b.M33,
                a.M10 * b.M03 + a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                a.M20 * b.M03 + a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
                a.M30 * b.M03 + a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33);
        }

        public FbxVector4 MultNormalize(FbxVector4 pVector)
        {
            return new FbxVector4(
                this.M00 * pVector.X + this.M01 * pVector.Y + this.M02 * pVector.Z + this.M03 * pVector.W,
                this.M10 * pVector.X + this.M11 * pVector.Y + this.M12 * pVector.Z + this.M13 * pVector.W,
                this.M20 * pVector.X + this.M21 * pVector.Y + this.M22 * pVector.Z + this.M23 * pVector.W,
                this.M30 * pVector.X + this.M31 * pVector.Y + this.M32 * pVector.Z + this.M33 * pVector.W);
        }
    }
}

