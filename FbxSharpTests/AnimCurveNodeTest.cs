using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimCurveNodeTest : TestBase
    {
        [Test]
        public void AnimCurveNodeTest_Create_NoChannels()
        {
            // given:

            // when:
            var acn = new FbxAnimCurveNode("");

            // then:
            Assert.AreEqual(0, acn.GetChannelsCount());
            Assert.AreEqual(1, CountProperties(acn));
        }

        [Test]
        public void AnimCurveNodeTest_AddChannel_TwoPropertiesOneChannel()
        {
            // given:
            var acn = new FbxAnimCurveNode("");

            // require:
            Assert.AreEqual(0, acn.GetChannelsCount());
            Assert.AreEqual(1, CountProperties(acn));

            // when:
            acn.AddChannel<float>("channel1", 0.0f);

            // then:
            Assert.AreEqual(2, CountProperties(acn));
            Assert.AreEqual(1, acn.GetChannelsCount());
            Assert.AreEqual(0, acn.GetCurveCount(0));

            var prop = acn.GetFirstProperty();
            Assert.True(prop.IsValid());
            prop = acn.GetNextProperty(prop);
            Assert.True(prop.IsValid());
            Assert.AreEqual("channel1", prop.GetName());
        }

        [Test]
        public void AnimCurveNodeTest_ConnectToChannel_AddsSrcConnection()
        {
            // given:
            var acn = new FbxAnimCurveNode("acn");
            var ac = new FbxAnimCurve("ac");
            acn.AddChannel<float>("channel1", 0.0f);

            // require:
            Assert.AreEqual(2, CountProperties(acn));
            Assert.AreEqual(1, acn.GetChannelsCount());
            Assert.AreEqual(0, acn.GetCurveCount(0));

            // when:
            acn.ConnectToChannel(ac, 0U);

            // then:
            Assert.AreEqual(2, CountProperties(acn));
            Assert.AreEqual(1, acn.GetChannelsCount());
            Assert.AreEqual(1, acn.GetCurveCount(0));
            Assert.AreEqual(1, ac.GetDstPropertyCount());
            Assert.AreEqual("channel1", ac.GetDstProperty(0).GetName());
            var prop = acn.GetFirstProperty();
            Assert.True(prop.IsValid());
            prop = acn.GetNextProperty(prop);
            Assert.True(prop.IsValid());
            Assert.AreEqual(1, prop.GetSrcObjectCount());
            Assert.AreSame(ac, prop.GetSrcObject(0));
        }

        [Test]
        public void FbxAnimCurveNode_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxAnimCurveNode("asdf");

            // then:
            Assert.AreEqual("AnimCurveNode::", obj.GetNameSpacePrefix());
        }
    }
}
