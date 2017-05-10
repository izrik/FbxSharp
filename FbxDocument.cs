using System;

namespace FbxSharp
{
    public class FbxDocument : FbxCollection
    {
        public FbxDocument(string name="")
            : base(name)
        {
            this.Properties.Add(Roots);
            this.Properties.Add(ActiveAnimStackName);
        }

        #region Properties

        public readonly FbxPropertyT<FbxObject> Roots = new FbxPropertyT<FbxObject>("SourceObject");

        #endregion

        #region Animation Stack Management

        public readonly FbxPropertyT<string> ActiveAnimStackName = new FbxPropertyT<string>("ActiveAnimStackName");

        bool CreateAnimStack(string pName/*, FbxStatus *pStatus=NULL*/)
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
    }
}

