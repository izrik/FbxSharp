using System;

namespace FbxSharp
{
    public class FbxGlobalSettings : FbxObject
    {
        #region Classes

        public struct TimeMarker
        {
        }

        #endregion

        #region Public Types

        // typedef FbxObject ParentClass

        #endregion

        #region Public Member Functions

        public virtual FbxClassId GetClassId() /*override*/ =>
            throw new NotImplementedException();

        public void SetOriginalUpAxis(FbxAxisSystem pAxisSystem) =>
            throw new NotImplementedException();

        public int GetOriginalUpAxis() => OriginalUpAxis.Get();

        #endregion

        #region Static Public Member Functions

        public static FbxGlobalSettings Create( /*FbxManager pManager,*/ string pName) =>
            throw new NotImplementedException();

        public static FbxGlobalSettings Create(FbxObject pContainer, string pName) =>
            throw new NotImplementedException();

        #endregion

        #region Static Public Attributes

        public static FbxClassId ClassId =>
            throw new NotImplementedException();

        #endregion

        #region Protected Member Functions

        public virtual void Dispose() =>
            // ~FbxGlobalSettings
            throw new NotImplementedException();

        [NotSdk]
        public FbxGlobalSettings()
            : this("")
        {
        }

        public FbxGlobalSettings( /*FbxManager pManager,*/ string pName)
            : base(pName)
        {
            UpAxis = FbxPropertyT<int>.StaticInit(this, "UpAxis", (int)FbxAxisSystem.EUpVector.eXAxis, false);
            UpAxisSign = FbxPropertyT<int>.StaticInit(this, "UpAxisSign", 1, false);
            FrontAxis = FbxPropertyT<int>.StaticInit(this, "FrontAxis", (int)FbxAxisSystem.EFrontVector.eParityOdd, false);
            FrontAxisSign = FbxPropertyT<int>.StaticInit(this, "FrontAxisSign", 1, false);
            CoordAxis = FbxPropertyT<int>.StaticInit(this, "CoordAxis", (int)FbxAxisSystem.ECoordSystem.eRightHanded, false);
            CoordAxisSign = FbxPropertyT<int>.StaticInit(this, "CoordAxisSign", 1, false);
            OriginalUpAxis = FbxPropertyT<int>.StaticInit(this, "OriginalUpAxis", -1, false);
            OriginalUpAxisSign = FbxPropertyT<int>.StaticInit(this, "OriginalUpAxisSign", 1, false);
            UnitScaleFactor = FbxPropertyT<double>.StaticInit(this, "UnitScaleFactor", 1, false);
            OriginalUnitScaleFactor = FbxPropertyT<double>.StaticInit(this, "OriginalUnitScaleFactor", 1, false);
            AmbientColor = FbxPropertyT<FbxColor>.StaticInit(this, "AmbientColor", new FbxColor(0,0,0), false);
            DefaultCamera = FbxPropertyT<string>.StaticInit(this, "DefaultCamera", "Producer Perspective", false);
            TimeMode = FbxPropertyTEnum.StaticInit(this, "TimeMode", (int)FbxTime.EMode.eDefaultMode);
            TimeProtocol = FbxPropertyTEnum.StaticInit(this, "TimeProtocol", (int)FbxTime.EProtocol.eDefaultProtocol);
            SnapOnFrameMode = FbxPropertyTEnum.StaticInit(this, "SnapOnFrameMode", (int)FbxGlobalSettings.ESnapOnFrameMode.eNoSnap);
            TimeSpanStart = FbxPropertyT<FbxTime>.StaticInit(this, "TimeSpanStart", new FbxTime(0), false);
            TimeSpanStop = FbxPropertyT<FbxTime>.StaticInit(this, "TimeSpanStop", new FbxTime(FbxTime.UnitsPerSecond), false);
            CustomFrameRate = FbxPropertyT<double>.StaticInit(this, "CustomFrameRate", -1, false);
            TimeMarkerP = FbxPropertyT<object>.StaticInit(this, "TimeMarker", null, false);
            CurrentTimeMarker = FbxPropertyT<int>.StaticInit(this, "CurrentTimeMarker", -1, false);
        }

        #endregion

        [NotSdk] public readonly FbxPropertyT<int> UpAxis;
        [NotSdk] public readonly FbxPropertyT<int> UpAxisSign;
        [NotSdk] public readonly FbxPropertyT<int> FrontAxis;
        [NotSdk] public readonly FbxPropertyT<int> FrontAxisSign;
        [NotSdk] public readonly FbxPropertyT<int> CoordAxis;
        [NotSdk] public readonly FbxPropertyT<int> CoordAxisSign;
        [NotSdk] public readonly FbxPropertyT<int> OriginalUpAxis;
        [NotSdk] public readonly FbxPropertyT<int> OriginalUpAxisSign;
        [NotSdk] public readonly FbxPropertyT<double> UnitScaleFactor;
        [NotSdk] public readonly FbxPropertyT<double> OriginalUnitScaleFactor;
        [NotSdk] public readonly FbxPropertyT<FbxColor> AmbientColor;
        [NotSdk] public readonly FbxPropertyT<string> DefaultCamera;
        [NotSdk] public readonly FbxPropertyTEnum TimeMode;
        [NotSdk] public readonly FbxPropertyTEnum TimeProtocol;
        [NotSdk] public readonly FbxPropertyTEnum SnapOnFrameMode;
        [NotSdk] public readonly FbxPropertyT<FbxTime> TimeSpanStart;
        [NotSdk] public readonly FbxPropertyT<FbxTime> TimeSpanStop;
        [NotSdk] public readonly FbxPropertyT<double> CustomFrameRate;
        [NotSdk] public readonly FbxPropertyT<object> TimeMarkerP;
        [NotSdk] public readonly FbxPropertyT<int> CurrentTimeMarker;
        private FbxSystemUnit systemUnit;
        

