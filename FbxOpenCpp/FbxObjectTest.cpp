
#include "Tests.h"

using namespace std;

void FbxObject_Create_HasZeroProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");

    // then:
    AssertEqual(0, CountProperties(obj));
    AssertEqual(0, obj->GetSrcPropertyCount());
    AssertEqual(0, obj->GetDstPropertyCount());
}

void FbxObject_Create_HasRootProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");

    // then:
    AssertTrue((&obj->RootProperty)->IsValid());
    AssertEqual("", obj->RootProperty.GetName());
}

void FbxObject_Create_HasClassRootProperty()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");

    // then:
    AssertTrue(obj->GetClassRootProperty().IsValid());
}

void FbxObjectTest::RegisterTestCases()
{
    AddTestCase(FbxObject_Create_HasZeroProperties);
    AddTestCase(FbxObject_Create_HasRootProperty);
    AddTestCase(FbxObject_Create_HasClassRootProperty);
}

