using System;

namespace FbxSharp;

public class FbxPropertyHandle
{
    #region Public Member Functions

    #region Assignment and basic info

    // public FbxPropertyHandle operator= (FbxPropertyHandle pHandle) =>
    //     throw new NotImplementedException();
    // public bool operator ==(FbxPropertyHandle pHandle) =>
    //     throw new NotImplementedException();
    // public bool operator !=(FbxPropertyHandle pHandle) =>
    //     throw new NotImplementedException();
    // public bool operator <(FbxPropertyHandle pHandle) =>
    //     throw new NotImplementedException();
    // public bool operator >(FbxPropertyHandle pHandle) =>
    //     throw new NotImplementedException();

    public bool Is(FbxPropertyHandle pHandle) =>
        throw new NotImplementedException();

    public bool Valid() => throw new NotImplementedException();
    public string GetName() => throw new NotImplementedException();
    public string GetLabel() => throw new NotImplementedException();
    public bool SetLabel(string pLabel) => throw new NotImplementedException();
    [DeviationFromSdk(
        "Original name conflicts with built-in method on base class")]
    public EFbxType GetFbxType() => throw new NotImplementedException();

    public FbxPropertyHandle GetTypeInfo() =>
        throw new NotImplementedException();

    public FbxPropertyFlags.EFlags GetFlags() =>
        throw new NotImplementedException();

    public FbxPropertyFlags.EInheritType GetFlagsInheritType(
        FbxPropertyFlags.EFlags pFlags, bool pCheckReferences) =>
        throw new NotImplementedException();

    public bool ModifyFlags(FbxPropertyFlags.EFlags pFlags, bool pValue) =>
        throw new NotImplementedException();

    public bool SetFlagsInheritType(FbxPropertyFlags.EFlags pFlags,
        FbxPropertyFlags.EInheritType pType) =>
        throw new NotImplementedException();

    public object GetUserData() => throw new NotImplementedException();

    public bool SetUserData(object pUserData) =>
        throw new NotImplementedException();

    public int GetUserTag() => throw new NotImplementedException();

    public bool SetUserTag(int pUserData) =>
        throw new NotImplementedException();

    #endregion

    #region Enum management

    public int AddEnumValue(string pStringValue) =>
        throw new NotImplementedException();

    public void InsertEnumValue(int pIndex, string pStringValue) =>
        throw new NotImplementedException();

    public int GetEnumCount() => throw new NotImplementedException();

    public void SetEnumValue(int pIndex, string pStringValue) =>
        throw new NotImplementedException();

    public void RemoveEnumValue(int pIndex) =>
        throw new NotImplementedException();

    public string GetEnumValue(int pIndex) =>
        throw new NotImplementedException();

    #endregion

    #region Child and Struct management

    public void BeginCreateOrFindProperty() =>
        throw new NotImplementedException();

    public void EndCreateOrFindProperty() =>
        throw new NotImplementedException();

    public bool IsRoot() => throw new NotImplementedException();

    public bool IsChildOf(FbxPropertyHandle pParent) =>
        throw new NotImplementedException();

    public bool IsDescendentOf(FbxPropertyHandle pParent) =>
        throw new NotImplementedException();

    public bool SetParent(FbxPropertyHandle pOther) =>
        throw new NotImplementedException();

    public FbxPropertyHandle Add(string pName, FbxPropertyHandle pTypeInfo) =>
        throw new NotImplementedException();

    public FbxPropertyHandle GetParent() =>
        throw new NotImplementedException();

    public FbxPropertyHandle GetChild() => throw new NotImplementedException();

    public FbxPropertyHandle GetSibling() =>
        throw new NotImplementedException();

    public FbxPropertyHandle GetFirstDescendent() =>
        throw new NotImplementedException();

    public FbxPropertyHandle GetNextDescendent(FbxPropertyHandle pHandle) =>
        throw new NotImplementedException();

    public FbxPropertyHandle Find(string pName, bool pCaseSensitive) =>
        throw new NotImplementedException();

    public FbxPropertyHandle Find(string pName, FbxPropertyHandle pTypeInfo,
        bool pCaseSensitive) => throw new NotImplementedException();

    public FbxPropertyHandle Find(string pName, string pChildrenSeparator,
        bool pCaseSensitive) => throw new NotImplementedException();

    public FbxPropertyHandle Find(string pName, string pChildrenSeparator,
        FbxPropertyHandle pTypeInfo, bool pCaseSensitive) =>
        throw new NotImplementedException();

    #endregion

    #region Connection management

    public bool ConnectSrc(FbxPropertyHandle pSrc,
        FbxConnection.EType pType = FbxConnection.EType.Default) =>
        throw new NotImplementedException();

    // public int GetSrcCount(FbxConnectionPointFilter pFilter = null) =>
    // throw new NotImplementedException();

