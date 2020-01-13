
#include "Tests.h"

using namespace std;

void SurfacePhong_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surface = FbxSurfacePhong::Create(manager, "");
    FbxProperty prop;

    // then:
    AssertEqual(22, CountProperties(surface));
    AssertEqual(0, surface->GetSrcPropertyCount());
    AssertEqual(0, surface->GetDstPropertyCount());

    prop = surface->FindProperty("ShadingModel");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->ShadingModel.IsValid());
    AssertEqual("ShadingModel", surface->ShadingModel.GetName());

    prop = surface->FindProperty("MultiLayer");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->MultiLayer.IsValid());
    AssertEqual("MultiLayer", surface->MultiLayer.GetName());

    prop = surface->FindProperty("EmissiveColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Emissive.IsValid());
    AssertEqual("EmissiveColor", surface->Emissive.GetName());

    prop = surface->FindProperty("EmissiveFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->EmissiveFactor.IsValid());
    AssertEqual("EmissiveFactor", surface->EmissiveFactor.GetName());

    prop = surface->FindProperty("AmbientColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Ambient.IsValid());
    AssertEqual("AmbientColor", surface->Ambient.GetName());

    prop = surface->FindProperty("AmbientFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->AmbientFactor.IsValid());
    AssertEqual("AmbientFactor", surface->AmbientFactor.GetName());

    prop = surface->FindProperty("DiffuseColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Diffuse.IsValid());
    AssertEqual("DiffuseColor", surface->Diffuse.GetName());

    prop = surface->FindProperty("DiffuseFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->DiffuseFactor.IsValid());
    AssertEqual("DiffuseFactor", surface->DiffuseFactor.GetName());

    prop = surface->FindProperty("Bump");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Bump.IsValid());
    AssertEqual("Bump", surface->Bump.GetName());

    prop = surface->FindProperty("NormalMap");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->NormalMap.IsValid());
    AssertEqual("NormalMap", surface->NormalMap.GetName());

    prop = surface->FindProperty("BumpFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->BumpFactor.IsValid());
    AssertEqual("BumpFactor", surface->BumpFactor.GetName());

    prop = surface->FindProperty("TransparentColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->TransparentColor.IsValid());
    AssertEqual("TransparentColor", surface->TransparentColor.GetName());

    prop = surface->FindProperty("TransparencyFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->TransparencyFactor.IsValid());
    AssertEqual("TransparencyFactor", surface->TransparencyFactor.GetName());

    prop = surface->FindProperty("DisplacementColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->DisplacementColor.IsValid());
    AssertEqual("DisplacementColor", surface->DisplacementColor.GetName());

    prop = surface->FindProperty("DisplacementFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->DisplacementFactor.IsValid());
    AssertEqual("DisplacementFactor", surface->DisplacementFactor.GetName());

    prop = surface->FindProperty("VectorDisplacementColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->VectorDisplacementColor.IsValid());
    AssertEqual("VectorDisplacementColor", surface->VectorDisplacementColor.GetName());

    prop = surface->FindProperty("VectorDisplacementFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->VectorDisplacementFactor.IsValid());
    AssertEqual("VectorDisplacementFactor", surface->VectorDisplacementFactor.GetName());

    prop = surface->FindProperty("SpecularColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Specular.IsValid());
    AssertEqual("SpecularColor", surface->Specular.GetName());

    prop = surface->FindProperty("SpecularFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->SpecularFactor.IsValid());
    AssertEqual("SpecularFactor", surface->SpecularFactor.GetName());

    prop = surface->FindProperty("ShininessExponent");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Shininess.IsValid());
    AssertEqual("ShininessExponent", surface->Shininess.GetName());

    prop = surface->FindProperty("ReflectionColor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->Reflection.IsValid());
    AssertEqual("ReflectionColor", surface->Reflection.GetName());

    prop = surface->FindProperty("ReflectionFactor");
    AssertTrue(prop.IsValid());
    AssertTrue(surface->ReflectionFactor.IsValid());
    AssertEqual("ReflectionFactor", surface->ReflectionFactor.GetName());
}

void SurfacePhong_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxSurfacePhong* surface = FbxSurfacePhong::Create(manager, "asdf");

    // then:
    AssertEqual("Material::", surface->GetNameSpacePrefix());
}

void SurfacePhongTest::RegisterTestCases()
{
    AddTestCase(SurfacePhong_Create_HasProperties);
    AddTestCase(SurfacePhong_Create_HasNamespacePrefix);
}

