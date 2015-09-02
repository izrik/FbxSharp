
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

void AnimCurve_Evaluate()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");

    FbxTime* time;
    time = new FbxTime(100);
    FbxAnimCurveKey key = FbxAnimCurveKey(*time, 1.5f);
    ac->KeyAdd(*time, key);

    FbxTime* time2;
    time2 = new FbxTime(10000);
    FbxAnimCurveKey key2 = FbxAnimCurveKey(*time2, 2.3f);
    ac->KeyAdd(*time2, key2);

    double value;

    // when:
    time = new FbxTime(0);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.5f, value);

    // when:
    time = new FbxTime(100);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.5f, value);

    // when:
    time = new FbxTime(500);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(1.53232f, value, 0.00001f);

    // when:
    time = new FbxTime(9000);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(2.21919f, value, 0.00001f);

    // when:
    time = new FbxTime(10000);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(2.3f, value);

    // when:
    time = new FbxTime(11000);
    value = ac->Evaluate(*time);

    // then:
    AssertEqual(2.3f, value);
}

void AnimCurve_TwoKeyBasic_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(0);
    key = new FbxAnimCurveKey(*time, 0.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1000);
    key = new FbxAnimCurveKey(*time, 1.0f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(0.1f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(200);
    AssertEqual(0.2f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(250);
    AssertEqual(0.25, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(300);
    AssertEqual(0.3f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(333);
    AssertEqual(0.333f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(400);
    AssertEqual(0.4f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(500);
    AssertEqual(0.5f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(600);
    AssertEqual(0.6f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(666);
    AssertEqual(0.666f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(700);
    AssertEqual(0.7f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(750);
    AssertEqual(0.75f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(800);
    AssertEqual(0.8f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(900);
    AssertEqual(0.9f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1000);
    AssertEqual(1.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(1.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1200);
    AssertEqual(1.0f, ac->Evaluate(*time), 0.000001);
}

void AnimCurve_TwoKeyVaryInTime_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(100);
    key = new FbxAnimCurveKey(*time, 0.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1300);
    key = new FbxAnimCurveKey(*time, 1.0f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(0.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(200);
    AssertEqual(0.0833333f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(250);
    AssertEqual(0.125f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(300);
    AssertEqual(0.166667, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(333);
    AssertEqual(0.194167f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(400);
    AssertEqual(0.25f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(500);
    AssertEqual(0.333333f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(600);
    AssertEqual(0.416667f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(666);
    AssertEqual(0.471667f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(700);
    AssertEqual(0.5f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(750);
    AssertEqual(0.541667, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(800);
    AssertEqual(0.583333f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(900);
    AssertEqual(0.666667f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1000);
    AssertEqual(0.75f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(0.833333f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1200);
    AssertEqual(0.916667f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1300);
    AssertEqual(1.0f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1400);
    AssertEqual(1.0f, ac->Evaluate(*time), 0.000001);
}

void AnimCurve_TwoKeyVaryInValue_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(0);
    key = new FbxAnimCurveKey(*time, -0.1f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1000);
    key = new FbxAnimCurveKey(*time, 2.3f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(-0.1f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(-0.1f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(-0.1f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(0.14f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(200);
    AssertEqual(0.38f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(250);
    AssertEqual(0.5f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(300);
    AssertEqual(0.62f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(333);
    AssertEqual(0.6992f, ac->Evaluate(*time), 0.00000001);
    time = new FbxTime(400);
    AssertEqual(0.86f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(500);
    AssertEqual(1.1f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(600);
    AssertEqual(1.34f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(666);
    AssertEqual(1.4984f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(700);
    AssertEqual(1.58f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(750);
    AssertEqual(1.7, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(800);
    AssertEqual(1.82f, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(900);
    AssertEqual(2.06, ac->Evaluate(*time), 0.00001);
    time = new FbxTime(1000);
    AssertEqual(2.3f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(2.3f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1200);
    AssertEqual(2.3f, ac->Evaluate(*time), 0.000001);
}

void AnimCurve_ThreeKeyBasic_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(0);
    key = new FbxAnimCurveKey(*time, 0.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1000);
    key = new FbxAnimCurveKey(*time, 1.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(2000);
    key = new FbxAnimCurveKey(*time, 2.0f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(0.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(0.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(0.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(0.100000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(200);
    AssertEqual(0.200000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(333);
    AssertEqual(0.333000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(500);
    AssertEqual(0.500000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(666);
    AssertEqual(0.666000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(900);
    AssertEqual(0.900000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1000);
    AssertEqual(1.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(1.100000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1333);
    AssertEqual(1.333000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1654);
    AssertEqual(1.654000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1900);
    AssertEqual(1.900000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2000);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2100);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2300);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
}

void AnimCurve_ThreeKeyVaryInTime_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(-150);
    key = new FbxAnimCurveKey(*time, 0.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1100);
    key = new FbxAnimCurveKey(*time, 1.0f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1900);
    key = new FbxAnimCurveKey(*time, 2.0f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(0.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-150);
    AssertEqual(0.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(0.039663f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(0.117218f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(0.192976f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(200);
    AssertEqual(0.267609f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(333);
    AssertEqual(0.366290f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(500);
    AssertEqual(0.491509f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(666);
    AssertEqual(0.620321f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(900);
    AssertEqual(0.815218f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1000);
    AssertEqual(0.905136f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(1.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1200);
    AssertEqual(1.103992f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1333);
    AssertEqual(1.259135f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1654);
    AssertEqual(1.678126f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1800);
    AssertEqual(1.871999f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1900);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2000);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2100);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2300);
    AssertEqual(2.000000f, ac->Evaluate(*time), 0.000001);
}

void AnimCurve_ThreeKeyVaryInValue_EvaluationsAreCorrect()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "");
    FbxTime* time;
    FbxAnimCurveKey* key;
    time = new FbxTime(0);
    key = new FbxAnimCurveKey(*time, -0.23f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(1000);
    key = new FbxAnimCurveKey(*time, 1.6724f);
    ac->KeyAdd(*time, *key);
    time = new FbxTime(2000);
    key = new FbxAnimCurveKey(*time, 1.11645f);
    ac->KeyAdd(*time, *key);

    // then:
    time = new FbxTime(-200);
    AssertEqual(-0.230000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-150);
    AssertEqual(-0.230000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(-100);
    AssertEqual(-0.230000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(0);
    AssertEqual(-0.230000f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(100);
    AssertEqual(-0.028697f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(200);
    AssertEqual(0.189814f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(333);
    AssertEqual(0.494413f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(500);
    AssertEqual(0.874847f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(666);
    AssertEqual(1.219098f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(900);
    AssertEqual(1.581723f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1000);
    AssertEqual(1.672400f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1100);
    AssertEqual(1.716368f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1200);
    AssertEqual(1.718544f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1333);
    AssertEqual(1.669369f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1654);
    AssertEqual(1.405046f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1800);
    AssertEqual(1.266974f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(1900);
    AssertEqual(1.183107f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2000);
    AssertEqual(1.116450f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2100);
    AssertEqual(1.116450f, ac->Evaluate(*time), 0.000001);
    time = new FbxTime(2300);
    AssertEqual(1.116450f, ac->Evaluate(*time), 0.000001);
}

void FbxAnimCurve_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurve* obj = FbxAnimCurve::Create(manager, "asdf");

    // then:
    AssertEqual("AnimCurve::", obj->GetNameSpacePrefix());
}

void AnimCurveTest::RegisterTestCases()
{
    AddTestCase(AnimCurveDef_Defaults);
    AddTestCase(AnimCurve_Create_AllZero);
    AddTestCase(AnimCurve_SingleKey_AllResultsSame);
    AddTestCase(AnimCurve_Evaluate);
    AddTestCase(AnimCurve_TwoKeyBasic_EvaluationsAreCorrect);
    AddTestCase(AnimCurve_TwoKeyVaryInTime_EvaluationsAreCorrect);
    AddTestCase(AnimCurve_TwoKeyVaryInValue_EvaluationsAreCorrect);
    AddTestCase(AnimCurve_ThreeKeyBasic_EvaluationsAreCorrect);
    AddTestCase(AnimCurve_ThreeKeyVaryInTime_EvaluationsAreCorrect);
    AddTestCase(AnimCurve_ThreeKeyVaryInValue_EvaluationsAreCorrect);
    AddTestCase(FbxAnimCurve_Create_HasNamespacePrefix);
}

