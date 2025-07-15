using System;

namespace FbxSharp
{
    public struct FbxTime
    {
        public static readonly FbxTime Infinite = new FbxTime(0x7fffffffffffffffL);
        public static readonly FbxTime Zero = new FbxTime(0);

        #region Public Member Functions

        public FbxTime(long time)
        {
            Value = time;
        }

        #endregion

        public long Value;

        #region Static Public Member Functions

        public static long GetOneFrameValue(EMode pTimeMode = EMode.eDefaultMode)
        {
            switch (pTimeMode)
            {
                case EMode.eDefaultMode: return 4704000L;
                case EMode.eFrames120: return 1176000L;
                case EMode.eFrames100: return 1411200L;
                case EMode.eFrames60: return 2352000L;
                case EMode.eFrames50: return 2822400L;
                case EMode.eFrames48: return 2940000L;
                case EMode.eFrames30: return 4704000L;
                case EMode.eFrames30Drop: return 0L;
                case EMode.eNTSCDropFrame: return 4708704L;
                case EMode.eNTSCFullFrame: return 4708704L;
                case EMode.ePAL: return 5644800L;
                case EMode.eFrames24: return 5880000L;
                case EMode.eFrames1000: return 141120L;
                case EMode.eFilmFullFrame: return 5885880L;
                case EMode.eCustom: return 11289600L;
                case EMode.eFrames96: return 1470000L;
                case EMode.eFrames72: return 1960000L;
                case EMode.eFrames59dot94: return 2354352L;
                case EMode.eFrames119dot88: return 1177176L;
                case EMode.eModesCount: return 0L;
            }

            throw new ArgumentOutOfRangeException(nameof(pTimeMode));
        }

        #endregion

        #region Time Modes and Protocols

        public enum EMode
        {
            eDefaultMode,
            eFrames120,
            eFrames100,
            eFrames60,
            eFrames50,
            eFrames48,
            eFrames30,
            eFrames30Drop,
            eNTSCDropFrame,
            eNTSCFullFrame,
            ePAL,
            eFrames24,
            eFrames1000,
            eFilmFullFrame,
            eCustom,
            eFrames96,
            eFrames72,
            eFrames59dot94,
            eFrames119dot88,
            eModesCount
        }

        public enum EProtocol
        {
            eSMPTE,
            eFrameCount,
            eDefaultProtocol,
        }

        public static void SetGlobalTimeMode(EMode mode) =>
            throw new NotImplementedException();

        public static EMode GetGlobalTimeMode()
        {
            // TODO: make the value change-able
            return EMode.eFrames30;
        }

        public static void SetGlobalTimeProtocol(EProtocol pTimeProtocol) =>
            throw new NotImplementedException();

        public static EProtocol GetGlobalTimeProtocol() =>
            // TODO: make this mutable
            EProtocol.eFrameCount;

        public static double GetFrameRate(EMode pTimeMode)
        {
            switch (pTimeMode)
            {
                case EMode.eDefaultMode: return 30.0;
                case EMode.eFrames120: return 120.0;
                case EMode.eFrames100: return 100.0;
                case EMode.eFrames60: return 60.0;
                case EMode.eFrames50: return 50.0;
                case EMode.eFrames48: return 48.0;
                case EMode.eFrames30: return 30.0;
                case EMode.eFrames30Drop: return 0.0;
                case EMode.eNTSCDropFrame:
                    // 0x403df853e2556b28
                    return 29.970029970029969490497023798525333404541015625;
                case EMode.eNTSCFullFrame:
                    // 0x403df853e2556b28
                    return 29.970029970029969490497023798525333404541015625;
                case EMode.ePAL: return 25.0;
                case EMode.eFrames24: return 24.0;
                case EMode.eFrames1000: return 1000.0;
                case EMode.eFilmFullFrame:
                    // 0x4037f9dcb5112287
                    return 23.976023976023977724025826319120824337005615234375;
                case EMode.eCustom: return 12.5;
                case EMode.eFrames96: return 96.0;
                case EMode.eFrames72: return 72.0;
                case EMode.eFrames59dot94:
                    // 0x404df853e2556b28
                    return 59.94005994005993898099404759705066680908203125;
                case EMode.eFrames119dot88:
                    // 0x405df853e2556b28
                    return 119.8801198801198779619880951941013336181640625;
                case EMode.eModesCount: return 0.0;
            }

            throw new ArgumentOutOfRangeException(nameof(pTimeMode));
        }

