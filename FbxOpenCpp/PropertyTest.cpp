
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

void PropertyTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_FindProperty_FindsProperty);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsSrcObject);
    AddTestCase(SurfacePhongDiffuseColor_ConnectSrcObject_ConnectsDstProperty);
}

