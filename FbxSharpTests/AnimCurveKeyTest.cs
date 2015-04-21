using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimCurveKeyTest : TestBase
    {
        [Test]
        public void AnimCurveKey_Create_HasDefaultValues()
        {
            // when:
            var key = new AnimCurveKey();

            // then:
            Assert.AreEqual(0L, key.GetTime().Get());
            Assert.AreEqual(0.0, key.GetValue());
            Assert.AreEqual(AnimCurveDef.ETangentMode.eTangentAuto, key.GetTangentMode());
            Assert.AreEqual(AnimCurveDef.EInterpolationType.eInterpolationCubic, key.GetInterpolation());
            Assert.AreEqual(AnimCurveDef.EWeightedMode.eWeightedNone, key.GetTangentWeightMode());
            Assert.AreEqual(AnimCurveDef.EConstantMode.eConstantNext, key.GetConstantMode());
            Assert.AreEqual(AnimCurveDef.EVelocityMode.eVelocityNone, key.GetTangentVelocityMode());
            Assert.AreEqual(AnimCurveDef.ETangentVisibility.eTangentShowNone, key.GetTangentVisibility());
            Assert.True(!key.GetBreak());
        }

        [Test]
        public void AnimCurve_SetWeightLeftThenRight_WeightIsAll()
        {
            // given:
            var key = new AnimCurveKey();

            // require:
            Assert.AreEqual(AnimCurveDef.EWeightedMode.eWeightedNone, key.GetTangentWeightMode());

            // when:
            key.SetTangentWeightMode(AnimCurveDef.EWeightedMode.eWeightedNextLeft);

            // then:
            Assert.AreEqual(AnimCurveDef.EWeightedMode.eWeightedNextLeft, key.GetTangentWeightMode());

            // when:
            key.SetTangentWeightMode(AnimCurveDef.EWeightedMode.eWeightedRight, AnimCurveDef.EWeightedMode.eWeightedRight);

            // then:
            Assert.AreEqual(AnimCurveDef.EWeightedMode.eWeightedAll, key.GetTangentWeightMode());
        }
    }
}
