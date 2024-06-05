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
            Assert.That(importer.GetFileFormat(), Is.EqualTo(-1));
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
            Assert.That(importer.GetProgress(null), Is.EqualTo(0.0));
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
            Assert.That(major, Is.EqualTo(0));
            Assert.That(minor, Is.EqualTo(0));
            Assert.That(revision, Is.EqualTo(0));
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
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(false));
            Assert.That(header.mFileVersion, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(false));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(0));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(0));
            Assert.That(header.mCreator, Is.EqualTo(""));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
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
            result = importer.Initialize(GetSample("monolith.fbx"));

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
            result = importer.Initialize(GetSample("monolith.fbx"));

            // then:
            Assert.That(importer.GetStatus().GetCode(), Is.EqualTo(FbxStatus.EStatusCode.eSuccess));
        }

        [Test]
        public void FbxImporter_Initialize_ValidFile_Succeeds3()
        {
            // given:
            var importer = new FbxImporter("");
            bool result;

            // when:
            result = importer.Initialize(GetSample("monolith.fbx"));

            // then:
            Assert.False(importer.GetStatus().Error());
        }

        [Test]
        public void FbxImporter_Initialize_ValidFile_Succeeds4()
        {
            // given:
            var importer = new FbxImporter("");
            bool result;

            // when:
            result = importer.Initialize(GetSample("monolith.fbx"));

            // then:
            Assert.That(importer.GetStatus().GetErrorString(), Is.EqualTo(""));
        }

        [Test]
        public void FbxImporter_IsImporting_InitializedYieldsFalse()
        {
            // given:
            var importer = new FbxImporter("");
            var result = false;
            importer.Initialize(GetSample("monolith.fbx"));

            // expect:
            Assert.False(importer.IsImporting(out result));
            Assert.False(result);
        }

        [Test]
        public void FbxImporter_GetProgress_InitializedYieldsZero()
        {
            // given:
            var importer = new FbxImporter("");
            importer.Initialize(GetSample("monolith.fbx"));

            // expect:
            Assert.That(importer.GetProgress(null), Is.EqualTo(0.0));
        }

        [Test]
        public void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;
            importer.Initialize(GetSample("monolith.fbx"));

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.That(major, Is.EqualTo(7));
            Assert.That(minor, Is.EqualTo(4));
            Assert.That(revision, Is.EqualTo(0));
        }

        [Test]
        public void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6a()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;
            importer.Initialize(GetSample("monolith_fbx6ascii.fbx"));

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.That(major, Is.EqualTo(6));
            Assert.That(minor, Is.EqualTo(1));
            Assert.That(revision, Is.EqualTo(0));
        }

        [Test]
        public void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6b()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;
            importer.Initialize(GetSample("monolith_fbx6binary.fbx"));

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.That(major, Is.EqualTo(6));
            Assert.That(minor, Is.EqualTo(1));
            Assert.That(revision, Is.EqualTo(0));
        }

        [Test]
        public void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7a()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;
            importer.Initialize(GetSample("monolith_fbx7ascii.fbx"));

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.That(major, Is.EqualTo(7));
            Assert.That(minor, Is.EqualTo(7));
            Assert.That(revision, Is.EqualTo(0));
        }

        [Test]
        public void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7b()
        {
            // given:
            var importer = new FbxImporter("");
            var major = 0;
            var minor = 0;
            var revision = 0;
            importer.Initialize(GetSample("monolith_fbx7binary.fbx"));

            // when:
            importer.GetFileVersion(out major, out minor, out revision);

            // then:
            Assert.That(major, Is.EqualTo(7));
            Assert.That(minor, Is.EqualTo(7));
            Assert.That(revision, Is.EqualTo(0));
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;
            importer.Initialize(GetSample("monolith.fbx"));

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(true));
            Assert.That(header.mFileVersion, Is.EqualTo(7400));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(true));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(2024));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(5));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(13));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(22));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(30));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(25));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(938));
            Assert.That(header.mCreator, Is.EqualTo("Blender (stable FBX IO) - 4.0.1 - 5.8.12"));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6a()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;
            importer.Initialize(GetSample("monolith_fbx6ascii.fbx"));

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(false));
            Assert.That(header.mFileVersion, Is.EqualTo(6100));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(true));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(2024));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(6));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(4));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(2));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(59));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(23));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(0));
            Assert.That(header.mCreator, Is.EqualTo("FBX SDK/FBX Plugins version 2020.3.4"));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6b()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;
            importer.Initialize(GetSample("monolith_fbx6binary.fbx"));

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(true));
            Assert.That(header.mFileVersion, Is.EqualTo(6100));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(true));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(2024));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(6));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(4));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(2));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(59));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(23));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(0));
            Assert.That(header.mCreator, Is.EqualTo("FBX SDK/FBX Plugins version 2020.3.4"));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7a()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;
            importer.Initialize(GetSample("monolith_fbx7ascii.fbx"));

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(false));
            Assert.That(header.mFileVersion, Is.EqualTo(7700));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(true));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(2024));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(6));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(4));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(2));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(59));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(23));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(0));
            Assert.That(header.mCreator, Is.EqualTo("FBX SDK/FBX Plugins version 2020.3.4"));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
        }

        [Test]
        public void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7b()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOFileHeaderInfo header;
            importer.Initialize(GetSample("monolith_fbx7binary.fbx"));

            // when:
            header = importer.GetFileHeaderInfo();

            // then:
            Assert.NotNull(header);
            Assert.That(header.mDefaultRenderResolution.mIsOK, Is.EqualTo(false));
            Assert.That(header.mDefaultRenderResolution.mCameraName, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionMode, Is.EqualTo(""));
            Assert.That(header.mDefaultRenderResolution.mResolutionW, Is.EqualTo(0.0));
            Assert.That(header.mDefaultRenderResolution.mResolutionH, Is.EqualTo(0.0));
            Assert.That(header.mBinary, Is.EqualTo(true));
            Assert.That(header.mFileVersion, Is.EqualTo(7700));
            Assert.That(header.mCreationTimeStampPresent, Is.EqualTo(true));
            Assert.That(header.mCreationTimeStamp.mYear, Is.EqualTo(2024));
            Assert.That(header.mCreationTimeStamp.mMonth, Is.EqualTo(6));
            Assert.That(header.mCreationTimeStamp.mDay, Is.EqualTo(4));
            Assert.That(header.mCreationTimeStamp.mHour, Is.EqualTo(2));
            Assert.That(header.mCreationTimeStamp.mMinute, Is.EqualTo(59));
            Assert.That(header.mCreationTimeStamp.mSecond, Is.EqualTo(23));
            Assert.That(header.mCreationTimeStamp.mMillisecond, Is.EqualTo(0));
            Assert.That(header.mCreator, Is.EqualTo("FBX SDK/FBX Plugins version 2020.3.4"));
            Assert.That(header.mIOPlugin, Is.EqualTo(false));
            Assert.That(header.mPLE, Is.EqualTo(false));
        }

        [Test]
        public void FbxImporter_GetIOSettings_InitializedYieldsAnObject()
        {
            // given:
            var importer = new FbxImporter("");
            FbxIOSettings result;
            FbxIOSettings result2;
            importer.Initialize(GetSample("monolith.fbx"));

            // when:
            result = importer.GetIOSettings();

            // then:
            Assert.NotNull(result);

            // when:
            result2 = importer.GetIOSettings();

            // then:
            // it's the same object;
            Assert.That(result2, Is.EqualTo(result));
        }
    }
}
