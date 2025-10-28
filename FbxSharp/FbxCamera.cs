using System;

namespace FbxSharp
{
    public class FbxCamera : FbxNodeAttribute
    {
        public FbxCamera(string name = "")
            : base(name)
        {
            Position = FbxPropertyT<FbxVector3>.StaticInit(this, "Position",
                FbxVector3.Zero, false);
            UpVector = FbxPropertyT<FbxVector3>.StaticInit(this, "UpVector",
                FbxVector3.Zero, false);
            InterestPosition = FbxPropertyT<FbxVector3>.StaticInit(this,
                "InterestPosition", FbxVector3.Zero, false);
            Roll = FbxPropertyT<double>.StaticInit(this, "Roll", 0.0, false);
            OpticalCenterX = FbxPropertyT<double>.StaticInit(this,
                "OpticalCenterX", 0.0, false);
            OpticalCenterY = FbxPropertyT<double>.StaticInit(this,
                "OpticalCenterY", 0.0, false);
            BackgroundColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "BackgroundColor", FbxVector3.Zero, false);
            TurnTable = FbxPropertyT<double>.StaticInit(this, "TurnTable",
                0.0, false);
            DisplayTurnTableIcon = FbxPropertyT<bool>.StaticInit(this,
                "DisplayTurnTableIcon", false, false);
            UseMotionBlur = FbxPropertyT<bool>.StaticInit(this,
                "UseMotionBlur", false, false);
            UseRealTimeMotionBlur = FbxPropertyT<bool>.StaticInit(this,
                "UseRealTimeMotionBlur", false, false);
            MotionBlurIntensity = FbxPropertyT<double>.StaticInit(this,
                "Motion Blur Intensity", 0.0, false);
            AspectRatioMode = FbxPropertyT<EAspectRatioMode>.StaticInit(this,
                "AspectRatioMode", null, default, false);
            AspectWidth = FbxPropertyT<double>.StaticInit(this, "AspectWidth",
                0.0, false);
            AspectHeight = FbxPropertyT<double>.StaticInit(this,
                "AspectHeight", 0.0, false);
            PixelAspectRatio = FbxPropertyT<double>.StaticInit(this,
                "PixelAspectRatio", 0.0, false);
            ApertureMode = FbxPropertyT<EApertureMode>.StaticInit(this,
                "ApertureMode", null, default, false);
            GateFit = FbxPropertyT<EGateFit>.StaticInit(this, "GateFit", null,
                default, false);
            FieldOfView = FbxPropertyT<double>.StaticInit(this, "FieldOfView",
                0.0, false);
            FieldOfViewX = FbxPropertyT<double>.StaticInit(this,
                "FieldOfViewX", 0.0, false);
            FieldOfViewY = FbxPropertyT<double>.StaticInit(this,
                "FieldOfViewY", 0.0, false);
            FocalLength = FbxPropertyT<double>.StaticInit(this, "FocalLength",
                0.0, false);
            CameraFormat = FbxPropertyT<EFormat>.StaticInit(this,
                "CameraFormat", null, default, false);
            UseFrameColor = FbxPropertyT<bool>.StaticInit(this,
                "UseFrameColor", false, false);
            FrameColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "FrameColor", FbxVector3.Zero, false);
            ShowName = FbxPropertyT<bool>.StaticInit(this, "ShowName", false,
                false);
            ShowInfoOnMoving = FbxPropertyT<bool>.StaticInit(this,
                "ShowInfoOnMoving", false, false);
            ShowGrid = FbxPropertyT<bool>.StaticInit(this, "ShowGrid", false,
                false);
            ShowOpticalCenter = FbxPropertyT<bool>.StaticInit(this,
                "ShowOpticalCenter", false, false);
            ShowAzimut = FbxPropertyT<bool>.StaticInit(this, "ShowAzimut",
                false, false);
            ShowTimeCode = FbxPropertyT<bool>.StaticInit(this, "ShowTimeCode",
                false, false);
            ShowAudio = FbxPropertyT<bool>.StaticInit(this, "ShowAudio",
                false, false);
            AudioColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "AudioColor", FbxVector3.Zero, false);
            NearPlane = FbxPropertyT<double>.StaticInit(this, "NearPlane",
                0.0, false);
            FarPlane = FbxPropertyT<double>.StaticInit(this, "FarPlane", 0.0,
                false);
            AutoComputeClipPlanes = FbxPropertyT<bool>.StaticInit(this,
                "AutoComputeClipPanes", false, false);
            FilmWidth = FbxPropertyT<double>.StaticInit(this, "FilmWidth",
                0.0, false);
            FilmHeight = FbxPropertyT<double>.StaticInit(this, "FilmHeight",
                0.0, false);
            FilmAspectRatio = FbxPropertyT<double>.StaticInit(this,
                "FilmAspectRatio", 0.0, false);
            FilmSqueezeRatio = FbxPropertyT<double>.StaticInit(this,
                "FilmSqueezeRatio", 0.0, false);
            FilmFormat = FbxPropertyT<EApertureFormat>.StaticInit(this,
                "FilmFormatIndex", null, default, false);
            FilmOffsetX = FbxPropertyT<double>.StaticInit(this,
                "FilmOffsetX", 0.0, false);
            FilmOffsetY = FbxPropertyT<double>.StaticInit(this, "FilmOffsetY",
                0.0, false);
            PreScale = FbxPropertyT<double>.StaticInit(this, "PreScale", 0.0,
                false);
            FilmTranslateX = FbxPropertyT<double>.StaticInit(this,
                "FilmTranslateX", 0.0, false);
            FilmTranslateY = FbxPropertyT<double>.StaticInit(this,
                "FilmTranslateY", 0.0, false);
            FilmRollPivotX = FbxPropertyT<double>.StaticInit(this,
                "FilmRollPivotX", 0.0, false);
            FilmRollPivotY = FbxPropertyT<double>.StaticInit(this,
                "FilmRollPivotY", 0.0, false);
            FilmRollValue = FbxPropertyT<double>.StaticInit(this,
                "FilmRollValue", 0.0, false);
            FilmRollOrder = FbxPropertyT<EFilmRollOrder>.StaticInit(this,
                "FilmRollOrder", null, default, false);
            ViewCameraToLookAt = FbxPropertyT<bool>.StaticInit(this,
                "ViewCameraToLookAt", false, false);
            ViewFrustumNearFarPlane = FbxPropertyT<bool>.StaticInit(this,
                "ViewFrustumNearFarPlane", false, false);
            ViewFrustumBackPlaneMode =
                FbxPropertyT<EFrontBackPlaneDisplayMode>.StaticInit(this,
                    "ViewFrustumBackPlaneMode", null, default, false);
            BackPlaneDistance = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneDistance", 0.0, false);
            BackPlaneDistanceMode =
                FbxPropertyT<EFrontBackPlaneDistanceMode>.StaticInit(this,
                    "BackPlaneDistanceMode", null, default, false);
            ViewFrustumFrontPlaneMode =
                FbxPropertyT<EFrontBackPlaneDisplayMode>.StaticInit(this,
                    "ViewFrustumFrontPlaneMode", null, default, false);
            FrontPlaneDistance = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneDistance", 0.0, false);
            FrontPlaneDistanceMode =
                FbxPropertyT<EFrontBackPlaneDistanceMode>.StaticInit(this,
                    "FrontPlaneDistanceMode", null, default, false);
            LockMode = FbxPropertyT<bool>.StaticInit(this, "LockMode", false,
                false);
            LockInterestNavigation = FbxPropertyT<bool>.StaticInit(this,
                "LockInterestNavigation", false, false);
            BackPlateFitImage = FbxPropertyT<bool>.StaticInit(this,
                "BackPlateFitImage", false, false);
            BackPlateCrop = FbxPropertyT<bool>.StaticInit(this,
                "BackPlateCrop", false, false);
            BackPlateCenter = FbxPropertyT<bool>.StaticInit(this,
                "BackPlateCenter", false, false);
            BackPlateKeepRatio = FbxPropertyT<bool>.StaticInit(this,
                "BackPlateKeepRatio", false, false);
            BackgroundAlphaTreshold = FbxPropertyT<double>.StaticInit(this,
                "BackgroundAlphaTreshold", 0.0, false);
            BackPlaneOffsetX = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneOffsetX", 0.0, false);
            BackPlaneOffsetY = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneOffsetY", 0.0, false);
            BackPlaneRotation = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneRotation", 0.0, false);
            BackPlaneScaleX = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneScaleX", 0.0, false);
            BackPlaneScaleY = FbxPropertyT<double>.StaticInit(this,
                "BackPlaneScaleY", 0.0, false);
            ShowBackplate = FbxPropertyT<bool>.StaticInit(this,
                "ShowBackplate", false, false);
            BackgroundTexture = FbxPropertyT<FbxObject>.StaticInit(this,
                "Background Texture", null, default, false);
            FrontPlateFitImage = FbxPropertyT<bool>.StaticInit(this,
                "FrontPlateFitImage", false, false);
            FrontPlateCrop = FbxPropertyT<bool>.StaticInit(this,
                "FrontPlateCrop", false, false);
            FrontPlateCenter = FbxPropertyT<bool>.StaticInit(this,
                "FrontPlateCenter", false, false);
            FrontPlateKeepRatio = FbxPropertyT<bool>.StaticInit(this,
                "FrontPlateKeepRatio", false, false);
            ShowFrontplate = FbxPropertyT<bool>.StaticInit(this,
                "ShowFrontplate", false, false);
            FrontPlaneOffsetX = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneOffsetX", 0.0, false);
            FrontPlaneOffsetY = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneOffsetY", 0.0, false);
            FrontPlaneRotation = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneRotation", 0.0, false);
            FrontPlaneScaleX = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneScaleX", 0.0, false);
            FrontPlaneScaleY = FbxPropertyT<double>.StaticInit(this,
                "FrontPlaneScaleY", 0.0, false);
            ForegroundTexture = FbxPropertyT<FbxObject>.StaticInit(this,
                "Foreground Texture", null, default, false);
            ForegroundOpacity = FbxPropertyT<double>.StaticInit(this,
                "Foreground Opacity", 0.0, false);
            DisplaySafeArea = FbxPropertyT<bool>.StaticInit(this,
                "DisplaySafeArea", false, false);
            DisplaySafeAreaOnRender = FbxPropertyT<bool>.StaticInit(this,
                "DisplaySafeAreaOnRender", false, false);
            SafeAreaDisplayStyle = FbxPropertyT<ESafeAreaStyle>.StaticInit(
                this, "SafeAreaDisplayStyle", null, default, false);
            SafeAreaAspectRatio = FbxPropertyT<double>.StaticInit(this,
                "SafeAreaAspectRatio", 0.0, false);
            Use2DMagnifierZoom = FbxPropertyT<bool>.StaticInit(this,
                "Use2DMagnifierZoom", false, false);
            _2DMagnifierZoom = FbxPropertyT<double>.StaticInit(this,
                "2D Magnifier Zoom", 0.0, false);
            _2DMagnifierX = FbxPropertyT<double>.StaticInit(this,
                "2D Magnifier X", 0.0, false);
            _2DMagnifierY = FbxPropertyT<double>.StaticInit(this,
                "2D Magnifier Y", 0.0, false);
            ProjectionType = FbxPropertyT<EProjectionType>.StaticInit(this,
                "CameraProjectionType", null, default, false);
            OrthoZoom = FbxPropertyT<double>.StaticInit(this, "OrthoZoom",
                0.0, false);
            UseRealTimeDOFAndAA = FbxPropertyT<bool>.StaticInit(this,
                "UseRealTimeDOFAndAA", false, false);
            UseDepthOfField = FbxPropertyT<bool>.StaticInit(this,
                "UseDepthOfField", false, false);
            FocusSource = FbxPropertyT<EFocusDistanceSource>.StaticInit(this,
                "FocusSource", null, default, false);
            FocusAngle = FbxPropertyT<double>.StaticInit(this, "FocusAngle",
                0.0, false);
            FocusDistance = FbxPropertyT<double>.StaticInit(this,
                "FocusDistance", 0.0, false);
            UseAntialiasing = FbxPropertyT<bool>.StaticInit(this,
                "UseAntialiasing", false, false);
            AntialiasingIntensity = FbxPropertyT<double>.StaticInit(this,
                "AntialiasingIntensity", 0.0, false);
            AntialiasingMethod = FbxPropertyT<EAntialiasingMethod>.StaticInit(
                this, "AntialiasingMethod", null, default, false);
            UseAccumulationBuffer = FbxPropertyT<bool>.StaticInit(this,
                "UseAccumulationBuffer", false, false);
            FrameSamplingCount = FbxPropertyT<int>.StaticInit(this,
                "FrameSamplingCount", 0, false);
            FrameSamplingType = FbxPropertyT<ESamplingType>.StaticInit(this,
                "FrameSamplingType", null, default, false);
        }

        #region implemented abstract members of NodeAttribute

        public override EAttributeType AttributeType {
            get {
                return EAttributeType.Camera;
            }
        }

        #endregion

        #region Public Types

        public enum EProjectionType
        {
            ePerspective,
            eOrthogonal,
        }

        #endregion

        #region Public Member Functions

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Attributes

        public FbxPropertyT<FbxVector3> Position;
        public FbxPropertyT<FbxVector3> UpVector;
        public FbxPropertyT<FbxVector3> InterestPosition;
        public FbxPropertyT<double> Roll;
        public FbxPropertyT<double> OpticalCenterX;
        public FbxPropertyT<double> OpticalCenterY;
        public FbxPropertyT<FbxVector3> BackgroundColor;
        public FbxPropertyT<double> TurnTable;
        public FbxPropertyT<bool> DisplayTurnTableIcon;
        public FbxPropertyT<bool> UseMotionBlur;
        public FbxPropertyT<bool> UseRealTimeMotionBlur;
        public FbxPropertyT<double> MotionBlurIntensity;
        public FbxPropertyT<EAspectRatioMode> AspectRatioMode;
        public FbxPropertyT<double> AspectWidth;
        public FbxPropertyT<double> AspectHeight;
        public FbxPropertyT<double> PixelAspectRatio;
        public FbxPropertyT<EApertureMode> ApertureMode;
        public FbxPropertyT<EGateFit> GateFit;
        public FbxPropertyT<double> FieldOfView;
        public FbxPropertyT<double> FieldOfViewX;
        public FbxPropertyT<double> FieldOfViewY;
        public FbxPropertyT<double> FocalLength;
        public FbxPropertyT<EFormat> CameraFormat;
        public FbxPropertyT<bool> UseFrameColor;
        public FbxPropertyT<FbxVector3> FrameColor;
        public FbxPropertyT<bool> ShowName;
        public FbxPropertyT<bool> ShowInfoOnMoving;
        public FbxPropertyT<bool> ShowGrid;
        public FbxPropertyT<bool> ShowOpticalCenter;
        public FbxPropertyT<bool> ShowAzimut;
        public FbxPropertyT<bool> ShowTimeCode;
        public FbxPropertyT<bool> ShowAudio;
        public FbxPropertyT<FbxVector3> AudioColor;
        public FbxPropertyT<double> NearPlane;
        public FbxPropertyT<double> FarPlane;
        public FbxPropertyT<bool> AutoComputeClipPlanes;
        public FbxPropertyT<double> FilmWidth;
        public FbxPropertyT<double> FilmHeight;
        public FbxPropertyT<double> FilmAspectRatio;
        public FbxPropertyT<double> FilmSqueezeRatio;
        public FbxPropertyT<EApertureFormat> FilmFormat;
        public FbxPropertyT<double> FilmOffsetX;
        public FbxPropertyT<double> FilmOffsetY;
        public FbxPropertyT<double> PreScale;
        public FbxPropertyT<double> FilmTranslateX;
        public FbxPropertyT<double> FilmTranslateY;
        public FbxPropertyT<double> FilmRollPivotX;
        public FbxPropertyT<double> FilmRollPivotY;
        public FbxPropertyT<double> FilmRollValue;
        public FbxPropertyT<EFilmRollOrder> FilmRollOrder;
        public FbxPropertyT<bool> ViewCameraToLookAt;
        public FbxPropertyT<bool> ViewFrustumNearFarPlane;

        public FbxPropertyT<EFrontBackPlaneDisplayMode>
            ViewFrustumBackPlaneMode;

        public FbxPropertyT<double> BackPlaneDistance;
        public FbxPropertyT<EFrontBackPlaneDistanceMode> BackPlaneDistanceMode;

        public FbxPropertyT<EFrontBackPlaneDisplayMode>
            ViewFrustumFrontPlaneMode;

        public FbxPropertyT<double> FrontPlaneDistance;
        public FbxPropertyT<EFrontBackPlaneDistanceMode> FrontPlaneDistanceMode;
        public FbxPropertyT<bool> LockMode;
        public FbxPropertyT<bool> LockInterestNavigation;
        public FbxPropertyT<bool> BackPlateFitImage;
        public FbxPropertyT<bool> BackPlateCrop;
        public FbxPropertyT<bool> BackPlateCenter;
        public FbxPropertyT<bool> BackPlateKeepRatio;
        public FbxPropertyT<double> BackgroundAlphaTreshold;
        public FbxPropertyT<double> BackPlaneOffsetX;
        public FbxPropertyT<double> BackPlaneOffsetY;
        public FbxPropertyT<double> BackPlaneRotation;
        public FbxPropertyT<double> BackPlaneScaleX;
        public FbxPropertyT<double> BackPlaneScaleY;
        public FbxPropertyT<bool> ShowBackplate;
        public FbxPropertyT<FbxObject> BackgroundTexture;
        public FbxPropertyT<bool> FrontPlateFitImage;
        public FbxPropertyT<bool> FrontPlateCrop;
        public FbxPropertyT<bool> FrontPlateCenter;
        public FbxPropertyT<bool> FrontPlateKeepRatio;
        public FbxPropertyT<bool> ShowFrontplate;
        public FbxPropertyT<double> FrontPlaneOffsetX;
        public FbxPropertyT<double> FrontPlaneOffsetY;
        public FbxPropertyT<double> FrontPlaneRotation;
        public FbxPropertyT<double> FrontPlaneScaleX;
        public FbxPropertyT<double> FrontPlaneScaleY;
        public FbxPropertyT<FbxObject> ForegroundTexture;
        public FbxPropertyT<double> ForegroundOpacity;
        public FbxPropertyT<bool> DisplaySafeArea;
        public FbxPropertyT<bool> DisplaySafeAreaOnRender;
        public FbxPropertyT<ESafeAreaStyle> SafeAreaDisplayStyle;
        public FbxPropertyT<double> SafeAreaAspectRatio;
        public FbxPropertyT<bool> Use2DMagnifierZoom;
        public FbxPropertyT<double> _2DMagnifierZoom;
        public FbxPropertyT<double> _2DMagnifierX;
        public FbxPropertyT<double> _2DMagnifierY;
        public FbxPropertyT<EProjectionType> ProjectionType;
        public FbxPropertyT<double> OrthoZoom;
        public FbxPropertyT<bool> UseRealTimeDOFAndAA;
        public FbxPropertyT<bool> UseDepthOfField;
        public FbxPropertyT<EFocusDistanceSource> FocusSource;
        public FbxPropertyT<double> FocusAngle;
        public FbxPropertyT<double> FocusDistance;
        public FbxPropertyT<bool> UseAntialiasing;
        public FbxPropertyT<double> AntialiasingIntensity;
        public FbxPropertyT<EAntialiasingMethod> AntialiasingMethod;
        public FbxPropertyT<bool> UseAccumulationBuffer;
        public FbxPropertyT<int> FrameSamplingCount;
        public FbxPropertyT<ESamplingType> FrameSamplingType;

        #endregion

        #region Functions to handle the viewing area

        public enum EFormat
        {
            eCustomFormat,
            eD1NTSC,
            eNTSC,
            ePAL,
            eD1PAL,
            eHD,
            e640x480,
            e320x200,
            e320x240,
            e128x128,
            eFullscreen
        }

        public enum EAspectRatioMode
        {
            eWindowSize,
            eFixedRatio,
            eFixedResolution,
            eFixedWidth,
            eFixedHeight
        }

        public void SetFormat(EFormat pFormat)
        {
            throw new NotImplementedException();
        }

        public EFormat GetFormat()
        {
            throw new NotImplementedException();
        }

        public void SetAspect(EAspectRatioMode pRatioMode, double pWidth, double pHeight)
        {
            throw new NotImplementedException();
        }

        public EAspectRatioMode GetAspectRatioMode()
        {
            throw new NotImplementedException();
        }

        public void SetPixelRatio(double pRatio)
        {
            throw new NotImplementedException();
        }

        public double GetPixelRatio()
        {
            throw new NotImplementedException();
        }

        public void SetNearPlane(double pDistance)
        {
            throw new NotImplementedException();
        }

        public double GetNearPlane()
        {
            throw new NotImplementedException();
        }

        public void SetFarPlane(double pDistance)
        {
            throw new NotImplementedException();
        }

        public double GetFarPlane()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Aperture and Film Functions

        public enum EApertureFormat
        {
            eCustomAperture,
            e16mmTheatrical,
            eSuper16mm,
            e35mmAcademy,
            e35mmTVProjection,
            e35mmFullAperture,
            e35mm185Projection,
            e35mmAnamorphic,
            e70mmProjection,
            eVistaVision,
            eDynaVision,
            eIMAX,
        }

        public enum EApertureMode
        {
            eHorizAndVert,
            eHorizontal,
            eVertical,
            eFocalLength,
        }

        public enum EGateFit
        {
            eFitNone,
            eFitVertical,
            eFitHorizontal,
            eFitFill,
            eFitOverscan,
            eFitStretch,
        }

        public enum EFilmRollOrder
        {
            eRotateFirst,
            eTranslateFirst,
        }

        public void SetApertureFormat(EApertureFormat pFormat)
        {
            throw new NotImplementedException();
        }

        public EApertureFormat GetApertureFormat()
        {
            throw new NotImplementedException();
        }

        public void SetApertureMode(EApertureMode pMode)
        {
            throw new NotImplementedException();
        }

        public EApertureMode GetApertureMode()
        {
            throw new NotImplementedException();
        }

        public void SetApertureWidth(double pWidth)
        {
            throw new NotImplementedException();
        }

        public double GetApertureWidth()
        {
            throw new NotImplementedException();
        }

        public void SetApertureHeight(double pHeight)
        {
            throw new NotImplementedException();
        }

        public double GetApertureHeight()
        {
            throw new NotImplementedException();
        }

        public void SetSqueezeRatio(double pRatio)
        {
            throw new NotImplementedException();
        }

        public double GetSqueezeRatio()
        {
            throw new NotImplementedException();
        }

        public double ComputeFieldOfView(double pFocalLength)
        {
            throw new NotImplementedException();
        }

        public double ComputeFocalLength(double pAngleOfView)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Functions to handle BackPlane/FrontPlane and Plate

        public enum EPlateDrawingMode
        {
            ePlateBackground,
            ePlateForeground,
            ePlateBackAndFront,
        }

        public enum EFrontBackPlaneDistanceMode
        {
            eRelativeToInterest,
            eRelativeToCamera,
        }

        public enum EFrontBackPlaneDisplayMode
        {
            ePlanesDisabled,
            ePlanesAlways,
            ePlanesWhenMedia,
        }

        public void SetBackgroundFileName(string pFileName)
        {
            throw new NotImplementedException();
        }

        public string GetBackgroundFileName()
        {
            throw new NotImplementedException();
        }

        public void SetBackgroundMediaName(string pFileName)
        {
            throw new NotImplementedException();
        }

        public string GetBackgroundMediaName()
        {
            throw new NotImplementedException();
        }

        public void SetForegroundFileName(string pFileName)
        {
            throw new NotImplementedException();
        }

        public string GetForegroundFileName()
        {
            throw new NotImplementedException();
        }

        public void SetForegroundMediaName(string pFileName)
        {
            throw new NotImplementedException();
        }

        public string GetForegroundMediaName()
        {
            throw new NotImplementedException();
        }

        public void SetBackgroundAlphaTreshold(double pThreshold)
        {
            throw new NotImplementedException();
        }

        public double GetBackgroundAlphaTreshold()
        {
            throw new NotImplementedException();
        }

        public void SetBackPlateFitImage(bool pFitImage)
        {
            throw new NotImplementedException();
        }

        public bool GetBackPlateFitImage()
        {
            throw new NotImplementedException();
        }

        public void SetBackPlateCrop(bool pCrop)
        {
            throw new NotImplementedException();
        }

        public bool GetBackPlateCrop()
        {
            throw new NotImplementedException();
        }

        public void SetBackPlateCenter(bool pCenter)
        {
            throw new NotImplementedException();
        }

        public bool GetBackPlateCenter()
        {
            throw new NotImplementedException();
        }

        public void SetBackPlateKeepRatio(bool pKeepRatio)
        {
            throw new NotImplementedException();
        }

        public bool GetBackPlateKeepRatio()
        {
            throw new NotImplementedException();
        }

        public void SetShowFrontPlate(bool pEnable)
        {
            throw new NotImplementedException();
        }

        public bool GetShowFrontPlate()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlateFitImage(bool pFrontPlateFitImage)
        {
            throw new NotImplementedException();
        }

        public bool GetFrontPlateFitImage()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlateCrop(bool pFrontPlateCrop)
        {
            throw new NotImplementedException();
        }

        public bool GetFrontPlateCrop()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlateCenter(bool pFrontPlateCenter)
        {
            throw new NotImplementedException();
        }

        public bool GetFrontPlateCenter()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlateKeepRatio(bool pFrontPlateKeepRatio)
        {
            throw new NotImplementedException();
        }

        public bool GetFrontPlateKeepRatio()
        {
            throw new NotImplementedException();
        }

        public void SetForegroundOpacity(double pOpacity)
        {
            throw new NotImplementedException();
        }

        public double GetForegroundOpacity()
        {
            throw new NotImplementedException();
        }

        public void SetForegroundTexture(FbxTexture pTexture)
        {
            throw new NotImplementedException();
        }

        public FbxTexture GetForegroundTexture()
        {
            throw new NotImplementedException();
        }

        public void SetBackPlaneDistanceMode(EFrontBackPlaneDistanceMode pMode)
        {
            throw new NotImplementedException();
        }

        public EFrontBackPlaneDistanceMode GetBackPlaneDistanceMode()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlaneDistance(double pDistance)
        {
            throw new NotImplementedException();
        }

        public double GetFrontPlaneDistance()
        {
            throw new NotImplementedException();
        }

        public void SetFrontPlaneDistanceMode(EFrontBackPlaneDistanceMode pMode)
        {
            throw new NotImplementedException();
        }

        public EFrontBackPlaneDistanceMode GetFrontPlaneDistanceMode()
        {
            throw new NotImplementedException();
        }

        public void SetViewFrustumFrontPlaneMode(EFrontBackPlaneDisplayMode pMode)
        {
            throw new NotImplementedException();
        }

        public EFrontBackPlaneDisplayMode GetViewFrustumFrontPlaneMode()
        {
            throw new NotImplementedException();
        }

        public void SetViewFrustumBackPlaneMode(EFrontBackPlaneDisplayMode pMode)
        {
            throw new NotImplementedException();
        }

        public EFrontBackPlaneDisplayMode GetViewFrustumBackPlaneMode()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Camera View Functions

        public enum ESafeAreaStyle
        {
            eSafeAreaRound,
            eSafeAreaSquare,
        }

        public void SetViewCameraInterest(bool pEnable)
        {
            throw new NotImplementedException();
        }

        public bool GetViewCameraInterest()
        {
            throw new NotImplementedException();
        }

        public void SetViewNearFarPlanes(bool pEnable)
        {
            throw new NotImplementedException();
        }

        public bool GetViewNearFarPlanes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Render Functions

        public enum ERenderOptionsUsageTime
        {
            eInteractive,
            eOnDemand,
        }

        public enum EAntialiasingMethod
        {
            eAAOversampling,
            eAAHardware,
        }

        public enum ESamplingType
        {
            eSamplingUniform,
            eSamplingStochastic,
        }

        public enum EFocusDistanceSource
        {
            eFocusSrcCameraInterest,
            eFocusSpecificDistance,
        }

        #endregion

        #region Utility Functions

        public FbxVector4 EvaluatePosition()
        {
            return EvaluatePosition(FbxTime.Zero);
        }
        public FbxVector4 EvaluatePosition(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public FbxVector4 EvaluateLookAtPosition()
        {
            return EvaluateLookAtPosition(FbxTime.Zero);
        }
        public FbxVector4 EvaluateLookAtPosition(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public FbxVector4 EvaluateUpDirection(FbxVector4 pCameraPosition, FbxVector4 pLookAtPosition)
        {
            return EvaluateUpDirection(pCameraPosition, pLookAtPosition, FbxTime.Zero);
        }
        public FbxVector4 EvaluateUpDirection(FbxVector4 pCameraPosition, FbxVector4 pLookAtPosition, FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix ComputeProjectionMatrix(int pWidth, int pHeight, bool pVerticalFOV = true)
        {
            throw new NotImplementedException();
        }

        public bool IsBoundingBoxInView(FbxMatrix pWorldToScreen, FbxMatrix pWorldToCamera, FbxVector4 [] pPoints)
        {
            if (pPoints.Length != 8) throw new ArgumentOutOfRangeException("pPoints");

            throw new NotImplementedException();
        }

        public bool IsPointInView(FbxMatrix pWorldToScreen, FbxMatrix pWorldToCamera, FbxVector4 pPoint)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix ComputeWorldToScreen(int pPixelWidth, int pPixelHeight, FbxMatrix pWorldToCamera)
        {
            throw new NotImplementedException();
        }

        public FbxVector4 ComputeScreenToWorld(float pX, float pY, float pWidth, float pHeight)
        {
            return ComputeScreenToWorld(pX, pY, pWidth, pHeight, FbxTime.Infinite);
        }
        public FbxVector4 ComputeScreenToWorld(float pX, float pY, float pWidth, float pHeight, FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

