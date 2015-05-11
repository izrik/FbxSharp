
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

void PropertyTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_FindProperty_FindsProperty);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsSrcObject);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsDstProperty);
    AddTestCase(Property_AttachCurveNode_IsAnimated);
}

