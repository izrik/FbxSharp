
#include "Tests.h"

using namespace std;

void FbxAnimStack_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimStack* obj = FbxAnimStack::Create(manager, "asdf");

    // then:
    AssertEqual("AnimStack::", obj->GetNameSpacePrefix());
}

void AnimStackTest::RegisterTestCases()
{
    AddTestCase(FbxAnimStack_Create_HasNamespacePrefix);
}

