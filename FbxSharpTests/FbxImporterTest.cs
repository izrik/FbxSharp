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

            // expect:
            Assert.False(importer.IsFBX());
            Assert.AreEqual(-1, importer.GetFileFormat());
        }

        [Test]
        public void FbxImporter_IsImporting_UninitializedYieldsFalse()
        {
            // given:
            var importer = new FbxImporter("");
            var result = false;

            // expect:
            Assert.False(importer.IsImporting(out result));
            Assert.False(result);
        }

        [Test]
        public void FbxImporter_GetProgress_UninitializedYieldsZero()
        {
            // given:
            var importer = new FbxImporter("");

            // expect:
            Assert.AreEqual(0.0, importer.GetProgress(null));
        }

        [Test]
        public void FbxImporter_GetFileVersion_UninitializedYieldsZero()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.AreEqual(0, major);
            Assert.AreEqual(0, minor);
            Assert.AreEqual(0, revision);
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_UninitializedYieldsDefaults()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.AreEqual(false, header.mDefaultRenderResolution.mIsOK);
            Assert.AreEqual("", header.mDefaultRenderResolution.mCameraName);
            Assert.AreEqual("", header.mDefaultRenderResolution.mResolutionMode);
            Assert.AreEqual(0.0, header.mDefaultRenderResolution.mResolutionW);
            Assert.AreEqual(0.0, header.mDefaultRenderResolution.mResolutionH);
            Assert.AreEqual(false, header.mBinary);
            Assert.AreEqual(0, header.mFileVersion);
            Assert.AreEqual(false, header.mCreationTimeStampPresent);
            Assert.AreEqual(0, header.mCreationTimeStamp.mYear);
            Assert.AreEqual(0, header.mCreationTimeStamp.mMonth);
            Assert.AreEqual(0, header.mCreationTimeStamp.mDay);
            Assert.AreEqual(0, header.mCreationTimeStamp.mHour);
            Assert.AreEqual(0, header.mCreationTimeStamp.mMinute);
            Assert.AreEqual(0, header.mCreationTimeStamp.mSecond);
            Assert.AreEqual(0, header.mCreationTimeStamp.mMillisecond);
            Assert.AreEqual("", header.mCreator);
            Assert.AreEqual(false, header.mIOPlugin);
            Assert.AreEqual(false, header.mPLE);
        }

        [Test]
        public void FbxImporter_GetIOSettings_UninitializedYieldsNull()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOSettings result;

            // when:
            result = importer.GetIOSettings();

            // then:
            Assert.Null(result);
        }

        [Test]
        public void FbxImporter_Initialize_ValidFile_Succeeds1()
        {
            // given:
            var importer = new FbxImporter("");
            bool result;

            // when:
            result = importer.Initialize("../samples/monolith.fbx");

            // then:
            Assert.True(result);
        }

        [Test]
        public void FbxImporter_Initialize_ValidFile_Succeeds2()
        {
            // given:
            var importer = new FbxImporter("");
            bool result;

            // when:
            result = importer.Initialize("../samples/monolith.fbx");

            // then:
            Assert.AreEqual(FbxStatus.EStatusCode.eSuccess, importer.GetStatus().GetCode());
        }

        [Test]
        public void FbxImporter_Initialize_ValidFile_Succeeds3()
        {
            // given:
            var importer = new FbxImporter("");
            bool result;

            // when:
            result = importer.Initialize("../samples/monolith.fbx");

            // then:
            Assert.False(importer.GetStatus().Error());
        }
    }
}
