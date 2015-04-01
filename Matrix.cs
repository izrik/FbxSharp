using System;

namespace FbxSharp
{
    public struct Matrix
    {
        public static readonly Matrix Identity = new Matrix(1,0,0,0,
                                                            0,1,0,0,
                                                            0,0,1,0,
                                                            0,0,0,1);

        public Matrix(Matrix pM)
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
        //public Matrix(Vector4 pT, Vector4 pR, Vector4 pS)
        //{
        //    throw new NotImplementedException();
        //}
        //public Matrix(Vector4 pT, Quaternion pQ, Vector4 pS)
        //{
        //    throw new NotImplementedException();
        //}
        public Matrix(double p00, double p10, double p20, double p30,
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
            if (!(obj is Matrix))
                return false;

            var m = (Matrix)obj;

            return this.Equals(m);
        }

        public bool Equals(Matrix m, double epsilon=0)
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

        public static bool operator == (Matrix a, Matrix b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Matrix a, Matrix b)
        {
            return !a.Equals(b);
        }
    }
}

