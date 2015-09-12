
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

void FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetNameWithNameSpacePrefix());
}

void FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // then:
    AssertEqual("asdf", obj->GetNameWithNameSpacePrefix());
}

void Mesh_GetNameOnly_GetsNameWithoutNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetNameOnly());
}

void Mesh_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // then:
    AssertEqual("sdf", obj->GetNameOnly());
}

void Mesh_SetNameSpaceThenSetName_FirstCharacterIsStillMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");
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

void Mesh_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");
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

void Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());

    // then:
    AssertEqual("asdf", obj->GetNameWithoutNameSpacePrefix());
}

void Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());

    // then:
    AssertEqual("asdf", obj->GetNameWithoutNameSpacePrefix());
}

void Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("Geometry::", obj->GetNameSpacePrefix());

    // then:
    AssertEqual("Geometry::asdf", obj->GetNameWithNameSpacePrefix());
}

void Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf");
    obj->SetNameSpace("qwer");

    // require:
    AssertEqual("asdf", obj->GetName());
    AssertEqual("qwer", obj->GetNameSpaceOnly());
    AssertEqual("Geometry::", obj->GetNameSpacePrefix());

    // then:
    AssertEqual("Geometry::asdf", obj->GetNameWithNameSpacePrefix());
}

void Mesh_SetNameUsingColons_IncludesNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf::Something|zxcv|qwer");

    // then:
    AssertEqual("asdf::Something|zxcv|qwer", obj->GetName());
    AssertEqual("", obj->GetNameSpaceOnly());
    AssertEqual("Geometry::", obj->GetNameSpacePrefix());
    AssertEqual("Geometry::asdf::Something|zxcv|qwer", obj->GetNameWithNameSpacePrefix());
}

void Mesh_SetNameUsingColonsandSetNameSpace_IncludesNamespace()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMesh* obj = FbxMesh::Create(manager, "asdf::Something|zxcv|qwer");
    obj->SetNameSpace("uiop::hjkl|cvbn|dfgh");;

    // then:
    AssertEqual("asdf::Something|zxcv|qwer", obj->GetName());
    AssertEqual("uiop::hjkl|cvbn|dfgh", obj->GetNameSpaceOnly());
    AssertEqual("Geometry::", obj->GetNameSpacePrefix());
    AssertEqual("Geometry::asdf::Something|zxcv|qwer", obj->GetNameWithNameSpacePrefix());
}

void FbxObject_RemovePrefix_RemovesAllPrefix()
{
    // then:
    AssertEqual("four", FbxObject::RemovePrefix("one::two::three::four"));
}

void FbxObject_StripPrefix_RemovesFirstPrefix()
{
    // then:
    AssertEqual("two::three::four", FbxObject::StripPrefix("one::two::three::four"));
}

void FbxObject_TypedGetSrcObjectCount_GetsCountOfObjectsOfThatType()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    FbxMesh* mesh1 = FbxMesh::Create(manager, "mesh1");
    FbxMesh* mesh2 = FbxMesh::Create(manager, "mesh2");
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxMesh* mesh3 = FbxMesh::Create(manager, "mesh3");
    FbxLight* light = FbxLight::Create(manager, "light");
    obj->ConnectSrcObject(mesh1);
    obj->ConnectSrcObject(mesh2);
    obj->ConnectSrcObject(node);
    obj->ConnectSrcObject(mesh3);
    obj->ConnectSrcObject(light);

    // require:
    AssertEqual(5, obj->GetSrcObjectCount());
    AssertEqual(mesh1, obj->GetSrcObject(0));
    AssertEqual(mesh2, obj->GetSrcObject(1));
    AssertEqual(node, obj->GetSrcObject(2));
    AssertEqual(mesh3, obj->GetSrcObject(3));
    AssertEqual(light, obj->GetSrcObject(4));

    // then:
    AssertEqual(3, obj->GetSrcObjectCount<FbxMesh>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxLight>());
    AssertEqual(4, obj->GetSrcObjectCount<FbxNodeAttribute>());
}

void FbxObject_TypedGetSrcObject_GetsObjectOfThatType()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    FbxMesh* mesh1 = FbxMesh::Create(manager, "mesh1");
    FbxMesh* mesh2 = FbxMesh::Create(manager, "mesh2");
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxMesh* mesh3 = FbxMesh::Create(manager, "mesh3");
    FbxLight* light = FbxLight::Create(manager, "light");
    obj->ConnectSrcObject(mesh1);
    obj->ConnectSrcObject(mesh2);
    obj->ConnectSrcObject(node);
    obj->ConnectSrcObject(mesh3);
    obj->ConnectSrcObject(light);

    // require:
    AssertEqual(5, obj->GetSrcObjectCount());
    AssertEqual(mesh1, obj->GetSrcObject(0));
    AssertEqual(mesh2, obj->GetSrcObject(1));
    AssertEqual(node, obj->GetSrcObject(2));
    AssertEqual(mesh3, obj->GetSrcObject(3));
    AssertEqual(light, obj->GetSrcObject(4));

    AssertEqual(3, obj->GetSrcObjectCount<FbxMesh>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxLight>());
    AssertEqual(4, obj->GetSrcObjectCount<FbxNodeAttribute>());

    // then:
    AssertEqual(mesh1, obj->GetSrcObject<FbxMesh>());
    AssertEqual(mesh1, obj->GetSrcObject<FbxMesh>(0));
    AssertEqual(mesh2, obj->GetSrcObject<FbxMesh>(1));
    AssertEqual(mesh3, obj->GetSrcObject<FbxMesh>(2));
    AssertEqual(node, obj->GetSrcObject<FbxNode>());
    AssertEqual(node, obj->GetSrcObject<FbxNode>(0));
    AssertEqual(light, obj->GetSrcObject<FbxLight>());
    AssertEqual(light, obj->GetSrcObject<FbxLight>(0));
    AssertEqual(mesh1, obj->GetSrcObject<FbxNodeAttribute>());
    AssertEqual(mesh1, obj->GetSrcObject<FbxNodeAttribute>(0));
    AssertEqual(mesh2, obj->GetSrcObject<FbxNodeAttribute>(1));
    AssertEqual(mesh3, obj->GetSrcObject<FbxNodeAttribute>(2));
    AssertEqual(light, obj->GetSrcObject<FbxNodeAttribute>(3));
}

