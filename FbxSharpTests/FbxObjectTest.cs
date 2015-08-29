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
    }
}
