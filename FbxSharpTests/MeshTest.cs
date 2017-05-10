using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class MeshTest : TestBase
    {
        [Test]
        public void Mesh_Create()
        {
            // given:
            var mesh = new FbxMesh("Mesh");

            // then:
            Assert.AreEqual(0, mesh.GetControlPointsCount());
        }

        [Test]
        public void Mesh_Create_HasProperties()
        {
            // given:
            var mesh = new FbxMesh("Mesh");
            FbxProperty prop;

            // then:
            Assert.AreEqual(6, CountProperties(mesh));
            Assert.AreEqual(0, mesh.GetSrcPropertyCount());
            Assert.AreEqual(0, mesh.GetDstPropertyCount());

            prop = mesh.FindProperty("Color");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.Color);
            Assert.True(mesh.Color.IsValid());
            Assert.AreEqual("Color", mesh.Color.GetName());
            Assert.AreSame(prop, mesh.Color);

            prop = mesh.FindProperty("Primary Visibility");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.PrimaryVisibility);
            Assert.True(mesh.PrimaryVisibility.IsValid());
            Assert.AreEqual("Primary Visibility", mesh.PrimaryVisibility.GetName());
            Assert.AreSame(prop, mesh.PrimaryVisibility);

            prop = mesh.FindProperty("Casts Shadows");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.CastShadow);
            Assert.True(mesh.CastShadow.IsValid());
            Assert.AreEqual("Casts Shadows", mesh.CastShadow.GetName());
            Assert.AreSame(prop, mesh.CastShadow);

            prop = mesh.FindProperty("Receive Shadows");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.ReceiveShadow);
            Assert.True(mesh.ReceiveShadow.IsValid());
            Assert.AreEqual("Receive Shadows", mesh.ReceiveShadow.GetName());
            Assert.AreSame(prop, mesh.ReceiveShadow);

            prop = mesh.FindProperty("BBoxMin");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.BBoxMin);
            Assert.True(mesh.BBoxMin.IsValid());
            Assert.AreEqual("BBoxMin", mesh.BBoxMin.GetName());
            Assert.AreSame(prop, mesh.BBoxMin);

            prop = mesh.FindProperty("BBoxMax");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(mesh.BBoxMax);
            Assert.True(mesh.BBoxMax.IsValid());
            Assert.AreEqual("BBoxMax", mesh.BBoxMax.GetName());
            Assert.AreSame(prop, mesh.BBoxMax);
        }

        [Test]
        public void Mesh_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxMesh("asdf");

            // then:
            Assert.AreEqual("Geometry::", obj.GetNameSpacePrefix());
        }
    }
}
