
#include "Tests.h"

using namespace std;

void SurfacePhong_FindProperty_FindsProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surf = FbxSurfacePhong::Create(manager, "");

    // when:
    FbxProperty prop = surf->FindProperty("SpecularColor");

    // then:
    AssertTrue(prop.IsValid());
}

void SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsSrcObject()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surf = FbxSurfacePhong::Create(manager, "");
    FbxTexture* tex = FbxTexture::Create(manager, "");

    // when:
    bool result = surf->Diffuse.ConnectSrcObject(tex);

    // then:
    AssertTrue(result);
    AssertEqual(1, surf->Diffuse.GetSrcObjectCount());
    FbxObject* obj = surf->Diffuse.GetSrcObject(0);
    AssertNotNull(obj);
    AssertEqual(tex, obj);
}

void SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsDstProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surf = FbxSurfacePhong::Create(manager, "");
    FbxTexture* tex = FbxTexture::Create(manager, "");

    // when:
    bool result = surf->Diffuse.ConnectSrcObject(tex);

    // then:
    AssertTrue(result);
    AssertEqual(1, tex->GetDstPropertyCount());
    FbxProperty prop = tex->GetDstProperty(0);
    AssertTrue(prop.IsValid());
    AssertEqual("DiffuseColor", prop.GetName());
}

void Property_AttachCurveNode_IsAnimated()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxAnimCurveNode* acn = FbxAnimCurveNode::Create(manager, "acn");
    FbxAnimCurve* x = FbxAnimCurve::Create(manager, "x");
    FbxScene* scene = FbxScene::Create(manager, "scene");
    FbxAnimLayer* layer = FbxAnimLayer::Create(manager, "layer");
    FbxAnimStack* stack = FbxAnimStack::Create(manager, "stack");

    FbxTime time = FbxTime(0);
    FbxAnimCurveKey key = FbxAnimCurveKey(time, 1.0f);
    x->KeyAdd(time, key);

    scene->ConnectSrcObject(node);
    scene->ConnectSrcObject(acn);
    scene->ConnectSrcObject(x);
    scene->ConnectSrcObject(layer);
    scene->ConnectSrcObject(stack);

    layer->ConnectSrcObject(acn);

    stack->ConnectSrcObject(layer);

    acn->AddChannel<double>("x", 1.0);
    acn->ConnectToChannel(x, 0U);

    // require:
    AssertFalse(node->LclTranslation.IsAnimated());

    // when:
    node->LclTranslation.ConnectSrcObject(acn);

    // then:
    AssertTrue(node->LclTranslation.IsAnimated());
}

void FbxProperty_HierarchicalSeparator()
{
    // require:
    AssertEqual("|", FbxProperty::sHierarchicalSeparator);
}

void Property_MultipleStacks_IsAnimatedOnlyWhenTheCorrectStackIsCurrent()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxScene* scene = FbxScene::Create(manager, "scene");

    FbxAnimCurveNode* acn1 = FbxAnimCurveNode::Create(manager, "acn1");
    FbxAnimCurve* ac1 = FbxAnimCurve::Create(manager, "ac1");
    FbxAnimLayer* layer1 = FbxAnimLayer::Create(manager, "layer1");
    FbxAnimStack* stack1 = FbxAnimStack::Create(manager, "stack1");

    FbxAnimCurveNode* acn2 = FbxAnimCurveNode::Create(manager, "acn2");
    FbxAnimCurve* ac2 = FbxAnimCurve::Create(manager, "ac2");
    FbxAnimLayer* layer2 = FbxAnimLayer::Create(manager, "layer2");
    FbxAnimStack* stack2 = FbxAnimStack::Create(manager, "stack2");

    FbxTime time = FbxTime(0);
    FbxAnimCurveKey key = FbxAnimCurveKey(time, 1.0f);
    ac1->KeyAdd(time, key);

    FbxTime time2 = FbxTime(0);
    FbxAnimCurveKey key2 = FbxAnimCurveKey(time2, 1.0f);
    ac2->KeyAdd(time2, key2);

    scene->ConnectSrcObject(node);
    scene->ConnectSrcObject(acn1);
    scene->ConnectSrcObject(ac1);
    scene->ConnectSrcObject(layer1);
    scene->ConnectSrcObject(stack1);
    scene->ConnectSrcObject(acn2);
    scene->ConnectSrcObject(ac2);
    scene->ConnectSrcObject(layer2);
    scene->ConnectSrcObject(stack2);

    acn1->AddChannel<double>("x", 1.0);
    acn1->ConnectToChannel(ac1, 0U);
    layer1->ConnectSrcObject(acn1);
    stack1->ConnectSrcObject(layer1);

    acn2->AddChannel<double>("y", -1.0);
    acn2->ConnectToChannel(ac2, 0U);
    layer2->ConnectSrcObject(acn2);
    stack2->ConnectSrcObject(layer2);

    scene->SetCurrentAnimationStack(stack1);

    node->LclTranslation.ConnectSrcObject(acn1);
    node->LclRotation.ConnectSrcObject(acn2);

    // require:
    AssertEqual(scene->GetCurrentAnimationStack(), stack1);
    AssertTrue(node->LclTranslation.IsAnimated());
    AssertFalse(node->LclRotation.IsAnimated());

    // when:
    scene->SetCurrentAnimationStack(stack2);

    // then:
    AssertFalse(node->LclTranslation.IsAnimated());
    AssertTrue(node->LclRotation.IsAnimated());
}

