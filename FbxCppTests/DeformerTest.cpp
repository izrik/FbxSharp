
#include "Tests.h"

using namespace std;

void Deformer_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSkin* obj = FbxSkin::Create(manager, "asdf");

    // then:
    AssertEqual("Deformer::", obj->GetNameSpacePrefix());;
}

void DeformerTest::RegisterTestCases()
{
    AddTestCase(Deformer_Create_HasNamespacePrefix);
}

