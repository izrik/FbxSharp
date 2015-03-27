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

        [Test]
        public void SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsSrcObject()
        {
            // given:
            var surf = new SurfacePhong("");
            var tex = new Texture("");

            // when:
            var result = surf.Diffuse.ConnectSrcObject(tex);

            // then:
            Assert.True(result);
            Assert.AreEqual(1, surf.Diffuse.GetSrcObjectCount());
            var obj = surf.Diffuse.GetSrcObject(0);
            Assert.NotNull(obj);
            Assert.AreSame(tex, obj);
        }

        [Test]
        public void SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsDstProperty()
        {
            // given:
            var surf = new SurfacePhong("");
            var tex = new Texture("");

            // when:
            var result = surf.Diffuse.ConnectSrcObject(tex);

            // then:
            Assert.True(result);
            Assert.AreEqual(1, tex.GetDstPropertyCount());
            var prop = tex.GetDstProperty(0);
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.AreEqual("DiffuseColor", prop.GetName());
        }
    }
}
