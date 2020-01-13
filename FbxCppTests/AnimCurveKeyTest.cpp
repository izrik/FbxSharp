
#include "Tests.h"

using namespace std;

void AnimCurveKey_Create_HasDefaultValues()
{
    // when:
    FbxAnimCurveKey* key = new FbxAnimCurveKey();

    // then:
    AssertEqual(0LL, key->GetTime().Get());
    AssertEqual(0.0, key->GetValue());
    AssertEqual(FbxAnimCurveDef::eTangentAuto, key->GetTangentMode());
    AssertEqual(FbxAnimCurveDef::eInterpolationCubic, key->GetInterpolation());
    AssertEqual(FbxAnimCurveDef::eWeightedNone, key->GetTangentWeightMode());
    AssertEqual(FbxAnimCurveDef::eConstantNext, key->GetConstantMode());
    AssertEqual(FbxAnimCurveDef::eVelocityNone, key->GetTangentVelocityMode());
    AssertEqual(FbxAnimCurveDef::eTangentShowNone, key->GetTangentVisibility());
    AssertTrue(!key->GetBreak());
}

void AnimCurveKey_SetWeightLeftThenRight_WeightIsAll()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurveKey* key = new FbxAnimCurveKey();

    // require:
    AssertEqual(FbxAnimCurveDef::eWeightedNone, key->GetTangentWeightMode());

    // when:
    key->SetTangentWeightMode(FbxAnimCurveDef::eWeightedNextLeft);

    // then:
    AssertEqual(FbxAnimCurveDef::eWeightedNextLeft, key->GetTangentWeightMode());

    // when:
    key->SetTangentWeightMode(FbxAnimCurveDef::eWeightedRight, FbxAnimCurveDef::eWeightedRight);

    // then:
    AssertEqual(FbxAnimCurveDef::eWeightedAll, key->GetTangentWeightMode());
}

void AnimCurveKey_SetTangentWeights_TangentWeightsGetSet()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurveKey* key = new FbxAnimCurveKey();
    key->SetTangentWeightMode(FbxAnimCurveDef::eWeightedAll);

    // require:
    AssertEqual(FbxAnimCurveDef::eWeightedAll, key->GetTangentWeightMode());
    AssertEqual(FbxAnimCurveDef::sDEFAULT_WEIGHT, key->GetDataFloat(FbxAnimCurveDef::eRightWeight));
    AssertEqual(FbxAnimCurveDef::sDEFAULT_WEIGHT, key->GetDataFloat(FbxAnimCurveDef::eNextLeftWeight));

    // when:
    key->SetTangentWeightAndAdjustTangent(FbxAnimCurveDef::eRightWeight, 0.234f);

    // then:
    AssertEqual(0.234f, key->GetDataFloat(FbxAnimCurveDef::eRightWeight), 0.0001f);
    AssertEqual(FbxAnimCurveDef::sDEFAULT_WEIGHT, key->GetDataFloat(FbxAnimCurveDef::eNextLeftWeight));

    // when:
    key->SetTangentWeightAndAdjustTangent(FbxAnimCurveDef::eNextLeftWeight, 0.567f);

    // then:
    AssertEqual(0.234f, key->GetDataFloat(FbxAnimCurveDef::eRightWeight), 0.0001f);
    AssertEqual(0.567f, key->GetDataFloat(FbxAnimCurveDef::eNextLeftWeight), 0.0001f);
}

void AnimCurveKeyTest::RegisterTestCases()
{
    AddTestCase(AnimCurveKey_Create_HasDefaultValues);
    AddTestCase(AnimCurveKey_SetWeightLeftThenRight_WeightIsAll);
    AddTestCase(AnimCurveKey_SetTangentWeights_TangentWeightsGetSet);
}

