using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class PropertyTest : TestBase
    {
        [Test]
        public void SurfacePhong_FindProperty_FindsProperty()
        {
            // given:
            var surf = new SurfacePhong("");

            // when:
            var prop = surf.FindProperty("SpecularColor");

            // then:
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
        }
    }
}
