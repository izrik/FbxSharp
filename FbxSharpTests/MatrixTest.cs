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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(2, 3, 4);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(22.5, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 35, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 55);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(22.5, 35, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 35, 55);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(22.5, 0, 55);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(22.5, 35, 55);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(2, 3, 4);
            var m = new FbxMatrix(t, r, s);

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
            var t = new FbxVector4(1, 0, 0);
            var r = new FbxVector4(22.5, 45, 135);
            var s = new FbxVector4(1, 2, 3);
            var m = new FbxMatrix(t, r, s);

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
            var a = new FbxMatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var b = new FbxMatrix(0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1);

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
            var a = new FbxMatrix(1, 0, -0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1); // 45 degrees around x;
            var b = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);

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

        [Test]
        public void Matrix_Multiply_3()
        {
            // given:
            var r = new FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var m = r * t * s;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(4.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(2.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(3.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = r * s * t;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(28.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(10.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(18.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = t * r * s;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = t * s * r;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = s * t * r;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(10.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(18.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(28.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);

            // when:
            m = s * r * t;

            // then:
            Assert.AreEqual(0.0f, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(6.0f, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(7.0f, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(5.0f, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.0f, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(20.0f, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(12.0f, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(21.0f, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.0f, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplicationIsAssociative()
        {
            // given:
            var r = new FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
            var t = new FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
            var s = new FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

            // when:
            var m1 = (r * t) * s;
            var m2 = r * (t * s);

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
            m1 = (r * s) * t;
            m2 = r * (s * t);

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
            m1 = (s * r) * t;
            m2 = s * (r * t);

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
            m1 = (s * t) * r;
            m2 = s * (t * r);

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
            m1 = (t * s) * r;
            m2 = t * (s * r);

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
            m1 = (t * r) * s;
            m2 = t * (r * s);

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

        [Test]
        public void MatrixMultiplication_IndividualElements_00()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(118, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(177, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(295, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(413, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_01()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(649,  m.Get(0, 0), 0.000001f);
            Assert.AreEqual(767,  m.Get(0, 1), 0.000001f);
            Assert.AreEqual(1003, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(1121, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_02()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(1357, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(1711, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(1829, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(2183, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_03()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(2419, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(2537, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(2773, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(3127, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_04()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,   m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 3), 0.000001f);
            Assert.AreEqual(118, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(177, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(295, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(413, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_05()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(649,  m.Get(1, 0), 0.000001f);
            Assert.AreEqual(767,  m.Get(1, 1), 0.000001f);
            Assert.AreEqual(1003, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(1121, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_06()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(1357, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(1711, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(1829, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(2183, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_07()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(2419, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(2537, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(2773, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(3127, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_08()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,   m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 3), 0.000001f);
            Assert.AreEqual(118, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(177, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(295, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(413, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_09()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(649,  m.Get(2, 0), 0.000001f);
            Assert.AreEqual(767,  m.Get(2, 1), 0.000001f);
            Assert.AreEqual(1003, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(1121, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_10()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(1357, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(1711, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(1829, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(2183, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_11()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(2419, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(2537, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(2773, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(3127, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_12()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,   m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,   m.Get(2, 3), 0.000001f);
            Assert.AreEqual(118, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(177, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(295, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(413, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_13()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(649,  m.Get(3, 0), 0.000001f);
            Assert.AreEqual(767,  m.Get(3, 1), 0.000001f);
            Assert.AreEqual(1003, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(1121, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_14()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(1357, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(1711, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(1829, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(2183, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixMultiplication_IndividualElements_15()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

            // when:
            var b = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59);
            var m = a * b;

            // then:
            Assert.AreEqual(0,    m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0,    m.Get(2, 3), 0.000001f);
            Assert.AreEqual(2419, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(2537, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(2773, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(3127, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_ConstructorElements_GetMethodGetsCorrectElements()
        {
            // when:
            var m = new FbxMatrix(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

            // then:
            Assert.AreEqual( 1, m.Get(0, 0), 0.000001f);
            Assert.AreEqual( 2, m.Get(0, 1), 0.000001f);
            Assert.AreEqual( 3, m.Get(0, 2), 0.000001f);
            Assert.AreEqual( 4, m.Get(0, 3), 0.000001f);
            Assert.AreEqual( 5, m.Get(1, 0), 0.000001f);
            Assert.AreEqual( 6, m.Get(1, 1), 0.000001f);
            Assert.AreEqual( 7, m.Get(1, 2), 0.000001f);
            Assert.AreEqual( 8, m.Get(1, 3), 0.000001f);
            Assert.AreEqual( 9, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(10, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(11, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(12, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(13, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(14, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(15, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(16, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_00()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual( 22, m.Get(0, 0), 0.000001f);
            Assert.AreEqual( 33, m.Get(0, 1), 0.000001f);
            Assert.AreEqual( 55, m.Get(0, 2), 0.000001f);
            Assert.AreEqual( 77, m.Get(0, 3), 0.000001f);
            Assert.AreEqual( 26, m.Get(1, 0), 0.000001f);
            Assert.AreEqual( 39, m.Get(1, 1), 0.000001f);
            Assert.AreEqual( 65, m.Get(1, 2), 0.000001f);
            Assert.AreEqual( 91, m.Get(1, 3), 0.000001f);
            Assert.AreEqual( 34, m.Get(2, 0), 0.000001f);
            Assert.AreEqual( 51, m.Get(2, 1), 0.000001f);
            Assert.AreEqual( 85, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(119, m.Get(2, 3), 0.000001f);
            Assert.AreEqual( 38, m.Get(3, 0), 0.000001f);
            Assert.AreEqual( 57, m.Get(3, 1), 0.000001f);
            Assert.AreEqual( 95, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(133, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_00()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(279, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_01()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_01()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(279, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_02()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_02()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(279, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_03()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_03()
        {
            // given:
            var a = new FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(279, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_10()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_10()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(279, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_11()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual( 22, m.Get(0, 0), 0.000001f);
            Assert.AreEqual( 33, m.Get(0, 1), 0.000001f);
            Assert.AreEqual( 55, m.Get(0, 2), 0.000001f);
            Assert.AreEqual( 77, m.Get(0, 3), 0.000001f);
            Assert.AreEqual( 26, m.Get(1, 0), 0.000001f);
            Assert.AreEqual( 39, m.Get(1, 1), 0.000001f);
            Assert.AreEqual( 65, m.Get(1, 2), 0.000001f);
            Assert.AreEqual( 91, m.Get(1, 3), 0.000001f);
            Assert.AreEqual( 34, m.Get(2, 0), 0.000001f);
            Assert.AreEqual( 51, m.Get(2, 1), 0.000001f);
            Assert.AreEqual( 85, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(119, m.Get(2, 3), 0.000001f);
            Assert.AreEqual( 38, m.Get(3, 0), 0.000001f);
            Assert.AreEqual( 57, m.Get(3, 1), 0.000001f);
            Assert.AreEqual( 95, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(133, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_11()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(279, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_12()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_12()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(279, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_13()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_13()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(279, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_20()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_20()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(279, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_21()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_21()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(279, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_22()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual( 22, m.Get(0, 0), 0.000001f);
            Assert.AreEqual( 33, m.Get(0, 1), 0.000001f);
            Assert.AreEqual( 55, m.Get(0, 2), 0.000001f);
            Assert.AreEqual( 77, m.Get(0, 3), 0.000001f);
            Assert.AreEqual( 26, m.Get(1, 0), 0.000001f);
            Assert.AreEqual( 39, m.Get(1, 1), 0.000001f);
            Assert.AreEqual( 65, m.Get(1, 2), 0.000001f);
            Assert.AreEqual( 91, m.Get(1, 3), 0.000001f);
            Assert.AreEqual( 34, m.Get(2, 0), 0.000001f);
            Assert.AreEqual( 51, m.Get(2, 1), 0.000001f);
            Assert.AreEqual( 85, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(119, m.Get(2, 3), 0.000001f);
            Assert.AreEqual( 38, m.Get(3, 0), 0.000001f);
            Assert.AreEqual( 57, m.Get(3, 1), 0.000001f);
            Assert.AreEqual( 95, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(133, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_22()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(279, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_23()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_23()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(279, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_30()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_30()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(279, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_31()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_31()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(279, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_32()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_32()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(279, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyRowsAndColumns_33()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = a * b;

            // then:
            Assert.AreEqual( 22, m.Get(0, 0), 0.000001f);
            Assert.AreEqual( 33, m.Get(0, 1), 0.000001f);
            Assert.AreEqual( 55, m.Get(0, 2), 0.000001f);
            Assert.AreEqual( 77, m.Get(0, 3), 0.000001f);
            Assert.AreEqual( 26, m.Get(1, 0), 0.000001f);
            Assert.AreEqual( 39, m.Get(1, 1), 0.000001f);
            Assert.AreEqual( 65, m.Get(1, 2), 0.000001f);
            Assert.AreEqual( 91, m.Get(1, 3), 0.000001f);
            Assert.AreEqual( 34, m.Get(2, 0), 0.000001f);
            Assert.AreEqual( 51, m.Get(2, 1), 0.000001f);
            Assert.AreEqual( 85, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(119, m.Get(2, 3), 0.000001f);
            Assert.AreEqual( 38, m.Get(3, 0), 0.000001f);
            Assert.AreEqual( 57, m.Get(3, 1), 0.000001f);
            Assert.AreEqual( 95, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(133, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void Matrix_MultiplyColumnsAndRows_33()
        {
            // given:
            var a = new FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
            var b = new FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

            // when:
            var m = b * a;

            // then:
            Assert.AreEqual(0, m.Get(0, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(0, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(1, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 2), 0.000001f);
            Assert.AreEqual(0, m.Get(2, 3), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 0), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 1), 0.000001f);
            Assert.AreEqual(0, m.Get(3, 2), 0.000001f);
            Assert.AreEqual(279, m.Get(3, 3), 0.000001f);
        }

        [Test]
        public void MatrixRotationIsCounterClockwiseX()
        {
            // given:
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(90, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);
            var v = new FbxVector4();
            var u = new FbxVector4();

            // require:
            Assert.AreEqual(1.0, m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 1), 0.00001);
            Assert.AreEqual(1.0, m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 0), 0.00001);
            Assert.AreEqual(-1.0,m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0, m.Get(3, 3), 0.00001);

            // when:
            v = new FbxVector4(0, 0, 1, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual(-1, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, 1, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 1, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, 0, -1, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 1, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, -1, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual(-1, u[2], 0.000001f);
        }

        [Test]
        public void MatrixRotationIsCounterClockwiseY()
        {
            // given:
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 90, 0);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);
            var v = new FbxVector4();
            var u = new FbxVector4();

            // require:
            Assert.AreEqual(0.0, m.Get(0, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 1), 0.00001);
            Assert.AreEqual(-1.0,m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 0), 0.00001);
            Assert.AreEqual(1.0, m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 3), 0.00001);
            Assert.AreEqual(1.0, m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0, m.Get(3, 3), 0.00001);

            // when:
            v = new FbxVector4(0, 0, 1, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 1, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(1, 0, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual(-1, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, 0, -1, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual(-1, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(-1, 0, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 1, u[2], 0.000001f);
        }

        [Test]
        public void MatrixRotationIsCounterClockwiseZ()
        {
            // given:
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 90);
            var s = new FbxVector4(1, 1, 1);
            var m = new FbxMatrix(t, r, s);
            var v = new FbxVector4();
            var u = new FbxVector4();

            // require:
            Assert.AreEqual(0.0, m.Get(0, 0), 0.00001);
            Assert.AreEqual(1.0, m.Get(0, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(0, 3), 0.00001);
            Assert.AreEqual(-1.0,m.Get(1, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(1, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 1), 0.00001);
            Assert.AreEqual(1.0, m.Get(2, 2), 0.00001);
            Assert.AreEqual(0.0, m.Get(2, 3), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 0), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 1), 0.00001);
            Assert.AreEqual(0.0, m.Get(3, 2), 0.00001);
            Assert.AreEqual(1.0, m.Get(3, 3), 0.00001);

            // when:
            v = new FbxVector4(1, 0, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual( 1, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, 1, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual(-1, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(-1, 0, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 0, u[0], 0.000001f);
            Assert.AreEqual(-1, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);

            // when:
            v = new FbxVector4(0, -1, 0, 1);
            u = m.MultNormalize(v);

            // then:
            Assert.AreEqual( 1, u[0], 0.000001f);
            Assert.AreEqual( 0, u[1], 0.000001f);
            Assert.AreEqual( 0, u[2], 0.000001f);
        }

        [Test]
        public void MatrixMultiplyTransformOrder_TransformationsOccurRightToLeft()
        {

            /*;
            transforming v by (m1 * m2) is equivalent to transforming v by m2, and;
            // then:
            */;

            // given:
            var t1 = new FbxVector4(1, 0, 0);
            var t2 = new FbxVector4(0, 0, 0);
            var r1 = new FbxVector4(0, 0, 0);
            var r2 = new FbxVector4(0, 90, 0);
            var s = new FbxVector4(1, 1, 1);
            var m1 = new FbxMatrix(t1, r1, s);
            var m2 = new FbxMatrix(t2, r2, s);
            var u = new FbxVector4();
            var zero = new FbxVector4(0, 0, 0, 1);
            var one = new FbxVector4(1, 1, 1, 1);
            var x = new FbxVector4(1, 0, 0, 1);
            var y = new FbxVector4(0, 1, 0, 1);
            var z = new FbxVector4(0, 0, 1, 1);

            // require:
            u = m1.MultNormalize(zero);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m1.MultNormalize(x);
            Assert.AreEqual(2, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m1.MultNormalize(y);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m1.MultNormalize(z);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(1, u[2], 0.000001f);
            u = m1.MultNormalize(one);
            Assert.AreEqual(2, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(1, u[2], 0.000001f);

            u = m2.MultNormalize(zero);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m2.MultNormalize(x);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);
            u = m2.MultNormalize(y);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m2.MultNormalize(z);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m2.MultNormalize(one);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);

            // when:
            var m = m1 * m2;

            // then:
            u = m.MultNormalize(zero);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m.MultNormalize(x);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);
            u = m.MultNormalize(y);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m.MultNormalize(z);
            Assert.AreEqual(2, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(0, u[2], 0.000001f);
            u = m.MultNormalize(one);
            Assert.AreEqual(2, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);

            // when:
            m = m2 * m1;

            // then:
            u = m.MultNormalize(zero);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);
            u = m.MultNormalize(x);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(-2,u[2], 0.000001f);
            u = m.MultNormalize(y);
            Assert.AreEqual(0, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);
            u = m.MultNormalize(z);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(0, u[1], 0.000001f);
            Assert.AreEqual(-1,u[2], 0.000001f);
            u = m.MultNormalize(one);
            Assert.AreEqual(1, u[0], 0.000001f);
            Assert.AreEqual(1, u[1], 0.000001f);
            Assert.AreEqual(-2,u[2], 0.000001f);
        }
    }
}
