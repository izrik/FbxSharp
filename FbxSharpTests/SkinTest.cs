using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SkinTest : TestBase
    {
        [Test]
        public void Skin_SetGeometry_SetsGeometry()
        {
            // given:
            var skin = new Skin("");
            var mesh = new Mesh("");

            // require:
            Assert.AreEqual(0, skin.GetSrcObjectCount());
            Assert.AreEqual(0, skin.GetDstObjectCount());
            Assert.AreEqual(null, skin.GetGeometry());

            Assert.AreEqual(0, mesh.GetSrcObjectCount());
            Assert.AreEqual(0, mesh.GetDstObjectCount());
            Assert.AreEqual(0, mesh.GetDeformerCount());

            // when:
            skin.SetGeometry(mesh);

            // then:
            Assert.AreEqual(0, skin.GetSrcObjectCount());
            Assert.AreEqual(1, skin.GetDstObjectCount());
            Assert.AreSame(mesh, skin.GetGeometry());

            Assert.AreEqual(1, mesh.GetSrcObjectCount());
            Assert.AreEqual(0, mesh.GetDstObjectCount());
            Assert.AreEqual(1, mesh.GetDeformerCount());
            Assert.AreSame(skin, mesh.GetDeformer(0));
        }
    }
}