void FbxObject_TypedDisconnectAllSrcObject_DisconnectsAllSrcObjectOfThatType()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    FbxMesh* mesh1 = FbxMesh::Create(manager, "mesh1");
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxMesh* mesh2 = FbxMesh::Create(manager, "mesh2");
    obj->ConnectSrcObject(mesh1);
    obj->ConnectSrcObject(node);
    obj->ConnectSrcObject(mesh2);

    // require:
    AssertEqual(3, obj->GetSrcObjectCount());
    AssertEqual(mesh1, obj->GetSrcObject(0));
    AssertEqual(node, obj->GetSrcObject(1));
    AssertEqual(mesh2, obj->GetSrcObject(2));

    AssertEqual(2, obj->GetSrcObjectCount<FbxMesh>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());

    AssertEqual(1, mesh1->GetDstObjectCount());
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(1, mesh2->GetDstObjectCount());

    // when:
    bool ret = obj->DisconnectAllSrcObject<FbxMesh>();

    // then:
    AssertTrue(ret);
    AssertEqual(1, obj->GetSrcObjectCount());
    AssertEqual(node, obj->GetSrcObject());
    AssertEqual(node, obj->GetSrcObject(0));

    AssertEqual(0, obj->GetSrcObjectCount<FbxMesh>());

    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());
    AssertEqual(node, obj->GetSrcObject<FbxNode>());
    AssertEqual(node, obj->GetSrcObject<FbxNode>(0));

    AssertEqual(0, mesh1->GetDstObjectCount());
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(0, mesh2->GetDstObjectCount());
}

void FbxObject_TypedDisconnectAllSrcObjectWithInheritance_DisconnectsAllSrcObjectOfThatType()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "asdf");
    FbxMesh* mesh1 = FbxMesh::Create(manager, "mesh1");
    FbxNode* node = FbxNode::Create(manager, "node");
    FbxLight* light = FbxLight::Create(manager, "light");
    obj->ConnectSrcObject(mesh1);
    obj->ConnectSrcObject(node);
    obj->ConnectSrcObject(light);

    // require:
    AssertEqual(3, obj->GetSrcObjectCount());
    AssertEqual(mesh1, obj->GetSrcObject(0));
    AssertEqual(node, obj->GetSrcObject(1));
    AssertEqual(light, obj->GetSrcObject(2));

    AssertEqual(1, obj->GetSrcObjectCount<FbxMesh>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());
    AssertEqual(1, obj->GetSrcObjectCount<FbxLight>());
    AssertEqual(2, obj->GetSrcObjectCount<FbxNodeAttribute>());

    AssertEqual(1, mesh1->GetDstObjectCount());
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(1, light->GetDstObjectCount());

    // when:
    bool ret = obj->DisconnectAllSrcObject<FbxNodeAttribute>();

    // then:
    AssertTrue(ret);
    AssertEqual(1, obj->GetSrcObjectCount());
    AssertEqual(node, obj->GetSrcObject());
    AssertEqual(node, obj->GetSrcObject(0));

    AssertEqual(0, obj->GetSrcObjectCount<FbxMesh>());
    AssertEqual(0, obj->GetSrcObjectCount<FbxLight>());
    AssertEqual(0, obj->GetSrcObjectCount<FbxNodeAttribute>());

    AssertEqual(1, obj->GetSrcObjectCount<FbxNode>());
    AssertEqual(node, obj->GetSrcObject<FbxNode>());
    AssertEqual(node, obj->GetSrcObject<FbxNode>(0));

    AssertEqual(0, mesh1->GetDstObjectCount());
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(0, light->GetDstObjectCount());
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
    AddTestCase(FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix);
    AddTestCase(FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace);
    AddTestCase(Mesh_GetNameOnly_GetsNameWithoutNamespacePrefix);
    AddTestCase(Mesh_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing);
    AddTestCase(Mesh_SetNameSpaceThenSetName_FirstCharacterIsStillMissing);
    AddTestCase(Mesh_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing);
    AddTestCase(Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix);
    AddTestCase(Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing);
    AddTestCase(Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix);
    AddTestCase(Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace);
    AddTestCase(Mesh_SetNameUsingColons_IncludesNamespace);
    AddTestCase(Mesh_SetNameUsingColonsandSetNameSpace_IncludesNamespace);
    AddTestCase(FbxObject_RemovePrefix_RemovesAllPrefix);
    AddTestCase(FbxObject_StripPrefix_RemovesFirstPrefix);
    AddTestCase(FbxObject_TypedGetSrcObjectCount_GetsCountOfObjectsOfThatType);
    AddTestCase(FbxObject_TypedGetSrcObject_GetsObjectOfThatType);
    AddTestCase(FbxObject_TypedDisconnectAllSrcObject_DisconnectsAllSrcObjectOfThatType);
    AddTestCase(FbxObject_TypedDisconnectAllSrcObjectWithInheritance_DisconnectsAllSrcObjectOfThatType);
}

