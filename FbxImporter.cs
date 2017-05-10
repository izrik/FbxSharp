using System;
using System.IO;

namespace FbxSharp
{
    public class FbxImporter
    {
        public FbxImporter(string name = null)
        {
            Name = name;
        }

        public string Name;

        //public bool Initialize(string pFileName /*, int pFileFormat = -1, FbxIOSettings*pIOSettings = null*/)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Import(Document pDocument /*, bool pNonBlocking=false*/)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxScene Import(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                var parser = new Parser(new Tokenizer(reader));
                var converter = new Converter();

                var pobjects = parser.ReadFile();
                var scene = converter.ConvertScene(pobjects);

                return scene;
            }
        }
    }
}

