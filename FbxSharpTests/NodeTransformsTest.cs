using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class NodeTransformsTest : TestBase
    {
        [Test]
        public void Node_CalcTransformFromCreatedState_ReturnsIdentity()
        {
            // given:
            var node = new Node("");
            var expected = new Matrix();
            Matrix actual;

            // when:
            actual = node.EvaluateGlobalTransform();

            // then:
            Assert.AreEqual(expected, actual);
        }
    }
}
