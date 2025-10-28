using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxTimeSpanTest : TestBase
    {
        [Test]
        public void FbxTimeSpan_Create_HasDefaults()
        {
            // given:
            FbxTimeSpan ts;
            ts = new FbxTimeSpan();

            // expect:
            Assert.That(ts.GetStart().Get(), Is.EqualTo(0L));
            Assert.That(ts.GetStop().Get(), Is.EqualTo(0L));
            Assert.That(ts.GetDuration().Get(), Is.EqualTo(0L));
            Assert.That(ts.GetSignedDuration().Get(), Is.EqualTo(0L));
            Assert.That(ts.GetDirection(), Is.EqualTo(1));
        }

        [Test]
        public void FbxTimeSpan_Create_WithArguments()
        {
            // given:
            FbxTimeSpan ts;

            // when:
            ts = new FbxTimeSpan(new FbxTime(141120000L), new FbxTime(423360000L));
            // then:
            Assert.That(ts.GetStart().Get(), Is.EqualTo(141120000L));
            Assert.That(ts.GetStop().Get(), Is.EqualTo(423360000L));
            Assert.That(ts.GetDuration().Get(), Is.EqualTo(282240000L));
            Assert.That(ts.GetSignedDuration().Get(), Is.EqualTo(282240000L));
            Assert.That(ts.GetDirection(), Is.EqualTo(1));

            // when:
            ts = new FbxTimeSpan(new FbxTime(423360000L), new FbxTime(141120000L));
            // then:
            Assert.That(ts.GetStart().Get(), Is.EqualTo(423360000L));
            Assert.That(ts.GetStop().Get(), Is.EqualTo(141120000L));
            Assert.That(ts.GetDuration().Get(), Is.EqualTo(-282240000L));
            Assert.That(ts.GetSignedDuration().Get(), Is.EqualTo(-282240000L));
            Assert.That(ts.GetDirection(), Is.EqualTo(-1));
        }
    }
}
