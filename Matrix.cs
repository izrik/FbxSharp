using System;

namespace FbxSharp
{
    public struct Matrix
    {

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
    }
}

