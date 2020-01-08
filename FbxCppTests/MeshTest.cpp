
#include "Tests.h"

using namespace std;

void Mesh_Create()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* mesh = FbxMesh::Create(manager, "Mesh");

    // then:
    AssertEqual(0, mesh->GetControlPointsCount());
}

void Mesh_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* mesh = FbxMesh::Create(manager, "Mesh");
    FbxProperty prop;

    // then:
    AssertEqual(6, CountProperties(mesh));
    AssertEqual(0, mesh->GetSrcPropertyCount());
    AssertEqual(0, mesh->GetDstPropertyCount());

    prop = mesh->FindProperty("Color");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->Color.IsValid());
    AssertEqual("Color", mesh->Color.GetName());

    prop = mesh->FindProperty("Primary Visibility");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->PrimaryVisibility.IsValid());
    AssertEqual("Primary Visibility", mesh->PrimaryVisibility.GetName());

    prop = mesh->FindProperty("Casts Shadows");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->CastShadow.IsValid());
    AssertEqual("Casts Shadows", mesh->CastShadow.GetName());

    prop = mesh->FindProperty("Receive Shadows");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->ReceiveShadow.IsValid());
    AssertEqual("Receive Shadows", mesh->ReceiveShadow.GetName());

    prop = mesh->FindProperty("BBoxMin");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->BBoxMin.IsValid());
    AssertEqual("BBoxMin", mesh->BBoxMin.GetName());

    prop = mesh->FindProperty("BBoxMax");
    AssertTrue(prop.IsValid());
    AssertTrue(mesh->BBoxMax.IsValid());
    AssertEqual("BBoxMax", mesh->BBoxMax.GetName());
}

void Mesh_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");

    // then:
    AssertEqual("Geometry::", obj->GetNameSpacePrefix());
}

void MeshTest::RegisterTestCases()
{
    AddTestCase(Mesh_Create);
    AddTestCase(Mesh_Create_HasProperties);
    AddTestCase(Mesh_Create_HasNamespacePrefix);
}

