
#include "Tests.h"

using namespace std;

void FbxProperty_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxIntDT;
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
    FbxDataType dt = FbxIntDT;
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

void FbxProperty_Find_FindsChildren()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxIntDT;
    FbxProperty parent = FbxProperty::Create(obj, dt, "parent");
    FbxProperty child = FbxProperty::Create(parent, dt, "child");

    // when:
    FbxProperty prop = parent.Find("child");

    // then:
    AssertTrue(prop.IsValid());
    AssertTrue(prop == child);

    // when:
    prop = parent.Find("something else");

    // then:
    AssertFalse(prop.IsValid());
}

void FbxProperty_Find_DoesNotFindGrandchildren()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxIntDT;
    FbxProperty parent = FbxProperty::Create(obj, dt, "parent");
    FbxProperty child = FbxProperty::Create(parent, dt, "child");
    FbxProperty grandchild = FbxProperty::Create(child, dt, "grandchild");

    // when:
    FbxProperty prop = parent.Find("grandchild");

    // then:
    AssertFalse(prop.IsValid());
}

void FbxProperty_FindHierarchical_FindsDescendants()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxObject* obj = FbxObject::Create(manager, "");
    FbxDataType dt = FbxIntDT;
    FbxProperty parent = FbxProperty::Create(obj, dt, "parent");
    FbxProperty child = FbxProperty::Create(parent, dt, "child");
    FbxProperty grandchild = FbxProperty::Create(child, dt, "grandchild");

    // when:
    FbxProperty prop = parent.FindHierarchical("child");

    // then:
    AssertTrue(prop.IsValid());
    AssertTrue(prop == child);

    // when:
    prop = parent.FindHierarchical("child|grandchild");

    // then:
    AssertTrue(prop.IsValid());
    AssertTrue(prop == grandchild);

    // when:
    prop = parent.FindHierarchical("parent|child|grandchild");

    // then:
    AssertFalse(prop.IsValid());

    // when:
    prop = parent.FindHierarchical("grandchild");

    // then:
    AssertFalse(prop.IsValid());

    // when:
    prop = child.FindHierarchical("grandchild");

    // then:
    AssertTrue(prop.IsValid());
    AssertTrue(prop == grandchild);
}

void FbxPropertyTest::RegisterTestCases()
{
    AddTestCase(FbxProperty_Create_HasDefaults);
    AddTestCase(FbxProperty_Create_WithParentSetsParent);
    AddTestCase(FbxProperty_Find_FindsChildren);
    AddTestCase(FbxProperty_Find_DoesNotFindGrandchildren);
    AddTestCase(FbxProperty_FindHierarchical_FindsDescendants);
}

