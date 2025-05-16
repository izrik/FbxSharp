
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

void FbxTime_Get_YieldsInternalRepresentation()
{
    // when:
    FbxTime* time = new FbxTime(0LL);
    // then:
    AssertEqual(0LL, time->Get());
    // when:
    time = new FbxTime(1LL);
    // then:
    AssertEqual(1LL, time->Get());
    // when:
    time = new FbxTime(2LL);
    // then:
    AssertEqual(2LL, time->Get());
    // when:
    time = new FbxTime(141119999L);
    // then:
    AssertEqual(141119999L, time->Get());
    // when:
    time = new FbxTime(141120000L);
    // then:
    AssertEqual(141120000L, time->Get());
    // when:
    time = new FbxTime(141120001L);
    // then:
    AssertEqual(141120001L, time->Get());
    // when:
    time = new FbxTime(-1LL);
    // then:
    AssertEqual(-1LL, time->Get());
    // when:
    time = new FbxTime(-2LL);
    // then:
    AssertEqual(-2LL, time->Get());
    // when:
    time = new FbxTime(-141119999L);
    // then:
    AssertEqual(-141119999L, time->Get());
    // when:
    time = new FbxTime(-141120000L);
    // then:
    AssertEqual(-141120000L, time->Get());
    // when:
    time = new FbxTime(-141120001L);
    // then:
    AssertEqual(-141120001L, time->Get());
}

void FbxTime_CountFunctionAreIndependent()
{
    // when:
    FbxTime* time = new FbxTime(516640320000LL);
    // then:
    AssertEqual(3661000LL, time->GetMilliSeconds());
    AssertEqual(3661, time->GetSecondCount());
    AssertEqual(61, time->GetMinuteCount());
    AssertEqual(1, time->GetHourCount());
    AssertEqual(3661.0, time->GetSecondDouble());

    // when:
    time = new FbxTime(516640461120LL);
    AssertEqual(3661001LL, time->GetMilliSeconds());
    AssertEqual(3661, time->GetSecondCount());
    AssertEqual(61, time->GetMinuteCount());
    AssertEqual(1, time->GetHourCount());
    AssertEqual(3661.001, time->GetSecondDouble());
}

void FbxTime_EMode_Values()
{
    // expect:
    AssertEqual(0, (int)FbxTime::EMode::eDefaultMode);
    AssertEqual(1, (int)FbxTime::EMode::eFrames120);
    AssertEqual(2, (int)FbxTime::EMode::eFrames100);
    AssertEqual(3, (int)FbxTime::EMode::eFrames60);
    AssertEqual(4, (int)FbxTime::EMode::eFrames50);
    AssertEqual(5, (int)FbxTime::EMode::eFrames48);
    AssertEqual(6, (int)FbxTime::EMode::eFrames30);
    AssertEqual(7, (int)FbxTime::EMode::eFrames30Drop);
    AssertEqual(8, (int)FbxTime::EMode::eNTSCDropFrame);
    AssertEqual(9, (int)FbxTime::EMode::eNTSCFullFrame);
    AssertEqual(10, (int)FbxTime::EMode::ePAL);
    AssertEqual(11, (int)FbxTime::EMode::eFrames24);
    AssertEqual(12, (int)FbxTime::EMode::eFrames1000);
    AssertEqual(13, (int)FbxTime::EMode::eFilmFullFrame);
    AssertEqual(14, (int)FbxTime::EMode::eCustom);
    AssertEqual(15, (int)FbxTime::EMode::eFrames96);
    AssertEqual(16, (int)FbxTime::EMode::eFrames72);
    AssertEqual(17, (int)FbxTime::EMode::eFrames59dot94);
    AssertEqual(18, (int)FbxTime::EMode::eFrames119dot88);
    AssertEqual(19, (int)FbxTime::EMode::eModesCount);
}

void FbxTime_EProtocol_Values()
{
    // expect:
    AssertEqual(0, (int)FbxTime::EProtocol::eSMPTE);
    AssertEqual(1, (int)FbxTime::EProtocol::eFrameCount);
    AssertEqual(2, (int)FbxTime::EProtocol::eDefaultProtocol);
}

