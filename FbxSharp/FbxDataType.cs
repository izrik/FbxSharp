using System;

namespace FbxSharp;

public class FbxDataType
{
    #region Public Member Functions

    // public FbxDataType operator= ( FbxDataType pDataType) => throw new NotImplementedException();


    private readonly bool valid;
    public bool Valid() => valid;

    public bool Is(FbxDataType pDataType) =>
        throw new NotImplementedException();

    private EFbxType fbxType;

    [DeviationFromSdk(
        "Original name conflicts with built-in method on base class")]
    public EFbxType GetFbxType() => fbxType;

    [NotSdk]
    public Type GetDotnetType()
    {
        return fbxType.ToDotnetType();
    }

    private string name;
    public string GetName() => name;

    public FbxPropertyHandle GetTypeInfoHandle() =>
        throw new NotImplementedException();

    #endregion

    #region Static Public Member Functions

    public static FbxDataType Create(string pName, EFbxType pType) =>
        new(pName, pType);

    public static FbxDataType Create(string pName, FbxDataType pDataType) =>
        Create(pName, pDataType.GetFbxType());

    #endregion

    #region Constructor and Destructor

    public FbxDataType()
        : this("", EFbxType.eFbxUndefined)
    {
    }

    public FbxDataType(FbxDataType pDataType)
        : this(pDataType.GetName(), pDataType.GetFbxType())
    {
    }

    void Destroy() => throw new NotImplementedException();

    public FbxDataType(FbxPropertyHandle pTypeInfoHandle)
        : this(pTypeInfoHandle.GetName(), pTypeInfoHandle.GetFbxType())
    {
    }

    // ~FbxDataType()
    // {
    // }

    [NotSdk]
    public FbxDataType(string name, EFbxType fbxType)
    {
        this.name = name;
        this.fbxType = fbxType;
        this.valid = fbxType != EFbxType.eFbxUndefined;
    }

    #endregion

    #region boolean operation

    // public static bool operator ==(FbxDataType pDataType)
    // {
    // }
    //
    // public static bool operator !=(FbxDataType pDataType)
    // {
    // }

    #endregion

    /// <summary>
    /// Get the FbxDataType object associated with the given EFbxType enum
    /// value.
    /// </summary>
    /// <param name="pType"></param>
    /// <returns></returns>
    [DeviationFromSdk(
        "FBXSDK_DLL const FbxDataType& FbxGetDataTypeFromEnum(" +
        "const EFbxType pType);",
        "Function in global namespace converted to static method")]
    public static FbxDataType FbxGetDataTypeFromEnum(EFbxType pType)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get the data type name used by iO operations.
    ///
    /// This is only used during I/O operations. It is not the same as the
    /// data type's actual name.
    /// </summary>
    /// <param name="pDataType"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [DeviationFromSdk(
        "FBXSDK_DLL const char* FbxGetDataTypeNameForIO(" +
        "const FbxDataType& pDataType)",
        "Function in global namespace converted to static method")]
    public static string FbxGetDataTypeNameForIO(FbxDataType pDataType) =>
        throw new NotImplementedException();
}
