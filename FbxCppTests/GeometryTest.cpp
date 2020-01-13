
#include "Tests.h"

using namespace std;

void Geometry_AddDeformer_AddsDeformer()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometry* g = FbxGeometry::Create(manager, "");
    FbxSkin* skin = FbxSkin::Create(manager, "");

    // require:
    AssertEqual(0, g->GetDeformerCount());
    AssertEqual(0, g->GetSrcObjectCount());

    // when:
    g->AddDeformer(skin);

    // then:
    AssertEqual(1, g->GetDeformerCount());
    AssertEqual(skin, g->GetDeformer(0));
    AssertEqual(1, g->GetSrcObjectCount());
    AssertEqual(skin, g->GetSrcObject(0));
}

void Geometry_AddSrcConnection_AddsDeformer()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometry* g = FbxGeometry::Create(manager, "");
    FbxSkin* skin = FbxSkin::Create(manager, "");

    // require:
    AssertEqual(0, g->GetDeformerCount());
    AssertEqual(0, g->GetSrcObjectCount());

    // when:
    g->ConnectSrcObject(skin);

    // then:
    AssertEqual(1, g->GetDeformerCount());
    AssertEqual(skin, g->GetDeformer(0));
    AssertEqual(1, g->GetSrcObjectCount());
    AssertEqual(skin, g->GetSrcObject(0));
}

void Geometry_RemoveDeformer_RemovesDeformer()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometry* g = FbxGeometry::Create(manager, "");
    FbxSkin* skin = FbxSkin::Create(manager, "");
    g->AddDeformer(skin);

    // require:
    AssertEqual(1, g->GetDeformerCount());
    AssertEqual(1, g->GetSrcObjectCount());

    // when:
    g->RemoveDeformer(0);

    // then:
    AssertEqual(0, g->GetDeformerCount());
    AssertEqual(0, g->GetSrcObjectCount());
}

void Geometry_DisconnectSrcObject_RemovesDeformer()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometry* g = FbxGeometry::Create(manager, "");
    FbxSkin* skin = FbxSkin::Create(manager, "");
    g->AddDeformer(skin);

    // require:
    AssertEqual(1, g->GetDeformerCount());
    AssertEqual(1, g->GetSrcObjectCount());

    // when:
    g->DisconnectSrcObject(skin);

    // then:
    AssertEqual(0, g->GetDeformerCount());
    AssertEqual(0, g->GetSrcObjectCount());
}

void GeometryTest::RegisterTestCases()
{
    AddTestCase(Geometry_AddDeformer_AddsDeformer);
    AddTestCase(Geometry_AddSrcConnection_AddsDeformer);
    AddTestCase(Geometry_RemoveDeformer_RemovesDeformer);
    AddTestCase(Geometry_DisconnectSrcObject_RemovesDeformer);
}

