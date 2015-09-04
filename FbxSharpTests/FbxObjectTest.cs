using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxObjectTest : TestBase
    {
        [Test]
        public void FbxObject_Create_HasZeroProperties()
        {
            // given:
            var obj = new FbxObject("");

            // then:
            Assert.AreEqual(0, CountProperties(obj));
            Assert.AreEqual(0, obj.GetSrcPropertyCount());
            Assert.AreEqual(0, obj.GetDstPropertyCount());
        }

        [Test]
        public void FbxObject_Create_HasRootProperty()
        {
            // given:
            var obj = new FbxObject("");

            // then:
            Assert.NotNull(obj.RootProperty);
            Assert.True((obj.RootProperty).IsValid());
            Assert.AreEqual("", obj.RootProperty.GetName());
        }

        [Test]
        public void FbxObject_Create_HasClassRootProperty()
        {
            // given:
            var obj = new FbxObject("");

            // then:
            Assert.NotNull(obj.GetClassRootProperty());
            Assert.True(obj.GetClassRootProperty().IsValid());
        }

        [Test]
        public void FbxObject_GetName_GetsName()
        {
            // given:
            var obj = new FbxObject("asdf");

            // then:
            Assert.AreEqual("asdf", obj.GetName());
        }

        [Test]
        public void FbxObject_SetName_SetsName()
        {
            // given:
            var obj = new FbxObject("asdf");

            // when:
            obj.SetName("qwer");

            // then:
            Assert.AreEqual("qwer", obj.GetName());
        }

        [Test]
        public void FbxObject_Create_EmptyNamespace()
        {
            // given:
            var obj = new FbxObject("asdf");

            // then:
            Assert.AreEqual("", obj.GetNameSpaceOnly());
        }

        [Test]
        public void FbxObject_SetNameSpace_SetsNamespace()
        {
            // given:
            var obj = new FbxObject("asdf");

            // when:
            obj.SetNameSpace("qwer");

            // then:
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());
        }

        [Test]
        public void FbxObject_GetNameSpaceArray_SplitsNamespace()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("name:space");
            string[] arr;

            // when:
            arr = obj.GetNameSpaceArray(':');

            // then:
            Assert.AreEqual(2, arr.GetCount());
            Assert.AreEqual("space", arr.GetAt(0));
            Assert.AreEqual("name", arr.GetAt(1));

            // when:
            arr = obj.GetNameSpaceArray('s');

            // then:
            Assert.AreEqual(2, arr.GetCount());
            Assert.AreEqual("pace", arr.GetAt(0));
            Assert.AreEqual("name:", arr.GetAt(1));

            // when:
            arr = obj.GetNameSpaceArray('a');

            // then:
            Assert.AreEqual(3, arr.GetCount());
            Assert.AreEqual("ce", arr.GetAt(0));
            Assert.AreEqual("me:sp", arr.GetAt(1));
            Assert.AreEqual("n", arr.GetAt(2));
        }

        [Test]
        public void FbxObject_Create_SetsInitialName()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetInitialName());
        }

        [Test]
        public void FbxObject_SetName_DoesntChangeInitialName()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetInitialName());
            Assert.AreEqual("asdf", obj.GetName());

            // when:
            obj.SetName("qwer");

            // then:
            Assert.AreEqual("asdf", obj.GetInitialName());
            Assert.AreEqual("qwer", obj.GetName());
        }

        [Test]
        public void FbxObject_SetInitialName_SetsInitialNameAndName()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetInitialName());
            Assert.AreEqual("asdf", obj.GetName());

            // when:
            obj.SetInitialName("qwer");

            // then:
            Assert.AreEqual("qwer", obj.GetInitialName());
            Assert.AreEqual("qwer", obj.GetName());
        }

        [Test]
        public void FbxObject_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxObject("asdf");

            // then:
            Assert.AreEqual("", obj.GetNameSpacePrefix());
        }

        [Test]
        public void FbxObject_GetNameOnly_GetsNameWithoutNamespacePrefix()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetNameOnly());
        }

        [Test]
        public void FbxObject_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // then:
            Assert.AreEqual("sdf", obj.GetNameOnly());
        }

        [Test]
        public void FbxObject_SetNameSpaceThenSetName_FirstCharacterIsStillMissing()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // when:
            obj.SetName("zxcv");

            // then:
            Assert.AreEqual("asdf", obj.GetInitialName());
            Assert.AreEqual("zxcv", obj.GetName());
            Assert.AreEqual("xcv", obj.GetNameOnly());
        }

        [Test]
        public void FbxObject_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // when:
            obj.SetInitialName("zxcv");

            // then:
            Assert.AreEqual("zxcv", obj.GetInitialName());
            Assert.AreEqual("zxcv", obj.GetName());
            Assert.AreEqual("xcv", obj.GetNameOnly());
        }

        [Test]
        public void FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithoutNameSpacePrefix());
        }

        [Test]
        public void FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithoutNameSpacePrefix());
        }

        [Test]
        public void FbxObject_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix()
        {
            // given:
            var obj = new FbxObject("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithNameSpacePrefix());
        }

        [Test]
        public void FbxObject_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace()
        {
            // given:
            var obj = new FbxObject("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithNameSpacePrefix());
        }

        [Test]
        public void Mesh_GetNameOnly_GetsNameWithoutNamespacePrefix()
        {
            // given:
            var obj = new Mesh("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetNameOnly());
        }

        [Test]
        public void Mesh_SetNameSpaceAndGetNameOnly_FirstCharacterIsMissing()
        {
            // given:
            var obj = new Mesh("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // then:
            Assert.AreEqual("sdf", obj.GetNameOnly());
        }

        [Test]
        public void Mesh_SetNameSpaceThenSetName_FirstCharacterIsStillMissing()
        {
            // given:
            var obj = new Mesh("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // when:
            obj.SetName("zxcv");

            // then:
            Assert.AreEqual("asdf", obj.GetInitialName());
            Assert.AreEqual("zxcv", obj.GetName());
            Assert.AreEqual("xcv", obj.GetNameOnly());
        }

        [Test]
        public void Mesh_SetNameSpaceThenSetInitialName_FirstCharacterIsStillMissing()
        {
            // given:
            var obj = new Mesh("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // when:
            obj.SetInitialName("zxcv");

            // then:
            Assert.AreEqual("zxcv", obj.GetInitialName());
            Assert.AreEqual("zxcv", obj.GetName());
            Assert.AreEqual("xcv", obj.GetNameOnly());
        }

        [Test]
        public void Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithoutNamespacePrefix()
        {
            // given:
            var obj = new Mesh("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithoutNameSpacePrefix());
        }

        [Test]
        public void Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_FirstCharacterIsNotMissing()
        {
            // given:
            var obj = new Mesh("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());

            // then:
            Assert.AreEqual("asdf", obj.GetNameWithoutNameSpacePrefix());
        }

        [Test]
        public void Mesh_GetNameWithoutNameSpacePrefix_GetsNameWithNamespacePrefix()
        {
            // given:
            var obj = new Mesh("asdf");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("Geometry::", obj.GetNameSpacePrefix());

            // then:
            Assert.AreEqual("Geometry::asdf", obj.GetNameWithNameSpacePrefix());
        }

        [Test]
        public void Mesh_SetNameSpaceAndGetNameWithoutNameSpacePrefix_IncludesNamespace()
        {
            // given:
            var obj = new Mesh("asdf");
            obj.SetNameSpace("qwer");

            // require:
            Assert.AreEqual("asdf", obj.GetName());
            Assert.AreEqual("qwer", obj.GetNameSpaceOnly());
            Assert.AreEqual("Geometry::", obj.GetNameSpacePrefix());

            // then:
            Assert.AreEqual("Geometry::asdf", obj.GetNameWithNameSpacePrefix());
        }

        [Test]
        public void Mesh_SetNameUsingColons_IncludesNamespace()
        {
            // given:
            var obj = new Mesh("asdf::Something|zxcv|qwer");

            // then:
            Assert.AreEqual("asdf::Something|zxcv|qwer", obj.GetName());
            Assert.AreEqual("", obj.GetNameSpaceOnly());
            Assert.AreEqual("Geometry::", obj.GetNameSpacePrefix());
            Assert.AreEqual("Geometry::asdf::Something|zxcv|qwer", obj.GetNameWithNameSpacePrefix());
        }

        [Test]
        public void Mesh_SetNameUsingColonsandSetNameSpace_IncludesNamespace()
        {
            // given:
            var obj = new Mesh("asdf::Something|zxcv|qwer");
            obj.SetNameSpace("uiop::hjkl|cvbn|dfgh");;

            // then:
            Assert.AreEqual("asdf::Something|zxcv|qwer", obj.GetName());
            Assert.AreEqual("uiop::hjkl|cvbn|dfgh", obj.GetNameSpaceOnly());
            Assert.AreEqual("Geometry::", obj.GetNameSpacePrefix());
            Assert.AreEqual("Geometry::asdf::Something|zxcv|qwer", obj.GetNameWithNameSpacePrefix());
        }
    }
}
