using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxImporterTest : TestBase
    {
        [Test]
        public void FbxImporter_Create_AllZero()
        {
            // given:
            var importer = new FbxImporter("");

            // then:
            Assert.False(importer.IsFBX());
            Assert.False(importer.IsImporting());
        }

        [Test]
        public void FbxImporter_GetFileVersion_UninitializedYieldsDefaults()
        {
            // given:
            var importer = new FbxImporter("");
            int major;
            int minor;
            int revision;

            // when:
            importer.GetFileVersion(major, minor, revision);

            // then:
            Assert.AreEqual(5, major);
            Assert.AreEqual(0, minor);
            Assert.AreEqual(0, revision);
        }
    }
}
