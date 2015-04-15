
#include "Tests.h"

using namespace std;

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

void AnimCurveTest::RegisterTestCases()
{
    AddTestCase(AnimCurve_Create_AllZero);
}

