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
            var key = new FbxAnimCurveKey();

            // then:
            Assert.AreEqual(0L, key.GetTime().Get());
            Assert.AreEqual(0.0, key.GetValue());
            Assert.AreEqual(FbxAnimCurveDef.ETangentMode.eTangentAuto, key.GetTangentMode());
            Assert.AreEqual(FbxAnimCurveDef.EInterpolationType.eInterpolationCubic, key.GetInterpolation());
            Assert.AreEqual(FbxAnimCurveDef.EWeightedMode.eWeightedNone, key.GetTangentWeightMode());
            Assert.AreEqual(FbxAnimCurveDef.EConstantMode.eConstantNext, key.GetConstantMode());
            Assert.AreEqual(FbxAnimCurveDef.EVelocityMode.eVelocityNone, key.GetTangentVelocityMode());
            Assert.AreEqual(FbxAnimCurveDef.ETangentVisibility.eTangentShowNone, key.GetTangentVisibility());
            Assert.True(!key.GetBreak());
        }

        [Test]
        public void AnimCurveKey_SetWeightLeftThenRight_WeightIsAll()
        {
            // given:
            var key = new FbxAnimCurveKey();

            // require:
            Assert.AreEqual(FbxAnimCurveDef.EWeightedMode.eWeightedNone, key.GetTangentWeightMode());

            // when:
            key.SetTangentWeightMode(FbxAnimCurveDef.EWeightedMode.eWeightedNextLeft);

            // then:
            Assert.AreEqual(FbxAnimCurveDef.EWeightedMode.eWeightedNextLeft, key.GetTangentWeightMode());

            // when:
            key.SetTangentWeightMode(FbxAnimCurveDef.EWeightedMode.eWeightedRight, FbxAnimCurveDef.EWeightedMode.eWeightedRight);

            // then:
            Assert.AreEqual(FbxAnimCurveDef.EWeightedMode.eWeightedAll, key.GetTangentWeightMode());
        }

        [Test]
        public void AnimCurveKey_SetTangentWeights_TangentWeightsGetSet()
        {
            // given:
            var key = new FbxAnimCurveKey();
            key.SetTangentWeightMode(FbxAnimCurveDef.EWeightedMode.eWeightedAll);

            // require:
            Assert.AreEqual(FbxAnimCurveDef.EWeightedMode.eWeightedAll, key.GetTangentWeightMode());
            Assert.AreEqual(FbxAnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eRightWeight));
            Assert.AreEqual(FbxAnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eNextLeftWeight));

            // when:
            key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eRightWeight, 0.234f);

            // then:
            Assert.AreEqual(0.234f, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eRightWeight), 0.0001f);
            Assert.AreEqual(FbxAnimCurveDef.sDEFAULT_WEIGHT, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eNextLeftWeight));

            // when:
            key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eNextLeftWeight, 0.567f);

            // then:
            Assert.AreEqual(0.234f, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eRightWeight), 0.0001f);
            Assert.AreEqual(0.567f, key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eNextLeftWeight), 0.0001f);
        }
    }
}
