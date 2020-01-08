
#include "Tests.h"

using namespace std;

void FbxAnimLayer_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimLayer* obj = FbxAnimLayer::Create(manager, "asdf");

    // then:
    AssertEqual("AnimLayer::", obj->GetNameSpacePrefix());
}

void AnimLayerTest::RegisterTestCases()
{
    AddTestCase(FbxAnimLayer_Create_HasNamespacePrefix);
}

