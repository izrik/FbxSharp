using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class LayerContainerTest : TestBase
    {
        [Test]
        public void LayerContainer_Create()
        {
            // given:

            // when:
            var lc = new FbxMesh("");

            // then:
            Assert.AreEqual(0, lc.GetSrcObjectCount());
            Assert.AreEqual(0, lc.GetDstObjectCount());
            Assert.AreEqual(0, lc.GetLayerCount());
        }

        [Test]
        public void LayerContainer_CreateLayer_CreatesNewLayer()
        {
            // given:
            var lc = new FbxMesh("");

            // require:
            Assert.AreEqual(null, lc.GetLayer(0));

            // when:
            var result = lc.CreateLayer();

            // then:
            Assert.AreEqual(0, result);
            Assert.AreNotEqual(null, lc.GetLayer(0));
        }
    }
}
