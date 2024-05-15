
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
    result = importer->Initialize("../samples/monolith.fbx");

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
    result = importer->Initialize("../samples/monolith.fbx");

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
    result = importer->Initialize("../samples/monolith.fbx");

    // then:
    AssertFalse(importer->GetStatus().Error());
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
}

