
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

void FbxObject_Create_EmptyNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // then:
    AssertEqual("", obj->GetNameSpaceOnly());
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

void FbxObject_Create_SetsInitialName()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetInitialName());
}

void FbxObject_SetName_DoesntChangeInitialName()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetInitialName());
    AssertEqual("asdf", obj->GetName());

    // when:
    obj->SetName("qwer");

    // then:
    AssertEqual("asdf", obj->GetInitialName());
    AssertEqual("qwer", obj->GetName());
}

void FbxObject_SetInitialName_SetsInitialNameAndName()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetInitialName());
    AssertEqual("asdf", obj->GetName());

    // when:
    obj->SetInitialName("qwer");

    // then:
    AssertEqual("qwer", obj->GetInitialName());
    AssertEqual("qwer", obj->GetName());
}

void FbxObject_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // then:
    AssertEqual("", obj->GetNameSpacePrefix());
}

void FbxObject_GetNameOnly_GetsNameWithoutNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetNameOnly());
}

void FbxObject_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // then:
    AssertEqual("sdf", obj->GetNameOnly());
}

void FbxObject_SetNameSpaceThenSetName_FirstCharacterIsStillMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // when:
    obj->SetName("zxcv");

    // then:
    AssertEqual("asdf", obj->GetInitialName());
    AssertEqual("zxcv", obj->GetName());
    AssertEqual("xcv", obj->GetNameOnly());
}

void FbxObject_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // when:
    obj->SetInitialName("zxcv");

    // then:
    AssertEqual("zxcv", obj->GetInitialName());
    AssertEqual("zxcv", obj->GetName());
    AssertEqual("xcv", obj->GetNameOnly());
}

void FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetNameWithoutNameSpacePrefix());
}

void FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // then:
    AssertEqual("asdf", obj->GetNameWithoutNameSpacePrefix());
}

void FbxObjectTest::RegisterTestCases()
{
    AddTestCase(FbxObject_Create_HasZeroProperties);
    AddTestCase(FbxObject_Create_HasRootProperty);
    AddTestCase(FbxObject_Create_HasClassRootProperty);
    AddTestCase(FbxObject_GetName_GetsName);
    AddTestCase(FbxObject_SetName_SetsName);
    AddTestCase(FbxObject_Create_EmptyNamespace);
    AddTestCase(FbxObject_SetNameSpace_SetsNamespace);
    AddTestCase(FbxObject_GetNameSpaceArray_SplitsNamespace);
    AddTestCase(FbxObject_Create_SetsInitialName);
    AddTestCase(FbxObject_SetName_DoesntChangeInitialName);
    AddTestCase(FbxObject_SetInitialName_SetsInitialNameAndName);
    AddTestCase(FbxObject_Create_HasNamespacePrefix);
    AddTestCase(FbxObject_GetNameOnly_GetsNameWithoutNamespacePrefix);
    AddTestCase(FbxObject_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing);
    AddTestCase(FbxObject_SetNameSpaceThenSetName_FirstCharacterIsStillMissing);
    AddTestCase(FbxObject_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing);
    AddTestCase(FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix);
    AddTestCase(FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing);
}

