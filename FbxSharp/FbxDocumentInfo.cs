using System;

namespace FbxSharp;

public class FbxDocumentInfo : FbxObject
{
    #region Public Types

    // typedef FbxObject ParentClass

    #endregion

    #region Public Member Functions

    // public override FbxClassId GetClassId() =>
    //     throw new NotImplementedException();

    public void Clear() => throw new NotImplementedException();

    #region Scene Thumbnail.

    // public FbxThumbnail GetSceneThumbnail() =>
    //     throw new NotImplementedException();

    // public void SetSceneThumbnail(FbxThumbnail pSceneThumbnail) =>
    //     throw new NotImplementedException();

    #endregion

    #endregion

    #region Static Public Member Functions

    public static FbxDocumentInfo Create( /*FbxManager pManager,*/
        string pName)
    {
        return new FbxDocumentInfo(pName);
    }

    public static FbxDocumentInfo Create(FbxObject pContainer, string pName) =>
        throw new NotImplementedException();

    #endregion

    #region Public Attributes

    #region Public properties

    public FbxPropertyT<string> LastSavedUrl;
    public FbxPropertyT<string> Url;
    public FbxProperty Original;
    public FbxPropertyT<string> Original_ApplicationVendor;
    public FbxPropertyT<string> Original_ApplicationName;
    public FbxPropertyT<string> Original_ApplicationVersion;

    public FbxPropertyT<string> Original_FileName;

    // public FbxPropertyT<FbxDateTime> Original_DateTime_GMT;
    public FbxProperty LastSaved;
    public FbxPropertyT<string> LastSaved_ApplicationVendor;
    public FbxPropertyT<string> LastSaved_ApplicationName;

    public FbxPropertyT<string> LastSaved_ApplicationVersion;

    // public FbxPropertyT<FbxDateTime> LastSaved_DateTime_GMT;
    public FbxPropertyT<string> EmbeddedUrl;

    #endregion

    #region User-defined summary data.

    public string mTitle;
    public string mSubject;
    public string mAuthor;
    public string mKeywords;
    public string mRevision;
    public string mComment;

    #endregion

    #endregion

    #region Static Public Attributes

    // public static FbxClassId ClassId

    #endregion

    #region Protected Member Functions

    // protected virtual ~FbxDocumentInfo()

    protected FbxDocumentInfo( /*FbxManager pManager,*/ string pName)
        : base(pName)
    {
    }

    #endregion

    #region Static Protected Member Functions

    // static FbxDocumentInfo Allocate( /*FbxManager pManager,*/ string pName, FbxDocumentInfo pFrom)

    #endregion
}
