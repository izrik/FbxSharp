using System;

namespace FbxSharp
{
    public class Document : FbxCollection
    {
        public Document(string name="")
            : base(name)
        {
            this.Properties.Add(Roots);
            this.Properties.Add(ActiveAnimStackName);
        }

        #region Properties

        public readonly PropertyT<FbxObject> Roots = new PropertyT<FbxObject>("SourceObject");

        #endregion

        #region Animation Stack Management

        public readonly PropertyT<string> ActiveAnimStackName = new PropertyT<string>("ActiveAnimStackName");

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

