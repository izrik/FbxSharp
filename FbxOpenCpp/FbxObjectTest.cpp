
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

void FbxObject_GetName_GetsName()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // then:
    AssertEqual("asdf", obj->GetName());
}

void FbxObject_SetName_SetsName()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // when:
    obj->SetName("qwer");

    // then:
    AssertEqual("qwer", obj->GetName());
}

void FbxObject_SetNameSpace_SetsNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // when:
    obj->SetNameSpace("qwer");

    // then:
    AssertEqual("qwer", obj->GetNameSpaceOnly());
}

void FbxObject_GetNameSpaceArray_SplitsNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("name:space");
    FbxArray<FbxString*> arr;

    // when:
    arr = obj->GetNameSpaceArray(':');

    // then:
    AssertEqual(2, arr.GetCount());
    AssertEqual("space", *arr.GetAt(0));
    AssertEqual("name", *arr.GetAt(1));

    // when:
    arr = obj->GetNameSpaceArray('s');

    // then:
    AssertEqual(2, arr.GetCount());
    AssertEqual("pace", *arr.GetAt(0));
    AssertEqual("name:", *arr.GetAt(1));

    // when:
    arr = obj->GetNameSpaceArray('a');

    // then:
    AssertEqual(3, arr.GetCount());
    AssertEqual("ce", *arr.GetAt(0));
    AssertEqual("me:sp", *arr.GetAt(1));
    AssertEqual("n", *arr.GetAt(2));
}

void FbxObjectTest::RegisterTestCases()
{
    AddTestCase(FbxObject_Create_HasZeroProperties);
    AddTestCase(FbxObject_Create_HasRootProperty);
    AddTestCase(FbxObject_Create_HasClassRootProperty);
    AddTestCase(FbxObject_GetName_GetsName);
    AddTestCase(FbxObject_SetName_SetsName);
    AddTestCase(FbxObject_SetNameSpace_SetsNamespace);
    AddTestCase(FbxObject_GetNameSpaceArray_SplitsNamespace);
}

