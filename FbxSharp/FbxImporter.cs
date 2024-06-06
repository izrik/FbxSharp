using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace FbxSharp
{
    public class FbxImporter : FbxIOBase
    {
        public FbxImporter(string name = null)
            : base(name)
        {
        }

        public string Name;

        private string initializedFilename = null;
        private FbxStatus currentStatus = new();

        bool ArraysEqual(byte[] a1, int offset1, byte[] a2, int offset2,
            int count)
        {
            for (var i = 0; i < count; i++)
                if (a1[offset1 + i] != a2[offset2 + i])
                    return false;
            return true;
        }

        public override string GetFileName() => initializedFilename;

        public override bool Initialize(string fileName, int fileFormat = -1,
            FbxIOSettings ioSettings = null)
        {
            if (ioSettings == null)
                ioSettings = new FbxIOSettings("IOSRoot");

            initializedFilename = fileName;
            this.ioSettings = ioSettings;

            // open the file
            var fhi = new FbxIOFileHeaderInfo();
            using (var fs = File.OpenRead(initializedFilename))
            {
                // determine if it's ascii or binary
                var buffer = new byte[1024];
                int count = fs.Read(buffer, 0, 20);
                if (count < 20)
                    throw new InvalidOperationException();
                var binaryHeader =
                    Encoding.ASCII.GetBytes("Kaydara FBX Binary  ");
                if (buffer[0] == ';')
                    fhi.mBinary = false;
                else if (ArraysEqual(buffer, 0, binaryHeader, 0, 20))
                    fhi.mBinary = true;
                else
                    throw new InvalidOperationException(
                        "Can't determine if it's ascii or binary");

                // determine the file format version
                // ascii major/minor/patch versions start at offset 6, "a.b.c"
                // format version XXXX is in .FBXHeaderExtension.FBXVersion
                // binary file format:
                //  header                  20 bytes
                //  header null-terminator  1 byte 0x00
                //  reserved/unknown        2 bytes 0x1a 0x00
                //  format version          4 bytes little endian uint32
                //      6100 = 0x17d4
                //      7400 = 0x1ce8
                //      7700 = 0x1e14
                if (fhi.mBinary)
                {
                    count = fs.Read(buffer, 20, 7);
                    if (count != 7)
                        throw new InvalidOperationException("Unexpected EOF");
                    int value =
                        BinaryPrimitives.ReadInt32LittleEndian(
                            new Span<byte>(buffer, 23, 4));
                    fhi.mFileVersion = value;
                }
                else
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(fs, Encoding.ASCII);
                    var t = new Tokenizer(reader);
                    var parser = new Parser(t);

                    var po = parser.ReadObject();
                    if (po == null)
                        throw new InvalidOperationException(
                            "No object read from file");
                    if (po.Name != "FBXHeaderExtension")
                        throw new InvalidOperationException(
                            $"Expected FBXHeaderExtension object, " +
                            $"got {po.Name}");

                    var prop = po.FindPropertyByName("FBXHeaderVersion");
                    if (prop == null)
                        throw new InvalidOperationException(
                            "No FBXHeaderVersion found");
                    int fbxHeaderVersion = prop.GetIntValue();

                    prop = po.FindPropertyByName("FBXVersion");
                    if (prop == null)
                        throw new InvalidOperationException(
                            "No FBXVersion found");
                    fhi.mFileVersion = prop.GetIntValue();

                    prop = po.FindPropertyByName("CreationTimeStamp");
                    if (prop != null)
                    {
                        var lt = new FbxLocalTime();
                        fhi.mCreationTimeStampPresent = true;
                        var prop2 = prop.FindPropertyByName("Version");
                        prop2 = prop.FindPropertyByName("Year");
                        lt.mYear = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Month");
                        lt.mMonth = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Day");
                        lt.mDay = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Hour");
                        lt.mHour = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Minute");
                        lt.mMinute = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Second");
                        lt.mSecond = prop2.GetIntValue();
                        prop2 = prop.FindPropertyByName("Millisecond");
                        lt.mMillisecond = prop2.GetIntValue();

                        fhi.mCreationTimeStamp = lt;
                    }

                    prop = po.FindPropertyByName("Creator");
                    fhi.mCreator = prop.GetStringValue();
                }
            }

            fileHeaderInfo = fhi;

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
            major = (fileHeaderInfo.mFileVersion / 1000) % 10;
            minor = (fileHeaderInfo.mFileVersion / 100) % 10;
            revision = (fileHeaderInfo.mFileVersion / 10) % 10;
        }

        private FbxIOFileHeaderInfo fileHeaderInfo = new();

        public FbxIOFileHeaderInfo GetFileHeaderInfo()
        {
            return fileHeaderInfo;
        }

        private FbxIOSettings ioSettings;

        public FbxIOSettings GetIOSettings()
        {
            return ioSettings;
        }

        public override FbxStatus GetStatus()
        {
            return currentStatus;
        }
    }
}
