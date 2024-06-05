using System;

namespace FbxSharp
{
    /// <summary>
    /// Base class for FBX file importer and exporter.
    /// </summary>
    public class FbxIOBase : FbxObject
    {
        #region Public Types

        //typedef FbxObject ParentClass

        #endregion

        #region Public Member Functions

        // virtual FbxClassId GetClassId () const override
        public virtual bool Initialize(string pFileName, int pFileFormat = -1,
            FbxIOSettings pIOSettings = null) =>
            throw new NotImplementedException();

        public virtual string GetFileName() =>
            throw new NotImplementedException();

        public FbxStatus GetStatus() => throw new NotImplementedException();

        #endregion

        #region Static Public Member Functions

        public static FbxIOBase Create(string pName) =>
            throw new NotImplementedException();

        public static FbxIOBase Create(FbxObject pContainer, string pName) =>
            throw new NotImplementedException();

        #endregion

        #region Static Public Attributes

        // static FbxClassId ClassId

        #endregion

        #region Protected Member Functions

        // virtual ~FbxIOBase()

        protected FbxIOBase(string pName)
            : base(pName)
        {
        }

        #endregion

        #region Static Protected Member Functions

        // static FbxIOBase* Allocate(FbxManager* pManager, const char* pName, const FbxIOBase* pFrom)

        #endregion
    }
}
