
#include "common.h"

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

    // then:
    AssertEqual(6, CountProperties(mesh));
    AssertEqual(0, mesh->GetSrcPropertyCount());
    AssertEqual(0, mesh->GetDstPropertyCount());
}

void MeshTest::RegisterTestCases()
{
    AddTestCase(Mesh_Create);
    AddTestCase(Mesh_Create_HasProperties);
}

