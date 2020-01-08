
#include "Tests.h"

using namespace std;

void Camera_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxCamera* camera = FbxCamera::Create(manager, "camera");
    FbxProperty prop;

    // then:
    AssertEqual(106, CountProperties(camera));
    AssertEqual(0, camera->GetSrcPropertyCount());
    AssertEqual(0, camera->GetDstPropertyCount());

    prop = camera->FindProperty("Color");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->Color.IsValid());
    AssertEqual("Color", camera->Color.GetName());

    prop = camera->FindProperty("Position");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->Position.IsValid());
    AssertEqual("Position", camera->Position.GetName());

    prop = camera->FindProperty("UpVector");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UpVector.IsValid());
    AssertEqual("UpVector", camera->UpVector.GetName());

    prop = camera->FindProperty("InterestPosition");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->InterestPosition.IsValid());
    AssertEqual("InterestPosition", camera->InterestPosition.GetName());

    prop = camera->FindProperty("Roll");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->Roll.IsValid());
    AssertEqual("Roll", camera->Roll.GetName());

    prop = camera->FindProperty("OpticalCenterX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->OpticalCenterX.IsValid());
    AssertEqual("OpticalCenterX", camera->OpticalCenterX.GetName());

    prop = camera->FindProperty("OpticalCenterY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->OpticalCenterY.IsValid());
    AssertEqual("OpticalCenterY", camera->OpticalCenterY.GetName());

    prop = camera->FindProperty("BackgroundColor");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackgroundColor.IsValid());
    AssertEqual("BackgroundColor", camera->BackgroundColor.GetName());

    prop = camera->FindProperty("TurnTable");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->TurnTable.IsValid());
    AssertEqual("TurnTable", camera->TurnTable.GetName());

    prop = camera->FindProperty("DisplayTurnTableIcon");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->DisplayTurnTableIcon.IsValid());
    AssertEqual("DisplayTurnTableIcon", camera->DisplayTurnTableIcon.GetName());

    prop = camera->FindProperty("UseMotionBlur");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseMotionBlur.IsValid());
    AssertEqual("UseMotionBlur", camera->UseMotionBlur.GetName());

    prop = camera->FindProperty("UseRealTimeMotionBlur");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseRealTimeMotionBlur.IsValid());
    AssertEqual("UseRealTimeMotionBlur", camera->UseRealTimeMotionBlur.GetName());

    prop = camera->FindProperty("Motion Blur Intensity");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->MotionBlurIntensity.IsValid());
    AssertEqual("Motion Blur Intensity", camera->MotionBlurIntensity.GetName());

    prop = camera->FindProperty("AspectRatioMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AspectRatioMode.IsValid());
    AssertEqual("AspectRatioMode", camera->AspectRatioMode.GetName());

    prop = camera->FindProperty("AspectWidth");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AspectWidth.IsValid());
    AssertEqual("AspectWidth", camera->AspectWidth.GetName());

    prop = camera->FindProperty("AspectHeight");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AspectHeight.IsValid());
    AssertEqual("AspectHeight", camera->AspectHeight.GetName());

    prop = camera->FindProperty("PixelAspectRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->PixelAspectRatio.IsValid());
    AssertEqual("PixelAspectRatio", camera->PixelAspectRatio.GetName());

    prop = camera->FindProperty("ApertureMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ApertureMode.IsValid());
    AssertEqual("ApertureMode", camera->ApertureMode.GetName());

    prop = camera->FindProperty("GateFit");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->GateFit.IsValid());
    AssertEqual("GateFit", camera->GateFit.GetName());

    prop = camera->FindProperty("FieldOfView");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FieldOfView.IsValid());
    AssertEqual("FieldOfView", camera->FieldOfView.GetName());

    prop = camera->FindProperty("FieldOfViewX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FieldOfViewX.IsValid());
    AssertEqual("FieldOfViewX", camera->FieldOfViewX.GetName());

    prop = camera->FindProperty("FieldOfViewY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FieldOfViewY.IsValid());
    AssertEqual("FieldOfViewY", camera->FieldOfViewY.GetName());

    prop = camera->FindProperty("FocalLength");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FocalLength.IsValid());
    AssertEqual("FocalLength", camera->FocalLength.GetName());

    prop = camera->FindProperty("CameraFormat");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->CameraFormat.IsValid());
    AssertEqual("CameraFormat", camera->CameraFormat.GetName());

    prop = camera->FindProperty("UseFrameColor");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseFrameColor.IsValid());
    AssertEqual("UseFrameColor", camera->UseFrameColor.GetName());

    prop = camera->FindProperty("FrameColor");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrameColor.IsValid());
    AssertEqual("FrameColor", camera->FrameColor.GetName());

    prop = camera->FindProperty("ShowName");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowName.IsValid());
    AssertEqual("ShowName", camera->ShowName.GetName());

    prop = camera->FindProperty("ShowInfoOnMoving");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowInfoOnMoving.IsValid());
    AssertEqual("ShowInfoOnMoving", camera->ShowInfoOnMoving.GetName());

    prop = camera->FindProperty("ShowGrid");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowGrid.IsValid());
    AssertEqual("ShowGrid", camera->ShowGrid.GetName());

    prop = camera->FindProperty("ShowOpticalCenter");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowOpticalCenter.IsValid());
    AssertEqual("ShowOpticalCenter", camera->ShowOpticalCenter.GetName());

    prop = camera->FindProperty("ShowAzimut");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowAzimut.IsValid());
    AssertEqual("ShowAzimut", camera->ShowAzimut.GetName());

    prop = camera->FindProperty("ShowTimeCode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowTimeCode.IsValid());
    AssertEqual("ShowTimeCode", camera->ShowTimeCode.GetName());

    prop = camera->FindProperty("ShowAudio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowAudio.IsValid());
    AssertEqual("ShowAudio", camera->ShowAudio.GetName());

    prop = camera->FindProperty("AudioColor");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AudioColor.IsValid());
    AssertEqual("AudioColor", camera->AudioColor.GetName());

    prop = camera->FindProperty("NearPlane");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->NearPlane.IsValid());
    AssertEqual("NearPlane", camera->NearPlane.GetName());

    prop = camera->FindProperty("FarPlane");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FarPlane.IsValid());
    AssertEqual("FarPlane", camera->FarPlane.GetName());

    prop = camera->FindProperty("AutoComputeClipPanes");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AutoComputeClipPlanes.IsValid());
    AssertEqual("AutoComputeClipPanes", camera->AutoComputeClipPlanes.GetName());

    prop = camera->FindProperty("FilmWidth");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmWidth.IsValid());
    AssertEqual("FilmWidth", camera->FilmWidth.GetName());

    prop = camera->FindProperty("FilmHeight");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmHeight.IsValid());
    AssertEqual("FilmHeight", camera->FilmHeight.GetName());

    prop = camera->FindProperty("FilmAspectRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmAspectRatio.IsValid());
    AssertEqual("FilmAspectRatio", camera->FilmAspectRatio.GetName());

    prop = camera->FindProperty("FilmSqueezeRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmSqueezeRatio.IsValid());
    AssertEqual("FilmSqueezeRatio", camera->FilmSqueezeRatio.GetName());

    prop = camera->FindProperty("FilmFormatIndex");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmFormat.IsValid());
    AssertEqual("FilmFormatIndex", camera->FilmFormat.GetName());

    prop = camera->FindProperty("FilmOffsetX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmOffsetX.IsValid());
    AssertEqual("FilmOffsetX", camera->FilmOffsetX.GetName());

    prop = camera->FindProperty("FilmOffsetY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmOffsetY.IsValid());
    AssertEqual("FilmOffsetY", camera->FilmOffsetY.GetName());

    prop = camera->FindProperty("PreScale");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->PreScale.IsValid());
    AssertEqual("PreScale", camera->PreScale.GetName());

    prop = camera->FindProperty("FilmTranslateX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmTranslateX.IsValid());
    AssertEqual("FilmTranslateX", camera->FilmTranslateX.GetName());

    prop = camera->FindProperty("FilmTranslateY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmTranslateY.IsValid());
    AssertEqual("FilmTranslateY", camera->FilmTranslateY.GetName());

    prop = camera->FindProperty("FilmRollPivotX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmRollPivotX.IsValid());
    AssertEqual("FilmRollPivotX", camera->FilmRollPivotX.GetName());

    prop = camera->FindProperty("FilmRollPivotY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmRollPivotY.IsValid());
    AssertEqual("FilmRollPivotY", camera->FilmRollPivotY.GetName());

    prop = camera->FindProperty("FilmRollValue");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmRollValue.IsValid());
    AssertEqual("FilmRollValue", camera->FilmRollValue.GetName());

    prop = camera->FindProperty("FilmRollOrder");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FilmRollOrder.IsValid());
    AssertEqual("FilmRollOrder", camera->FilmRollOrder.GetName());

    prop = camera->FindProperty("ViewCameraToLookAt");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ViewCameraToLookAt.IsValid());
    AssertEqual("ViewCameraToLookAt", camera->ViewCameraToLookAt.GetName());

    prop = camera->FindProperty("ViewFrustumNearFarPlane");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ViewFrustumNearFarPlane.IsValid());
    AssertEqual("ViewFrustumNearFarPlane", camera->ViewFrustumNearFarPlane.GetName());

    prop = camera->FindProperty("ViewFrustumBackPlaneMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ViewFrustumBackPlaneMode.IsValid());
    AssertEqual("ViewFrustumBackPlaneMode", camera->ViewFrustumBackPlaneMode.GetName());

    prop = camera->FindProperty("BackPlaneDistance");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneDistance.IsValid());
    AssertEqual("BackPlaneDistance", camera->BackPlaneDistance.GetName());

    prop = camera->FindProperty("BackPlaneDistanceMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneDistanceMode.IsValid());
    AssertEqual("BackPlaneDistanceMode", camera->BackPlaneDistanceMode.GetName());

    prop = camera->FindProperty("ViewFrustumFrontPlaneMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ViewFrustumFrontPlaneMode.IsValid());
    AssertEqual("ViewFrustumFrontPlaneMode", camera->ViewFrustumFrontPlaneMode.GetName());

    prop = camera->FindProperty("FrontPlaneDistance");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneDistance.IsValid());
    AssertEqual("FrontPlaneDistance", camera->FrontPlaneDistance.GetName());

    prop = camera->FindProperty("FrontPlaneDistanceMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneDistanceMode.IsValid());
    AssertEqual("FrontPlaneDistanceMode", camera->FrontPlaneDistanceMode.GetName());

    prop = camera->FindProperty("LockMode");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->LockMode.IsValid());
    AssertEqual("LockMode", camera->LockMode.GetName());

    prop = camera->FindProperty("LockInterestNavigation");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->LockInterestNavigation.IsValid());
    AssertEqual("LockInterestNavigation", camera->LockInterestNavigation.GetName());

    prop = camera->FindProperty("BackPlateFitImage");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlateFitImage.IsValid());
    AssertEqual("BackPlateFitImage", camera->BackPlateFitImage.GetName());

    prop = camera->FindProperty("BackPlateCrop");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlateCrop.IsValid());
    AssertEqual("BackPlateCrop", camera->BackPlateCrop.GetName());

    prop = camera->FindProperty("BackPlateCenter");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlateCenter.IsValid());
    AssertEqual("BackPlateCenter", camera->BackPlateCenter.GetName());

    prop = camera->FindProperty("BackPlateKeepRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlateKeepRatio.IsValid());
    AssertEqual("BackPlateKeepRatio", camera->BackPlateKeepRatio.GetName());

    prop = camera->FindProperty("BackgroundAlphaTreshold");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackgroundAlphaTreshold.IsValid());
    AssertEqual("BackgroundAlphaTreshold", camera->BackgroundAlphaTreshold.GetName());

    prop = camera->FindProperty("BackPlaneOffsetX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneOffsetX.IsValid());
    AssertEqual("BackPlaneOffsetX", camera->BackPlaneOffsetX.GetName());

    prop = camera->FindProperty("BackPlaneOffsetY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneOffsetY.IsValid());
    AssertEqual("BackPlaneOffsetY", camera->BackPlaneOffsetY.GetName());

    prop = camera->FindProperty("BackPlaneRotation");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneRotation.IsValid());
    AssertEqual("BackPlaneRotation", camera->BackPlaneRotation.GetName());

    prop = camera->FindProperty("BackPlaneScaleX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneScaleX.IsValid());
    AssertEqual("BackPlaneScaleX", camera->BackPlaneScaleX.GetName());

    prop = camera->FindProperty("BackPlaneScaleY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackPlaneScaleY.IsValid());
    AssertEqual("BackPlaneScaleY", camera->BackPlaneScaleY.GetName());

    prop = camera->FindProperty("ShowBackplate");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowBackplate.IsValid());
    AssertEqual("ShowBackplate", camera->ShowBackplate.GetName());

    prop = camera->FindProperty("Background Texture");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->BackgroundTexture.IsValid());
    AssertEqual("Background Texture", camera->BackgroundTexture.GetName());

    prop = camera->FindProperty("FrontPlateFitImage");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlateFitImage.IsValid());
    AssertEqual("FrontPlateFitImage", camera->FrontPlateFitImage.GetName());

    prop = camera->FindProperty("FrontPlateCrop");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlateCrop.IsValid());
    AssertEqual("FrontPlateCrop", camera->FrontPlateCrop.GetName());

    prop = camera->FindProperty("FrontPlateCenter");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlateCenter.IsValid());
    AssertEqual("FrontPlateCenter", camera->FrontPlateCenter.GetName());

    prop = camera->FindProperty("FrontPlateKeepRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlateKeepRatio.IsValid());
    AssertEqual("FrontPlateKeepRatio", camera->FrontPlateKeepRatio.GetName());

    prop = camera->FindProperty("ShowFrontplate");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ShowFrontplate.IsValid());
    AssertEqual("ShowFrontplate", camera->ShowFrontplate.GetName());

    prop = camera->FindProperty("FrontPlaneOffsetX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneOffsetX.IsValid());
    AssertEqual("FrontPlaneOffsetX", camera->FrontPlaneOffsetX.GetName());

    prop = camera->FindProperty("FrontPlaneOffsetY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneOffsetY.IsValid());
    AssertEqual("FrontPlaneOffsetY", camera->FrontPlaneOffsetY.GetName());

    prop = camera->FindProperty("FrontPlaneRotation");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneRotation.IsValid());
    AssertEqual("FrontPlaneRotation", camera->FrontPlaneRotation.GetName());

    prop = camera->FindProperty("FrontPlaneScaleX");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneScaleX.IsValid());
    AssertEqual("FrontPlaneScaleX", camera->FrontPlaneScaleX.GetName());

    prop = camera->FindProperty("FrontPlaneScaleY");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrontPlaneScaleY.IsValid());
    AssertEqual("FrontPlaneScaleY", camera->FrontPlaneScaleY.GetName());

    prop = camera->FindProperty("Foreground Texture");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ForegroundTexture.IsValid());
    AssertEqual("Foreground Texture", camera->ForegroundTexture.GetName());

    prop = camera->FindProperty("Foreground Opacity");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ForegroundOpacity.IsValid());
    AssertEqual("Foreground Opacity", camera->ForegroundOpacity.GetName());

    prop = camera->FindProperty("DisplaySafeArea");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->DisplaySafeArea.IsValid());
    AssertEqual("DisplaySafeArea", camera->DisplaySafeArea.GetName());

    prop = camera->FindProperty("DisplaySafeAreaOnRender");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->DisplaySafeAreaOnRender.IsValid());
    AssertEqual("DisplaySafeAreaOnRender", camera->DisplaySafeAreaOnRender.GetName());

    prop = camera->FindProperty("SafeAreaDisplayStyle");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->SafeAreaDisplayStyle.IsValid());
    AssertEqual("SafeAreaDisplayStyle", camera->SafeAreaDisplayStyle.GetName());

    prop = camera->FindProperty("SafeAreaAspectRatio");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->SafeAreaAspectRatio.IsValid());
    AssertEqual("SafeAreaAspectRatio", camera->SafeAreaAspectRatio.GetName());

    prop = camera->FindProperty("Use2DMagnifierZoom");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->Use2DMagnifierZoom.IsValid());
    AssertEqual("Use2DMagnifierZoom", camera->Use2DMagnifierZoom.GetName());

    prop = camera->FindProperty("2D Magnifier Zoom");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->_2DMagnifierZoom.IsValid());
    AssertEqual("2D Magnifier Zoom", camera->_2DMagnifierZoom.GetName());

    prop = camera->FindProperty("2D Magnifier X");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->_2DMagnifierX.IsValid());
    AssertEqual("2D Magnifier X", camera->_2DMagnifierX.GetName());

    prop = camera->FindProperty("2D Magnifier Y");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->_2DMagnifierY.IsValid());
    AssertEqual("2D Magnifier Y", camera->_2DMagnifierY.GetName());

    prop = camera->FindProperty("CameraProjectionType");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->ProjectionType.IsValid());
    AssertEqual("CameraProjectionType", camera->ProjectionType.GetName());

    prop = camera->FindProperty("OrthoZoom");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->OrthoZoom.IsValid());
    AssertEqual("OrthoZoom", camera->OrthoZoom.GetName());

    prop = camera->FindProperty("UseRealTimeDOFAndAA");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseRealTimeDOFAndAA.IsValid());
    AssertEqual("UseRealTimeDOFAndAA", camera->UseRealTimeDOFAndAA.GetName());

    prop = camera->FindProperty("UseDepthOfField");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseDepthOfField.IsValid());
    AssertEqual("UseDepthOfField", camera->UseDepthOfField.GetName());

    prop = camera->FindProperty("FocusSource");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FocusSource.IsValid());
    AssertEqual("FocusSource", camera->FocusSource.GetName());

    prop = camera->FindProperty("FocusAngle");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FocusAngle.IsValid());
    AssertEqual("FocusAngle", camera->FocusAngle.GetName());

    prop = camera->FindProperty("FocusDistance");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FocusDistance.IsValid());
    AssertEqual("FocusDistance", camera->FocusDistance.GetName());

    prop = camera->FindProperty("UseAntialiasing");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseAntialiasing.IsValid());
    AssertEqual("UseAntialiasing", camera->UseAntialiasing.GetName());

    prop = camera->FindProperty("AntialiasingIntensity");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AntialiasingIntensity.IsValid());
    AssertEqual("AntialiasingIntensity", camera->AntialiasingIntensity.GetName());

    prop = camera->FindProperty("AntialiasingMethod");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->AntialiasingMethod.IsValid());
    AssertEqual("AntialiasingMethod", camera->AntialiasingMethod.GetName());

    prop = camera->FindProperty("UseAccumulationBuffer");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->UseAccumulationBuffer.IsValid());
    AssertEqual("UseAccumulationBuffer", camera->UseAccumulationBuffer.GetName());

    prop = camera->FindProperty("FrameSamplingCount");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrameSamplingCount.IsValid());
    AssertEqual("FrameSamplingCount", camera->FrameSamplingCount.GetName());

    prop = camera->FindProperty("FrameSamplingType");
    AssertTrue(prop.IsValid());
    AssertTrue(camera->FrameSamplingType.IsValid());
    AssertEqual("FrameSamplingType", camera->FrameSamplingType.GetName());
}

void FbxCamera_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxCamera* obj = FbxCamera::Create(manager, "asdf");

    // then:
    AssertEqual("NodeAttribute::", obj->GetNameSpacePrefix());
}

void CameraTest::RegisterTestCases()
{
    AddTestCase(Camera_Create_HasProperties);
    AddTestCase(FbxCamera_Create_HasNamespacePrefix);
}

