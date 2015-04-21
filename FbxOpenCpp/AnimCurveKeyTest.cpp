
#include "Tests.h"

using namespace std;

void AnimCurveKey_Create_HasDefaultValues()
{
    // when:
    FbxAnimCurveKey* key = new FbxAnimCurveKey();

    // then:
    AssertEqual(0L, key->GetTime().Get());
    AssertEqual(0.0, key->GetValue());
    AssertEqual(FbxAnimCurveDef::eTangentAuto, key->GetTangentMode());
    AssertEqual(FbxAnimCurveDef::eInterpolationCubic, key->GetInterpolation());
    AssertEqual(FbxAnimCurveDef::eWeightedNone, key->GetTangentWeightMode());
    AssertEqual(FbxAnimCurveDef::eConstantNext, key->GetConstantMode());
    AssertEqual(FbxAnimCurveDef::eVelocityNone, key->GetTangentVelocityMode());
    AssertEqual(FbxAnimCurveDef::eTangentShowNone, key->GetTangentVisibility());
    AssertTrue(!key->GetBreak());
}

void AnimCurve_SetWeightLeftThenRight_WeightIsAll()
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

void AnimCurveKeyTest::RegisterTestCases()
{
    AddTestCase(AnimCurveKey_Create_HasDefaultValues);
    AddTestCase(AnimCurve_SetWeightLeftThenRight_WeightIsAll);
}

