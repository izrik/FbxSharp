
#include "Tests.h"

using namespace std;

void FbxImporter_Create_AllZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // expect:
    AssertFalse(importer->IsFBX());
}

void FbxImporter_IsImporting_UninitializedYieldsFalse()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // expect:
    AssertFalse(importer->IsImporting(result));
}

void FbxImporter_GetProgress_UninitializedYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    bool result;

    // expect:
    AssertEqual(0.0, importer->GetProgress(NULL));
}

void FbxImporter_GetFileVersion_UninitializedYieldsZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    int major;
    int minor;
    int revision;

    // when:
    importer->GetFileVersion(major, minor, revision);

    // then:
    AssertEqual(0, major);
    AssertEqual(0, minor);
    AssertEqual(0, revision);
}

void FbxImporter_GetFileHeaderInfo_UninitializedYieldsNonNull()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");
    FbxIOFileHeaderInfo* header;

    // when:
    header = importer->GetFileHeaderInfo();

    // then:
    AssertNotNull(header);  // !!!;
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

void FbxImporterTest::RegisterTestCases()
{
    AddTestCase(FbxImporter_Create_AllZero);
    AddTestCase(FbxImporter_IsImporting_UninitializedYieldsFalse);
    AddTestCase(FbxImporter_GetProgress_UninitializedYieldsZero);
    AddTestCase(FbxImporter_GetFileVersion_UninitializedYieldsZero);
    AddTestCase(FbxImporter_GetFileHeaderInfo_UninitializedYieldsNonNull);
    AddTestCase(FbxImporter_GetIOSettings_UninitializedYieldsNull);
}

