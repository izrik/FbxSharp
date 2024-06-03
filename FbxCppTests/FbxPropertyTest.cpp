
#include "Tests.h"

using namespace std;

void FbxProperty_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxDataType::Create("int", EFbxType::eFbxInt);;
    // when:
    FbxProperty prop = FbxProperty::Create(obj, dt, "prop");
    // then:
    AssertTrue(prop.IsValid());
    AssertEqual("prop", prop.GetName());
    AssertEqual("prop", prop.GetHierarchicalName());
    AssertTrue(prop.GetParent().IsValid());
    AssertFalse(prop.IsRoot());
    AssertTrue(prop.GetParent().IsRoot());
    AssertFalse(prop.GetChild().IsValid());
    AssertFalse(prop.GetSibling().IsValid());
    AssertFalse(prop.GetFirstDescendent().IsValid());
}

void FbxProperty_Create_WithParentSetsParent()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxDataType::Create("int", EFbxType::eFbxInt);;
    FbxProperty parent = FbxProperty::Create(obj, dt, "parent");
    // when:
    FbxProperty prop = FbxProperty::Create(parent, dt, "prop");
    AssertTrue(prop.IsValid());
    AssertEqual("prop", prop.GetName());
    AssertEqual("parent|prop", prop.GetHierarchicalName());
    AssertTrue(prop.GetParent().IsValid());
    AssertEqual("parent", prop.GetParent().GetHierarchicalName());
    AssertFalse(prop.IsRoot());
    AssertFalse(prop.GetChild().IsValid());
    AssertFalse(prop.GetSibling().IsValid());
    AssertFalse(prop.GetFirstDescendent().IsValid());
    AssertTrue(prop.IsChildOf(parent));
    AssertTrue(prop.IsDescendentOf(parent));
    AssertTrue(parent.GetChild().IsValid());
    AssertEqual("parent|prop", parent.GetChild().GetHierarchicalName());
    AssertTrue(parent.GetFirstDescendent().IsValid());
    AssertEqual("parent|prop", parent.GetFirstDescendent().GetHierarchicalName());
}

void FbxPropertyTest::RegisterTestCases()
{
    AddTestCase(FbxProperty_Create_HasDefaults);
    AddTestCase(FbxProperty_Create_WithParentSetsParent);
}

