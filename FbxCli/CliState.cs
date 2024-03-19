using FbxSharp;

namespace FbxCli
{
    public class CliState
    {
        public CliState(FbxObject rootObject)
        {
            RootObject = rootObject;
            Current = rootObject;
        }

        public FbxObject RootObject { get; }
        public FbxObject Current { get; set; }
    }
}