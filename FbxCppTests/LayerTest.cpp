
#include "Tests.h"

using namespace std;

void Layer_SetVisibility_SetsVisibility()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxLayerContainer* lc = FbxLayerContainer::Create(manager, "");
    lc->CreateLayer();
    FbxLayer* layer = lc->GetLayer(0);
    FbxLayerElementVisibility* lev = FbxLayerElementVisibility::Create(manager, "");

    // require:
    AssertEqual(NULL, layer->GetVisibility());

    // when:
    layer->SetVisibility(lev);

    // then:
    AssertEqual(lev, layer->GetVisibility());
}

void Layer_SetVisibility_ReplacesPreviousVisibilityElement()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxLayerContainer* lc = FbxLayerContainer::Create(manager, "");
    lc->CreateLayer();
    FbxLayer* layer = lc->GetLayer(0);
    FbxLayerElementVisibility* lev1 = FbxLayerElementVisibility::Create(manager, "one");
    FbxLayerElementVisibility* lev2 = FbxLayerElementVisibility::Create(manager, "two");
    layer->SetVisibility(lev1);;

    // require:
    AssertEqual(lev1, layer->GetVisibility());

    // when:
    layer->SetVisibility(lev2);

    // then:
    AssertEqual(lev2, layer->GetVisibility());
}

void LayerTest::RegisterTestCases()
{
    AddTestCase(Layer_SetVisibility_SetsVisibility);
    AddTestCase(Layer_SetVisibility_ReplacesPreviousVisibilityElement);
}

