
#include "Tests.h"

using namespace std;

void FbxTimeSpan_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTimeSpan ts;
    ts = FbxTimeSpan();

    // expect:
    AssertEqual(0LL, ts.GetStart().Get());
    AssertEqual(0LL, ts.GetStop().Get());
    AssertEqual(0LL, ts.GetDuration().Get());
    AssertEqual(0LL, ts.GetSignedDuration().Get());
    AssertEqual(1, ts.GetDirection());
}

void FbxTimeSpan_Create_WithArguments()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTimeSpan ts;

    // when:
    ts = FbxTimeSpan(FbxTime(141120000L), FbxTime(423360000L));
    // then:
    AssertEqual(141120000LL, ts.GetStart().Get());
    AssertEqual(423360000LL, ts.GetStop().Get());
    AssertEqual(282240000LL, ts.GetDuration().Get());
    AssertEqual(282240000LL, ts.GetSignedDuration().Get());
    AssertEqual(1, ts.GetDirection());

    // when:
    ts = FbxTimeSpan(FbxTime(423360000L), FbxTime(141120000L));
    // then:
    AssertEqual(423360000LL, ts.GetStart().Get());
    AssertEqual(141120000LL, ts.GetStop().Get());
    AssertEqual(282240000LL, ts.GetDuration().Get());
    AssertEqual(-282240000LL, ts.GetSignedDuration().Get());
    AssertEqual(-1, ts.GetDirection());
}

void FbxTimeSpanTest::RegisterTestCases()
{
    AddTestCase(FbxTimeSpan_Create_HasDefaults);
    AddTestCase(FbxTimeSpan_Create_WithArguments);
}

