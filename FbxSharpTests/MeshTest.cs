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
            var mesh = new Mesh("Mesh");

            // then:
            Assert.AreEqual(0, mesh.GetControlPointsCount());
        }

        [Test]
        public void Mesh_Create_HasProperties()
        {
            // given:
            var mesh = new Mesh("Mesh");

            // then:
            Assert.AreEqual(6, CountProperties(mesh));
            Assert.AreEqual(0, mesh.GetSrcPropertyCount());
            Assert.AreEqual(0, mesh.GetDstPropertyCount());
        }
    }
}
