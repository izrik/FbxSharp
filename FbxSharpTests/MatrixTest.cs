using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class MatrixTest : TestBase
    {
        [Test]
        public void Matrix_TrsConstructorNoTransforms_CreatesIdentity()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(1.0, m.Get(0, 0));
            Assert.AreEqual(0.0, m.Get(0, 1));
            Assert.AreEqual(0.0, m.Get(0, 2));
            Assert.AreEqual(0.0, m.Get(0, 3));
            Assert.AreEqual(0.0, m.Get(1, 0));
            Assert.AreEqual(1.0, m.Get(1, 1));
            Assert.AreEqual(0.0, m.Get(1, 2));
            Assert.AreEqual(0.0, m.Get(1, 3));
            Assert.AreEqual(0.0, m.Get(2, 0));
            Assert.AreEqual(0.0, m.Get(2, 1));
            Assert.AreEqual(1.0, m.Get(2, 2));
            Assert.AreEqual(0.0, m.Get(2, 3));
            Assert.AreEqual(0.0, m.Get(3, 0));
            Assert.AreEqual(0.0, m.Get(3, 1));
            Assert.AreEqual(0.0, m.Get(3, 2));
            Assert.AreEqual(1.0, m.Get(3, 3));
        }

        [Test]
        public void Matrix_TrsConstructorTranslation_CreatesWithTranslation()
        {
            // when:
            var t = new Vector4(2, 3, 4);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(1.0, m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 0), 0.00001);
            Assert.AreEqual(1.0, m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 1), 0.00001);
            Assert.AreEqual(1.0, m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 3), 0.00001);
            Assert.AreEqual(2.0, m.Get(3, 0), 0.00001);
            Assert.AreEqual(3.0, m.Get(3, 1), 0.00001);
            Assert.AreEqual(4.0, m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0, m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationX_CreatesWithRotationX()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(22.5, 0, 0);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(1.0,       m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.92388,   m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.382683,  m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 0), 0.00001);
            Assert.AreEqual(-0.382683, m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.92388,   m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationY_CreatesWithRotationY()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 35, 0);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.819152,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 1), 0.00001);
            Assert.AreEqual(-0.573576, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 0), 0.00001);
            Assert.AreEqual(1.0,       m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.573576,  m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.819152,  m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationZ_CreatesWithRotationZ()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 0, 55);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.573576,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.819152,  m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(-0.819152, m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.573576,  m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 1), 0.00001);
            Assert.AreEqual(1.0,       m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationXY_CreatesWithRotationXY()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(22.5, 35, 0);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.819152,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 1), 0.00001);
            Assert.AreEqual(-0.573576, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.219498,  m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.92388,   m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.313476,  m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.529916,  m.Get(2, 0), 0.00001);
            Assert.AreEqual(-0.382683, m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.756798,  m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationYZ_CreatesWithRotationYZ()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 35, 55);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.469846,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.67101,   m.Get(0, 1), 0.00001);
            Assert.AreEqual(-0.573576, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(-0.819152, m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.573576,  m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.32899,   m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.469846,  m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.819152,  m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationXZ_CreatesWithRotationXZ()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(22.5, 0, 55);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.573576,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.819152,  m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(-0.756798, m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.529916,  m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.382683,  m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.313476,  m.Get(2, 0), 0.00001);
            Assert.AreEqual(-0.219498, m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.92388,   m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorRotationXYZ_CreatesWithRotationXYZ()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(22.5, 35, 55);
            var s = new Vector4(1, 1, 1);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(0.469846,  m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.67101,   m.Get(0, 1), 0.00001);
            Assert.AreEqual(-0.573576, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0,         m.Get(0, 3), 0.00001);
            Assert.AreEqual(-0.630899, m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.709718,  m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.313476,  m.Get(1, 2), 0.00001);
            Assert.AreEqual(0,         m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.617423,  m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.214583,  m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.756798,  m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorScale_CreatesWithScale()
        {
            // when:
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(2, 3, 4);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(2.0, m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 0), 0.00001);
            Assert.AreEqual(3.0, m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 1), 0.00001);
            Assert.AreEqual(4.0, m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0, m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_TrsConstructorEverything_CreatesMatrix()
        {
            // when:
            var t = new Vector4(1, 0, 0);
            var r = new Vector4(22.5, 45, 135);
            var s = new Vector4(1, 2, 3);
            var m = new Matrix(t, r, s);

            // then:
            Assert.AreEqual(-0.5,      m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.5,       m.Get(0, 1), 0.00001);
            Assert.AreEqual(-0.707107, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(0, 3), 0.00001);
            Assert.AreEqual(-1.68925,  m.Get(1, 0), 0.00001);
            Assert.AreEqual(-0.92388,  m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.541196,  m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(1, 3), 0.00001);
            Assert.AreEqual(-0.574025, m.Get(2, 0), 0.00001);
            Assert.AreEqual(2.19761,   m.Get(2, 1), 0.00001);
            Assert.AreEqual(1.95984,   m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0,       m.Get(2, 3), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0,       m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0,       m.Get(3, 3), 0.00001);
        }

        [Test]
        public void Matrix_Multiply()
        {
            // given:
            var a = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var b = new Matrix(0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = b * a;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(3.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(4.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(2.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_Multiply_2()
        {
            // given:
            var a = new Matrix(1, 0, -0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1); // 45 degrees around x;
            var b = new Matrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(1.000000f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(-.707107f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.000000f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(-.707107f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.949748f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, m.Get(3, 3), 0.000001f);

            // when:
            m = b * a;

            // then:
            Assert.AreEqual(1.000000f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(-.707107f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.707107f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.000000f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.000000f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.000000f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, m.Get(3, 3), 0.000001f);
        }
    }
}
