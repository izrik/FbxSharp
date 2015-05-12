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

        [Test]
        public void Property_AttachCurveNode_IsAnimated()
        {
            // given:
            var node = new Node("node");
            var acn = new AnimCurveNode("acn");
            var x = new AnimCurve("x");
            var scene = new Scene("scene");
            var layer = new AnimLayer("layer");
            var stack = new AnimStack("stack");

            var time = new FbxTime(0);
            var key = new AnimCurveKey(time, 1.0f);
            x.KeyAdd(time, key);

            scene.ConnectSrcObject(node);
            scene.ConnectSrcObject(acn);
            scene.ConnectSrcObject(x);
            scene.ConnectSrcObject(layer);
            scene.ConnectSrcObject(stack);

            layer.ConnectSrcObject(acn);

            stack.ConnectSrcObject(layer);

            acn.AddChannel<double>("x", 1.0);
            acn.ConnectToChannel(x, 0U);

            // require:
            Assert.False(node.LclTranslation.IsAnimated());

            // when:
            node.LclTranslation.ConnectSrcObject(acn);

            // then:
            Assert.True(node.LclTranslation.IsAnimated());
        }

        [Test]
        public void FbxProperty_HierarchicalSeparator()
        {
            // require:
            Assert.AreEqual("|", Property.sHierarchicalSeparator);
        }
    }
}
