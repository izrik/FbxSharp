using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class MatrixTest2
    {
        [Test]
        public void Matrix_ConstructorElements_FieldsCorrespondToCorrectElements()
        {
            // when:
            var m = new FbxMatrix(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

            // then:
            Assert.AreEqual( 1, m.M00, 0.000001f);
            Assert.AreEqual( 2, m.M10, 0.000001f);
            Assert.AreEqual( 3, m.M20, 0.000001f);
            Assert.AreEqual( 4, m.M30, 0.000001f);
            Assert.AreEqual( 5, m.M01, 0.000001f);
            Assert.AreEqual( 6, m.M11, 0.000001f);
            Assert.AreEqual( 7, m.M21, 0.000001f);
            Assert.AreEqual( 8, m.M31, 0.000001f);
            Assert.AreEqual( 9, m.M02, 0.000001f);
            Assert.AreEqual(10, m.M12, 0.000001f);
            Assert.AreEqual(11, m.M22, 0.000001f);
            Assert.AreEqual(12, m.M32, 0.000001f);
            Assert.AreEqual(13, m.M03, 0.000001f);
            Assert.AreEqual(14, m.M13, 0.000001f);
            Assert.AreEqual(15, m.M23, 0.000001f);
            Assert.AreEqual(16, m.M33, 0.000001f);
        }


//        [Test]
//        public void Matrix_MultiplyRowsAndColumns_00()
//        {
//            int r;
//            int c;
//            for (r = 0; r < 4; r++)
//            {
//                for (c = 0; c < 4; c++)
//                {
//                    Console.WriteLine("test Matrix_MultiplyRowsAndColumns_{0}{1}", r, c);
//                    Console.WriteLine("    given");
//
//                    Console.Write("    Matrix! a = new(");
//                    int i;
//                    for (i = 0; i < 4; i++)
//                    {
//                        if (i == r)
//                        {
//                            Console.Write("2, 3, 5, 7");
//                        }
//                        else
//                        {
//                            Console.Write("0, 0, 0, 0");
//                        }
//                        if (i < 3)
//                            Console.Write(", ");
//                    }
//                    Console.WriteLine(")");
//
//                    Console.Write("    Matrix! b = new(");
//                    for (i = 0; i < 4; i++)
//                    {
//                        if (i == c)
//                        {
//                            Console.Write("11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19");
//                        }
//                        else
//                        {
//                            Console.Write("0");
//                        }
//                        if (i < 3) Console.Write(", ");
//                    }
//
//                    Console.WriteLine(")");
//                    Console.WriteLine();
//                    Console.WriteLine("    when");
//                    Console.WriteLine("    Matrix! m = a * b");
//                    Console.WriteLine();
//                    Console.WriteLine("    then");
//                    int rr;
//                    int cc;
//                    for (rr = 0; rr < 4; rr++)
//                    {
//                        for (cc = 0; cc < 4; cc++)
//                        {
//                            Console.WriteLine("    AssertEqual({0}, m&.Get({1}, {2}), 0.000001f)",
//                                (rr == r && cc == c ? 279 : 0),
//                                rr,
//                                cc);
//                        }
//                    }
//                    Console.WriteLine();
//
//                    Console.WriteLine("test Matrix_MultiplyRowsAndColumns_{0}{1}", r, c);
//                    Console.WriteLine("    given");
//
//                    Console.Write("    Matrix! a = new(");
//                    int i;
//                    for (i = 0; i < 4; i++)
//                    {
//                        if (i == r)
//                        {
//                            Console.Write("2, 3, 5, 7");
//                        }
//                        else
//                        {
//                            Console.Write("0, 0, 0, 0");
//                        }
//                        if (i < 3)
//                            Console.Write(", ");
//                    }
//                    Console.WriteLine(")");
//
//                    Console.Write("    Matrix! b = new(");
//                    for (i = 0; i < 4; i++)
//                    {
//                        if (i == c)
//                        {
//                            Console.Write("11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19");
//                        }
//                        else
//                        {
//                            Console.Write("0");
//                        }
//                        if (i < 3) Console.Write(", ");
//                    }
//                    Console.WriteLine();
//                    Console.WriteLine("    when");
//                    Console.WriteLine("    Matrix! m = b * a");
//                    Console.WriteLine();
//                    Console.WriteLine("    then");
//                    for (rr = 0; rr < 4; rr++)
//                    {
//                        for (cc = 0; cc < 4; cc++)
//                        {
//                            Console.WriteLine("    AssertEqual({0}, m&.Get({1}, {2}), 0.000001f)",
//                                (rr == c && cc == r ? 279 : 0),
//                                rr,
//                                cc);
//                        }
//                    }
//                    Console.WriteLine();
//                }
//            }
//        }
    }
}

