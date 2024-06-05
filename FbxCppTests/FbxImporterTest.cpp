
#include "Tests.h"

using namespace std;

void FbxImporter_Create_AllZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // expect:
    AssertFalse(importer->IsFBX());
    AssertEqual(-1, importer->GetFileFormat());
}

void FbxImporter_IsImporting_UninitializedYieldsFalse()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result = false;

    // expect:
    AssertFalse(importer->IsImporting(result));
    AssertFalse(result);
}

void FbxImporter_GetProgress_UninitializedYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // expect:
    AssertEqual(0.0, importer->GetProgress(NULL));
}

void FbxImporter_GetFileVersion_UninitializedYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(0, major);
    AssertEqual(0, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileHeaderInfo_UninitializedYieldsDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(false, header->mBinary);
    AssertEqual(0, header->mFileVersion);
    AssertEqual(false, header->mCreationTimeStampPresent);
    AssertEqual(0, header->mCreationTimeStamp.mYear);
    AssertEqual(0, header->mCreationTimeStamp.mMonth);
    AssertEqual(0, header->mCreationTimeStamp.mDay);
    AssertEqual(0, header->mCreationTimeStamp.mHour);
    AssertEqual(0, header->mCreationTimeStamp.mMinute);
    AssertEqual(0, header->mCreationTimeStamp.mSecond);
    AssertEqual(0, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetIOSettings_UninitializedYieldsNull()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOSettings* result;

    // when:
    result = importer->GetIOSettings();

    // then:
    AssertNull(result);
}

void FbxImporter_Initialize_ValidFile_Succeeds1()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // when:
    result = importer->Initialize(GetSample("monolith.fbx").c_str());

    // then:
    AssertTrue(result);
}

void FbxImporter_Initialize_ValidFile_Succeeds2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // when:
    result = importer->Initialize(GetSample("monolith.fbx").c_str());

    // then:
    AssertEqual(FbxStatus::EStatusCode::eSuccess, importer->GetStatus().GetCode());
}

void FbxImporter_Initialize_ValidFile_Succeeds3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // when:
    result = importer->Initialize(GetSample("monolith.fbx").c_str());

    // then:
    AssertFalse(importer->GetStatus().Error());
}

void FbxImporter_Initialize_ValidFile_Succeeds4()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // when:
    result = importer->Initialize(GetSample("monolith.fbx").c_str());

    // then:
    AssertEqual("", importer->GetStatus().GetErrorString());
}

void FbxImporter_IsImporting_InitializedYieldsFalse()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result = false;
    importer->Initialize(GetSample("monolith.fbx").c_str());

    // expect:
    AssertFalse(importer->IsImporting(result));
    AssertFalse(result);
}

void FbxImporter_GetProgress_InitializedYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    importer->Initialize(GetSample("monolith.fbx").c_str());

    // expect:
    AssertEqual(0.0, importer->GetProgress(NULL));
}

