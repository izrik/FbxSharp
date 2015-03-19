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
    }
}