        #region Static Protected Member Functions

        public static FbxGlobalSettings Allocate( /*FbxManager pManager,*/ string pName, FbxGlobalSettings pFrom) =>
            throw new NotImplementedException();

        #endregion

        #region Axis system

        public void SetAxisSystem(FbxAxisSystem pAxisSystem) =>
            throw new NotImplementedException();

        public FbxAxisSystem GetAxisSystem() =>
            new FbxAxisSystem();

        #endregion

        #region System Units

        public void SetSystemUnit(FbxSystemUnit pOther) =>
            throw new NotImplementedException();

        public FbxSystemUnit GetSystemUnit() => FbxSystemUnit.cm;

        public void SetOriginalSystemUnit(FbxSystemUnit pOther) =>
            throw new NotImplementedException();

        public FbxSystemUnit GetOriginalSystemUnit() => FbxSystemUnit.cm;

        #endregion

        #region Light Settings

        public void SetAmbientColor(FbxColor pAmbientColor) =>
            AmbientColor.Set(pAmbientColor);

        public FbxColor GetAmbientColor() => AmbientColor.Get();

        #endregion

        #region Camera Settings

        public bool SetDefaultCamera(string pCameraName)
        {
            DefaultCamera.Set(pCameraName);
            return true;
        }

        public string GetDefaultCamera() => DefaultCamera.Get();

        #endregion

        #region Time Settings

        public enum ESnapOnFrameMode
        {
            eNoSnap,
            eSnapOnFrame,
            ePlayOnFrame,
            eSnapAndPlayOnFrame
        }

        public void SetTimeMode(FbxTime.EMode pTimeMode) =>
            TimeMode.Set((int)pTimeMode);

        public FbxTime.EMode GetTimeMode()
        {
            var mode = (FbxTime.EMode)TimeMode.Get();
            if (mode == FbxTime.EMode.eDefaultMode) 
                return FbxTime.EMode.eFrames30;
            return mode;
        }

        public void SetTimeProtocol(FbxTime.EProtocol pTimeProtocol) =>
            throw new NotImplementedException();

        public FbxTime.EProtocol GetTimeProtocol()
        {
            var value = (FbxTime.EProtocol)TimeProtocol.Get();
            if (value == FbxTime.EProtocol.eDefaultProtocol)
                return FbxTime.EProtocol.eFrameCount;
            return value;
        }

        public void SetSnapOnFrameMode(ESnapOnFrameMode pSnapOnFrameMode) =>
            SnapOnFrameMode.Set((int)pSnapOnFrameMode);

        public ESnapOnFrameMode GetSnapOnFrameMode() =>
            (ESnapOnFrameMode)SnapOnFrameMode.Get();

        public void SetTimelineDefaultTimeSpan(FbxTimeSpan pTimeSpan) =>
            throw new NotImplementedException();

        [DeviationFromSdk("out parameter instead of reference")]
        public void GetTimelineDefaultTimeSpan(out FbxTimeSpan pTimeSpan)
        {
            pTimeSpan = new FbxTimeSpan(new FbxTime(0), 
                new FbxTime(FbxTime.UnitsPerSecond));
        }

        public void SetCustomFrameRate(double pCustomFrameRate) =>
            throw new NotImplementedException();

        public double GetCustomFrameRate() => CustomFrameRate.Get();

        #endregion

        #region Time Markers

        public int GetTimeMarkerCount() => 0;

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public TimeMarker GetTimeMarker(int pIndex) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public TimeMarker GetTimeMarker(int pIndex, ref FbxStatus pStatus) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public void AddTimeMarker(TimeMarker pTimeMarker) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public void AddTimeMarker(TimeMarker pTimeMarker, ref FbxStatus pStatus) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public void ReplaceTimeMarker(int pIndex, TimeMarker pTimeMarker) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public void ReplaceTimeMarker(int pIndex, TimeMarker pTimeMarker, ref FbxStatus pStatus) =>
            throw new NotImplementedException();

        public void RemoveAllTimeMarkers() =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public bool SetCurrentTimeMarker(int pIndex) =>
            throw new NotImplementedException();

        [DeviationFromSdk("two overloads in lieu of null default pointer value")]
        public bool SetCurrentTimeMarker(int pIndex, ref FbxStatus pStatus) =>
            throw new NotImplementedException();

        public int GetCurrentTimeMarker() => -1;

        #endregion
    }
}