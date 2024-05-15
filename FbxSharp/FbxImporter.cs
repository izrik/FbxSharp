using System;
using System.IO;

namespace FbxSharp
{
    public class FbxImporter : FbxIOBase
    {
        public FbxImporter(string name = null)
        {
            Name = name;
        }

        public string Name;

        private string initializedFilename = null;
        private FbxStatus currentStatus = new();

        public bool Initialize(string fileName, int fileFormat = -1,
            FbxIOSettings ioSettings = null)
        {
            initializedFilename = fileName;
            currentStatus = new FbxStatus()
            {

            };
            return true;
        }

        public bool Import(FbxDocument document, bool pNonBlocking = false)
        {
            throw new NotImplementedException();
        }

        [NotSdk]
        public FbxScene Import(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                var parser =
                    new Parser(new Tokenizer(reader, filename: filename));
                var converter = new Converter();

                var pobjects = parser.ReadFile();
                var scene = converter.ConvertScene(pobjects);

                return scene;
            }
        }

        public bool IsFBX()
        {
            return false;
        }

        public int GetFileFormat()
        {
            return -1;
        }

        public bool IsImporting(out bool importResult)
        {
            importResult = false;
            return false;
        }

        public float GetProgress(object param)
        {
            return 0;
        }

        public void GetFileVersion(out int major, out int minor,
            out int revision)
        {
            major = 0;
            minor = 0;
            revision = 0;
        }

        public FbxIOFileHeaderInfo GetFileHeaderInfo()
        {
            return new FbxIOFileHeaderInfo();
        }

        public FbxIOSettings GetIOSettings()
        {
            return null;
        }

        public FbxStatus GetStatus()
        {
            return currentStatus;
        }
    }
}