void FbxTime_GetOneFrameValue()
{
    // expect:
    AssertEqual(4704000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eDefaultMode));
    AssertEqual(1176000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames120));
    AssertEqual(1411200L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames100));
    AssertEqual(2352000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames60));
    AssertEqual(2822400L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames50));
    AssertEqual(2940000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames48));
    AssertEqual(4704000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames30));
    AssertEqual(0L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames30Drop));
    AssertEqual(4708704L, FbxTime::GetOneFrameValue(FbxTime::EMode::eNTSCDropFrame));
    AssertEqual(4708704L, FbxTime::GetOneFrameValue(FbxTime::EMode::eNTSCFullFrame));
    AssertEqual(5644800L, FbxTime::GetOneFrameValue(FbxTime::EMode::ePAL));
    AssertEqual(5880000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames24));
    AssertEqual(141120L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames1000));
    AssertEqual(5885880L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFilmFullFrame));
    AssertEqual(11289600L, FbxTime::GetOneFrameValue(FbxTime::EMode::eCustom));
    AssertEqual(1470000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames96));
    AssertEqual(1960000L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames72));
    AssertEqual(2354352L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames59dot94));
    AssertEqual(1177176L, FbxTime::GetOneFrameValue(FbxTime::EMode::eFrames119dot88));
    AssertEqual(0L, FbxTime::GetOneFrameValue(FbxTime::EMode::eModesCount));
}

void FbxTime_GetGlobalTimeProtocol()
{
    // expect:
    AssertEqual(FbxTime::EProtocol::eFrameCount, FbxTime::GetGlobalTimeProtocol());
}

void FbxTime_GetFrameRate()
{
    // expect:
    AssertEqual(30.0, FbxTime::GetFrameRate(FbxTime::EMode::eDefaultMode));
    AssertEqual(120.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames120));
    AssertEqual(100.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames100));
    AssertEqual(60.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames60));
    AssertEqual(50.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames50));
    AssertEqual(48.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames48));
    AssertEqual(30.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames30));
    AssertEqual(0.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames30Drop));
    AssertEqual(29.970029970029969490497023798525333404541015625, FbxTime::GetFrameRate(FbxTime::EMode::eNTSCDropFrame));
    AssertEqual(29.970029970029969490497023798525333404541015625, FbxTime::GetFrameRate(FbxTime::EMode::eNTSCFullFrame));
    AssertEqual(25.0, FbxTime::GetFrameRate(FbxTime::EMode::ePAL));
    AssertEqual(24.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames24));
    AssertEqual(1000.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames1000));
    AssertEqual(23.976023976023977724025826319120824337005615234375, FbxTime::GetFrameRate(FbxTime::EMode::eFilmFullFrame));
    AssertEqual(12.5, FbxTime::GetFrameRate(FbxTime::EMode::eCustom));
    AssertEqual(96.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames96));
    AssertEqual(72.0, FbxTime::GetFrameRate(FbxTime::EMode::eFrames72));
    AssertEqual(59.94005994005993898099404759705066680908203125, FbxTime::GetFrameRate(FbxTime::EMode::eFrames59dot94));
    AssertEqual(119.8801198801198779619880951941013336181640625, FbxTime::GetFrameRate(FbxTime::EMode::eFrames119dot88));
    AssertEqual(0.0, FbxTime::GetFrameRate(FbxTime::EMode::eModesCount));
}

