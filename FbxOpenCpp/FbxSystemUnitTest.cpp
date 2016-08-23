
#include "Tests.h"

using namespace std;

void FbxSystemUnitTest_Create_DefaultScaleFactorIsOne()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit();

    // then:
    AssertEqual(1, su->GetScaleFactor(), 0.00001);
}

void FbxSystemUnitTest_Create_DefaultMultiplierIsOne()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit();

    // then:
    AssertEqual(1, su->GetMultiplier(), 0.00001);
}

void FbxSystemUnitTest_Create_SettingScaleFactorSetsScaleFactor()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit(2);

    // then:
    AssertEqual(2, su->GetScaleFactor(), 0.00001);
    AssertEqual(1, su->GetMultiplier(), 0.00001);

    // when:
    su = new FbxSystemUnit(2.3);

    // then:
    AssertEqual(2.3, su->GetScaleFactor(), 0.00001);
    AssertEqual(1, su->GetMultiplier(), 0.00001);
}

void FbxSystemUnitTest_Create_SettingMultiplierSetsMultiplier()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit(1, 3);

    // then:
    AssertEqual(1, su->GetScaleFactor(), 0.00001);
    AssertEqual(3, su->GetMultiplier(), 0.00001);

    // when:
    su = new FbxSystemUnit(1, 4.5);

    // then:
    AssertEqual(1, su->GetScaleFactor(), 0.00001);
    AssertEqual(4.5, su->GetMultiplier(), 0.00001);
}

void FbxSystemUnitTest_Create_SettingBothSetsBoth()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit(5, 6);

    // then:
    AssertEqual(5, su->GetScaleFactor(), 0.00001);
    AssertEqual(6, su->GetMultiplier(), 0.00001);

    // when:
    su = new FbxSystemUnit(7.8, 8.9);

    // then:
    AssertEqual(7.8, su->GetScaleFactor(), 0.00001);
    AssertEqual(8.9, su->GetMultiplier(), 0.00001);
}

void FbxSystemUnitTest_Create_NegativeValuesAreAllowed()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit(-2, 1);

    // then:
    AssertEqual(-2, su->GetScaleFactor(), 0.00001);
    AssertEqual(1, su->GetMultiplier(), 0.00001);

    // when:
    su = new FbxSystemUnit(1, -3);

    // then:
    AssertEqual(1, su->GetScaleFactor(), 0.00001);
    AssertEqual(-3, su->GetMultiplier(), 0.00001);

    // when:
    su = new FbxSystemUnit(-4, -5);

    // then:
    AssertEqual(-4, su->GetScaleFactor(), 0.00001);
    AssertEqual(-5, su->GetMultiplier(), 0.00001);
}

void FbxSystemUnitTest_GetScaleFactorAsString_AsString()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSystemUnit* su;

    // when:
    su = new FbxSystemUnit(1, 1);

    // then:
    AssertEqual("cm", su->GetScaleFactorAsString());

    // when:
    su = new FbxSystemUnit(100, 3);

    // then:
    AssertEqual("custom unit", su->GetScaleFactorAsString());
}

void FbxSystemUnitTest::RegisterTestCases()
{
    AddTestCase(FbxSystemUnitTest_Create_DefaultScaleFactorIsOne);
    AddTestCase(FbxSystemUnitTest_Create_DefaultMultiplierIsOne);
    AddTestCase(FbxSystemUnitTest_Create_SettingScaleFactorSetsScaleFactor);
    AddTestCase(FbxSystemUnitTest_Create_SettingMultiplierSetsMultiplier);
    AddTestCase(FbxSystemUnitTest_Create_SettingBothSetsBoth);
    AddTestCase(FbxSystemUnitTest_Create_NegativeValuesAreAllowed);
    AddTestCase(FbxSystemUnitTest_GetScaleFactorAsString_AsString);
}

