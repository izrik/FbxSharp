
#include "Tests.h"

using namespace std;

void Light_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxLight* light = FbxLight::Create(manager, "light");
    FbxProperty prop;

    // then:
    AssertEqual(27, CountProperties(light));
    AssertEqual(0, light->GetSrcPropertyCount());
    AssertEqual(0, light->GetDstPropertyCount());

    prop = light->FindProperty("LightType");
    AssertTrue(prop.IsValid());
    AssertTrue(light->LightType.IsValid());
    AssertEqual("LightType", light->LightType.GetName());

    prop = light->FindProperty("CastLightOnObject");
    AssertTrue(prop.IsValid());
    AssertTrue(light->CastLight.IsValid());
    AssertEqual("CastLightOnObject", light->CastLight.GetName());

    prop = light->FindProperty("DrawVolumetricLight");
    AssertTrue(prop.IsValid());
    AssertTrue(light->DrawVolumetricLight.IsValid());
    AssertEqual("DrawVolumetricLight", light->DrawVolumetricLight.GetName());

    prop = light->FindProperty("DrawGroundProjection");
    AssertTrue(prop.IsValid());
    AssertTrue(light->DrawGroundProjection.IsValid());
    AssertEqual("DrawGroundProjection", light->DrawGroundProjection.GetName());

    prop = light->FindProperty("DrawFrontFacingVolumetricLight");
    AssertTrue(prop.IsValid());
    AssertTrue(light->DrawFrontFacingVolumetricLight.IsValid());
    AssertEqual("DrawFrontFacingVolumetricLight", light->DrawFrontFacingVolumetricLight.GetName());

    prop = light->FindProperty("Color");
    AssertTrue(prop.IsValid());
    AssertTrue(light->Color.IsValid());
    AssertEqual("Color", light->Color.GetName());

    prop = light->FindProperty("Intensity");
    AssertTrue(prop.IsValid());
    AssertTrue(light->Intensity.IsValid());
    AssertEqual("Intensity", light->Intensity.GetName());

    prop = light->FindProperty("InnerAngle");
    AssertTrue(prop.IsValid());
    AssertTrue(light->InnerAngle.IsValid());
    AssertEqual("InnerAngle", light->InnerAngle.GetName());

    prop = light->FindProperty("OuterAngle");
    AssertTrue(prop.IsValid());
    AssertTrue(light->OuterAngle.IsValid());
    AssertEqual("OuterAngle", light->OuterAngle.GetName());

    prop = light->FindProperty("Fog");
    AssertTrue(prop.IsValid());
    AssertTrue(light->Fog.IsValid());
    AssertEqual("Fog", light->Fog.GetName());

    prop = light->FindProperty("DecayType");
    AssertTrue(prop.IsValid());
    AssertTrue(light->DecayType.IsValid());
    AssertEqual("DecayType", light->DecayType.GetName());

    prop = light->FindProperty("DecayStart");
    AssertTrue(prop.IsValid());
    AssertTrue(light->DecayStart.IsValid());
    AssertEqual("DecayStart", light->DecayStart.GetName());

    prop = light->FindProperty("FileName");
    AssertTrue(prop.IsValid());
    AssertTrue(light->FileName.IsValid());
    AssertEqual("FileName", light->FileName.GetName());

    prop = light->FindProperty("EnableNearAttenuation");
    AssertTrue(prop.IsValid());
    AssertTrue(light->EnableNearAttenuation.IsValid());
    AssertEqual("EnableNearAttenuation", light->EnableNearAttenuation.GetName());

    prop = light->FindProperty("NearAttenuationStart");
    AssertTrue(prop.IsValid());
    AssertTrue(light->NearAttenuationStart.IsValid());
    AssertEqual("NearAttenuationStart", light->NearAttenuationStart.GetName());

    prop = light->FindProperty("NearAttenuationEnd");
    AssertTrue(prop.IsValid());
    AssertTrue(light->NearAttenuationEnd.IsValid());
    AssertEqual("NearAttenuationEnd", light->NearAttenuationEnd.GetName());

    prop = light->FindProperty("EnableFarAttenuation");
    AssertTrue(prop.IsValid());
    AssertTrue(light->EnableFarAttenuation.IsValid());
    AssertEqual("EnableFarAttenuation", light->EnableFarAttenuation.GetName());

    prop = light->FindProperty("FarAttenuationStart");
    AssertTrue(prop.IsValid());
    AssertTrue(light->FarAttenuationStart.IsValid());
    AssertEqual("FarAttenuationStart", light->FarAttenuationStart.GetName());

    prop = light->FindProperty("FarAttenuationEnd");
    AssertTrue(prop.IsValid());
    AssertTrue(light->FarAttenuationEnd.IsValid());
    AssertEqual("FarAttenuationEnd", light->FarAttenuationEnd.GetName());

    prop = light->FindProperty("CastShadows");
    AssertTrue(prop.IsValid());
    AssertTrue(light->CastShadows.IsValid());
    AssertEqual("CastShadows", light->CastShadows.GetName());

    prop = light->FindProperty("ShadowColor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->ShadowColor.IsValid());
    AssertEqual("ShadowColor", light->ShadowColor.GetName());

    prop = light->FindProperty("AreaLightShape");
    AssertTrue(prop.IsValid());
    AssertTrue(light->AreaLightShape.IsValid());
    AssertEqual("AreaLightShape", light->AreaLightShape.GetName());

    prop = light->FindProperty("LeftBarnDoor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->LeftBarnDoor.IsValid());
    AssertEqual("LeftBarnDoor", light->LeftBarnDoor.GetName());

    prop = light->FindProperty("RightBarnDoor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->RightBarnDoor.IsValid());
    AssertEqual("RightBarnDoor", light->RightBarnDoor.GetName());

    prop = light->FindProperty("TopBarnDoor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->TopBarnDoor.IsValid());
    AssertEqual("TopBarnDoor", light->TopBarnDoor.GetName());

    prop = light->FindProperty("BottomBarnDoor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->BottomBarnDoor.IsValid());
    AssertEqual("BottomBarnDoor", light->BottomBarnDoor.GetName());

    prop = light->FindProperty("EnableBarnDoor");
    AssertTrue(prop.IsValid());
    AssertTrue(light->EnableBarnDoor.IsValid());
    AssertEqual("EnableBarnDoor", light->EnableBarnDoor.GetName());
}

void Light_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxLight* obj = FbxLight::Create(manager, "asdf");

    // then:
    AssertEqual("NodeAttribute::", obj->GetNameSpacePrefix());
}

void LightTest::RegisterTestCases()
{
    AddTestCase(Light_Create_HasProperties);
    AddTestCase(Light_Create_HasNamespacePrefix);
}

