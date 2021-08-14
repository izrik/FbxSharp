
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

void FbxTime_GetSecondCount_ZeroYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(0);

    // when:
    int result = time->GetSecondCount();

    // then:
    AssertEqual(0, result);
}

void FbxTime_GetSecondCount_OneYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141120000L);

    // when:
    int result = time->GetSecondCount();

    // then:
    AssertEqual(1, result);
}

void FbxTime_GetSecondCount_FractionYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(70560000L);

    // when:
    int result = time->GetSecondCount();

    // then:
    AssertEqual(0, result);
}

void FbxTime_GetSecondCount_FractionYieldsCount2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141119999L);

    // when:
    int result = time->GetSecondCount();

    // then:
    AssertEqual(0, result);
}

void FbxTime_GetSecondCount_FractionYieldsCount3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141120001L);

    // when:
    int result = time->GetSecondCount();

    // then:
    AssertEqual(1, result);
}

void FbxTimeTest::RegisterTestCases()
{
    AddTestCase(FbxTime_Constants);
    AddTestCase(FbxTime_CreateLongLong_HasSeconds);
    AddTestCase(FbxTime_GetSecondCount_ZeroYieldsCount);
    AddTestCase(FbxTime_GetSecondCount_OneYieldsCount);
    AddTestCase(FbxTime_GetSecondCount_FractionYieldsCount);
    AddTestCase(FbxTime_GetSecondCount_FractionYieldsCount2);
    AddTestCase(FbxTime_GetSecondCount_FractionYieldsCount3);
}

