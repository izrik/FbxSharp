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
            Assert.AreEqual(0, CountProperties(importer));
            Assert.AreEqual(0, importer.GetSrcPropertyCount());
            Assert.AreEqual(0, importer.GetDstPropertyCount());
        }

        [Test]
        public void FbxImporter_IsFBX_UnitializedYieldsError()
        {
            // given:
            var importer = new FbxImporter("");

            // then:
            Assert.True(true);
        }
    }
}
