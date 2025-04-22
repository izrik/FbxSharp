
#include "Tests.h"

using namespace std;

void FbxNull_StaticInitialization()
{
    // expect:
    AssertEqual(100.0d, FbxNull::sDefaultSize);
    AssertEqual(FbxNull::ELook::eCross, FbxNull::sDefaultLook);
    AssertEqual("Size", FbxNull::sSize);
    AssertEqual("Look", FbxNull::sLook);
}

void FbxNull_Create_SetsDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    // when:
    FbxNull* n = FbxNull::Create(manager, "name");
    // then:
    AssertEqual("name", n->GetName());
    AssertEqual(100.0d, n->GetSizeDefaultValue());
    AssertEqual(100.0d, n->Size.Get());
    AssertEqual(FbxNull::ELook::eCross, n->Look.Get());
}

void FbxNull_Reset_ResetsPropertyValues()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNull* n = FbxNull::Create(manager, "");
    n->Size.Set(234);
    n->Look.Set(FbxNull::ELook::eNone);
    // require:
    AssertEqual(234.0d, n->Size.Get());
    AssertEqual(FbxNull::ELook::eNone, n->Look.Get());
    // when:
    n->Reset();
    // then:
    AssertEqual(FbxNull::sDefaultSize, n->Size.Get());
    AssertEqual(FbxNull::sDefaultLook, n->Look.Get());
}

void FbxNullTest::RegisterTestCases()
{
    AddTestCase(FbxNull_StaticInitialization);
    AddTestCase(FbxNull_Create_SetsDefaults);
    AddTestCase(FbxNull_Reset_ResetsPropertyValues);
}

