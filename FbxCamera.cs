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

        public PropertyT<Vector3>                      Position                    = new PropertyT<Vector3>                    ("Position");
        public PropertyT<Vector3>                      UpVector                    = new PropertyT<Vector3>                    ("UpVector");
        public PropertyT<Vector3>                      InterestPosition            = new PropertyT<Vector3>                    ("InterestPosition");
        public PropertyT<double>                       Roll                        = new PropertyT<double>                     ("Roll");
        public PropertyT<double>                       OpticalCenterX              = new PropertyT<double>                     ("OpticalCenterX");
        public PropertyT<double>                       OpticalCenterY              = new PropertyT<double>                     ("OpticalCenterY");
        public PropertyT<Vector3>                      BackgroundColor             = new PropertyT<Vector3>                    ("BackgroundColor");
        public PropertyT<double>                       TurnTable                   = new PropertyT<double>                     ("TurnTable");
        public PropertyT<bool>                         DisplayTurnTableIcon        = new PropertyT<bool>                       ("DisplayTurnTableIcon");
        public PropertyT<bool>                         UseMotionBlur               = new PropertyT<bool>                       ("UseMotionBlur");
        public PropertyT<bool>                         UseRealTimeMotionBlur       = new PropertyT<bool>                       ("UseRealTimeMotionBlur");
        public PropertyT<double>                       MotionBlurIntensity         = new PropertyT<double>                     ("Motion Blur Intensity");
        public PropertyT<EAspectRatioMode>             AspectRatioMode             = new PropertyT<EAspectRatioMode>           ("AspectRatioMode");
        public PropertyT<double>                       AspectWidth                 = new PropertyT<double>                     ("AspectWidth");
        public PropertyT<double>                       AspectHeight                = new PropertyT<double>                     ("AspectHeight");
        public PropertyT<double>                       PixelAspectRatio            = new PropertyT<double>                     ("PixelAspectRatio");
        public PropertyT<EApertureMode>                ApertureMode                = new PropertyT<EApertureMode>              ("ApertureMode");
        public PropertyT<EGateFit>                     GateFit                     = new PropertyT<EGateFit>                   ("GateFit");
        public PropertyT<double>                       FieldOfView                 = new PropertyT<double>                     ("FieldOfView");
        public PropertyT<double>                       FieldOfViewX                = new PropertyT<double>                     ("FieldOfViewX");
        public PropertyT<double>                       FieldOfViewY                = new PropertyT<double>                     ("FieldOfViewY");
        public PropertyT<double>                       FocalLength                 = new PropertyT<double>                     ("FocalLength");
        public PropertyT<EFormat>                      CameraFormat                = new PropertyT<EFormat>                    ("CameraFormat");
        public PropertyT<bool>                         UseFrameColor               = new PropertyT<bool>                       ("UseFrameColor");
        public PropertyT<Vector3>                      FrameColor                  = new PropertyT<Vector3>                    ("FrameColor");
        public PropertyT<bool>                         ShowName                    = new PropertyT<bool>                       ("ShowName");
        public PropertyT<bool>                         ShowInfoOnMoving            = new PropertyT<bool>                       ("ShowInfoOnMoving");
        public PropertyT<bool>                         ShowGrid                    = new PropertyT<bool>                       ("ShowGrid");
        public PropertyT<bool>                         ShowOpticalCenter           = new PropertyT<bool>                       ("ShowOpticalCenter");
        public PropertyT<bool>                         ShowAzimut                  = new PropertyT<bool>                       ("ShowAzimut");
        public PropertyT<bool>                         ShowTimeCode                = new PropertyT<bool>                       ("ShowTimeCode");
        public PropertyT<bool>                         ShowAudio                   = new PropertyT<bool>                       ("ShowAudio");
        public PropertyT<Vector3>                      AudioColor                  = new PropertyT<Vector3>                    ("AudioColor");
        public PropertyT<double>                       NearPlane                   = new PropertyT<double>                     ("NearPlane");
        public PropertyT<double>                       FarPlane                    = new PropertyT<double>                     ("FarPlane");
        public PropertyT<bool>                         AutoComputeClipPlanes       = new PropertyT<bool>                       ("AutoComputeClipPanes");
        public PropertyT<double>                       FilmWidth                   = new PropertyT<double>                     ("FilmWidth");
        public PropertyT<double>                       FilmHeight                  = new PropertyT<double>                     ("FilmHeight");
        public PropertyT<double>                       FilmAspectRatio             = new PropertyT<double>                     ("FilmAspectRatio");
        public PropertyT<double>                       FilmSqueezeRatio            = new PropertyT<double>                     ("FilmSqueezeRatio");
        public PropertyT<EApertureFormat>              FilmFormat                  = new PropertyT<EApertureFormat>            ("FilmFormatIndex");
        public PropertyT<double>                       FilmOffsetX                 = new PropertyT<double>                     ("FilmOffsetX");
        public PropertyT<double>                       FilmOffsetY                 = new PropertyT<double>                     ("FilmOffsetY");
        public PropertyT<double>                       PreScale                    = new PropertyT<double>                     ("PreScale");
        public PropertyT<double>                       FilmTranslateX              = new PropertyT<double>                     ("FilmTranslateX");
        public PropertyT<double>                       FilmTranslateY              = new PropertyT<double>                     ("FilmTranslateY");
        public PropertyT<double>                       FilmRollPivotX              = new PropertyT<double>                     ("FilmRollPivotX");
        public PropertyT<double>                       FilmRollPivotY              = new PropertyT<double>                     ("FilmRollPivotY");
        public PropertyT<double>                       FilmRollValue               = new PropertyT<double>                     ("FilmRollValue");
        public PropertyT<EFilmRollOrder>               FilmRollOrder               = new PropertyT<EFilmRollOrder>             ("FilmRollOrder");
        public PropertyT<bool>                         ViewCameraToLookAt          = new PropertyT<bool>                       ("ViewCameraToLookAt");
        public PropertyT<bool>                         ViewFrustumNearFarPlane     = new PropertyT<bool>                       ("ViewFrustumNearFarPlane");
        public PropertyT<EFrontBackPlaneDisplayMode>   ViewFrustumBackPlaneMode    = new PropertyT<EFrontBackPlaneDisplayMode> ("ViewFrustumBackPlaneMode");
        public PropertyT<double>                       BackPlaneDistance           = new PropertyT<double>                     ("BackPlaneDistance");
        public PropertyT<EFrontBackPlaneDistanceMode>  BackPlaneDistanceMode       = new PropertyT<EFrontBackPlaneDistanceMode>("BackPlaneDistanceMode");
        public PropertyT<EFrontBackPlaneDisplayMode>   ViewFrustumFrontPlaneMode   = new PropertyT<EFrontBackPlaneDisplayMode> ("ViewFrustumFrontPlaneMode");
        public PropertyT<double>                       FrontPlaneDistance          = new PropertyT<double>                     ("FrontPlaneDistance");
        public PropertyT<EFrontBackPlaneDistanceMode>  FrontPlaneDistanceMode      = new PropertyT<EFrontBackPlaneDistanceMode>("FrontPlaneDistanceMode");
        public PropertyT<bool>                         LockMode                    = new PropertyT<bool>                       ("LockMode");
        public PropertyT<bool>                         LockInterestNavigation      = new PropertyT<bool>                       ("LockInterestNavigation");
        public PropertyT<bool>                         BackPlateFitImage           = new PropertyT<bool>                       ("BackPlateFitImage");
        public PropertyT<bool>                         BackPlateCrop               = new PropertyT<bool>                       ("BackPlateCrop");
        public PropertyT<bool>                         BackPlateCenter             = new PropertyT<bool>                       ("BackPlateCenter");
        public PropertyT<bool>                         BackPlateKeepRatio          = new PropertyT<bool>                       ("BackPlateKeepRatio");
        public PropertyT<double>                       BackgroundAlphaTreshold     = new PropertyT<double>                     ("BackgroundAlphaTreshold");
        public PropertyT<double>                       BackPlaneOffsetX            = new PropertyT<double>                     ("BackPlaneOffsetX");
        public PropertyT<double>                       BackPlaneOffsetY            = new PropertyT<double>                     ("BackPlaneOffsetY");
        public PropertyT<double>                       BackPlaneRotation           = new PropertyT<double>                     ("BackPlaneRotation");
        public PropertyT<double>                       BackPlaneScaleX             = new PropertyT<double>                     ("BackPlaneScaleX");
        public PropertyT<double>                       BackPlaneScaleY             = new PropertyT<double>                     ("BackPlaneScaleY");
        public PropertyT<bool>                         ShowBackplate               = new PropertyT<bool>                       ("ShowBackplate");
        public PropertyT<FbxObject>                    BackgroundTexture           = new PropertyT<FbxObject>                  ("Background Texture");
        public PropertyT<bool>                         FrontPlateFitImage          = new PropertyT<bool>                       ("FrontPlateFitImage");
        public PropertyT<bool>                         FrontPlateCrop              = new PropertyT<bool>                       ("FrontPlateCrop");
        public PropertyT<bool>                         FrontPlateCenter            = new PropertyT<bool>                       ("FrontPlateCenter");
        public PropertyT<bool>                         FrontPlateKeepRatio         = new PropertyT<bool>                       ("FrontPlateKeepRatio");
        public PropertyT<bool>                         ShowFrontplate              = new PropertyT<bool>                       ("ShowFrontplate");
        public PropertyT<double>                       FrontPlaneOffsetX           = new PropertyT<double>                     ("FrontPlaneOffsetX");
        public PropertyT<double>                       FrontPlaneOffsetY           = new PropertyT<double>                     ("FrontPlaneOffsetY");
        public PropertyT<double>                       FrontPlaneRotation          = new PropertyT<double>                     ("FrontPlaneRotation");
        public PropertyT<double>                       FrontPlaneScaleX            = new PropertyT<double>                     ("FrontPlaneScaleX");
        public PropertyT<double>                       FrontPlaneScaleY            = new PropertyT<double>                     ("FrontPlaneScaleY");
        public PropertyT<FbxObject>                    ForegroundTexture           = new PropertyT<FbxObject>                  ("Foreground Texture");
        public PropertyT<double>                       ForegroundOpacity           = new PropertyT<double>                     ("Foreground Opacity");
        public PropertyT<bool>                         DisplaySafeArea             = new PropertyT<bool>                       ("DisplaySafeArea");
        public PropertyT<bool>                         DisplaySafeAreaOnRender     = new PropertyT<bool>                       ("DisplaySafeAreaOnRender");
        public PropertyT<ESafeAreaStyle>               SafeAreaDisplayStyle        = new PropertyT<ESafeAreaStyle>             ("SafeAreaDisplayStyle");
        public PropertyT<double>                       SafeAreaAspectRatio         = new PropertyT<double>                     ("SafeAreaAspectRatio");
        public PropertyT<bool>                         Use2DMagnifierZoom          = new PropertyT<bool>                       ("Use2DMagnifierZoom");
        public PropertyT<double>                       _2DMagnifierZoom            = new PropertyT<double>                     ("2D Magnifier Zoom");
        public PropertyT<double>                       _2DMagnifierX               = new PropertyT<double>                     ("2D Magnifier X");
        public PropertyT<double>                       _2DMagnifierY               = new PropertyT<double>                     ("2D Magnifier Y");
        public PropertyT<EProjectionType>              ProjectionType              = new PropertyT<EProjectionType>            ("CameraProjectionType");
        public PropertyT<double>                       OrthoZoom                   = new PropertyT<double>                     ("OrthoZoom");
        public PropertyT<bool>                         UseRealTimeDOFAndAA         = new PropertyT<bool>                       ("UseRealTimeDOFAndAA");
        public PropertyT<bool>                         UseDepthOfField             = new PropertyT<bool>                       ("UseDepthOfField");
        public PropertyT<EFocusDistanceSource>         FocusSource                 = new PropertyT<EFocusDistanceSource>       ("FocusSource");
        public PropertyT<double>                       FocusAngle                  = new PropertyT<double>                     ("FocusAngle");
        public PropertyT<double>                       FocusDistance               = new PropertyT<double>                     ("FocusDistance");
        public PropertyT<bool>                         UseAntialiasing             = new PropertyT<bool>                       ("UseAntialiasing");
        public PropertyT<double>                       AntialiasingIntensity       = new PropertyT<double>                     ("AntialiasingIntensity");
        public PropertyT<EAntialiasingMethod>          AntialiasingMethod          = new PropertyT<EAntialiasingMethod>        ("AntialiasingMethod");
        public PropertyT<bool>                         UseAccumulationBuffer       = new PropertyT<bool>                       ("UseAccumulationBuffer");
        public PropertyT<int>                          FrameSamplingCount          = new PropertyT<int>                        ("FrameSamplingCount");
        public PropertyT<ESamplingType>                FrameSamplingType           = new PropertyT<ESamplingType>              ("FrameSamplingType");

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

        public void SetForegroundTexture(Texture pTexture)
        {
            throw new NotImplementedException();
        }

        public Texture GetForegroundTexture()
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

        public Vector4 EvaluatePosition()
        {
            return EvaluatePosition(FbxTime.Zero);
        }
        public Vector4 EvaluatePosition(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public Vector4 EvaluateLookAtPosition()
        {
            return EvaluateLookAtPosition(FbxTime.Zero);
        }
        public Vector4 EvaluateLookAtPosition(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public Vector4 EvaluateUpDirection(Vector4 pCameraPosition, Vector4 pLookAtPosition)
        {
            return EvaluateUpDirection(pCameraPosition, pLookAtPosition, FbxTime.Zero);
        }
        public Vector4 EvaluateUpDirection(Vector4 pCameraPosition, Vector4 pLookAtPosition, FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix ComputeProjectionMatrix(int pWidth, int pHeight, bool pVerticalFOV = true)
        {
            throw new NotImplementedException();
        }

        public bool IsBoundingBoxInView(FbxMatrix pWorldToScreen, FbxMatrix pWorldToCamera, Vector4 [] pPoints)
        {
            if (pPoints.Length != 8) throw new ArgumentOutOfRangeException("pPoints");

            throw new NotImplementedException();
        }

        public bool IsPointInView(FbxMatrix pWorldToScreen, FbxMatrix pWorldToCamera, Vector4 pPoint)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix ComputeWorldToScreen(int pPixelWidth, int pPixelHeight, FbxMatrix pWorldToCamera)
        {
            throw new NotImplementedException();
        }

        public Vector4 ComputeScreenToWorld(float pX, float pY, float pWidth, float pHeight)
        {
            return ComputeScreenToWorld(pX, pY, pWidth, pHeight, FbxTime.Infinite);
        }
        public Vector4 ComputeScreenToWorld(float pX, float pY, float pWidth, float pHeight, FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

