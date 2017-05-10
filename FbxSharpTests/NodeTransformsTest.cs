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
            var node = new FbxNode("");
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var expected = new FbxMatrix(t, r, s);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Node_CalcGlobalTransformWithTranslation_ReturnsTranslation()
        {
            // given:
            var node = new FbxNode("");
            var t = new FbxVector4(2, 3, 4);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(1, 1, 1);
            var expected = new FbxMatrix(t, r, s);
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
            var node = new FbxNode("");
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(22, 33, 44);
            var s = new FbxVector4(1, 1, 1);
            var expected = new FbxMatrix(t, r, s);
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
            var node = new FbxNode("");
            var t = new FbxVector4(0, 0, 0);
            var r = new FbxVector4(0, 0, 0);
            var s = new FbxVector4(5, 6, 7);
            var expected = new FbxMatrix(t, r, s);
            node.LclScaling.Set(s);

            // when:
            var actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NodesInHierarchy_CalcGlobalTransformWithTranslationAndWithRotation_ReturnsRotatedThenTranslated()
        {
            // given:
            var node1 = new FbxNode("node1");
            var node2 = new FbxNode("node2");
            node1.AddChild(node2);
            var t = new FbxVector4(2, 3, 4);
            var r = new FbxVector4(45, 0, 0);
            node1.LclTranslation.Set(t);
            node2.LclRotation.Set(r);

            // when:
            var actual = node1.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(1.000000f, actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.000000f, actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.000000f, actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.000000f, actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(3, 3), 0.000001f);

            // when:
            actual = node2.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(1.000000f, actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.000000f, actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(3.000000f, actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.000000f, actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(3, 3), 0.000001f);
        }

        [Test]
        public void NodesInHierarchy_CalcGlobalTransformWithRotationAndWithTranslation_ReturnsTranslatedThenRotated()
        {
            // given:
            var node1 = new FbxNode("node1");
            var node2 = new FbxNode("node2");
            node1.AddChild(node2);
            var t = new FbxVector4(2, 3, 4);
            var r = new FbxVector4(45, 0, 0);
            node1.LclRotation.Set(r);
            node2.LclTranslation.Set(t);

            // when:
            var actual = node1.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(1.000000f, actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(3, 3), 0.000001f);

            // when:
            actual = node2.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(1.000000f, actual.Get(0, 0), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 1), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(0, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 0), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(1, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(1, 3), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 0), 0.000001f);
            Assert.AreEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
            Assert.AreEqual(0.707107f, actual.Get(2, 2), 0.000001f);
            Assert.AreEqual(0.000000f, actual.Get(2, 3), 0.000001f);
            Assert.AreEqual(2.000000f, actual.Get(3, 0), 0.000001f);
            Assert.AreEqual(-0.707107f,actual.Get(3, 1), 0.000001f);
            Assert.AreEqual(4.949748f, actual.Get(3, 2), 0.000001f);
            Assert.AreEqual(1.000000f, actual.Get(3, 3), 0.000001f);
        }

        [Test]
        public void NodesInHierarchy_CalcGlobalTransform_ChildsIsTimesParent()
        {
            // given:
            var node1 = new FbxNode("node1");
            var node2 = new FbxNode("node2");
            node1.AddChild(node2);
            var r1 = new FbxVector4(45, 0, 0);
            var r2 = new FbxVector4(0, 60, 0);
            node1.LclRotation.Set(r1);
            node2.LclRotation.Set(r2);

            // when:
            var g1 = node1.EvaluateGlobalTransform();
            var g2 = node2.EvaluateGlobalTransform();
            var l1 = node1.EvaluateLocalTransform();
            var l2 = node2.EvaluateLocalTransform();

            Assert.AreEqual(l1.Get(0, 0), g1.Get(0, 0), 0.000001f);
            Assert.AreEqual(l1.Get(0, 1), g1.Get(0, 1), 0.000001f);
            Assert.AreEqual(l1.Get(0, 2), g1.Get(0, 2), 0.000001f);
            Assert.AreEqual(l1.Get(0, 3), g1.Get(0, 3), 0.000001f);
            Assert.AreEqual(l1.Get(1, 0), g1.Get(1, 0), 0.000001f);
            Assert.AreEqual(l1.Get(1, 1), g1.Get(1, 1), 0.000001f);
            Assert.AreEqual(l1.Get(1, 2), g1.Get(1, 2), 0.000001f);
            Assert.AreEqual(l1.Get(1, 3), g1.Get(1, 3), 0.000001f);
            Assert.AreEqual(l1.Get(2, 0), g1.Get(2, 0), 0.000001f);
            Assert.AreEqual(l1.Get(2, 1), g1.Get(2, 1), 0.000001f);
            Assert.AreEqual(l1.Get(2, 2), g1.Get(2, 2), 0.000001f);
            Assert.AreEqual(l1.Get(2, 3), g1.Get(2, 3), 0.000001f);
            Assert.AreEqual(l1.Get(3, 0), g1.Get(3, 0), 0.000001f);
            Assert.AreEqual(l1.Get(3, 1), g1.Get(3, 1), 0.000001f);
            Assert.AreEqual(l1.Get(3, 2), g1.Get(3, 2), 0.000001f);
            Assert.AreEqual(l1.Get(3, 3), g1.Get(3, 3), 0.000001f);

            var m = l1 * l2;
            Assert.AreEqual(m.Get(0, 0), g2.Get(0, 0), 0.000001f);
            Assert.AreEqual(m.Get(0, 1), g2.Get(0, 1), 0.000001f);
            Assert.AreEqual(m.Get(0, 2), g2.Get(0, 2), 0.000001f);
            Assert.AreEqual(m.Get(0, 3), g2.Get(0, 3), 0.000001f);
            Assert.AreEqual(m.Get(1, 0), g2.Get(1, 0), 0.000001f);
            Assert.AreEqual(m.Get(1, 1), g2.Get(1, 1), 0.000001f);
            Assert.AreEqual(m.Get(1, 2), g2.Get(1, 2), 0.000001f);
            Assert.AreEqual(m.Get(1, 3), g2.Get(1, 3), 0.000001f);
            Assert.AreEqual(m.Get(2, 0), g2.Get(2, 0), 0.000001f);
            Assert.AreEqual(m.Get(2, 1), g2.Get(2, 1), 0.000001f);
            Assert.AreEqual(m.Get(2, 2), g2.Get(2, 2), 0.000001f);
            Assert.AreEqual(m.Get(2, 3), g2.Get(2, 3), 0.000001f);
            Assert.AreEqual(m.Get(3, 0), g2.Get(3, 0), 0.000001f);
            Assert.AreEqual(m.Get(3, 1), g2.Get(3, 1), 0.000001f);
            Assert.AreEqual(m.Get(3, 2), g2.Get(3, 2), 0.000001f);
            Assert.AreEqual(m.Get(3, 3), g2.Get(3, 3), 0.000001f);
        }
    }
}
