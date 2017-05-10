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
            var surf = new FbxSurfacePhong("");

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
            var surf = new FbxSurfacePhong("");
            var tex = new FbxTexture("");

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
            var surf = new FbxSurfacePhong("");
            var tex = new FbxTexture("");

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
            var node = new FbxNode("node");
            var acn = new FbxAnimCurveNode("acn");
            var x = new FbxAnimCurve("x");
            var scene = new FbxScene("scene");
            var layer = new FbxAnimLayer("layer");
            var stack = new FbxAnimStack("stack");

            var time = new FbxTime(0);
            var key = new FbxAnimCurveKey(time, 1.0f);
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
            Assert.AreEqual("|", FbxProperty.sHierarchicalSeparator);
        }

        [Test]
        public void Property_MultipleStacks_IsAnimatedOnlyWhenTheCorrectStackIsCurrent()
        {
            // given:
            var node = new FbxNode("node");
            var scene = new FbxScene("scene");

            var acn1 = new FbxAnimCurveNode("acn1");
            var ac1 = new FbxAnimCurve("ac1");
            var layer1 = new FbxAnimLayer("layer1");
            var stack1 = new FbxAnimStack("stack1");

            var acn2 = new FbxAnimCurveNode("acn2");
            var ac2 = new FbxAnimCurve("ac2");
            var layer2 = new FbxAnimLayer("layer2");
            var stack2 = new FbxAnimStack("stack2");

            var time = new FbxTime(0);
            var key = new FbxAnimCurveKey(time, 1.0f);
            ac1.KeyAdd(time, key);

            var time2 = new FbxTime(0);
            var key2 = new FbxAnimCurveKey(time2, 1.0f);
            ac2.KeyAdd(time2, key2);

            scene.ConnectSrcObject(node);
            scene.ConnectSrcObject(acn1);
            scene.ConnectSrcObject(ac1);
            scene.ConnectSrcObject(layer1);
            scene.ConnectSrcObject(stack1);
            scene.ConnectSrcObject(acn2);
            scene.ConnectSrcObject(ac2);
            scene.ConnectSrcObject(layer2);
            scene.ConnectSrcObject(stack2);

            acn1.AddChannel<double>("x", 1.0);
            acn1.ConnectToChannel(ac1, 0U);
            layer1.ConnectSrcObject(acn1);
            stack1.ConnectSrcObject(layer1);

            acn2.AddChannel<double>("y", -1.0);
            acn2.ConnectToChannel(ac2, 0U);
            layer2.ConnectSrcObject(acn2);
            stack2.ConnectSrcObject(layer2);

            scene.SetCurrentAnimationStack(stack1);

            node.LclTranslation.ConnectSrcObject(acn1);
            node.LclRotation.ConnectSrcObject(acn2);

            // require:
            Assert.AreSame(scene.GetCurrentAnimationStack(), stack1);
            Assert.True(node.LclTranslation.IsAnimated());
            Assert.False(node.LclRotation.IsAnimated());

            // when:
            scene.SetCurrentAnimationStack(stack2);

            // then:
            Assert.False(node.LclTranslation.IsAnimated());
            Assert.True(node.LclRotation.IsAnimated());
        }

        [Test]
        public void Property_MultipleStacks_GetCurveNodeOnlyGetsCurvesOnTheCurrentStack()
        {
            // given:
            var node = new FbxNode("node");
            var scene = new FbxScene("scene");

            var acn1 = new FbxAnimCurveNode("acn1");
            var ac1 = new FbxAnimCurve("ac1");
            var layer1 = new FbxAnimLayer("layer1");
            var stack1 = new FbxAnimStack("stack1");

            var acn2 = new FbxAnimCurveNode("acn2");
            var ac2 = new FbxAnimCurve("ac2");
            var layer2 = new FbxAnimLayer("layer2");
            var stack2 = new FbxAnimStack("stack2");

            var time = new FbxTime(0);
            var key = new FbxAnimCurveKey(time, 1.0f);
            ac1.KeyAdd(time, key);

            var time2 = new FbxTime(0);
            var key2 = new FbxAnimCurveKey(time2, 1.0f);
            ac2.KeyAdd(time2, key2);

            scene.ConnectSrcObject(node);
            scene.ConnectSrcObject(acn1);
            scene.ConnectSrcObject(ac1);
            scene.ConnectSrcObject(layer1);
            scene.ConnectSrcObject(stack1);
            scene.ConnectSrcObject(acn2);
            scene.ConnectSrcObject(ac2);
            scene.ConnectSrcObject(layer2);
            scene.ConnectSrcObject(stack2);

            acn1.AddChannel<double>("x", 1.0);
            acn1.ConnectToChannel(ac1, 0U);
            layer1.ConnectSrcObject(acn1);
            stack1.ConnectSrcObject(layer1);

            acn2.AddChannel<double>("y", -1.0);
            acn2.ConnectToChannel(ac2, 0U);
            layer2.ConnectSrcObject(acn2);
            stack2.ConnectSrcObject(layer2);

            scene.SetCurrentAnimationStack(stack1);

            node.LclTranslation.ConnectSrcObject(acn1);
            node.LclRotation.ConnectSrcObject(acn2);

            // require:
            Assert.AreSame(stack1, scene.GetCurrentAnimationStack());
            Assert.AreSame(acn1, node.LclTranslation.GetCurveNode());
            Assert.Null(node.LclRotation.GetCurveNode());

            // when:
            scene.SetCurrentAnimationStack(stack2);

            // then:
            Assert.Null(node.LclTranslation.GetCurveNode());
            Assert.AreSame(acn2, node.LclRotation.GetCurveNode());
        }
    }
}
