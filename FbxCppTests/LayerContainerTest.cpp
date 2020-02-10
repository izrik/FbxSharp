
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

void LayerContainer_CreateLayer_CreatesNewLayer()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxLayerContainer* lc = FbxLayerContainer::Create(manager, "");

    // require:
    AssertEqual(NULL, lc->GetLayer(0));

    // when:
    int result = lc->CreateLayer();

    // then:
    AssertEqual(0, result);
    AssertNotEqual(NULL, lc->GetLayer(0));
}

void LayerContainerTest::RegisterTestCases()
{
    AddTestCase(LayerContainer_Create);
    AddTestCase(LayerContainer_CreateLayer_CreatesNewLayer);
}

