
#include "Tests.h"

using namespace std;

void Skin_SetGeometry_SetsGeometry()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSkin* skin = FbxSkin::Create(manager, "");
    FbxMesh* mesh = FbxMesh::Create(manager, "");

    // require:
    AssertEqual(0, skin->GetSrcObjectCount());
    AssertEqual(0, skin->GetDstObjectCount());
    AssertEqual(NULL, skin->GetGeometry());

    AssertEqual(0, mesh->GetSrcObjectCount());
    AssertEqual(0, mesh->GetDstObjectCount());
    AssertEqual(0, mesh->GetDeformerCount());

    // when:
    skin->SetGeometry(mesh);

    // then:
    AssertEqual(0, skin->GetSrcObjectCount());
    AssertEqual(1, skin->GetDstObjectCount());
    AssertEqual(mesh, skin->GetGeometry());

    AssertEqual(1, mesh->GetSrcObjectCount());
    AssertEqual(0, mesh->GetDstObjectCount());
    AssertEqual(1, mesh->GetDeformerCount());
    AssertEqual(skin, mesh->GetDeformer(0));
}

void SkinTest::RegisterTestCases()
{
    AddTestCase(Skin_SetGeometry_SetsGeometry);
}

