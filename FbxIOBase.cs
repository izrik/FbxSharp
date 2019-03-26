using System;

namespace FbxSharp
{
    public class FbxIOBase : FbxObject
    {
        public FbxIOBase()
        {
        }

//        public virtual bool Initialize(string pFilename,  int pFileFormat=-1, FbxIOSettings pIOSettings=null)
//        {
//            throw new NotImplementedException();
//        }

        public virtual string GetFilename()
        {
            throw new NotImplementedException();
        }

//        public FbxStatus& GetStatus()
//        {
//            throw new NotImplementedException();
//        }
    }
}

