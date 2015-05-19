
#include "Tests.h"

using namespace std;

void LayerContainer_Create()
{
    // given:
    FbxManager* manager = FbxManager::Create();

    // when:
    FbxLayerContainer* lc = FbxLayerContainer::Create(manager, "");

    // then:
    AssertEqual(0, lc->GetSrcObjectCount());
    AssertEqual(0, lc->GetDstObjectCount());
    AssertEqual(0, lc->GetLayerCount());
}

void LayerContainerTest::RegisterTestCases()
{
    AddTestCase(LayerContainer_Create);
}

