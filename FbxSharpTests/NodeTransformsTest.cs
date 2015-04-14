using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class NodeTransformsTest : TestBase
    {
        [Test]
        public void Node_CalcGlobalTransformFromCreatedState_ReturnsIdentity()
        {
            // given:
            var node = new Node("");
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(1, 1, 1);
            var expected = new Matrix(t, r, s);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Node_CalcGlobalTransformWithTranslation_ReturnsTranslation()
        {
            // given:
            var node = new Node("");
            var t = new Vector4(2, 3, 4);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(1, 1, 1);
            var expected = new Matrix(t, r, s);
            node.LclTranslation.Set(t);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Node_CalcGlobalTransformWithRotation_ReturnsRotation()
        {
            // given:
            var node = new Node("");
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(22, 33, 44);
            var s = new Vector4(1, 1, 1);
            var expected = new Matrix(t, r, s);
            node.LclRotation.Set(r);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Node_CalcGlobalTransformWithScale_ReturnsScale()
        {
            // given:
            var node = new Node("");
            var t = new Vector4(0, 0, 0);
            var r = new Vector4(0, 0, 0);
            var s = new Vector4(5, 6, 7);
            var expected = new Matrix(t, r, s);
            node.LclScaling.Set(s);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }
    }
}
