
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

void MeshTest::RegisterTestCases()
{
    AddTestCase(Mesh_Create);
}

