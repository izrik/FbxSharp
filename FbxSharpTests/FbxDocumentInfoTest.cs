using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxDocumentInfoTest : TestBase
    {
        [Test]
        public void FbxDocumentInfo_Create_HasDefaults()
        {
            // given:
            var dt0 = new FbxDateTime();
            FbxProperty prop;

            // when:
            var docinfo = FbxDocumentInfo.Create("");

            // then:
            Assert.AreEqual(15, CountProperties(docinfo));

            prop = docinfo.FindProperty("DocumentUrl");
            Assert.True(prop.IsValid());
            Assert.AreEqual("DocumentUrl", prop.GetName());
            Assert.AreEqual("DocumentUrl", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxUrlDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.LastSavedUrl);

            prop = docinfo.FindProperty("SrcDocumentUrl");
            Assert.True(prop.IsValid());
            Assert.AreEqual("SrcDocumentUrl", prop.GetName());
            Assert.AreEqual("SrcDocumentUrl", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxUrlDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Url);

            prop = docinfo.FindProperty("Original");
            Assert.True(prop.IsValid());
            Assert.AreEqual("Original", prop.GetName());
            Assert.AreEqual("Original", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxCompoundDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Original);

            prop = docinfo.FindPropertyHierarchical("Original|ApplicationVendor");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationVendor", prop.GetName());
            Assert.AreEqual("Original|ApplicationVendor", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Original_ApplicationVendor);

            prop = docinfo.FindPropertyHierarchical("Original|ApplicationName");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationName", prop.GetName());
            Assert.AreEqual("Original|ApplicationName", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Original_ApplicationName);

            prop = docinfo.FindPropertyHierarchical("Original|ApplicationVersion");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationVersion", prop.GetName());
            Assert.AreEqual("Original|ApplicationVersion", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Original_ApplicationVersion);

            prop = docinfo.FindPropertyHierarchical("Original|DateTime_GMT");
            Assert.True(prop.IsValid());
            Assert.AreEqual("DateTime_GMT", prop.GetName());
            Assert.AreEqual("Original|DateTime_GMT", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxDateTimeDT, prop.GetPropertyDataType());
            Assert.AreEqual(dt0, prop.Get<FbxDateTime>());
            Assert.True(prop == docinfo.Original_DateTime_GMT);

            prop = docinfo.FindPropertyHierarchical("Original|FileName");
            Assert.True(prop.IsValid());
            Assert.AreEqual("FileName", prop.GetName());
            Assert.AreEqual("Original|FileName", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.Original_FileName);

            prop = docinfo.FindProperty("LastSaved");
            Assert.True(prop.IsValid());
            Assert.AreEqual("LastSaved", prop.GetName());
            Assert.AreEqual("LastSaved", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxCompoundDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.LastSaved);

            prop = docinfo.FindPropertyHierarchical("LastSaved|ApplicationVendor");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationVendor", prop.GetName());
            Assert.AreEqual("LastSaved|ApplicationVendor", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.LastSaved_ApplicationVendor);

            prop = docinfo.FindPropertyHierarchical("LastSaved|ApplicationName");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationName", prop.GetName());
            Assert.AreEqual("LastSaved|ApplicationName", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.LastSaved_ApplicationName);

            prop = docinfo.FindPropertyHierarchical("LastSaved|ApplicationVersion");
            Assert.True(prop.IsValid());
            Assert.AreEqual("ApplicationVersion", prop.GetName());
            Assert.AreEqual("LastSaved|ApplicationVersion", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxStringDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.LastSaved_ApplicationVersion);

            prop = docinfo.FindPropertyHierarchical("LastSaved|DateTime_GMT");
            Assert.True(prop.IsValid());
            Assert.AreEqual("DateTime_GMT", prop.GetName());
            Assert.AreEqual("LastSaved|DateTime_GMT", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxDateTimeDT, prop.GetPropertyDataType());
            Assert.AreEqual(dt0, prop.Get<FbxDateTime>());
            Assert.True(prop == docinfo.LastSaved_DateTime_GMT);

            prop = docinfo.FindProperty("DocumentEmbeddedUrl");
            Assert.True(prop.IsValid());
            Assert.AreEqual("DocumentEmbeddedUrl", prop.GetName());
            Assert.AreEqual("DocumentEmbeddedUrl", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxUrlDT, prop.GetPropertyDataType());
            Assert.AreEqual("", prop.Get<string>());
            Assert.True(prop == docinfo.EmbeddedUrl);

            prop = docinfo.FindProperty("SceneThumbnail");
            Assert.True(prop.IsValid());
            Assert.AreEqual("SceneThumbnail", prop.GetName());
            Assert.AreEqual("SceneThumbnail", prop.GetHierarchicalName());
            Assert.AreEqual(FbxDataTypes.FbxReferenceObjectDT, prop.GetPropertyDataType());
            Assert.AreEqual(null, prop.Get<FbxObject>());
        }
    }
}
