
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

void FbxSystemUnitTest::RegisterTestCases()
{
    AddTestCase(FbxSystemUnitTest_Create_DefaultScaleFactorIsOne);
    AddTestCase(FbxSystemUnitTest_Create_DefaultMultiplierIsOne);
}

