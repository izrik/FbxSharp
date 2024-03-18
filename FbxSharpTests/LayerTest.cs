using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class LayerTest : TestBase
    {
        [Test]
        public void Layer_SetVisibility_SetsVisibility()
        {
            // given:
            var lc = new FbxMesh("");
            lc.CreateLayer();
            var layer = lc.GetLayer(0);
            var lev = new FbxLayerElementVisibility("");

            // require:
            Assert.AreEqual(null, layer.GetVisibility());

            // when:
            layer.SetVisibility(lev);

            // then:
            Assert.AreEqual(lev, layer.GetVisibility());
        }

        [Test]
        public void Layer_SetVisibility_ReplacesPreviousVisibilityElement()
        {
            // given:
            var lc = new FbxMesh("");
            lc.CreateLayer();
            var layer = lc.GetLayer(0);
            var lev1 = new FbxLayerElementVisibility("one");
            var lev2 = new FbxLayerElementVisibility("two");
            layer.SetVisibility(lev1);;

            // require:
            Assert.AreEqual(lev1, layer.GetVisibility());

            // when:
            layer.SetVisibility(lev2);

            // then:
            Assert.AreEqual(lev2, layer.GetVisibility());
        }
    }
}