        public static EMode ConvertFrameRateToTimeMode(double pFrameRate, double pPrecision = 0.00000001)
        {
            if (pFrameRate <= 0) return EMode.eFrames30Drop;
            if (Math.Abs(pFrameRate - 120.0) <= pPrecision) return EMode.eFrames120;
            if (Math.Abs(pFrameRate - 100.0) <= pPrecision) return EMode.eFrames100;
            if (Math.Abs(pFrameRate - 60.0) <= pPrecision) return EMode.eFrames60;
            if (Math.Abs(pFrameRate - 50.0) <= pPrecision) return EMode.eFrames50;
            if (Math.Abs(pFrameRate - 48.0) <= pPrecision) return EMode.eFrames48;
            if (Math.Abs(pFrameRate - 30.0) <= pPrecision) return EMode.eFrames30;
            if (Math.Abs(pFrameRate - 29.970029970029969490497023798525333404541015625) <= pPrecision) return EMode.eNTSCDropFrame;
            if (Math.Abs(pFrameRate - 25.0) <= pPrecision) return EMode.ePAL;
            if (Math.Abs(pFrameRate - 24.0) <= pPrecision) return EMode.eFrames24;
            if (Math.Abs(pFrameRate - 1000.0) <= pPrecision) return EMode.eFrames1000;
            if (Math.Abs(pFrameRate - 23.976023976023977724025826319120824337005615234375) <= pPrecision) return EMode.eFilmFullFrame;
            if (Math.Abs(pFrameRate - 12.5) <= pPrecision) return EMode.eCustom;
            if (Math.Abs(pFrameRate - 96.0) <= pPrecision) return EMode.eFrames96;
            if (Math.Abs(pFrameRate - 72.0) <= pPrecision) return EMode.eFrames72;
            if (Math.Abs(pFrameRate - 59.94005994005993898099404759705066680908203125) <= pPrecision) return EMode.eFrames59dot94;
            if (Math.Abs(pFrameRate - 119.8801198801198779619880951941013336181640625) <= pPrecision) return EMode.eFrames119dot88;

            return EMode.eDefaultMode;
        }

        #endregion

        #region Time Conversion

        public enum EElement
        {
            eHours,
            eMinutes,
            eSeconds,
            eFrames,
            eField,
            eResidual
        }

        public void Set(long pTime) =>
            Value = pTime;

        public long Get()
        {
            return Value;
        }

        public long SetMilliSeconds(long pMilliSeconds) =>
            throw new NotImplementedException();

        public long GetMilliSeconds()
        {
            return Value / FbxTimeCode.FBXSDK_TC_MILLISECOND;
        }


        public void SetSecondDouble(double pTime) =>
            throw new NotImplementedException();

        public double GetSecondDouble() =>
            Value / (double)FbxTimeCode.FBXSDK_TC_LEGACY_SECOND;

        public void SetTime(int pHour, int pMinute, int pSecond, int pFrame = 0, int pField = 0,
            EMode pTimeMode = EMode.eDefaultMode) =>
            throw new NotImplementedException();

        public void SetTime(int pHour, int pMinute, int pSecond, int pFrame, int pField, int pResidual,
            EMode pTimeMode) =>
            throw new NotImplementedException();

        public bool GetTime(ref int pHour, ref int pMinute, ref int pSecond, ref int pFrame, ref int pField,
            ref int pResidual, EMode pTimeMode =
                EMode.eDefaultMode) /*const*/ =>
            throw new NotImplementedException();

        public FbxTime GetFramedTime(bool pRound = true) /*const*/ =>
            throw new NotImplementedException();

        public void SetFrame(long pFrames, EMode pTimeMode = EMode.eDefaultMode) =>
            throw new NotImplementedException();

        public void SetFramePrecise(double pFrames, EMode pTimeMode = EMode.eDefaultMode) =>
            throw new NotImplementedException();

        public int GetHourCount() /*const*/ =>
            (int)(Value / FbxTimeCode.FBXSDK_TC_SECOND / 3600);

        public int GetMinuteCount() /*const*/ => (int)(Value / FbxTimeCode.FBXSDK_TC_SECOND / 60);

        public int GetSecondCount()
        {
            return (int)(Value / FbxTimeCode.FBXSDK_TC_LEGACY_SECOND);
        }

        public long GetFrameCount(EMode pTimeMode = EMode.eDefaultMode) /*const*/
        {
            // TODO: take time mode into account
            return Value / (FbxTimeCode.FBXSDK_TC_SECOND / 30);
        }

        public double GetFrameCountPrecise(EMode pTimeMode = EMode.eDefaultMode) /*const*/
        {
            // TODO: take time mode into account
            return Value / (double)(FbxTimeCode.FBXSDK_TC_SECOND / 30);
        }

        public long GetFieldCount(EMode pTimeMode = EMode.eDefaultMode) /*const*/
        {
            // TODO: take time mode into account
            return Value / (FbxTimeCode.FBXSDK_TC_SECOND / 60);
        }

        public int GetResidual(EMode pTimeMode = EMode.eDefaultMode) /*const*/ =>
            throw new NotImplementedException();

        public char GetFrameSeparator(EMode pTimeMode = EMode.eDefaultMode) /*const*/ =>
            throw new NotImplementedException();

        public string GetTimeString(string pTimeString, /*const*/ ushort pTimeStringSize, int pInfo = 5,
            EMode pTimeMode = EMode.eDefaultMode, EProtocol pTimeFormat = EProtocol.eDefaultProtocol) /*const*/ =>
            throw new NotImplementedException();

        public string GetTimeString(EElement pStart = EElement.eHours, EElement pEnd = EElement.eResidual,
            EMode pTimeMode = EMode.eDefaultMode,
            EProtocol pTimeFormat = EProtocol.eDefaultProtocol) /*const*/ =>
            throw new NotImplementedException();

        public bool SetTimeString(string pTime, EMode pTimeMode = EMode.eDefaultMode,
            EProtocol pTimeFormat = EProtocol.eDefaultProtocol) =>
            throw new NotImplementedException();

        public static bool IsDropFrame(EMode pTimeMode = EMode.eDefaultMode) =>
            throw new NotImplementedException();

        #endregion
    }
}
