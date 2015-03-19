
#include "Tests.h"

using namespace std;

void SurfacePhong_FindProperty_FindsProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surf = FbxSurfacePhong::Create(manager, "");

    // when:
    FbxProperty prop = surf->FindProperty("SpecularColor");

    // then:
    AssertTrue(prop.IsValid());
}

void PropertyTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_FindProperty_FindsProperty);
}