    // public FbxPropertyHandle GetSrc(FbxConnectionPointFilter pFilter = null,
    // int pIndex = 0) => throw new NotImplementedException();

    public bool DisconnectSrc(FbxPropertyHandle pSrc) =>
        throw new NotImplementedException();

    public bool IsConnectedSrc(FbxPropertyHandle pSrc) =>
        throw new NotImplementedException();

    public bool ConnectDst(FbxPropertyHandle pDst,
        FbxConnection.EType pType = FbxConnection.EType.eDefault) =>
        throw new NotImplementedException();

    // public int GetDstCount(FbxConnectionPointFilter pFilter = null) =>
    // throw new NotImplementedException();

    // public FbxPropertyHandle GetDst(FbxConnectionPointFilter pFilter = null,
    // int pIndex = 0) => throw new NotImplementedException();

    public bool DisconnectDst(FbxPropertyHandle pDst) =>
        throw new NotImplementedException();

    public bool IsConnectedDst(FbxPropertyHandle pDst) =>
        throw new NotImplementedException();

    public void ClearConnectCache() => throw new NotImplementedException();
    public void WipeAllConnections() => throw new NotImplementedException();

    #endregion

    #region Limits Functions

    public bool HasMin() => throw new NotImplementedException();

    public bool GetMin(object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetMin(object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetMin<T>(T pValue) => throw new NotImplementedException();
    public T GetMin<T>(out T pFBX_TYPE) => throw new NotImplementedException();
    public bool HasSoftMin() => throw new NotImplementedException();

    public bool GetSoftMin(out object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetSoftMin(object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetSoftMin<T>(T pValue) => throw new NotImplementedException();

    public T GetSoftMin<T>(out T pFBX_TYPE) =>
        throw new NotImplementedException();

    public bool HasMax() => throw new NotImplementedException();

    public bool GetMax(out object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetMax(object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetMax<T>(T pValue) => throw new NotImplementedException();
    public T GetMax<T>(out T pFBX_TYPE) => throw new NotImplementedException();
    public bool HasSoftMax() => throw new NotImplementedException();

    public bool GetSoftMax(out object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetSoftMax(object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool SetSoftMax<T>(T pValue) => throw new NotImplementedException();

    public T GetSoftMax<T>(out T pFBX_TYPE) =>
        throw new NotImplementedException();

    #endregion

    #region Value

    public FbxPropertyFlags.EInheritType GetValueInheritType(
        bool pCheckReferences) =>
        throw new NotImplementedException();

    public bool SetValueInheritType(FbxPropertyFlags.EInheritType pType) =>
        throw new NotImplementedException();

    public bool GetDefaultValue(out object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool Get(out object pValue, EFbxType pValueType) =>
        throw new NotImplementedException();

    public bool Set(object pValue, EFbxType pValueType,
        bool pCheckValueEquality) =>
        throw new NotImplementedException();

    public bool Set<T>(T pValue) => throw new NotImplementedException();
    public T Get<T>(out T pFBX_TYPE) => throw new NotImplementedException();

    #endregion

    #region Page settings

    public void SetPageDataPtr(object pData) =>
        throw new NotImplementedException();

    public object GetPageDataPtr() => throw new NotImplementedException();

    #endregion

    #region Page Internal Entry Management

    public bool PushPropertiesToParentInstance() =>
        throw new NotImplementedException();

    #endregion

    #region Reference Management

    public bool IsAReferenceTo() => throw new NotImplementedException();
    public object GetReferenceTo() => throw new NotImplementedException();
    public bool IsReferencedBy() => throw new NotImplementedException();

    public int GetReferencedByCount() => throw new NotImplementedException();

    // FBX_DEPRECATED object GetReferencedBy (int pIndex) 

    // TODO: int GetReferencedBy(FbxArray<object> pReferencedBy) =>
    // throw new NotImplementedException();

    #endregion

    #endregion

    #region Constructor and Destructor

    public static FbxPropertyHandle Create() =>
        throw new NotImplementedException();

    public static FbxPropertyHandle Create(FbxPropertyHandle pInstanceOf) =>
        throw new NotImplementedException();

    public static FbxPropertyHandle Create(string pName,
        EFbxType pType = EFbxType.eFbxUndefined) =>
        throw new NotImplementedException();

    public static FbxPropertyHandle
        Create(string pName, FbxPropertyHandle pTypeInfo) =>
        throw new NotImplementedException();

    public bool Destroy() => throw new NotImplementedException();
    public FbxPropertyHandle() => throw new NotImplementedException();

    public FbxPropertyHandle(FbxPropertyHandle pAddress) =>
        throw new NotImplementedException();

    ~FbxPropertyHandle() => throw new NotImplementedException();

    // TODO: public FbxPropertyHandle(FbxPropertyPage pPage, FbxInt pId = 0) =>
    // throw new NotImplementedException();

    #endregion
}