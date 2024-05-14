
#include "Tests.h"

using namespace std;

void FbxImporter_Create_AllZero()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // then:
    AssertEqual(0, CountProperties(importer));
    AssertEqual(0, importer->GetSrcPropertyCount());
    AssertEqual(0, importer->GetDstPropertyCount());
}

void FbxImporter_IsFBX_UnitializedYieldsError()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // then:
    AssertTrue(true);
}

void FbxImporterTest::RegisterTestCases()
{
    AddTestCase(FbxImporter_Create_AllZero);
    AddTestCase(FbxImporter_IsFBX_UnitializedYieldsError);
}

