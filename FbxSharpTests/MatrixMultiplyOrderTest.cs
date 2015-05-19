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
            var a = new Matrix(1, 0, -0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1); // 45 degrees around x;
            var b = new Matrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);

            // when:
            var expected = a * b;
            var actual = Matrix.Multiply(a, b);

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
            actual = Matrix.Multiply(b, a);

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
            var r = new Matrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new Matrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new Matrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var expected = r * t * s;
            var actual = Matrix.Multiply(r, Matrix.Multiply(t, s));

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
            actual = Matrix.Multiply(Matrix.Multiply(r, t), s);

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
            var r = new Matrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new Matrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new Matrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var m1 = Matrix.Multiply(Matrix.Multiply(r, t), s);
            var m2 = Matrix.Multiply(r, Matrix.Multiply(t, s));

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
            m1 = Matrix.Multiply(Matrix.Multiply(r, s), t);
            m2 = Matrix.Multiply(r, Matrix.Multiply(s, t));

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
            m1 = Matrix.Multiply(Matrix.Multiply(s, r), t);
            m2 = Matrix.Multiply(s, Matrix.Multiply(r, t));

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
            m1 = Matrix.Multiply(Matrix.Multiply(s, t), r);
            m2 = Matrix.Multiply(s, Matrix.Multiply(t, r));

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
            m1 = Matrix.Multiply(Matrix.Multiply(t, s), r);
            m2 = Matrix.Multiply(t, Matrix.Multiply(s, r));

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
            m1 = Matrix.Multiply(Matrix.Multiply(t, r), s);
            m2 = Matrix.Multiply(t, Matrix.Multiply(r, s));

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

