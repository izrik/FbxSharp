
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

void FbxImporter_IsFBX_UnitializedYieldsFalse()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxImporter* importer = FbxImporter::Create(manager, "");

    // then:
    AssertFalse(importer->IsFBX());
}

void FbxImporterTest::RegisterTestCases()
{
    AddTestCase(FbxImporter_Create_AllZero);
    AddTestCase(FbxImporter_IsFBX_UnitializedYieldsFalse);
}