void Property_MultipleStacks_GetCurveNodeOnlyGetsCurvesOnTheCurrentStack()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxScene* scene = FbxScene::Create(manager, "scene");

    FbxAnimCurveNode* acn1 = FbxAnimCurveNode::Create(manager, "acn1");
    FbxAnimCurve* ac1 = FbxAnimCurve::Create(manager, "ac1");
    FbxAnimLayer* layer1 = FbxAnimLayer::Create(manager, "layer1");
    FbxAnimStack* stack1 = FbxAnimStack::Create(manager, "stack1");

    FbxAnimCurveNode* acn2 = FbxAnimCurveNode::Create(manager, "acn2");
    FbxAnimCurve* ac2 = FbxAnimCurve::Create(manager, "ac2");
    FbxAnimLayer* layer2 = FbxAnimLayer::Create(manager, "layer2");
    FbxAnimStack* stack2 = FbxAnimStack::Create(manager, "stack2");

    FbxTime time = FbxTime(0);
    FbxAnimCurveKey key = FbxAnimCurveKey(time, 1.0f);
    ac1->KeyAdd(time, key);

    FbxTime time2 = FbxTime(0);
    FbxAnimCurveKey key2 = FbxAnimCurveKey(time2, 1.0f);
    ac2->KeyAdd(time2, key2);

    scene->ConnectSrcObject(node);
    scene->ConnectSrcObject(acn1);
    scene->ConnectSrcObject(ac1);
    scene->ConnectSrcObject(layer1);
    scene->ConnectSrcObject(stack1);
    scene->ConnectSrcObject(acn2);
    scene->ConnectSrcObject(ac2);
    scene->ConnectSrcObject(layer2);
    scene->ConnectSrcObject(stack2);

    acn1->AddChannel<double>("x", 1.0);
    acn1->ConnectToChannel(ac1, 0U);
    layer1->ConnectSrcObject(acn1);
    stack1->ConnectSrcObject(layer1);

    acn2->AddChannel<double>("y", -1.0);
    acn2->ConnectToChannel(ac2, 0U);
    layer2->ConnectSrcObject(acn2);
    stack2->ConnectSrcObject(layer2);

    scene->SetCurrentAnimationStack(stack1);

    node->LclTranslation.ConnectSrcObject(acn1);
    node->LclRotation.ConnectSrcObject(acn2);

    // require:
    AssertEqual(stack1, scene->GetCurrentAnimationStack());
    AssertEqual(acn1, node->LclTranslation.GetCurveNode());
    AssertNull(node->LclRotation.GetCurveNode());

    // when:
    scene->SetCurrentAnimationStack(stack2);

    // then:
    AssertNull(node->LclTranslation.GetCurveNode());
    AssertEqual(acn2, node->LclRotation.GetCurveNode());
}

void PropertyTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_FindProperty_FindsProperty);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsSrcObject);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsDstProperty);
    AddTestCase(Property_AttachCurveNode_IsAnimated);
    AddTestCase(FbxProperty_HierarchicalSeparator);
    AddTestCase(Property_MultipleStacks_IsAnimatedOnlyWhenTheCorrectStackIsCurrent);
    AddTestCase(Property_MultipleStacks_GetCurveNodeOnlyGetsCurvesOnTheCurrentStack);
}

