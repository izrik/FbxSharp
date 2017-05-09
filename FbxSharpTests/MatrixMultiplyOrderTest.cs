using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class MatrixMultiplyOrderTest
    {
        [Test]
        public void MultiplyMethodShouldMatchOperatorOperandOrder()
        {
            // given:
            var a = new FbxMatrix(1, 0, -0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1); // 45 degrees around x;
            var b = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);

            // when:
            var expected = a * b;
            var actual = FbxMatrix.Multiply(a, b);

            // then:
            Assert.AreEqual(expected.Get(0, 0), actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(expected.Get(0, 1), actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(expected.Get(0, 2), actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(expected.Get(0, 3), actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(expected.Get(1, 0), actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(expected.Get(1, 1), actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(expected.Get(1, 2), actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(expected.Get(1, 3), actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(expected.Get(2, 0), actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(expected.Get(2, 1), actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(expected.Get(2, 2), actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(expected.Get(2, 3), actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(expected.Get(3, 0), actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(expected.Get(3, 1), actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(expected.Get(3, 2), actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(expected.Get(3, 3), actual.Get(3, 3), 0.000001f);

            // when:
            expected = b * a;
            actual = FbxMatrix.Multiply(b, a);

            // then:
            Assert.AreEqual(expected.Get(0, 0), actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(expected.Get(0, 1), actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(expected.Get(0, 2), actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(expected.Get(0, 3), actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(expected.Get(1, 0), actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(expected.Get(1, 1), actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(expected.Get(1, 2), actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(expected.Get(1, 3), actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(expected.Get(2, 0), actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(expected.Get(2, 1), actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(expected.Get(2, 2), actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(expected.Get(2, 3), actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(expected.Get(3, 0), actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(expected.Get(3, 1), actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(expected.Get(3, 2), actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(expected.Get(3, 3), actual.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MultiplyMethodShouldMatchOperatorOperandOrder3()
        {
            // given:
            var r = new FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var expected = r * t * s;
            var actual = FbxMatrix.Multiply(r, FbxMatrix.Multiply(t, s));

            // then:
            Assert.AreEqual(expected.Get(0, 0), actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(expected.Get(0, 1), actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(expected.Get(0, 2), actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(expected.Get(0, 3), actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(expected.Get(1, 0), actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(expected.Get(1, 1), actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(expected.Get(1, 2), actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(expected.Get(1, 3), actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(expected.Get(2, 0), actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(expected.Get(2, 1), actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(expected.Get(2, 2), actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(expected.Get(2, 3), actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(expected.Get(3, 0), actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(expected.Get(3, 1), actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(expected.Get(3, 2), actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(expected.Get(3, 3), actual.Get(3, 3), 0.000001f);

            // when:
            actual = FbxMatrix.Multiply(FbxMatrix.Multiply(r, t), s);

            // then:
            Assert.AreEqual(expected.Get(0, 0), actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(expected.Get(0, 1), actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(expected.Get(0, 2), actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(expected.Get(0, 3), actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(expected.Get(1, 0), actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(expected.Get(1, 1), actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(expected.Get(1, 2), actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(expected.Get(1, 3), actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(expected.Get(2, 0), actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(expected.Get(2, 1), actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(expected.Get(2, 2), actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(expected.Get(2, 3), actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(expected.Get(3, 0), actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(expected.Get(3, 1), actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(expected.Get(3, 2), actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(expected.Get(3, 3), actual.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MultiplyMethodIsAssociative()
        {
            // given:
            var r = new FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(r, t), s);
            var m2 = FbxMatrix.Multiply(r, FbxMatrix.Multiply(t, s));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

            // when:
            m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(r, s), t);
            m2 = FbxMatrix.Multiply(r, FbxMatrix.Multiply(s, t));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

            // when:
            m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(s, r), t);
            m2 = FbxMatrix.Multiply(s, FbxMatrix.Multiply(r, t));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

            // when:
            m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(s, t), r);
            m2 = FbxMatrix.Multiply(s, FbxMatrix.Multiply(t, r));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

            // when:
            m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(t, s), r);
            m2 = FbxMatrix.Multiply(t, FbxMatrix.Multiply(s, r));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

            // when:
            m1 = FbxMatrix.Multiply(FbxMatrix.Multiply(t, r), s);
            m2 = FbxMatrix.Multiply(t, FbxMatrix.Multiply(r, s));

            // then:
            Assert.AreEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);
        }
    }
}

