using System;

namespace FbxSharp;

public class FbxStatus
{
    public enum EStatusCode
    {
        eSuccess = 0,
        eFailure = 1,
        eInsufficientMemory = 2,
        eInvalidParameter = 3,
        eIndexOutOfRange = 4,
        ePasswordError = 5,
        eInvalidFileVersion = 6,
        eInvalidFile = 7,
        eSceneCheckFail = 8,
    }

    public FbxStatus()
    {
    }

    public FbxStatus(EStatusCode pCode)
    {
    }

    // public FbxStatus (const FbxStatus &rhs){
    // }
    //
    // public FbxStatus & 	operator= (const FbxStatus &rhs)
    // public FbxStatus & 	operator+= (const FbxStatus &rhs)
    // public bool 	operator== (const FbxStatus &rhs) const
    // public bool 	operator== (const EStatusCode pCode) const
    // public bool 	operator!= (const FbxStatus &rhs) const
    // public bool 	operator!= (const EStatusCode rhs) const
    // public operator bool () const

    private EStatusCode code;
    private bool isError = false;
    public bool Error()
    {
        return isError;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public EStatusCode GetCode()
    {
        return code;
    }

    public void SetCode(EStatusCode rhs)
    {
        throw new NotImplementedException();
    }

    public void SetCode(EStatusCode rhs, string pErrorMsg, params object[] vararg)
    {
        throw new NotImplementedException();
    }

    public string GetErrorString()
    {
        switch (code)
        {
            case EStatusCode.eSuccess:
                return "eSuccess";
            case EStatusCode.eFailure:
                return "eFailure";
            case EStatusCode.eInsufficientMemory:
                return "eInsufficientMemory";
            case EStatusCode.eInvalidParameter:
                return "eInvalidParameter";
            case EStatusCode.eIndexOutOfRange:
                return "eIndexOutOfRange";
            case EStatusCode.ePasswordError:
                return "ePasswordError";
            case EStatusCode.eInvalidFileVersion:
                return "eInvalidFileVersion";
            case EStatusCode.eInvalidFile:
                return "eInvalidFile";
            case EStatusCode.eSceneCheckFail:
                return "eSceneCheckFail";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool KeepErrorStringHistory(bool pState)
    {
        throw new NotImplementedException();
    }

    // public void GetErrorStringHistory(FbxArray<FbxString> pHistory)
    // {
    //     throw new NotImplementedException();
    // }
}