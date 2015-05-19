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
        public void AnimCurveKey_SetWeightLeftThenRight_WeightIsAll()
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

        [Test]
        public void AnimCurveKey_SetTangentWeights_TangentWeightsGetSet()
        {
            // given:
            var key = new AnimCurveKey();
            key.SetTangentWeightMode(AnimCurveDef.EWeightedMode.eWeightedAll);

            // require:
            Assert.AreEqual(AnimCurveDef.EWeightedMode.eWeightedAll, key.GetTangentWeightMode());
            Assert.AreEqual(AnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(AnimCurveDef.EDataIndex.eRightWeight));
            Assert.AreEqual(AnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(AnimCurveDef.EDataIndex.eNextLeftWeight));

            // when:
            key.SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex.eRightWeight, 0.234f);

            // then:
            Assert.AreEqual(0.234f, key.GetDataFloat(AnimCurveDef.EDataIndex.eRightWeight), 0.0001f);
            Assert.AreEqual(AnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(AnimCurveDef.EDataIndex.eNextLeftWeight));

            // when:
            key.SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex.eNextLeftWeight, 0.567f);

            // then:
            Assert.AreEqual(0.234f, key.GetDataFloat(AnimCurveDef.EDataIndex.eRightWeight), 0.0001f);
            Assert.AreEqual(0.567f, key.GetDataFloat(AnimCurveDef.EDataIndex.eNextLeftWeight), 0.0001f);
        }
    }
}
