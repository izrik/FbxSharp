
#include "Tests.h"

using namespace std;

void AnimCurveDef_Defaults()
{
    // require:
    AssertEqual(1/3.0f, FbxAnimCurveDef::sDEFAULT_WEIGHT);
    AssertEqual(0.000099999997f, FbxAnimCurveDef::sMIN_WEIGHT);
    AssertEqual(0.99f, FbxAnimCurveDef::sMAX_WEIGHT);
    AssertEqual(0.0f, FbxAnimCurveDef::sDEFAULT_VELOCITY);
}

void AnimCurve_Create_AllZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    double value;

    // when:
    time = new FbxTime(0);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(0.0, value);

    // when:
    time = new FbxTime(100);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(0.0, value);

    // when:
    time = new FbxTime(-100);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(0.0, value);

    // when:
    time = new FbxTime(10000000L);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(0.0, value);
}

void AnimCurve_SingleKey_AllResultsSame()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    time = new FbxTime(100);
    FbxAnimCurveKey key = FbxAnimCurveKey(*time, 1.5f);
    ac->KeyAdd(*time, key);
    double value;

    // when:
    time = new FbxTime(0);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.5, value);

    // when:
    time = new FbxTime(100);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.5, value);

    // when:
    time = new FbxTime(200);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.5, value);
}

void AnimCurveTest::RegisterTestCases()
{
    AddTestCase(AnimCurveDef_Defaults);
    AddTestCase(AnimCurve_Create_AllZero);
    AddTestCase(AnimCurve_SingleKey_AllResultsSame);
}

