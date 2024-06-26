
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

void FbxTime_GetMilliSeconds_ZeroYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(0);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetMilliSeconds_OneYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141120L);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(1, result);
}

void FbxTime_GetMilliSeconds_FractionYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(70560L);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetMilliSeconds_FractionYieldsCount2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141119L);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetMilliSeconds_FractionYieldsCount3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(141121L);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(1, result);
}

void FbxTime_GetMilliSeconds_NegativeYieldsCount()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-141120L);
    // when:
    long result = time->GetMilliSeconds();
    // then:
    AssertEqual(-1, result);
}

void FbxTime_GetFrameCountPrecise_ZeroYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(0);
    // when:
    double result = time->GetFrameCountPrecise();
    // then:
    AssertEqual(0, result, 0);
}

void FbxTime_GetFrameCountPrecise_OneYieldsOne()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4704000L);
    // when:
    double result = time->GetFrameCountPrecise();
    // then:
    AssertEqual(1, result, 0);
}

void FbxTime_GetFrameCountPrecise_NegativeYieldsNegative()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-4704000);
    // when:
    double result = time->GetFrameCountPrecise();
    // then:
    AssertEqual(-1, result, 0);
}

void FbxTime_GetFrameCountPrecise_FractionYieldsFraction()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4703999);
    // when:
    double result = time->GetFrameCountPrecise();
    // then:
    AssertEqual(0.999999787414966, result, 0);
}

void FbxTime_GetFrameCountPrecise_FractionYieldsFraction2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4704001);
    // when:
    double result = time->GetFrameCountPrecise();
    // then:
    AssertEqual(1.000000212585034, result, 0);
}

void FbxTime_GetFieldCount_ZeroYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(0);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetFieldCount_OneYieldsTwo()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4704000L);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(2, result);
}

void FbxTime_GetFieldCount_NegativeYieldsNegative()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-4704000);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(-2, result);
}

void FbxTime_GetFieldCount_FractionYieldsInteger()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4703999);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(1, result);
}

void FbxTime_GetFieldCount_FractionYieldsInteger2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(4704001);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(2, result);
}

void FbxTime_GetFieldCount_NegFractionYieldsInteger()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-1);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetFieldCount_NegFractionYieldsInteger2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-4703999);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(-1, result);
}

void FbxTime_GetFieldCount_NegFractionYieldsInteger3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-4704001);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(-2, result);
}

void FbxTime_GetFieldCount_HalfYieldsOne()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(2352000);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(1, result);
}

void FbxTime_GetFieldCount_HalfYieldsOne2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(2351999);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetFieldCount_HalfYieldsOne3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(2352001);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(1, result);
}

void FbxTime_GetFieldCount_NegHalfYieldsOne()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-2352000);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(-1, result);
}

void FbxTime_GetFieldCount_NegHalfYieldsOne2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-2351999);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(0, result);
}

void FbxTime_GetFieldCount_NegHalfYieldsOne3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxTime* time = new FbxTime(-2352001);
    // when:
    long result = time->GetFieldCount();
    // then:
    AssertEqual(-1, result);
}

void FbxTime_GetGlobalTimeMode()
{
    // expect:
    AssertEqual(FbxTime::EMode::eFrames30, FbxTime::GetGlobalTimeMode());
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
    AddTestCase(FbxTime_GetMilliSeconds_ZeroYieldsCount);
    AddTestCase(FbxTime_GetMilliSeconds_OneYieldsCount);
    AddTestCase(FbxTime_GetMilliSeconds_FractionYieldsCount);
    AddTestCase(FbxTime_GetMilliSeconds_FractionYieldsCount2);
    AddTestCase(FbxTime_GetMilliSeconds_FractionYieldsCount3);
    AddTestCase(FbxTime_GetMilliSeconds_NegativeYieldsCount);
    AddTestCase(FbxTime_GetFrameCountPrecise_ZeroYieldsZero);
    AddTestCase(FbxTime_GetFrameCountPrecise_OneYieldsOne);
    AddTestCase(FbxTime_GetFrameCountPrecise_NegativeYieldsNegative);
    AddTestCase(FbxTime_GetFrameCountPrecise_FractionYieldsFraction);
    AddTestCase(FbxTime_GetFrameCountPrecise_FractionYieldsFraction2);
    AddTestCase(FbxTime_GetFieldCount_ZeroYieldsZero);
    AddTestCase(FbxTime_GetFieldCount_OneYieldsTwo);
    AddTestCase(FbxTime_GetFieldCount_NegativeYieldsNegative);
    AddTestCase(FbxTime_GetFieldCount_FractionYieldsInteger);
    AddTestCase(FbxTime_GetFieldCount_FractionYieldsInteger2);
    AddTestCase(FbxTime_GetFieldCount_NegFractionYieldsInteger);
    AddTestCase(FbxTime_GetFieldCount_NegFractionYieldsInteger2);
    AddTestCase(FbxTime_GetFieldCount_NegFractionYieldsInteger3);
    AddTestCase(FbxTime_GetFieldCount_HalfYieldsOne);
    AddTestCase(FbxTime_GetFieldCount_HalfYieldsOne2);
    AddTestCase(FbxTime_GetFieldCount_HalfYieldsOne3);
    AddTestCase(FbxTime_GetFieldCount_NegHalfYieldsOne);
    AddTestCase(FbxTime_GetFieldCount_NegHalfYieldsOne2);
    AddTestCase(FbxTime_GetFieldCount_NegHalfYieldsOne3);
    AddTestCase(FbxTime_GetGlobalTimeMode);
}

