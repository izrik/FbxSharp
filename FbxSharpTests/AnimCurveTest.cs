using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimCurveTest : TestBase
    {
        [Test]
        public void AnimCurve_Create_AllZero()
        {
            // given:
            var ac = new AnimCurve("");
            FbxTime time;
            double value;

            // when:
            time = new FbxTime(0);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(0.0, value);

            // when:
            time = new FbxTime(100);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(0.0, value);

            // when:
            time = new FbxTime(-100);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(0.0, value);

            // when:
            time = new FbxTime(10000000L);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(0.0, value);
        }
    }
}