void FbxTime_ConvertFrameRateToTimeMode()
{
    // expect:
    AssertEqual(FbxTime::EMode::eFrames30, FbxTime::ConvertFrameRateToTimeMode(30.0));
    AssertEqual(FbxTime::EMode::eFrames120, FbxTime::ConvertFrameRateToTimeMode(120.0));
    AssertEqual(FbxTime::EMode::eFrames100, FbxTime::ConvertFrameRateToTimeMode(100.0));
    AssertEqual(FbxTime::EMode::eFrames60, FbxTime::ConvertFrameRateToTimeMode(60.0));
    AssertEqual(FbxTime::EMode::eFrames50, FbxTime::ConvertFrameRateToTimeMode(50.0));
    AssertEqual(FbxTime::EMode::eFrames48, FbxTime::ConvertFrameRateToTimeMode(48.0));
    AssertEqual(FbxTime::EMode::eFrames30, FbxTime::ConvertFrameRateToTimeMode(30.0));
    AssertEqual(FbxTime::EMode::eNTSCDropFrame, FbxTime::ConvertFrameRateToTimeMode(29.970029970029969490497023798525333404541015625));
    AssertEqual(FbxTime::EMode::ePAL, FbxTime::ConvertFrameRateToTimeMode(25.0));
    AssertEqual(FbxTime::EMode::eFrames24, FbxTime::ConvertFrameRateToTimeMode(24.0));
    AssertEqual(FbxTime::EMode::eFrames1000, FbxTime::ConvertFrameRateToTimeMode(1000.0));
    AssertEqual(FbxTime::EMode::eFilmFullFrame, FbxTime::ConvertFrameRateToTimeMode(23.976023976023977724025826319120824337005615234375));
    AssertEqual(FbxTime::EMode::eCustom, FbxTime::ConvertFrameRateToTimeMode(12.5));
    AssertEqual(FbxTime::EMode::eFrames96, FbxTime::ConvertFrameRateToTimeMode(96.0));
    AssertEqual(FbxTime::EMode::eFrames72, FbxTime::ConvertFrameRateToTimeMode(72.0));
    AssertEqual(FbxTime::EMode::eFrames59dot94, FbxTime::ConvertFrameRateToTimeMode(59.94005994005993898099404759705066680908203125));
    AssertEqual(FbxTime::EMode::eFrames119dot88, FbxTime::ConvertFrameRateToTimeMode(119.8801198801198779619880951941013336181640625));

    AssertEqual(FbxTime::EMode::eFrames30Drop, FbxTime::ConvertFrameRateToTimeMode(0.0));
    AssertEqual(FbxTime::EMode::eDefaultMode, FbxTime::ConvertFrameRateToTimeMode(0.00001));
    AssertEqual(FbxTime::EMode::eDefaultMode, FbxTime::ConvertFrameRateToTimeMode(1.0));
    AssertEqual(FbxTime::EMode::eDefaultMode, FbxTime::ConvertFrameRateToTimeMode(10.0));

    AssertEqual(FbxTime::EMode::ePAL, FbxTime::ConvertFrameRateToTimeMode(27.0, 2.9));
    AssertEqual(FbxTime::EMode::eFrames30, FbxTime::ConvertFrameRateToTimeMode(27.0, 3.0));
    AssertEqual(FbxTime::EMode::eFrames30, FbxTime::ConvertFrameRateToTimeMode(27.0, 3.1));

    AssertEqual(FbxTime::EMode::ePAL, FbxTime::ConvertFrameRateToTimeMode(24.5, 0.5));
    AssertEqual(FbxTime::EMode::eDefaultMode, FbxTime::ConvertFrameRateToTimeMode(24.5, 0.4));
    AssertEqual(FbxTime::EMode::ePAL, FbxTime::ConvertFrameRateToTimeMode(24.6, 0.4));
    AssertEqual(FbxTime::EMode::eDefaultMode, FbxTime::ConvertFrameRateToTimeMode(24.41, 0.4));
    AssertEqual(FbxTime::EMode::eFrames24, FbxTime::ConvertFrameRateToTimeMode(24.4, 0.4));
    AssertEqual(FbxTime::EMode::eFrames24, FbxTime::ConvertFrameRateToTimeMode(24.3, 0.4));
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
    AddTestCase(FbxTime_Get_YieldsInternalRepresentation);
    AddTestCase(FbxTime_CountFunctionAreIndependent);
    AddTestCase(FbxTime_EMode_Values);
    AddTestCase(FbxTime_EProtocol_Values);
    AddTestCase(FbxTime_GetOneFrameValue);
    AddTestCase(FbxTime_GetGlobalTimeProtocol);
    AddTestCase(FbxTime_GetFrameRate);
    AddTestCase(FbxTime_ConvertFrameRateToTimeMode);
}

