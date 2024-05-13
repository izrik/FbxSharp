
#include "Tests.h"

using namespace std;

void FbxTime_Constants()
{
    // expect:
    AssertEqual(141120L, FBXSDK_TC_MILLISECOND);
    AssertEqual(141120000L, FBXSDK_TC_SECOND);
}

void FbxTime_CreateLongLong_HasSeconds()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time;

    // when:
    time = new FbxTime(0);

    // then:
    AssertEqual(0.0, time->GetSecondDouble());
    AssertEqual(0LL, time->GetFrameCount());

    // when:
    time = new FbxTime(-23520000LL);

    // then:
    AssertEqual(-5/30.0, time->GetSecondDouble());
    AssertEqual(-5LL, time->GetFrameCount());
}

void FbxTimeTest::RegisterTestCases()
{
    AddTestCase(FbxTime_Constants);
    AddTestCase(FbxTime_CreateLongLong_HasSeconds);
}