void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;
    importer->Initialize(GetSample("monolith.fbx").c_str());

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(7, major);
    AssertEqual(4, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6a()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;
    importer->Initialize(GetSample("monolith_fbx6ascii.fbx").c_str());

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(6, major);
    AssertEqual(1, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6b()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;
    importer->Initialize(GetSample("monolith_fbx6binary.fbx").c_str());

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(6, major);
    AssertEqual(1, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7a()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;
    importer->Initialize(GetSample("monolith_fbx7ascii.fbx").c_str());

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(7, major);
    AssertEqual(7, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7b()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major = 0;
    int minor = 0;
    int revision = 0;
    importer->Initialize(GetSample("monolith_fbx7binary.fbx").c_str());

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(7, major);
    AssertEqual(7, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;
    importer->Initialize(GetSample("monolith.fbx").c_str());

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(true, header->mBinary);
    AssertEqual(7400, header->mFileVersion);
    AssertEqual(true, header->mCreationTimeStampPresent);
    AssertEqual(2024, header->mCreationTimeStamp.mYear);
    AssertEqual(5, header->mCreationTimeStamp.mMonth);
    AssertEqual(13, header->mCreationTimeStamp.mDay);
    AssertEqual(22, header->mCreationTimeStamp.mHour);
    AssertEqual(30, header->mCreationTimeStamp.mMinute);
    AssertEqual(25, header->mCreationTimeStamp.mSecond);
    AssertEqual(938, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("Blender (stable FBX IO) - 4.0.1 - 5.8.12", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6a()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;
    importer->Initialize(GetSample("monolith_fbx6ascii.fbx").c_str());

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(false, header->mBinary);
    AssertEqual(6100, header->mFileVersion);
    AssertEqual(true, header->mCreationTimeStampPresent);
    AssertEqual(2024, header->mCreationTimeStamp.mYear);
    AssertEqual(6, header->mCreationTimeStamp.mMonth);
    AssertEqual(4, header->mCreationTimeStamp.mDay);
    AssertEqual(2, header->mCreationTimeStamp.mHour);
    AssertEqual(59, header->mCreationTimeStamp.mMinute);
    AssertEqual(23, header->mCreationTimeStamp.mSecond);
    AssertEqual(0, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("FBX SDK/FBX Plugins version 2020.3.4", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6b()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;
    importer->Initialize(GetSample("monolith_fbx6binary.fbx").c_str());

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(true, header->mBinary);
    AssertEqual(6100, header->mFileVersion);
    AssertEqual(true, header->mCreationTimeStampPresent);
    AssertEqual(2024, header->mCreationTimeStamp.mYear);
    AssertEqual(6, header->mCreationTimeStamp.mMonth);
    AssertEqual(4, header->mCreationTimeStamp.mDay);
    AssertEqual(2, header->mCreationTimeStamp.mHour);
    AssertEqual(59, header->mCreationTimeStamp.mMinute);
    AssertEqual(23, header->mCreationTimeStamp.mSecond);
    AssertEqual(0, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("FBX SDK/FBX Plugins version 2020.3.4", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7a()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;
    importer->Initialize(GetSample("monolith_fbx7ascii.fbx").c_str());

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(false, header->mBinary);
    AssertEqual(7700, header->mFileVersion);
    AssertEqual(true, header->mCreationTimeStampPresent);
    AssertEqual(2024, header->mCreationTimeStamp.mYear);
    AssertEqual(6, header->mCreationTimeStamp.mMonth);
    AssertEqual(4, header->mCreationTimeStamp.mDay);
    AssertEqual(2, header->mCreationTimeStamp.mHour);
    AssertEqual(59, header->mCreationTimeStamp.mMinute);
    AssertEqual(23, header->mCreationTimeStamp.mSecond);
    AssertEqual(0, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("FBX SDK/FBX Plugins version 2020.3.4", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7b()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;
    importer->Initialize(GetSample("monolith_fbx7binary.fbx").c_str());

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);
    AssertEqual(false, header->mDefaultRenderResolution.mIsOK);
    AssertEqual("", header->mDefaultRenderResolution.mCameraName);
    AssertEqual("", header->mDefaultRenderResolution.mResolutionMode);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionW);
    AssertEqual(0.0, header->mDefaultRenderResolution.mResolutionH);
    AssertEqual(true, header->mBinary);
    AssertEqual(7700, header->mFileVersion);
    AssertEqual(true, header->mCreationTimeStampPresent);
    AssertEqual(2024, header->mCreationTimeStamp.mYear);
    AssertEqual(6, header->mCreationTimeStamp.mMonth);
    AssertEqual(4, header->mCreationTimeStamp.mDay);
    AssertEqual(2, header->mCreationTimeStamp.mHour);
    AssertEqual(59, header->mCreationTimeStamp.mMinute);
    AssertEqual(23, header->mCreationTimeStamp.mSecond);
    AssertEqual(0, header->mCreationTimeStamp.mMillisecond);
    AssertEqual("FBX SDK/FBX Plugins version 2020.3.4", header->mCreator);
    AssertEqual(false, header->mIOPlugin);
    AssertEqual(false, header->mPLE);
}

void FbxImporter_GetIOSettings_InitializedYieldsAnObject()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOSettings* result;
    FbxIOSettings* result2;
    importer->Initialize(GetSample("monolith.fbx").c_str());

    // when:
    result = importer->GetIOSettings();

    // then:
    AssertNotNull(result);
    AssertEqual("IOSRoot", result->GetName());

    // when:
    result2 = importer->GetIOSettings();

    // then:
    // it's the same object;
    AssertEqual(result, result2);
}

void FbxImporterTest::RegisterTestCases()
{
    AddTestCase(FbxImporter_Create_AllZero);
    AddTestCase(FbxImporter_IsImporting_UninitializedYieldsFalse);
    AddTestCase(FbxImporter_GetProgress_UninitializedYieldsZero);
    AddTestCase(FbxImporter_GetFileVersion_UninitializedYieldsZero);
    AddTestCase(FbxImporter_GetFileHeaderInfo_UninitializedYieldsDefaults);
    AddTestCase(FbxImporter_GetIOSettings_UninitializedYieldsNull);
    AddTestCase(FbxImporter_Initialize_ValidFile_Succeeds1);
    AddTestCase(FbxImporter_Initialize_ValidFile_Succeeds2);
    AddTestCase(FbxImporter_Initialize_ValidFile_Succeeds3);
    AddTestCase(FbxImporter_Initialize_ValidFile_Succeeds4);
    AddTestCase(FbxImporter_IsImporting_InitializedYieldsFalse);
    AddTestCase(FbxImporter_GetProgress_InitializedYieldsZero);
    AddTestCase(FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile);
    AddTestCase(FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6a);
    AddTestCase(FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile6b);
    AddTestCase(FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7a);
    AddTestCase(FbxImporter_GetFileVersion_InitializedYieldsVersionNumbersFromTheFile7b);
    AddTestCase(FbxImporter_GetFileHeaderInfo_InitializedYieldsValues);
    AddTestCase(FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6a);
    AddTestCase(FbxImporter_GetFileHeaderInfo_InitializedYieldsValues6b);
    AddTestCase(FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7a);
    AddTestCase(FbxImporter_GetFileHeaderInfo_InitializedYieldsValues7b);
    AddTestCase(FbxImporter_GetIOSettings_InitializedYieldsAnObject);
}

