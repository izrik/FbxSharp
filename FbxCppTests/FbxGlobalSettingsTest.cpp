
#include "Tests.h"

using namespace std;

void FbxGlobalSettings_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGlobalSettings* settings = FbxGlobalSettings::Create(manager, "");
    FbxProperty prop;

    // expect:
    AssertNotNull(settings);
    AssertEqual(0, settings->GetSrcObjectCount());
    AssertEqual(0, settings->GetDstObjectCount());
    AssertEqual(0, settings->GetSrcPropertyCount());
    AssertEqual(0, settings->GetDstPropertyCount());

    AssertEqual(20, CountProperties(settings));

    prop = settings->FindProperty("UpAxis");
    AssertTrue(prop.IsValid());
    AssertEqual("UpAxis", prop.GetName());
    AssertEqual("UpAxis", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxAxisSystem::EUpVector::eXAxis, prop.Get<FbxInt>());

    prop = settings->FindProperty("UpAxisSign");
    AssertTrue(prop.IsValid());
    AssertEqual("UpAxisSign", prop.GetName());
    AssertEqual("UpAxisSign", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(1, prop.Get<FbxInt>());

    prop = settings->FindProperty("FrontAxis");
    AssertTrue(prop.IsValid());
    AssertEqual("FrontAxis", prop.GetName());
    AssertEqual("FrontAxis", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxAxisSystem::EFrontVector::eParityOdd, prop.Get<FbxInt>());

    prop = settings->FindProperty("FrontAxisSign");
    AssertTrue(prop.IsValid());
    AssertEqual("FrontAxisSign", prop.GetName());
    AssertEqual("FrontAxisSign", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(1, prop.Get<FbxInt>());

    prop = settings->FindProperty("CoordAxis");
    AssertTrue(prop.IsValid());
    AssertEqual("CoordAxis", prop.GetName());
    AssertEqual("CoordAxis", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxAxisSystem::ECoordSystem::eRightHanded, prop.Get<FbxInt>());

    prop = settings->FindProperty("CoordAxisSign");
    AssertTrue(prop.IsValid());
    AssertEqual("CoordAxisSign", prop.GetName());
    AssertEqual("CoordAxisSign", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(1, prop.Get<FbxInt>());

    prop = settings->FindProperty("OriginalUpAxis");
    AssertTrue(prop.IsValid());
    AssertEqual("OriginalUpAxis", prop.GetName());
    AssertEqual("OriginalUpAxis", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(-1, prop.Get<FbxInt>());

    prop = settings->FindProperty("OriginalUpAxisSign");
    AssertTrue(prop.IsValid());
    AssertEqual("OriginalUpAxisSign", prop.GetName());
    AssertEqual("OriginalUpAxisSign", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(1, prop.Get<FbxInt>());

    prop = settings->FindProperty("UnitScaleFactor");
    AssertTrue(prop.IsValid());
    AssertEqual("UnitScaleFactor", prop.GetName());
    AssertEqual("UnitScaleFactor", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxDouble, prop.GetPropertyDataType().GetType());
    AssertEqual(1.0d, prop.Get<FbxDouble>());

    prop = settings->FindProperty("OriginalUnitScaleFactor");
    AssertTrue(prop.IsValid());
    AssertEqual("OriginalUnitScaleFactor", prop.GetName());
    AssertEqual("OriginalUnitScaleFactor", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxDouble, prop.GetPropertyDataType().GetType());
    AssertEqual(1.0d, prop.Get<FbxDouble>());

    prop = settings->FindProperty("AmbientColor");
    AssertTrue(prop.IsValid());
    AssertEqual("AmbientColor", prop.GetName());
    AssertEqual("AmbientColor", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxDouble3, prop.GetPropertyDataType().GetType());
    FbxColor color = prop.Get<FbxColor>();
    AssertEqual(0.0d, color.mRed);
    AssertEqual(0.0d, color.mGreen);
    AssertEqual(0.0d, color.mBlue);

    prop = settings->FindProperty("DefaultCamera");
    AssertTrue(prop.IsValid());
    AssertEqual("DefaultCamera", prop.GetName());
    AssertEqual("DefaultCamera", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxString, prop.GetPropertyDataType().GetType());
    AssertEqual("Producer Perspective", prop.Get<FbxString>());

    prop = settings->FindProperty("TimeMode");
    AssertTrue(prop.IsValid());
    AssertEqual("TimeMode", prop.GetName());
    AssertEqual("TimeMode", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxEnum, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxTime::EMode::eDefaultMode, prop.Get<FbxInt>());

    prop = settings->FindProperty("TimeProtocol");
    AssertTrue(prop.IsValid());
    AssertEqual("TimeProtocol", prop.GetName());
    AssertEqual("TimeProtocol", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxEnum, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxTime::EProtocol::eDefaultProtocol, prop.Get<FbxInt>());

    prop = settings->FindProperty("SnapOnFrameMode");
    AssertTrue(prop.IsValid());
    AssertEqual("SnapOnFrameMode", prop.GetName());
    AssertEqual("SnapOnFrameMode", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxEnum, prop.GetPropertyDataType().GetType());
    AssertEqual((int)FbxGlobalSettings::ESnapOnFrameMode::eNoSnap, prop.Get<FbxInt>());

    prop = settings->FindProperty("TimeSpanStart");
    AssertTrue(prop.IsValid());
    AssertEqual("TimeSpanStart", prop.GetName());
    AssertEqual("TimeSpanStart", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxTime, prop.GetPropertyDataType().GetType());
    AssertEqual(FbxTime(0), prop.Get<FbxTime>());

    prop = settings->FindProperty("TimeSpanStop");
    AssertTrue(prop.IsValid());
    AssertEqual("TimeSpanStop", prop.GetName());
    AssertEqual("TimeSpanStop", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxTime, prop.GetPropertyDataType().GetType());
    AssertEqual(FbxTime(141120000L), prop.Get<FbxTime>());

    prop = settings->FindProperty("CustomFrameRate");
    AssertTrue(prop.IsValid());
    AssertEqual("CustomFrameRate", prop.GetName());
    AssertEqual("CustomFrameRate", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxDouble, prop.GetPropertyDataType().GetType());
    AssertEqual(-1.0d, prop.Get<FbxDouble>());

    prop = settings->FindProperty("TimeMarker");
    AssertTrue(prop.IsValid());
    AssertEqual("TimeMarker", prop.GetName());
    AssertEqual("TimeMarker", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxUndefined, prop.GetPropertyDataType().GetType());
    AssertEqual(0.0d, prop.Get<FbxDouble>());

    prop = settings->FindProperty("CurrentTimeMarker");
    AssertTrue(prop.IsValid());
    AssertEqual("CurrentTimeMarker", prop.GetName());
    AssertEqual("CurrentTimeMarker", prop.GetHierarchicalName());
    AssertEqual(EFbxType::eFbxInt, prop.GetPropertyDataType().GetType());
    AssertEqual(-1, prop.Get<FbxInt>());

    AssertEqual(-1, settings->GetOriginalUpAxis());

    FbxAxisSystem a = settings->GetAxisSystem();
    int sign = 0;
    AssertEqual(FbxAxisSystem::EUpVector::eYAxis, a.GetUpVector(sign));
    AssertEqual(1, sign);
    AssertEqual(FbxAxisSystem::EFrontVector::eParityOdd, a.GetFrontVector(sign));
    AssertEqual(1, sign);
    AssertEqual(FbxAxisSystem::ECoordSystem::eRightHanded, a.GetCoorSystem( ));

    FbxSystemUnit su = settings->GetSystemUnit();
    AssertEqual(1.0d, su.GetMultiplier());
    AssertEqual("cm", su.GetScaleFactorAsString());
    AssertEqual("Centimeters", su.GetScaleFactorAsString_Plurial());
    AssertTrue(FbxSystemUnit::cm == su);

    su = settings->GetOriginalSystemUnit();
    AssertEqual(1.0d, su.GetMultiplier());
    AssertEqual("cm", su.GetScaleFactorAsString());
    AssertEqual("Centimeters", su.GetScaleFactorAsString_Plurial());
    AssertTrue(FbxSystemUnit::cm == su);

    color = settings->GetAmbientColor();
    AssertEqual(0.0d, color.mRed);
    AssertEqual(0.0d, color.mGreen);
    AssertEqual(0.0d, color.mBlue);

    AssertEqual("Producer Perspective", settings->GetDefaultCamera());

    AssertEqual(FbxTime::EMode::eFrames30, settings->GetTimeMode());
    AssertEqual(FbxTime::EProtocol::eFrameCount, settings->GetTimeProtocol());
    AssertEqual(FbxGlobalSettings::ESnapOnFrameMode::eNoSnap, settings->GetSnapOnFrameMode());
    FbxTimeSpan ts;
    settings->GetTimelineDefaultTimeSpan(ts);
    AssertEqual(0L, ts.GetStart().Get());
    AssertEqual(141120000L, ts.GetStop().Get());
    AssertEqual(141120000L, ts.GetDuration().Get());
    AssertEqual(-1.0d, settings->GetCustomFrameRate());

    AssertEqual(0, settings->GetTimeMarkerCount());
    AssertEqual(-1, settings->GetCurrentTimeMarker());
}

void FbxGlobalSettings_SetTimeMode_DifferentFromProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGlobalSettings* settings = FbxGlobalSettings::Create(manager, "");
    FbxProperty prop;
    prop = settings->FindProperty("TimeMode");

    // expect:
    AssertEqual((int)FbxTime::EMode::eDefaultMode, prop.Get<FbxInt>());
    AssertEqual(FbxTime::EMode::eFrames30, settings->GetTimeMode());

    // when:
    settings->SetTimeMode(FbxTime::EMode::eFrames48);
    // then:
    AssertEqual((int)FbxTime::EMode::eFrames48, prop.Get<FbxInt>());
    AssertEqual(FbxTime::EMode::eFrames48, settings->GetTimeMode());

    // when:
    settings->SetTimeMode(FbxTime::EMode::eFrames30);
    // then:
    AssertEqual((int)FbxTime::EMode::eFrames30, prop.Get<FbxInt>());
    AssertEqual(FbxTime::EMode::eFrames30, settings->GetTimeMode());

    // when:
    settings->SetTimeMode(FbxTime::EMode::eDefaultMode);
    // then:
    AssertEqual((int)FbxTime::EMode::eDefaultMode, prop.Get<FbxInt>());
    AssertEqual(FbxTime::EMode::eFrames30, settings->GetTimeMode());
}

void FbxGlobalSettingsTest::RegisterTestCases()
{
    AddTestCase(FbxGlobalSettings_Create_HasDefaults);
    AddTestCase(FbxGlobalSettings_SetTimeMode_DifferentFromProperty);
}

