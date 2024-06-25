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

    public FbxPropertyT<FbxDateTime> Original_DateTime_GMT;
    public FbxProperty LastSaved;
    public FbxPropertyT<string> LastSaved_ApplicationVendor;
    public FbxPropertyT<string> LastSaved_ApplicationName;

    public FbxPropertyT<string> LastSaved_ApplicationVersion;

    public FbxPropertyT<FbxDateTime> LastSaved_DateTime_GMT;
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
        LastSavedUrl = new FbxPropertyT<string>("DocumentUrl", "");
        Properties.Add(LastSavedUrl);
        Url = new FbxPropertyT<string>("SrcDocumentUrl", "");
        Properties.Add(Url);

        Original = FbxProperty.FromEFbxType(EFbxType.eFbxUndefined,
            "Original");
        Properties.Add(Original);
        Original_ApplicationVendor =
            new FbxPropertyT<string>("Original|ApplicationVendor", "");
        Properties.Add(Original_ApplicationVendor);
        Original_ApplicationName =
            new FbxPropertyT<string>("Original|ApplicationName", "");
        Properties.Add(Original_ApplicationName);
        Original_ApplicationVersion =
            new FbxPropertyT<string>("Original|ApplicationVersion", "");
        Properties.Add(Original_ApplicationVersion);
        Original_FileName = new FbxPropertyT<string>("Original|FileName", "");
        Properties.Add(Original_FileName);
        Original_DateTime_GMT =
            new FbxPropertyT<FbxDateTime>("Original|DateTime_GMT");
        Properties.Add(Original_DateTime_GMT);

        LastSaved = new FbxPropertyT<string>("LastSaved");
        Properties.Add(LastSaved);
        LastSaved_ApplicationVendor =
            new FbxPropertyT<string>("LastSaved|ApplicationVendor", "");
        Properties.Add(LastSaved_ApplicationVendor);
        LastSaved_ApplicationName =
            new FbxPropertyT<string>("LastSaved|ApplicationName", "");
        Properties.Add(LastSaved_ApplicationName);
        LastSaved_ApplicationVersion =
            new FbxPropertyT<string>("LastSaved|ApplicationVersion", "");
        Properties.Add(LastSaved_ApplicationVersion);
        LastSaved_DateTime_GMT =
            new FbxPropertyT<FbxDateTime>("LastSaved|DateTime_GMT");
        Properties.Add(LastSaved_DateTime_GMT);

        EmbeddedUrl = new FbxPropertyT<string>("DocumentEmbeddedUrl");
        Properties.Add(EmbeddedUrl);
    }

    #endregion

    #region Static Protected Member Functions

    // static FbxDocumentInfo Allocate( /*FbxManager pManager,*/ string pName, FbxDocumentInfo pFrom)

    #endregion
}
