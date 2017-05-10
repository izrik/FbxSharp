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
            var skin = new FbxSkin("");
            var mesh = new FbxMesh("");

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

        [Test]
        public void Skin_AddCluster_AddsCluster()
        {
            // given:
            var s = new FbxSkin("");
            var c = new FbxCluster("");

            // require:
            Assert.AreEqual(0, s.GetSrcObjectCount());
            Assert.AreEqual(0, s.GetDstObjectCount());
            Assert.AreEqual(0, s.GetClusterCount());

            Assert.AreEqual(0, c.GetSrcObjectCount());
            Assert.AreEqual(0, c.GetDstObjectCount());

            // when:
            s.AddCluster(c);

            // then:
            Assert.AreEqual(1, s.GetSrcObjectCount());
            Assert.AreSame(c, s.GetSrcObject(0));
            Assert.AreEqual(0, s.GetDstObjectCount());
            Assert.AreEqual(1, s.GetClusterCount());
            Assert.AreSame(c, s.GetCluster(0));

            Assert.AreEqual(0, c.GetSrcObjectCount());
            Assert.AreEqual(1, c.GetDstObjectCount());
            Assert.AreSame(s, c.GetDstObject(0));
        }

        [Test]
        public void Skin_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxSkin("asdf");

            // then:
            Assert.AreEqual("Deformer::", obj.GetNameSpacePrefix());
        }
    }
}
