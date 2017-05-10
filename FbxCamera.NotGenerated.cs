using System;

namespace FbxSharp
{
    public class FbxCamera : FbxNodeAttribute
    {
        public FbxCamera(string name="")
            : base(name)
        {
            Properties.Add(Position);
            Properties.Add(UpVector);
            Properties.Add(InterestPosition);
            Properties.Add(Roll);
            Properties.Add(OpticalCenterX);
            Properties.Add(OpticalCenterY);
            Properties.Add(BackgroundColor);
            Properties.Add(TurnTable);
            Properties.Add(DisplayTurnTableIcon);
            Properties.Add(UseMotionBlur);
            Properties.Add(UseRealTimeMotionBlur);
            Properties.Add(MotionBlurIntensity);
            Properties.Add(AspectRatioMode);
            Properties.Add(AspectWidth);
            Properties.Add(AspectHeight);
            Properties.Add(PixelAspectRatio);
            Properties.Add(ApertureMode);
            Properties.Add(GateFit);
            Properties.Add(FieldOfView);
            Properties.Add(FieldOfViewX);
            Properties.Add(FieldOfViewY);
            Properties.Add(FocalLength);
            Properties.Add(CameraFormat);
            Properties.Add(UseFrameColor);
            Properties.Add(FrameColor);
            Properties.Add(ShowName);
            Properties.Add(ShowInfoOnMoving);
            Properties.Add(ShowGrid);
            Properties.Add(ShowOpticalCenter);
            Properties.Add(ShowAzimut);
            Properties.Add(ShowTimeCode);
            Properties.Add(ShowAudio);
            Properties.Add(AudioColor);
            Properties.Add(NearPlane);
            Properties.Add(FarPlane);
            Properties.Add(AutoComputeClipPlanes);
            Properties.Add(FilmWidth);
            Properties.Add(FilmHeight);
            Properties.Add(FilmAspectRatio);
            Properties.Add(FilmSqueezeRatio);
            Properties.Add(FilmFormat);
            Properties.Add(FilmOffsetX);
            Properties.Add(FilmOffsetY);
            Properties.Add(PreScale);
            Properties.Add(FilmTranslateX);
            Properties.Add(FilmTranslateY);
            Properties.Add(FilmRollPivotX);
            Properties.Add(FilmRollPivotY);
            Properties.Add(FilmRollValue);
            Properties.Add(FilmRollOrder);
            Properties.Add(ViewCameraToLookAt);
            Properties.Add(ViewFrustumNearFarPlane);
            Properties.Add(ViewFrustumBackPlaneMode);
            Properties.Add(BackPlaneDistance);
            Properties.Add(BackPlaneDistanceMode);
            Properties.Add(ViewFrustumFrontPlaneMode);
            Properties.Add(FrontPlaneDistance);
            Properties.Add(FrontPlaneDistanceMode);
            Properties.Add(LockMode);
            Properties.Add(LockInterestNavigation);
            Properties.Add(BackPlateFitImage);
            Properties.Add(BackPlateCrop);
            Properties.Add(BackPlateCenter);
            Properties.Add(BackPlateKeepRatio);
            Properties.Add(BackgroundAlphaTreshold);
            Properties.Add(BackPlaneOffsetX);
            Properties.Add(BackPlaneOffsetY);
            Properties.Add(BackPlaneRotation);
            Properties.Add(BackPlaneScaleX);
            Properties.Add(BackPlaneScaleY);
            Properties.Add(ShowBackplate);
            Properties.Add(BackgroundTexture);
            Properties.Add(FrontPlateFitImage);
            Properties.Add(FrontPlateCrop);
            Properties.Add(FrontPlateCenter);
            Properties.Add(FrontPlateKeepRatio);
            Properties.Add(ShowFrontplate);
            Properties.Add(FrontPlaneOffsetX);
            Properties.Add(FrontPlaneOffsetY);
            Properties.Add(FrontPlaneRotation);
            Properties.Add(FrontPlaneScaleX);
            Properties.Add(FrontPlaneScaleY);
            Properties.Add(ForegroundTexture);
            Properties.Add(ForegroundOpacity);
            Properties.Add(DisplaySafeArea);
            Properties.Add(DisplaySafeAreaOnRender);
            Properties.Add(SafeAreaDisplayStyle);
            Properties.Add(SafeAreaAspectRatio);
            Properties.Add(Use2DMagnifierZoom);
            Properties.Add(_2DMagnifierZoom);
            Properties.Add(_2DMagnifierX);
            Properties.Add(_2DMagnifierY);
            Properties.Add(ProjectionType);
            Properties.Add(OrthoZoom);
            Properties.Add(UseRealTimeDOFAndAA);
            Properties.Add(UseDepthOfField);
            Properties.Add(FocusSource);
            Properties.Add(FocusAngle);
            Properties.Add(FocusDistance);
            Properties.Add(UseAntialiasing);
            Properties.Add(AntialiasingIntensity);
            Properties.Add(AntialiasingMethod);
            Properties.Add(UseAccumulationBuffer);
            Properties.Add(FrameSamplingCount);
            Properties.Add(FrameSamplingType);
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

        public FbxPropertyT<FbxVector3>                      Position                    = new FbxPropertyT<FbxVector3>                    ("Position");
        public FbxPropertyT<FbxVector3>                      UpVector                    = new FbxPropertyT<FbxVector3>                    ("UpVector");
        public FbxPropertyT<FbxVector3>                      InterestPosition            = new FbxPropertyT<FbxVector3>                    ("InterestPosition");
        public FbxPropertyT<double>                       Roll                        = new FbxPropertyT<double>                     ("Roll");
        public FbxPropertyT<double>                       OpticalCenterX              = new FbxPropertyT<double>                     ("OpticalCenterX");
        public FbxPropertyT<double>                       OpticalCenterY              = new FbxPropertyT<double>                     ("OpticalCenterY");
        public FbxPropertyT<FbxVector3>                      BackgroundColor             = new FbxPropertyT<FbxVector3>                    ("BackgroundColor");
        public FbxPropertyT<double>                       TurnTable                   = new FbxPropertyT<double>                     ("TurnTable");
        public FbxPropertyT<bool>                         DisplayTurnTableIcon        = new FbxPropertyT<bool>                       ("DisplayTurnTableIcon");
        public FbxPropertyT<bool>                         UseMotionBlur               = new FbxPropertyT<bool>                       ("UseMotionBlur");
        public FbxPropertyT<bool>                         UseRealTimeMotionBlur       = new FbxPropertyT<bool>                       ("UseRealTimeMotionBlur");
        public FbxPropertyT<double>                       MotionBlurIntensity         = new FbxPropertyT<double>                     ("Motion Blur Intensity");
        public FbxPropertyT<EAspectRatioMode>             AspectRatioMode             = new FbxPropertyT<EAspectRatioMode>           ("AspectRatioMode");
        public FbxPropertyT<double>                       AspectWidth                 = new FbxPropertyT<double>                     ("AspectWidth");
        public FbxPropertyT<double>                       AspectHeight                = new FbxPropertyT<double>                     ("AspectHeight");
        public FbxPropertyT<double>                       PixelAspectRatio            = new FbxPropertyT<double>                     ("PixelAspectRatio");
        public FbxPropertyT<EApertureMode>                ApertureMode                = new FbxPropertyT<EApertureMode>              ("ApertureMode");
        public FbxPropertyT<EGateFit>                     GateFit                     = new FbxPropertyT<EGateFit>                   ("GateFit");
        public FbxPropertyT<double>                       FieldOfView                 = new FbxPropertyT<double>                     ("FieldOfView");
        public FbxPropertyT<double>                       FieldOfViewX                = new FbxPropertyT<double>                     ("FieldOfViewX");
        public FbxPropertyT<double>                       FieldOfViewY                = new FbxPropertyT<double>                     ("FieldOfViewY");
        public FbxPropertyT<double>                       FocalLength                 = new FbxPropertyT<double>                     ("FocalLength");
        public FbxPropertyT<EFormat>                      CameraFormat                = new FbxPropertyT<EFormat>                    ("CameraFormat");
        public FbxPropertyT<bool>                         UseFrameColor               = new FbxPropertyT<bool>                       ("UseFrameColor");
        public FbxPropertyT<FbxVector3>                      FrameColor                  = new FbxPropertyT<FbxVector3>                    ("FrameColor");
        public FbxPropertyT<bool>                         ShowName                    = new FbxPropertyT<bool>                       ("ShowName");
        public FbxPropertyT<bool>                         ShowInfoOnMoving            = new FbxPropertyT<bool>                       ("ShowInfoOnMoving");
        public FbxPropertyT<bool>                         ShowGrid                    = new FbxPropertyT<bool>                       ("ShowGrid");
        public FbxPropertyT<bool>                         ShowOpticalCenter           = new FbxPropertyT<bool>                       ("ShowOpticalCenter");
        public FbxPropertyT<bool>                         ShowAzimut                  = new FbxPropertyT<bool>                       ("ShowAzimut");
        public FbxPropertyT<bool>                         ShowTimeCode                = new FbxPropertyT<bool>                       ("ShowTimeCode");
        public FbxPropertyT<bool>                         ShowAudio                   = new FbxPropertyT<bool>                       ("ShowAudio");
        public FbxPropertyT<FbxVector3>                      AudioColor                  = new FbxPropertyT<FbxVector3>                    ("AudioColor");
        public FbxPropertyT<double>                       NearPlane                   = new FbxPropertyT<double>                     ("NearPlane");
        public FbxPropertyT<double>                       FarPlane                    = new FbxPropertyT<double>                     ("FarPlane");
        public FbxPropertyT<bool>                         AutoComputeClipPlanes       = new FbxPropertyT<bool>                       ("AutoComputeClipPanes");
        public FbxPropertyT<double>                       FilmWidth                   = new FbxPropertyT<double>                     ("FilmWidth");
        public FbxPropertyT<double>                       FilmHeight                  = new FbxPropertyT<double>                     ("FilmHeight");
        public FbxPropertyT<double>                       FilmAspectRatio             = new FbxPropertyT<double>                     ("FilmAspectRatio");
        public FbxPropertyT<double>                       FilmSqueezeRatio            = new FbxPropertyT<double>                     ("FilmSqueezeRatio");
        public FbxPropertyT<EApertureFormat>              FilmFormat                  = new FbxPropertyT<EApertureFormat>            ("FilmFormatIndex");
        public FbxPropertyT<double>                       FilmOffsetX                 = new FbxPropertyT<double>                     ("FilmOffsetX");
        public FbxPropertyT<double>                       FilmOffsetY                 = new FbxPropertyT<double>                     ("FilmOffsetY");
        public FbxPropertyT<double>                       PreScale                    = new FbxPropertyT<double>                     ("PreScale");
        public FbxPropertyT<double>                       FilmTranslateX              = new FbxPropertyT<double>                     ("FilmTranslateX");
        public FbxPropertyT<double>                       FilmTranslateY              = new FbxPropertyT<double>                     ("FilmTranslateY");
        public FbxPropertyT<double>                       FilmRollPivotX              = new FbxPropertyT<double>                     ("FilmRollPivotX");
        public FbxPropertyT<double>                       FilmRollPivotY              = new FbxPropertyT<double>                     ("FilmRollPivotY");
        public FbxPropertyT<double>                       FilmRollValue               = new FbxPropertyT<double>                     ("FilmRollValue");
        public FbxPropertyT<EFilmRollOrder>               FilmRollOrder               = new FbxPropertyT<EFilmRollOrder>             ("FilmRollOrder");
        public FbxPropertyT<bool>                         ViewCameraToLookAt          = new FbxPropertyT<bool>                       ("ViewCameraToLookAt");
        public FbxPropertyT<bool>                         ViewFrustumNearFarPlane     = new FbxPropertyT<bool>                       ("ViewFrustumNearFarPlane");
        public FbxPropertyT<EFrontBackPlaneDisplayMode>   ViewFrustumBackPlaneMode    = new FbxPropertyT<EFrontBackPlaneDisplayMode> ("ViewFrustumBackPlaneMode");
        public FbxPropertyT<double>                       BackPlaneDistance           = new FbxPropertyT<double>                     ("BackPlaneDistance");
        public FbxPropertyT<EFrontBackPlaneDistanceMode>  BackPlaneDistanceMode       = new FbxPropertyT<EFrontBackPlaneDistanceMode>("BackPlaneDistanceMode");
        public FbxPropertyT<EFrontBackPlaneDisplayMode>   ViewFrustumFrontPlaneMode   = new FbxPropertyT<EFrontBackPlaneDisplayMode> ("ViewFrustumFrontPlaneMode");
        public FbxPropertyT<double>                       FrontPlaneDistance          = new FbxPropertyT<double>                     ("FrontPlaneDistance");
        public FbxPropertyT<EFrontBackPlaneDistanceMode>  FrontPlaneDistanceMode      = new FbxPropertyT<EFrontBackPlaneDistanceMode>("FrontPlaneDistanceMode");
        public FbxPropertyT<bool>                         LockMode                    = new FbxPropertyT<bool>                       ("LockMode");
        public FbxPropertyT<bool>                         LockInterestNavigation      = new FbxPropertyT<bool>                       ("LockInterestNavigation");
        public FbxPropertyT<bool>                         BackPlateFitImage           = new FbxPropertyT<bool>                       ("BackPlateFitImage");
        public FbxPropertyT<bool>                         BackPlateCrop               = new FbxPropertyT<bool>                       ("BackPlateCrop");
        public FbxPropertyT<bool>                         BackPlateCenter             = new FbxPropertyT<bool>                       ("BackPlateCenter");
        public FbxPropertyT<bool>                         BackPlateKeepRatio          = new FbxPropertyT<bool>                       ("BackPlateKeepRatio");
        public FbxPropertyT<double>                       BackgroundAlphaTreshold     = new FbxPropertyT<double>                     ("BackgroundAlphaTreshold");
        public FbxPropertyT<double>                       BackPlaneOffsetX            = new FbxPropertyT<double>                     ("BackPlaneOffsetX");
        public FbxPropertyT<double>                       BackPlaneOffsetY            = new FbxPropertyT<double>                     ("BackPlaneOffsetY");
        public FbxPropertyT<double>                       BackPlaneRotation           = new FbxPropertyT<double>                     ("BackPlaneRotation");
        public FbxPropertyT<double>                       BackPlaneScaleX             = new FbxPropertyT<double>                     ("BackPlaneScaleX");
        public FbxPropertyT<double>                       BackPlaneScaleY             = new FbxPropertyT<double>                     ("BackPlaneScaleY");
        public FbxPropertyT<bool>                         ShowBackplate               = new FbxPropertyT<bool>                       ("ShowBackplate");
        public FbxPropertyT<FbxObject>                    BackgroundTexture           = new FbxPropertyT<FbxObject>                  ("Background Texture");
        public FbxPropertyT<bool>                         FrontPlateFitImage          = new FbxPropertyT<bool>                       ("FrontPlateFitImage");
        public FbxPropertyT<bool>                         FrontPlateCrop              = new FbxPropertyT<bool>                       ("FrontPlateCrop");
        public FbxPropertyT<bool>                         FrontPlateCenter            = new FbxPropertyT<bool>                       ("FrontPlateCenter");
        public FbxPropertyT<bool>                         FrontPlateKeepRatio         = new FbxPropertyT<bool>                       ("FrontPlateKeepRatio");
        public FbxPropertyT<bool>                         ShowFrontplate              = new FbxPropertyT<bool>                       ("ShowFrontplate");
        public FbxPropertyT<double>                       FrontPlaneOffsetX           = new FbxPropertyT<double>                     ("FrontPlaneOffsetX");
        public FbxPropertyT<double>                       FrontPlaneOffsetY           = new FbxPropertyT<double>                     ("FrontPlaneOffsetY");
        public FbxPropertyT<double>                       FrontPlaneRotation          = new FbxPropertyT<double>                     ("FrontPlaneRotation");
        public FbxPropertyT<double>                       FrontPlaneScaleX            = new FbxPropertyT<double>                     ("FrontPlaneScaleX");
        public FbxPropertyT<double>                       FrontPlaneScaleY            = new FbxPropertyT<double>                     ("FrontPlaneScaleY");
        public FbxPropertyT<FbxObject>                    ForegroundTexture           = new FbxPropertyT<FbxObject>                  ("Foreground Texture");
        public FbxPropertyT<double>                       ForegroundOpacity           = new FbxPropertyT<double>                     ("Foreground Opacity");
        public FbxPropertyT<bool>                         DisplaySafeArea             = new FbxPropertyT<bool>                       ("DisplaySafeArea");
        public FbxPropertyT<bool>                         DisplaySafeAreaOnRender     = new FbxPropertyT<bool>                       ("DisplaySafeAreaOnRender");
        public FbxPropertyT<ESafeAreaStyle>               SafeAreaDisplayStyle        = new FbxPropertyT<ESafeAreaStyle>             ("SafeAreaDisplayStyle");
        public FbxPropertyT<double>                       SafeAreaAspectRatio         = new FbxPropertyT<double>                     ("SafeAreaAspectRatio");
        public FbxPropertyT<bool>                         Use2DMagnifierZoom          = new FbxPropertyT<bool>                       ("Use2DMagnifierZoom");
        public FbxPropertyT<double>                       _2DMagnifierZoom            = new FbxPropertyT<double>                     ("2D Magnifier Zoom");
        public FbxPropertyT<double>                       _2DMagnifierX               = new FbxPropertyT<double>                     ("2D Magnifier X");
        public FbxPropertyT<double>                       _2DMagnifierY               = new FbxPropertyT<double>                     ("2D Magnifier Y");
        public FbxPropertyT<EProjectionType>              ProjectionType              = new FbxPropertyT<EProjectionType>            ("CameraProjectionType");
        public FbxPropertyT<double>                       OrthoZoom                   = new FbxPropertyT<double>                     ("OrthoZoom");
        public FbxPropertyT<bool>                         UseRealTimeDOFAndAA         = new FbxPropertyT<bool>                       ("UseRealTimeDOFAndAA");
        public FbxPropertyT<bool>                         UseDepthOfField             = new FbxPropertyT<bool>                       ("UseDepthOfField");
        public FbxPropertyT<EFocusDistanceSource>         FocusSource                 = new FbxPropertyT<EFocusDistanceSource>       ("FocusSource");
        public FbxPropertyT<double>                       FocusAngle                  = new FbxPropertyT<double>                     ("FocusAngle");
        public FbxPropertyT<double>                       FocusDistance               = new FbxPropertyT<double>                     ("FocusDistance");
        public FbxPropertyT<bool>                         UseAntialiasing             = new FbxPropertyT<bool>                       ("UseAntialiasing");
        public FbxPropertyT<double>                       AntialiasingIntensity       = new FbxPropertyT<double>                     ("AntialiasingIntensity");
        public FbxPropertyT<EAntialiasingMethod>          AntialiasingMethod          = new FbxPropertyT<EAntialiasingMethod>        ("AntialiasingMethod");
        public FbxPropertyT<bool>                         UseAccumulationBuffer       = new FbxPropertyT<bool>                       ("UseAccumulationBuffer");
        public FbxPropertyT<int>                          FrameSamplingCount          = new FbxPropertyT<int>                        ("FrameSamplingCount");
        public FbxPropertyT<ESamplingType>                FrameSamplingType           = new FbxPropertyT<ESamplingType>              ("FrameSamplingType");

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

