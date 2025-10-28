
#include "Tests.h"

using namespace std;

void FbxAxisSystem_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAxisSystem* obj;

    // when:
    obj = new FbxAxisSystem();

    // then:
    int sign = 0;
    AssertEqual(FbxAxisSystem::EFrontVector::eParityOdd, obj->GetFrontVector(sign));
    AssertEqual(1, sign);
    AssertEqual(FbxAxisSystem::EUpVector::eYAxis, obj->GetUpVector(sign));
    AssertEqual(1, sign);
    AssertEqual(FbxAxisSystem::ECoordSystem::eRightHanded, obj->GetCoorSystem());
}

void FbxAxisSystemTest::RegisterTestCases()
{
    AddTestCase(FbxAxisSystem_Create_HasDefaults);
}

