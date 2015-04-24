using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimCurveTest : TestBase
    {
        [Test]
        public void AnimCurveDef_Defaults()
        {
            // require:
            Assert.AreEqual(1/3.0f, AnimCurveDef.sDEFAULT_WEIGHT);
            Assert.AreEqual(0.000099999997f, AnimCurveDef.sMIN_WEIGHT);
            Assert.AreEqual(0.99f, AnimCurveDef.sMAX_WEIGHT);
            Assert.AreEqual(0.0f, AnimCurveDef.sDEFAULT_VELOCITY);
        }

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

        [Test]
        public void AnimCurve_SingleKey_AllResultsSame()
        {
            // given:
            var ac = new AnimCurve("");
            FbxTime time;
            time = new FbxTime(100);
            var key = new AnimCurveKey(time, 1.5f);
            ac.KeyAdd(time, key);
            double value;

            // when:
            time = new FbxTime(0);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.5, value);

            // when:
            time = new FbxTime(100);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.5, value);

            // when:
            time = new FbxTime(200);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.5, value);
        }
    }
}
