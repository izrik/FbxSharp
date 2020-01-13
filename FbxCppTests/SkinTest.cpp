
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

void Skin_AddCluster_AddsCluster()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSkin* s = FbxSkin::Create(manager, "");
    FbxCluster* c = FbxCluster::Create(manager, "");

    // require:
    AssertEqual(0, s->GetSrcObjectCount());
    AssertEqual(0, s->GetDstObjectCount());
    AssertEqual(0, s->GetClusterCount());

    AssertEqual(0, c->GetSrcObjectCount());
    AssertEqual(0, c->GetDstObjectCount());

    // when:
    s->AddCluster(c);

    // then:
    AssertEqual(1, s->GetSrcObjectCount());
    AssertEqual(c, s->GetSrcObject(0));
    AssertEqual(0, s->GetDstObjectCount());
    AssertEqual(1, s->GetClusterCount());
    AssertEqual(c, s->GetCluster(0));

    AssertEqual(0, c->GetSrcObjectCount());
    AssertEqual(1, c->GetDstObjectCount());
    AssertEqual(s, c->GetDstObject(0));
}

void Skin_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSkin* obj = FbxSkin::Create(manager, "asdf");

    // then:
    AssertEqual("Deformer::", obj->GetNameSpacePrefix());
}

void SkinTest::RegisterTestCases()
{
    AddTestCase(Skin_SetGeometry_SetsGeometry);
    AddTestCase(Skin_AddCluster_AddsCluster);
    AddTestCase(Skin_Create_HasNamespacePrefix);
}

