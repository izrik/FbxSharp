using System;

namespace FbxSharp;

public class FbxIOFileHeaderInfo
{
    public FbxIODefaultRenderResolution mDefaultRenderResolution = new();

    public bool mBinary;

    public virtual void Reset()
    {
        throw new NotImplementedException();
    }

    public virtual bool ReadExtendedHeaderInformation(FbxIO file)
    {
        throw new NotImplementedException();
    }

    public int mFileVersion;
    public bool mCreationTimeStampPresent;
    public FbxLocalTime mCreationTimeStamp = new();
    public string mCreator = ""; // FbxString
    public bool mIOPlugin;
    public bool mPLE;
}