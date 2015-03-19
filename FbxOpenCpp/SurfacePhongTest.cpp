
#include "Tests.h"

using namespace std;

void SurfacePhong_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surface = FbxSurfacePhong::Create(manager, "");

    // then:
    AssertEqual(22, CountProperties(surface));
    AssertEqual(0, surface->GetSrcPropertyCount());
    AssertEqual(0, surface->GetDstPropertyCount());
}

void SurfacePhongTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_Create_HasProperties);
}

