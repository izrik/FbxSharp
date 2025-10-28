
#include "Tests.h"

using namespace std;

void SubDeformer_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxCluster* obj = FbxCluster::Create(manager, "asdf");

    // then:
    AssertEqual("SubDeformer::", obj->GetNameSpacePrefix());;
}

void SubDeformerTest::RegisterTestCases()
{
    AddTestCase(SubDeformer_Create_HasNamespacePrefix);
}

