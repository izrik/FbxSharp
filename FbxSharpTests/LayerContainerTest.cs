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
    }
}
