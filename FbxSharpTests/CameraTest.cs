using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class CameraTest : TestBase
    {
        [Test]
        public void Camera_Create_HasProperties()
        {
            // given:
            var camera = new FbxCamera("camera");
            FbxProperty prop;

            // then:
            Assert.AreEqual(106, CountProperties(camera));
            Assert.AreEqual(0, camera.GetSrcPropertyCount());
            Assert.AreEqual(0, camera.GetDstPropertyCount());

            prop = camera.FindProperty("Color");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.Color);
            Assert.True(camera.Color.IsValid());
            Assert.AreEqual("Color", camera.Color.GetName());
            Assert.AreSame(prop, camera.Color);

            prop = camera.FindProperty("Position");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.Position);
            Assert.True(camera.Position.IsValid());
            Assert.AreEqual("Position", camera.Position.GetName());
            Assert.AreSame(prop, camera.Position);

            prop = camera.FindProperty("UpVector");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UpVector);
            Assert.True(camera.UpVector.IsValid());
            Assert.AreEqual("UpVector", camera.UpVector.GetName());
            Assert.AreSame(prop, camera.UpVector);

            prop = camera.FindProperty("InterestPosition");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.InterestPosition);
            Assert.True(camera.InterestPosition.IsValid());
            Assert.AreEqual("InterestPosition", camera.InterestPosition.GetName());
            Assert.AreSame(prop, camera.InterestPosition);

            prop = camera.FindProperty("Roll");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.Roll);
            Assert.True(camera.Roll.IsValid());
            Assert.AreEqual("Roll", camera.Roll.GetName());
            Assert.AreSame(prop, camera.Roll);

            prop = camera.FindProperty("OpticalCenterX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.OpticalCenterX);
            Assert.True(camera.OpticalCenterX.IsValid());
            Assert.AreEqual("OpticalCenterX", camera.OpticalCenterX.GetName());
            Assert.AreSame(prop, camera.OpticalCenterX);

            prop = camera.FindProperty("OpticalCenterY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.OpticalCenterY);
            Assert.True(camera.OpticalCenterY.IsValid());
            Assert.AreEqual("OpticalCenterY", camera.OpticalCenterY.GetName());
            Assert.AreSame(prop, camera.OpticalCenterY);

            prop = camera.FindProperty("BackgroundColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackgroundColor);
            Assert.True(camera.BackgroundColor.IsValid());
            Assert.AreEqual("BackgroundColor", camera.BackgroundColor.GetName());
            Assert.AreSame(prop, camera.BackgroundColor);

            prop = camera.FindProperty("TurnTable");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.TurnTable);
            Assert.True(camera.TurnTable.IsValid());
            Assert.AreEqual("TurnTable", camera.TurnTable.GetName());
            Assert.AreSame(prop, camera.TurnTable);

            prop = camera.FindProperty("DisplayTurnTableIcon");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.DisplayTurnTableIcon);
            Assert.True(camera.DisplayTurnTableIcon.IsValid());
            Assert.AreEqual("DisplayTurnTableIcon", camera.DisplayTurnTableIcon.GetName());
            Assert.AreSame(prop, camera.DisplayTurnTableIcon);

            prop = camera.FindProperty("UseMotionBlur");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseMotionBlur);
            Assert.True(camera.UseMotionBlur.IsValid());
            Assert.AreEqual("UseMotionBlur", camera.UseMotionBlur.GetName());
            Assert.AreSame(prop, camera.UseMotionBlur);

            prop = camera.FindProperty("UseRealTimeMotionBlur");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseRealTimeMotionBlur);
            Assert.True(camera.UseRealTimeMotionBlur.IsValid());
            Assert.AreEqual("UseRealTimeMotionBlur", camera.UseRealTimeMotionBlur.GetName());
            Assert.AreSame(prop, camera.UseRealTimeMotionBlur);

            prop = camera.FindProperty("Motion Blur Intensity");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.MotionBlurIntensity);
            Assert.True(camera.MotionBlurIntensity.IsValid());
            Assert.AreEqual("Motion Blur Intensity", camera.MotionBlurIntensity.GetName());
            Assert.AreSame(prop, camera.MotionBlurIntensity);

            prop = camera.FindProperty("AspectRatioMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AspectRatioMode);
            Assert.True(camera.AspectRatioMode.IsValid());
            Assert.AreEqual("AspectRatioMode", camera.AspectRatioMode.GetName());
            Assert.AreSame(prop, camera.AspectRatioMode);

            prop = camera.FindProperty("AspectWidth");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AspectWidth);
            Assert.True(camera.AspectWidth.IsValid());
            Assert.AreEqual("AspectWidth", camera.AspectWidth.GetName());
            Assert.AreSame(prop, camera.AspectWidth);

            prop = camera.FindProperty("AspectHeight");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AspectHeight);
            Assert.True(camera.AspectHeight.IsValid());
            Assert.AreEqual("AspectHeight", camera.AspectHeight.GetName());
            Assert.AreSame(prop, camera.AspectHeight);

            prop = camera.FindProperty("PixelAspectRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.PixelAspectRatio);
            Assert.True(camera.PixelAspectRatio.IsValid());
            Assert.AreEqual("PixelAspectRatio", camera.PixelAspectRatio.GetName());
            Assert.AreSame(prop, camera.PixelAspectRatio);

            prop = camera.FindProperty("ApertureMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ApertureMode);
            Assert.True(camera.ApertureMode.IsValid());
            Assert.AreEqual("ApertureMode", camera.ApertureMode.GetName());
            Assert.AreSame(prop, camera.ApertureMode);

            prop = camera.FindProperty("GateFit");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.GateFit);
            Assert.True(camera.GateFit.IsValid());
            Assert.AreEqual("GateFit", camera.GateFit.GetName());
            Assert.AreSame(prop, camera.GateFit);

            prop = camera.FindProperty("FieldOfView");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FieldOfView);
            Assert.True(camera.FieldOfView.IsValid());
            Assert.AreEqual("FieldOfView", camera.FieldOfView.GetName());
            Assert.AreSame(prop, camera.FieldOfView);

            prop = camera.FindProperty("FieldOfViewX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FieldOfViewX);
            Assert.True(camera.FieldOfViewX.IsValid());
            Assert.AreEqual("FieldOfViewX", camera.FieldOfViewX.GetName());
            Assert.AreSame(prop, camera.FieldOfViewX);

            prop = camera.FindProperty("FieldOfViewY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FieldOfViewY);
            Assert.True(camera.FieldOfViewY.IsValid());
            Assert.AreEqual("FieldOfViewY", camera.FieldOfViewY.GetName());
            Assert.AreSame(prop, camera.FieldOfViewY);

            prop = camera.FindProperty("FocalLength");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FocalLength);
            Assert.True(camera.FocalLength.IsValid());
            Assert.AreEqual("FocalLength", camera.FocalLength.GetName());
            Assert.AreSame(prop, camera.FocalLength);

            prop = camera.FindProperty("CameraFormat");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.CameraFormat);
            Assert.True(camera.CameraFormat.IsValid());
            Assert.AreEqual("CameraFormat", camera.CameraFormat.GetName());
            Assert.AreSame(prop, camera.CameraFormat);

            prop = camera.FindProperty("UseFrameColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseFrameColor);
            Assert.True(camera.UseFrameColor.IsValid());
            Assert.AreEqual("UseFrameColor", camera.UseFrameColor.GetName());
            Assert.AreSame(prop, camera.UseFrameColor);

            prop = camera.FindProperty("FrameColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrameColor);
            Assert.True(camera.FrameColor.IsValid());
            Assert.AreEqual("FrameColor", camera.FrameColor.GetName());
            Assert.AreSame(prop, camera.FrameColor);

            prop = camera.FindProperty("ShowName");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowName);
            Assert.True(camera.ShowName.IsValid());
            Assert.AreEqual("ShowName", camera.ShowName.GetName());
            Assert.AreSame(prop, camera.ShowName);

            prop = camera.FindProperty("ShowInfoOnMoving");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowInfoOnMoving);
            Assert.True(camera.ShowInfoOnMoving.IsValid());
            Assert.AreEqual("ShowInfoOnMoving", camera.ShowInfoOnMoving.GetName());
            Assert.AreSame(prop, camera.ShowInfoOnMoving);

            prop = camera.FindProperty("ShowGrid");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowGrid);
            Assert.True(camera.ShowGrid.IsValid());
            Assert.AreEqual("ShowGrid", camera.ShowGrid.GetName());
            Assert.AreSame(prop, camera.ShowGrid);

            prop = camera.FindProperty("ShowOpticalCenter");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowOpticalCenter);
            Assert.True(camera.ShowOpticalCenter.IsValid());
            Assert.AreEqual("ShowOpticalCenter", camera.ShowOpticalCenter.GetName());
            Assert.AreSame(prop, camera.ShowOpticalCenter);

            prop = camera.FindProperty("ShowAzimut");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowAzimut);
            Assert.True(camera.ShowAzimut.IsValid());
            Assert.AreEqual("ShowAzimut", camera.ShowAzimut.GetName());
            Assert.AreSame(prop, camera.ShowAzimut);

            prop = camera.FindProperty("ShowTimeCode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowTimeCode);
            Assert.True(camera.ShowTimeCode.IsValid());
            Assert.AreEqual("ShowTimeCode", camera.ShowTimeCode.GetName());
            Assert.AreSame(prop, camera.ShowTimeCode);

            prop = camera.FindProperty("ShowAudio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowAudio);
            Assert.True(camera.ShowAudio.IsValid());
            Assert.AreEqual("ShowAudio", camera.ShowAudio.GetName());
            Assert.AreSame(prop, camera.ShowAudio);

            prop = camera.FindProperty("AudioColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AudioColor);
            Assert.True(camera.AudioColor.IsValid());
            Assert.AreEqual("AudioColor", camera.AudioColor.GetName());
            Assert.AreSame(prop, camera.AudioColor);

            prop = camera.FindProperty("NearPlane");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.NearPlane);
            Assert.True(camera.NearPlane.IsValid());
            Assert.AreEqual("NearPlane", camera.NearPlane.GetName());
            Assert.AreSame(prop, camera.NearPlane);

            prop = camera.FindProperty("FarPlane");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FarPlane);
            Assert.True(camera.FarPlane.IsValid());
            Assert.AreEqual("FarPlane", camera.FarPlane.GetName());
            Assert.AreSame(prop, camera.FarPlane);

            prop = camera.FindProperty("AutoComputeClipPanes");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AutoComputeClipPlanes);
            Assert.True(camera.AutoComputeClipPlanes.IsValid());
            Assert.AreEqual("AutoComputeClipPanes", camera.AutoComputeClipPlanes.GetName());
            Assert.AreSame(prop, camera.AutoComputeClipPlanes);

            prop = camera.FindProperty("FilmWidth");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmWidth);
            Assert.True(camera.FilmWidth.IsValid());
            Assert.AreEqual("FilmWidth", camera.FilmWidth.GetName());
            Assert.AreSame(prop, camera.FilmWidth);

            prop = camera.FindProperty("FilmHeight");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmHeight);
            Assert.True(camera.FilmHeight.IsValid());
            Assert.AreEqual("FilmHeight", camera.FilmHeight.GetName());
            Assert.AreSame(prop, camera.FilmHeight);

            prop = camera.FindProperty("FilmAspectRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmAspectRatio);
            Assert.True(camera.FilmAspectRatio.IsValid());
            Assert.AreEqual("FilmAspectRatio", camera.FilmAspectRatio.GetName());
            Assert.AreSame(prop, camera.FilmAspectRatio);

            prop = camera.FindProperty("FilmSqueezeRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmSqueezeRatio);
            Assert.True(camera.FilmSqueezeRatio.IsValid());
            Assert.AreEqual("FilmSqueezeRatio", camera.FilmSqueezeRatio.GetName());
            Assert.AreSame(prop, camera.FilmSqueezeRatio);

            prop = camera.FindProperty("FilmFormatIndex");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmFormat);
            Assert.True(camera.FilmFormat.IsValid());
            Assert.AreEqual("FilmFormatIndex", camera.FilmFormat.GetName());
            Assert.AreSame(prop, camera.FilmFormat);

            prop = camera.FindProperty("FilmOffsetX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmOffsetX);
            Assert.True(camera.FilmOffsetX.IsValid());
            Assert.AreEqual("FilmOffsetX", camera.FilmOffsetX.GetName());
            Assert.AreSame(prop, camera.FilmOffsetX);

            prop = camera.FindProperty("FilmOffsetY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmOffsetY);
            Assert.True(camera.FilmOffsetY.IsValid());
            Assert.AreEqual("FilmOffsetY", camera.FilmOffsetY.GetName());
            Assert.AreSame(prop, camera.FilmOffsetY);

            prop = camera.FindProperty("PreScale");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.PreScale);
            Assert.True(camera.PreScale.IsValid());
            Assert.AreEqual("PreScale", camera.PreScale.GetName());
            Assert.AreSame(prop, camera.PreScale);

            prop = camera.FindProperty("FilmTranslateX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmTranslateX);
            Assert.True(camera.FilmTranslateX.IsValid());
            Assert.AreEqual("FilmTranslateX", camera.FilmTranslateX.GetName());
            Assert.AreSame(prop, camera.FilmTranslateX);

            prop = camera.FindProperty("FilmTranslateY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmTranslateY);
            Assert.True(camera.FilmTranslateY.IsValid());
            Assert.AreEqual("FilmTranslateY", camera.FilmTranslateY.GetName());
            Assert.AreSame(prop, camera.FilmTranslateY);

            prop = camera.FindProperty("FilmRollPivotX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmRollPivotX);
            Assert.True(camera.FilmRollPivotX.IsValid());
            Assert.AreEqual("FilmRollPivotX", camera.FilmRollPivotX.GetName());
            Assert.AreSame(prop, camera.FilmRollPivotX);

            prop = camera.FindProperty("FilmRollPivotY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmRollPivotY);
            Assert.True(camera.FilmRollPivotY.IsValid());
            Assert.AreEqual("FilmRollPivotY", camera.FilmRollPivotY.GetName());
            Assert.AreSame(prop, camera.FilmRollPivotY);

            prop = camera.FindProperty("FilmRollValue");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmRollValue);
            Assert.True(camera.FilmRollValue.IsValid());
            Assert.AreEqual("FilmRollValue", camera.FilmRollValue.GetName());
            Assert.AreSame(prop, camera.FilmRollValue);

            prop = camera.FindProperty("FilmRollOrder");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FilmRollOrder);
            Assert.True(camera.FilmRollOrder.IsValid());
            Assert.AreEqual("FilmRollOrder", camera.FilmRollOrder.GetName());
            Assert.AreSame(prop, camera.FilmRollOrder);

            prop = camera.FindProperty("ViewCameraToLookAt");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ViewCameraToLookAt);
            Assert.True(camera.ViewCameraToLookAt.IsValid());
            Assert.AreEqual("ViewCameraToLookAt", camera.ViewCameraToLookAt.GetName());
            Assert.AreSame(prop, camera.ViewCameraToLookAt);

            prop = camera.FindProperty("ViewFrustumNearFarPlane");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ViewFrustumNearFarPlane);
            Assert.True(camera.ViewFrustumNearFarPlane.IsValid());
            Assert.AreEqual("ViewFrustumNearFarPlane", camera.ViewFrustumNearFarPlane.GetName());
            Assert.AreSame(prop, camera.ViewFrustumNearFarPlane);

            prop = camera.FindProperty("ViewFrustumBackPlaneMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ViewFrustumBackPlaneMode);
            Assert.True(camera.ViewFrustumBackPlaneMode.IsValid());
            Assert.AreEqual("ViewFrustumBackPlaneMode", camera.ViewFrustumBackPlaneMode.GetName());
            Assert.AreSame(prop, camera.ViewFrustumBackPlaneMode);

            prop = camera.FindProperty("BackPlaneDistance");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneDistance);
            Assert.True(camera.BackPlaneDistance.IsValid());
            Assert.AreEqual("BackPlaneDistance", camera.BackPlaneDistance.GetName());
            Assert.AreSame(prop, camera.BackPlaneDistance);

            prop = camera.FindProperty("BackPlaneDistanceMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneDistanceMode);
            Assert.True(camera.BackPlaneDistanceMode.IsValid());
            Assert.AreEqual("BackPlaneDistanceMode", camera.BackPlaneDistanceMode.GetName());
            Assert.AreSame(prop, camera.BackPlaneDistanceMode);

            prop = camera.FindProperty("ViewFrustumFrontPlaneMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ViewFrustumFrontPlaneMode);
            Assert.True(camera.ViewFrustumFrontPlaneMode.IsValid());
            Assert.AreEqual("ViewFrustumFrontPlaneMode", camera.ViewFrustumFrontPlaneMode.GetName());
            Assert.AreSame(prop, camera.ViewFrustumFrontPlaneMode);

            prop = camera.FindProperty("FrontPlaneDistance");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneDistance);
            Assert.True(camera.FrontPlaneDistance.IsValid());
            Assert.AreEqual("FrontPlaneDistance", camera.FrontPlaneDistance.GetName());
            Assert.AreSame(prop, camera.FrontPlaneDistance);

            prop = camera.FindProperty("FrontPlaneDistanceMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneDistanceMode);
            Assert.True(camera.FrontPlaneDistanceMode.IsValid());
            Assert.AreEqual("FrontPlaneDistanceMode", camera.FrontPlaneDistanceMode.GetName());
            Assert.AreSame(prop, camera.FrontPlaneDistanceMode);

            prop = camera.FindProperty("LockMode");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.LockMode);
            Assert.True(camera.LockMode.IsValid());
            Assert.AreEqual("LockMode", camera.LockMode.GetName());
            Assert.AreSame(prop, camera.LockMode);

            prop = camera.FindProperty("LockInterestNavigation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.LockInterestNavigation);
            Assert.True(camera.LockInterestNavigation.IsValid());
            Assert.AreEqual("LockInterestNavigation", camera.LockInterestNavigation.GetName());
            Assert.AreSame(prop, camera.LockInterestNavigation);

            prop = camera.FindProperty("BackPlateFitImage");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlateFitImage);
            Assert.True(camera.BackPlateFitImage.IsValid());
            Assert.AreEqual("BackPlateFitImage", camera.BackPlateFitImage.GetName());
            Assert.AreSame(prop, camera.BackPlateFitImage);

            prop = camera.FindProperty("BackPlateCrop");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlateCrop);
            Assert.True(camera.BackPlateCrop.IsValid());
            Assert.AreEqual("BackPlateCrop", camera.BackPlateCrop.GetName());
            Assert.AreSame(prop, camera.BackPlateCrop);

            prop = camera.FindProperty("BackPlateCenter");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlateCenter);
            Assert.True(camera.BackPlateCenter.IsValid());
            Assert.AreEqual("BackPlateCenter", camera.BackPlateCenter.GetName());
            Assert.AreSame(prop, camera.BackPlateCenter);

            prop = camera.FindProperty("BackPlateKeepRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlateKeepRatio);
            Assert.True(camera.BackPlateKeepRatio.IsValid());
            Assert.AreEqual("BackPlateKeepRatio", camera.BackPlateKeepRatio.GetName());
            Assert.AreSame(prop, camera.BackPlateKeepRatio);

            prop = camera.FindProperty("BackgroundAlphaTreshold");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackgroundAlphaTreshold);
            Assert.True(camera.BackgroundAlphaTreshold.IsValid());
            Assert.AreEqual("BackgroundAlphaTreshold", camera.BackgroundAlphaTreshold.GetName());
            Assert.AreSame(prop, camera.BackgroundAlphaTreshold);

            prop = camera.FindProperty("BackPlaneOffsetX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneOffsetX);
            Assert.True(camera.BackPlaneOffsetX.IsValid());
            Assert.AreEqual("BackPlaneOffsetX", camera.BackPlaneOffsetX.GetName());
            Assert.AreSame(prop, camera.BackPlaneOffsetX);

            prop = camera.FindProperty("BackPlaneOffsetY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneOffsetY);
            Assert.True(camera.BackPlaneOffsetY.IsValid());
            Assert.AreEqual("BackPlaneOffsetY", camera.BackPlaneOffsetY.GetName());
            Assert.AreSame(prop, camera.BackPlaneOffsetY);

            prop = camera.FindProperty("BackPlaneRotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneRotation);
            Assert.True(camera.BackPlaneRotation.IsValid());
            Assert.AreEqual("BackPlaneRotation", camera.BackPlaneRotation.GetName());
            Assert.AreSame(prop, camera.BackPlaneRotation);

            prop = camera.FindProperty("BackPlaneScaleX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneScaleX);
            Assert.True(camera.BackPlaneScaleX.IsValid());
            Assert.AreEqual("BackPlaneScaleX", camera.BackPlaneScaleX.GetName());
            Assert.AreSame(prop, camera.BackPlaneScaleX);

            prop = camera.FindProperty("BackPlaneScaleY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackPlaneScaleY);
            Assert.True(camera.BackPlaneScaleY.IsValid());
            Assert.AreEqual("BackPlaneScaleY", camera.BackPlaneScaleY.GetName());
            Assert.AreSame(prop, camera.BackPlaneScaleY);

            prop = camera.FindProperty("ShowBackplate");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowBackplate);
            Assert.True(camera.ShowBackplate.IsValid());
            Assert.AreEqual("ShowBackplate", camera.ShowBackplate.GetName());
            Assert.AreSame(prop, camera.ShowBackplate);

            prop = camera.FindProperty("Background Texture");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.BackgroundTexture);
            Assert.True(camera.BackgroundTexture.IsValid());
            Assert.AreEqual("Background Texture", camera.BackgroundTexture.GetName());
            Assert.AreSame(prop, camera.BackgroundTexture);

            prop = camera.FindProperty("FrontPlateFitImage");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlateFitImage);
            Assert.True(camera.FrontPlateFitImage.IsValid());
            Assert.AreEqual("FrontPlateFitImage", camera.FrontPlateFitImage.GetName());
            Assert.AreSame(prop, camera.FrontPlateFitImage);

            prop = camera.FindProperty("FrontPlateCrop");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlateCrop);
            Assert.True(camera.FrontPlateCrop.IsValid());
            Assert.AreEqual("FrontPlateCrop", camera.FrontPlateCrop.GetName());
            Assert.AreSame(prop, camera.FrontPlateCrop);

            prop = camera.FindProperty("FrontPlateCenter");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlateCenter);
            Assert.True(camera.FrontPlateCenter.IsValid());
            Assert.AreEqual("FrontPlateCenter", camera.FrontPlateCenter.GetName());
            Assert.AreSame(prop, camera.FrontPlateCenter);

            prop = camera.FindProperty("FrontPlateKeepRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlateKeepRatio);
            Assert.True(camera.FrontPlateKeepRatio.IsValid());
            Assert.AreEqual("FrontPlateKeepRatio", camera.FrontPlateKeepRatio.GetName());
            Assert.AreSame(prop, camera.FrontPlateKeepRatio);

            prop = camera.FindProperty("ShowFrontplate");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ShowFrontplate);
            Assert.True(camera.ShowFrontplate.IsValid());
            Assert.AreEqual("ShowFrontplate", camera.ShowFrontplate.GetName());
            Assert.AreSame(prop, camera.ShowFrontplate);

            prop = camera.FindProperty("FrontPlaneOffsetX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneOffsetX);
            Assert.True(camera.FrontPlaneOffsetX.IsValid());
            Assert.AreEqual("FrontPlaneOffsetX", camera.FrontPlaneOffsetX.GetName());
            Assert.AreSame(prop, camera.FrontPlaneOffsetX);

            prop = camera.FindProperty("FrontPlaneOffsetY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneOffsetY);
            Assert.True(camera.FrontPlaneOffsetY.IsValid());
            Assert.AreEqual("FrontPlaneOffsetY", camera.FrontPlaneOffsetY.GetName());
            Assert.AreSame(prop, camera.FrontPlaneOffsetY);

            prop = camera.FindProperty("FrontPlaneRotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneRotation);
            Assert.True(camera.FrontPlaneRotation.IsValid());
            Assert.AreEqual("FrontPlaneRotation", camera.FrontPlaneRotation.GetName());
            Assert.AreSame(prop, camera.FrontPlaneRotation);

            prop = camera.FindProperty("FrontPlaneScaleX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneScaleX);
            Assert.True(camera.FrontPlaneScaleX.IsValid());
            Assert.AreEqual("FrontPlaneScaleX", camera.FrontPlaneScaleX.GetName());
            Assert.AreSame(prop, camera.FrontPlaneScaleX);

            prop = camera.FindProperty("FrontPlaneScaleY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrontPlaneScaleY);
            Assert.True(camera.FrontPlaneScaleY.IsValid());
            Assert.AreEqual("FrontPlaneScaleY", camera.FrontPlaneScaleY.GetName());
            Assert.AreSame(prop, camera.FrontPlaneScaleY);

            prop = camera.FindProperty("Foreground Texture");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ForegroundTexture);
            Assert.True(camera.ForegroundTexture.IsValid());
            Assert.AreEqual("Foreground Texture", camera.ForegroundTexture.GetName());
            Assert.AreSame(prop, camera.ForegroundTexture);

            prop = camera.FindProperty("Foreground Opacity");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ForegroundOpacity);
            Assert.True(camera.ForegroundOpacity.IsValid());
            Assert.AreEqual("Foreground Opacity", camera.ForegroundOpacity.GetName());
            Assert.AreSame(prop, camera.ForegroundOpacity);

            prop = camera.FindProperty("DisplaySafeArea");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.DisplaySafeArea);
            Assert.True(camera.DisplaySafeArea.IsValid());
            Assert.AreEqual("DisplaySafeArea", camera.DisplaySafeArea.GetName());
            Assert.AreSame(prop, camera.DisplaySafeArea);

            prop = camera.FindProperty("DisplaySafeAreaOnRender");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.DisplaySafeAreaOnRender);
            Assert.True(camera.DisplaySafeAreaOnRender.IsValid());
            Assert.AreEqual("DisplaySafeAreaOnRender", camera.DisplaySafeAreaOnRender.GetName());
            Assert.AreSame(prop, camera.DisplaySafeAreaOnRender);

            prop = camera.FindProperty("SafeAreaDisplayStyle");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.SafeAreaDisplayStyle);
            Assert.True(camera.SafeAreaDisplayStyle.IsValid());
            Assert.AreEqual("SafeAreaDisplayStyle", camera.SafeAreaDisplayStyle.GetName());
            Assert.AreSame(prop, camera.SafeAreaDisplayStyle);

            prop = camera.FindProperty("SafeAreaAspectRatio");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.SafeAreaAspectRatio);
            Assert.True(camera.SafeAreaAspectRatio.IsValid());
            Assert.AreEqual("SafeAreaAspectRatio", camera.SafeAreaAspectRatio.GetName());
            Assert.AreSame(prop, camera.SafeAreaAspectRatio);

            prop = camera.FindProperty("Use2DMagnifierZoom");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.Use2DMagnifierZoom);
            Assert.True(camera.Use2DMagnifierZoom.IsValid());
            Assert.AreEqual("Use2DMagnifierZoom", camera.Use2DMagnifierZoom.GetName());
            Assert.AreSame(prop, camera.Use2DMagnifierZoom);

            prop = camera.FindProperty("2D Magnifier Zoom");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera._2DMagnifierZoom);
            Assert.True(camera._2DMagnifierZoom.IsValid());
            Assert.AreEqual("2D Magnifier Zoom", camera._2DMagnifierZoom.GetName());
            Assert.AreSame(prop, camera._2DMagnifierZoom);

            prop = camera.FindProperty("2D Magnifier X");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera._2DMagnifierX);
            Assert.True(camera._2DMagnifierX.IsValid());
            Assert.AreEqual("2D Magnifier X", camera._2DMagnifierX.GetName());
            Assert.AreSame(prop, camera._2DMagnifierX);

            prop = camera.FindProperty("2D Magnifier Y");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera._2DMagnifierY);
            Assert.True(camera._2DMagnifierY.IsValid());
            Assert.AreEqual("2D Magnifier Y", camera._2DMagnifierY.GetName());
            Assert.AreSame(prop, camera._2DMagnifierY);

            prop = camera.FindProperty("CameraProjectionType");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.ProjectionType);
            Assert.True(camera.ProjectionType.IsValid());
            Assert.AreEqual("CameraProjectionType", camera.ProjectionType.GetName());
            Assert.AreSame(prop, camera.ProjectionType);

            prop = camera.FindProperty("OrthoZoom");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.OrthoZoom);
            Assert.True(camera.OrthoZoom.IsValid());
            Assert.AreEqual("OrthoZoom", camera.OrthoZoom.GetName());
            Assert.AreSame(prop, camera.OrthoZoom);

            prop = camera.FindProperty("UseRealTimeDOFAndAA");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseRealTimeDOFAndAA);
            Assert.True(camera.UseRealTimeDOFAndAA.IsValid());
            Assert.AreEqual("UseRealTimeDOFAndAA", camera.UseRealTimeDOFAndAA.GetName());
            Assert.AreSame(prop, camera.UseRealTimeDOFAndAA);

            prop = camera.FindProperty("UseDepthOfField");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseDepthOfField);
            Assert.True(camera.UseDepthOfField.IsValid());
            Assert.AreEqual("UseDepthOfField", camera.UseDepthOfField.GetName());
            Assert.AreSame(prop, camera.UseDepthOfField);

            prop = camera.FindProperty("FocusSource");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FocusSource);
            Assert.True(camera.FocusSource.IsValid());
            Assert.AreEqual("FocusSource", camera.FocusSource.GetName());
            Assert.AreSame(prop, camera.FocusSource);

            prop = camera.FindProperty("FocusAngle");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FocusAngle);
            Assert.True(camera.FocusAngle.IsValid());
            Assert.AreEqual("FocusAngle", camera.FocusAngle.GetName());
            Assert.AreSame(prop, camera.FocusAngle);

            prop = camera.FindProperty("FocusDistance");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FocusDistance);
            Assert.True(camera.FocusDistance.IsValid());
            Assert.AreEqual("FocusDistance", camera.FocusDistance.GetName());
            Assert.AreSame(prop, camera.FocusDistance);

            prop = camera.FindProperty("UseAntialiasing");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseAntialiasing);
            Assert.True(camera.UseAntialiasing.IsValid());
            Assert.AreEqual("UseAntialiasing", camera.UseAntialiasing.GetName());
            Assert.AreSame(prop, camera.UseAntialiasing);

            prop = camera.FindProperty("AntialiasingIntensity");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AntialiasingIntensity);
            Assert.True(camera.AntialiasingIntensity.IsValid());
            Assert.AreEqual("AntialiasingIntensity", camera.AntialiasingIntensity.GetName());
            Assert.AreSame(prop, camera.AntialiasingIntensity);

            prop = camera.FindProperty("AntialiasingMethod");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.AntialiasingMethod);
            Assert.True(camera.AntialiasingMethod.IsValid());
            Assert.AreEqual("AntialiasingMethod", camera.AntialiasingMethod.GetName());
            Assert.AreSame(prop, camera.AntialiasingMethod);

            prop = camera.FindProperty("UseAccumulationBuffer");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.UseAccumulationBuffer);
            Assert.True(camera.UseAccumulationBuffer.IsValid());
            Assert.AreEqual("UseAccumulationBuffer", camera.UseAccumulationBuffer.GetName());
            Assert.AreSame(prop, camera.UseAccumulationBuffer);

            prop = camera.FindProperty("FrameSamplingCount");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrameSamplingCount);
            Assert.True(camera.FrameSamplingCount.IsValid());
            Assert.AreEqual("FrameSamplingCount", camera.FrameSamplingCount.GetName());
            Assert.AreSame(prop, camera.FrameSamplingCount);

            prop = camera.FindProperty("FrameSamplingType");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(camera.FrameSamplingType);
            Assert.True(camera.FrameSamplingType.IsValid());
            Assert.AreEqual("FrameSamplingType", camera.FrameSamplingType.GetName());
            Assert.AreSame(prop, camera.FrameSamplingType);
        }

        [Test]
        public void FbxCamera_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxCamera("asdf");

            // then:
            Assert.AreEqual("NodeAttribute::", obj.GetNameSpacePrefix());
        }
    }
}
