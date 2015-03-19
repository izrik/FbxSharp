using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SurfacePhongTest : TestBase
    {
        [Test]
        public void SurfacePhong_Create_HasProperties()
        {
            // given:
            var surface = new SurfacePhong("");

            // then:
            Assert.AreEqual(22, CountProperties(surface));
            Assert.AreEqual(0, surface.GetSrcPropertyCount());
            Assert.AreEqual(0, surface.GetDstPropertyCount());
        }
    }
}
