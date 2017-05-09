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
            Assert.AreEqual(1/3.0f, FbxAnimCurveDef.sDEFAULT_WEIGHT);
            Assert.AreEqual(0.000099999997f, FbxAnimCurveDef.sMIN_WEIGHT);
            Assert.AreEqual(0.99f, FbxAnimCurveDef.sMAX_WEIGHT);
            Assert.AreEqual(0.0f, FbxAnimCurveDef.sDEFAULT_VELOCITY);
        }

        [Test]
        public void AnimCurve_Create_AllZero()
        {
            // given:
            var ac = new FbxAnimCurve("");
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
            var ac = new FbxAnimCurve("");
            FbxTime time;
            time = new FbxTime(100);
            var key = new FbxAnimCurveKey(time, 1.5f);
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

        [Test]
        public void AnimCurve_Evaluate()
        {
            // given:
            var ac = new FbxAnimCurve("");

            FbxTime time;
            time = new FbxTime(100);
            var key = new FbxAnimCurveKey(time, 1.5f);
            ac.KeyAdd(time, key);

            FbxTime time2;
            time2 = new FbxTime(10000);
            var key2 = new FbxAnimCurveKey(time2, 2.3f);
            ac.KeyAdd(time2, key2);

            double value;

            // when:
            time = new FbxTime(0);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.5f, value);

            // when:
            time = new FbxTime(100);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.5f, value);

            // when:
            time = new FbxTime(500);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(1.53232f, value, 0.00001f);

            // when:
            time = new FbxTime(9000);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(2.21919f, value, 0.00001f);

            // when:
            time = new FbxTime(10000);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(2.3f, value);

            // when:
            time = new FbxTime(11000);
            value = ac.Evaluate(time);

            // then:
            Assert.AreEqual(2.3f, value);
        }

        [Test]
        public void AnimCurve_TwoKeyBasic_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(0);
            key = new FbxAnimCurveKey(time, 0.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1000);
            key = new FbxAnimCurveKey(time, 1.0f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(0.1f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(200);
            Assert.AreEqual(0.2f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(250);
            Assert.AreEqual(0.25, ac.Evaluate(time), 0.00001);
            time = new FbxTime(300);
            Assert.AreEqual(0.3f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(333);
            Assert.AreEqual(0.333f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(400);
            Assert.AreEqual(0.4f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(500);
            Assert.AreEqual(0.5f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(600);
            Assert.AreEqual(0.6f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(666);
            Assert.AreEqual(0.666f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(700);
            Assert.AreEqual(0.7f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(750);
            Assert.AreEqual(0.75f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(800);
            Assert.AreEqual(0.8f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(900);
            Assert.AreEqual(0.9f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1000);
            Assert.AreEqual(1.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(1.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1200);
            Assert.AreEqual(1.0f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void AnimCurve_TwoKeyVaryInTime_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(100);
            key = new FbxAnimCurveKey(time, 0.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1300);
            key = new FbxAnimCurveKey(time, 1.0f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(0.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(200);
            Assert.AreEqual(0.0833333f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(250);
            Assert.AreEqual(0.125f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(300);
            Assert.AreEqual(0.166667, ac.Evaluate(time), 0.000001);
            time = new FbxTime(333);
            Assert.AreEqual(0.194167f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(400);
            Assert.AreEqual(0.25f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(500);
            Assert.AreEqual(0.333333f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(600);
            Assert.AreEqual(0.416667f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(666);
            Assert.AreEqual(0.471667f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(700);
            Assert.AreEqual(0.5f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(750);
            Assert.AreEqual(0.541667, ac.Evaluate(time), 0.000001);
            time = new FbxTime(800);
            Assert.AreEqual(0.583333f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(900);
            Assert.AreEqual(0.666667f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1000);
            Assert.AreEqual(0.75f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(0.833333f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1200);
            Assert.AreEqual(0.916667f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1300);
            Assert.AreEqual(1.0f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1400);
            Assert.AreEqual(1.0f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void AnimCurve_TwoKeyVaryInValue_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(0);
            key = new FbxAnimCurveKey(time, -0.1f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1000);
            key = new FbxAnimCurveKey(time, 2.3f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(-0.1f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(-0.1f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(-0.1f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(0.14f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(200);
            Assert.AreEqual(0.38f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(250);
            Assert.AreEqual(0.5f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(300);
            Assert.AreEqual(0.62f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(333);
            Assert.AreEqual(0.6992f, ac.Evaluate(time), 0.00000001);
            time = new FbxTime(400);
            Assert.AreEqual(0.86f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(500);
            Assert.AreEqual(1.1f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(600);
            Assert.AreEqual(1.34f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(666);
            Assert.AreEqual(1.4984f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(700);
            Assert.AreEqual(1.58f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(750);
            Assert.AreEqual(1.7, ac.Evaluate(time), 0.00001);
            time = new FbxTime(800);
            Assert.AreEqual(1.82f, ac.Evaluate(time), 0.00001);
            time = new FbxTime(900);
            Assert.AreEqual(2.06, ac.Evaluate(time), 0.00001);
            time = new FbxTime(1000);
            Assert.AreEqual(2.3f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(2.3f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1200);
            Assert.AreEqual(2.3f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void AnimCurve_ThreeKeyBasic_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(0);
            key = new FbxAnimCurveKey(time, 0.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1000);
            key = new FbxAnimCurveKey(time, 1.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(2000);
            key = new FbxAnimCurveKey(time, 2.0f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(0.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(0.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(0.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(0.100000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(200);
            Assert.AreEqual(0.200000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(333);
            Assert.AreEqual(0.333000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(500);
            Assert.AreEqual(0.500000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(666);
            Assert.AreEqual(0.666000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(900);
            Assert.AreEqual(0.900000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1000);
            Assert.AreEqual(1.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(1.100000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1333);
            Assert.AreEqual(1.333000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1654);
            Assert.AreEqual(1.654000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1900);
            Assert.AreEqual(1.900000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2000);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2100);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2300);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void AnimCurve_ThreeKeyVaryInTime_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(-150);
            key = new FbxAnimCurveKey(time, 0.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1100);
            key = new FbxAnimCurveKey(time, 1.0f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1900);
            key = new FbxAnimCurveKey(time, 2.0f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(0.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-150);
            Assert.AreEqual(0.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(0.039663f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(0.117218f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(0.192976f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(200);
            Assert.AreEqual(0.267609f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(333);
            Assert.AreEqual(0.366290f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(500);
            Assert.AreEqual(0.491509f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(666);
            Assert.AreEqual(0.620321f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(900);
            Assert.AreEqual(0.815218f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1000);
            Assert.AreEqual(0.905136f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(1.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1200);
            Assert.AreEqual(1.103992f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1333);
            Assert.AreEqual(1.259135f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1654);
            Assert.AreEqual(1.678126f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1800);
            Assert.AreEqual(1.871999f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1900);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2000);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2100);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2300);
            Assert.AreEqual(2.000000f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void AnimCurve_ThreeKeyVaryInValue_EvaluationsAreCorrect()
        {
            // given:
            var ac = new FbxAnimCurve("");
            FbxTime time;
            FbxAnimCurveKey key;
            time = new FbxTime(0);
            key = new FbxAnimCurveKey(time, -0.23f);
            ac.KeyAdd(time, key);
            time = new FbxTime(1000);
            key = new FbxAnimCurveKey(time, 1.6724f);
            ac.KeyAdd(time, key);
            time = new FbxTime(2000);
            key = new FbxAnimCurveKey(time, 1.11645f);
            ac.KeyAdd(time, key);

            // then:
            time = new FbxTime(-200);
            Assert.AreEqual(-0.230000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-150);
            Assert.AreEqual(-0.230000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(-100);
            Assert.AreEqual(-0.230000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(0);
            Assert.AreEqual(-0.230000f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(100);
            Assert.AreEqual(-0.028697f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(200);
            Assert.AreEqual(0.189814f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(333);
            Assert.AreEqual(0.494413f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(500);
            Assert.AreEqual(0.874847f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(666);
            Assert.AreEqual(1.219098f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(900);
            Assert.AreEqual(1.581723f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1000);
            Assert.AreEqual(1.672400f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1100);
            Assert.AreEqual(1.716368f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1200);
            Assert.AreEqual(1.718544f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1333);
            Assert.AreEqual(1.669369f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1654);
            Assert.AreEqual(1.405046f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1800);
            Assert.AreEqual(1.266974f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(1900);
            Assert.AreEqual(1.183107f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2000);
            Assert.AreEqual(1.116450f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2100);
            Assert.AreEqual(1.116450f, ac.Evaluate(time), 0.000001);
            time = new FbxTime(2300);
            Assert.AreEqual(1.116450f, ac.Evaluate(time), 0.000001);
        }

        [Test]
        public void FbxAnimCurve_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxAnimCurve("asdf");

            // then:
            Assert.AreEqual("AnimCurve::", obj.GetNameSpacePrefix());
        }
    }
}
