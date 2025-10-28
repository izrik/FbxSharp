
#include "Tests.h"

using namespace std;

void FbxDocumentInfo_Create_HasDefaults()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxDateTime dt0 = FbxDateTime();
    FbxProperty prop;

    // when:
    FbxDocumentInfo* docinfo = FbxDocumentInfo::Create(manager, "");

    // then:
    AssertEqual(15, CountProperties(docinfo));

    prop = docinfo->FindProperty("DocumentUrl");
    AssertTrue(prop.IsValid());
    AssertEqual("DocumentUrl", prop.GetName());
    AssertEqual("DocumentUrl", prop.GetHierarchicalName());
    AssertEqual(FbxUrlDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->LastSavedUrl);

    prop = docinfo->FindProperty("SrcDocumentUrl");
    AssertTrue(prop.IsValid());
    AssertEqual("SrcDocumentUrl", prop.GetName());
    AssertEqual("SrcDocumentUrl", prop.GetHierarchicalName());
    AssertEqual(FbxUrlDT, prop.GetPropertyDataType());
    AssertEqual(FbxString(""), prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Url);

    prop = docinfo->FindProperty("Original");
    AssertTrue(prop.IsValid());
    AssertEqual("Original", prop.GetName());
    AssertEqual("Original", prop.GetHierarchicalName());
    AssertEqual(FbxCompoundDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Original);

    prop = docinfo->FindPropertyHierarchical("Original|ApplicationVendor");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationVendor", prop.GetName());
    AssertEqual("Original|ApplicationVendor", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Original_ApplicationVendor);

    prop = docinfo->FindPropertyHierarchical("Original|ApplicationName");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationName", prop.GetName());
    AssertEqual("Original|ApplicationName", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Original_ApplicationName);

    prop = docinfo->FindPropertyHierarchical("Original|ApplicationVersion");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationVersion", prop.GetName());
    AssertEqual("Original|ApplicationVersion", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Original_ApplicationVersion);

    prop = docinfo->FindPropertyHierarchical("Original|DateTime_GMT");
    AssertTrue(prop.IsValid());
    AssertEqual("DateTime_GMT", prop.GetName());
    AssertEqual("Original|DateTime_GMT", prop.GetHierarchicalName());
    AssertEqual(FbxDateTimeDT, prop.GetPropertyDataType());
    AssertEqual(dt0, prop.Get<FbxDateTime>());
    AssertTrue(prop == docinfo->Original_DateTime_GMT);

    prop = docinfo->FindPropertyHierarchical("Original|FileName");
    AssertTrue(prop.IsValid());
    AssertEqual("FileName", prop.GetName());
    AssertEqual("Original|FileName", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->Original_FileName);

    prop = docinfo->FindProperty("LastSaved");
    AssertTrue(prop.IsValid());
    AssertEqual("LastSaved", prop.GetName());
    AssertEqual("LastSaved", prop.GetHierarchicalName());
    AssertEqual(FbxCompoundDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->LastSaved);

    prop = docinfo->FindPropertyHierarchical("LastSaved|ApplicationVendor");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationVendor", prop.GetName());
    AssertEqual("LastSaved|ApplicationVendor", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->LastSaved_ApplicationVendor);

    prop = docinfo->FindPropertyHierarchical("LastSaved|ApplicationName");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationName", prop.GetName());
    AssertEqual("LastSaved|ApplicationName", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->LastSaved_ApplicationName);

    prop = docinfo->FindPropertyHierarchical("LastSaved|ApplicationVersion");
    AssertTrue(prop.IsValid());
    AssertEqual("ApplicationVersion", prop.GetName());
    AssertEqual("LastSaved|ApplicationVersion", prop.GetHierarchicalName());
    AssertEqual(FbxStringDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->LastSaved_ApplicationVersion);

    prop = docinfo->FindPropertyHierarchical("LastSaved|DateTime_GMT");
    AssertTrue(prop.IsValid());
    AssertEqual("DateTime_GMT", prop.GetName());
    AssertEqual("LastSaved|DateTime_GMT", prop.GetHierarchicalName());
    AssertEqual(FbxDateTimeDT, prop.GetPropertyDataType());
    AssertEqual(dt0, prop.Get<FbxDateTime>());
    AssertTrue(prop == docinfo->LastSaved_DateTime_GMT);

    prop = docinfo->FindProperty("DocumentEmbeddedUrl");
    AssertTrue(prop.IsValid());
    AssertEqual("DocumentEmbeddedUrl", prop.GetName());
    AssertEqual("DocumentEmbeddedUrl", prop.GetHierarchicalName());
    AssertEqual(FbxUrlDT, prop.GetPropertyDataType());
    AssertEqual("", prop.Get<FbxString>());
    AssertTrue(prop == docinfo->EmbeddedUrl);

    prop = docinfo->FindProperty("SceneThumbnail");
    AssertTrue(prop.IsValid());
    AssertEqual("SceneThumbnail", prop.GetName());
    AssertEqual("SceneThumbnail", prop.GetHierarchicalName());
    AssertEqual(FbxReferenceObjectDT, prop.GetPropertyDataType());
    AssertEqual(NULL, prop.Get<FbxObject*>());
}

void FbxDocumentInfoTest::RegisterTestCases()
{
    AddTestCase(FbxDocumentInfo_Create_HasDefaults);
}

