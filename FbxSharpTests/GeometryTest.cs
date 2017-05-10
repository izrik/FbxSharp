using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class GeometryTest : TestBase
    {
        [Test]
        public void Geometry_AddDeformer_AddsDeformer()
        {
            // given:
            var g = new FbxMesh("");
            var skin = new FbxSkin("");

            // require:
            Assert.AreEqual(0, g.GetDeformerCount());
            Assert.AreEqual(0, g.GetSrcObjectCount());

            // when:
            g.AddDeformer(skin);

            // then:
            Assert.AreEqual(1, g.GetDeformerCount());
            Assert.AreSame(skin, g.GetDeformer(0));
            Assert.AreEqual(1, g.GetSrcObjectCount());
            Assert.AreSame(skin, g.GetSrcObject(0));
        }

        [Test]
        public void Geometry_AddSrcConnection_AddsDeformer()
        {
            // given:
            var g = new FbxMesh("");
            var skin = new FbxSkin("");

            // require:
            Assert.AreEqual(0, g.GetDeformerCount());
            Assert.AreEqual(0, g.GetSrcObjectCount());

            // when:
            g.ConnectSrcObject(skin);

            // then:
            Assert.AreEqual(1, g.GetDeformerCount());
            Assert.AreSame(skin, g.GetDeformer(0));
            Assert.AreEqual(1, g.GetSrcObjectCount());
            Assert.AreSame(skin, g.GetSrcObject(0));
        }

        [Test]
        public void Geometry_RemoveDeformer_RemovesDeformer()
        {
            // given:
            var g = new FbxMesh("");
            var skin = new FbxSkin("");
            g.AddDeformer(skin);

            // require:
            Assert.AreEqual(1, g.GetDeformerCount());
            Assert.AreEqual(1, g.GetSrcObjectCount());

            // when:
            g.RemoveDeformer(0);

            // then:
            Assert.AreEqual(0, g.GetDeformerCount());
            Assert.AreEqual(0, g.GetSrcObjectCount());
        }

        [Test]
        public void Geometry_DisconnectSrcObject_RemovesDeformer()
        {
            // given:
            var g = new FbxMesh("");
            var skin = new FbxSkin("");
            g.AddDeformer(skin);

            // require:
            Assert.AreEqual(1, g.GetDeformerCount());
            Assert.AreEqual(1, g.GetSrcObjectCount());

            // when:
            g.DisconnectSrcObject(skin);

            // then:
            Assert.AreEqual(0, g.GetDeformerCount());
            Assert.AreEqual(0, g.GetSrcObjectCount());
        }
    }
}
