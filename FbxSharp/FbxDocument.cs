using System;

namespace FbxSharp
{
    public class FbxDocument : FbxCollection
    {
        public FbxDocument(string name = "")
            : base(name)
        {
            this.Properties.Add(Roots);
            this.Properties.Add(ActiveAnimStackName);
        }

        #region Public Types

        // typedef FbxCollection ParentClass

        #endregion

        #region Public Member Functions

        // public override FbxClassId GetClassId() =>
        //     throw new NotImplementedException();

        #endregion

        #region Static Public Member Functions

        static FbxDocument Create( /*FbxManager *pManager,*/ string pName) =>
            throw new NotImplementedException();

        static FbxDocument Create(FbxObject pContainer, string pName) =>
            throw new NotImplementedException();

        #endregion

        #region Static Public Attributes

        // private static FbxClassId ClassId

        #endregion

        #region Protected Member Functions

        // virtual ~FbxDocument();
        // FbxDocument(FbxManager pManager, string pName);

        #endregion

        #region Static Protected Member Functions

        // static FbxDocument Allocate( /*FbxManager pManager,*/ string pName, FbxDocument pFrom)

        #endregion

        #region Properties

        public readonly FbxPropertyT<FbxObject> Roots =
            new FbxPropertyT<FbxObject>("SourceObject");

        #endregion

        #region Document Member Manager

        // public override void Clear() => throw new NotImplementedException();

        public void AddRootMember(FbxObject pMember) =>
            throw new NotImplementedException();

        public void RootRootRemoveMember(FbxObject pMember) =>
            throw new NotImplementedException();

        public T FindRootMember<T>(char pName) =>
            throw new NotImplementedException();

        public int GetRootMemberCount() => throw new NotImplementedException();

        public int GetRootMemberCount<T>() =>
            throw new NotImplementedException();

        public int GetRootMemberCount(FbxCriteria pCriteria) =>
            throw new NotImplementedException();

        public FbxObject GetRootMember(int pIndex = 0) =>
            throw new NotImplementedException();


        public T GetRootMember<T>(int pIndex = 0) =>
            throw new NotImplementedException();

        public FbxObject GetRootMember(FbxCriteria pCriteria, int pIndex = 0) =>
            throw new NotImplementedException();

        public virtual bool IsRootMember(FbxObject pMember) =>
            throw new NotImplementedException();

        #endregion

        #region Document information

        private FbxDocumentInfo documentInfo = FbxDocumentInfo.Create("");
        public FbxDocumentInfo GetDocumentInfo() => documentInfo;

        public void SetDocumentInfo(FbxDocumentInfo pSceneInfo) =>
            documentInfo = pSceneInfo;

        #endregion

        #region Offloading management

        // public void SetPeripheral(FbxPeripheral pPeripheral);
        // public override FbxPeripheral GetPeripheral();

        public int UnloadContent(FbxStatus pStatus = null) =>
            throw new NotImplementedException();

        public int LoadContent(FbxStatus pStatus = null) =>
            throw new NotImplementedException();

        #endregion

        #region Referencing management

        // int GetReferencingDocuments(
        //     FbxArray<FbxDocument> pReferencingDocuments) =>
        //     throw new NotImplementedException();
        //
        // int GetReferencingObjects(FbxDocument pFromDoc,
        //     FbxArray<FbxObject> pReferencingObjects) =>
        //     throw new NotImplementedException();
        //
        // int GetReferencedDocuments(
        //     FbxArray<FbxDocument> pReferencedDocuments) =>
        //     throw new NotImplementedException();
        //
        // int GetReferencedObjects(const FbxDocument pToDoc,
        //     FbxArray< FbxObject > pReferencedObjects) => throw new
        //     NotImplementedException();
        //
        // FbxString GetPathToRootDocument() =>
        //     throw new NotImplementedException();
        //
        // void GetDocumentPathToRootDocument(FbxArray<FbxDocument> pDocumentPath,
        //     bool pFirstCall = true) => throw new NotImplementedException();
        //
        // bool IsARootDocument() => throw new NotImplementedException();

        #endregion

        #region Animation Stack Management

        public readonly FbxPropertyT<string> ActiveAnimStackName =
            new FbxPropertyT<string>("ActiveAnimStackName");

        bool CreateAnimStack(string pName /*, FbxStatus *pStatus=NULL*/)
        {
            throw new NotImplementedException();
        }

        bool RemoveAnimStack(string pName)
        {
            throw new NotImplementedException();
        }

        void FillAnimStackNameArray(string[] pNameArray)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Animation Stack Information Management

        // public bool SetTakeInfo(FbxTakeInfo pTakeInfo) =>
        //     throw new NotImplementedException();
        // public FbxTakeInfo GetTakeInfo(string pTakeName) =>
        //     throw new NotImplementedException();

        #endregion
    }
}
