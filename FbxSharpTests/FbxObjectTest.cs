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

        [Test]
        public void FbxObject_RemovePrefix_RemovesAllPrefix()
        {
            // then:
            Assert.AreEqual("four", FbxObject.RemovePrefix("one::two::three::four"));
        }

        [Test]
        public void FbxObject_StripPrefix_RemovesFirstPrefix()
        {
            // then:
            Assert.AreEqual("two::three::four", FbxObject.StripPrefix("one::two::three::four"));
        }

        [Test]
        public void FbxObject_TypedGetSrcObjectCount_GetsCountOfObjectsOfThatType()
        {
            // given:
            var obj = new FbxObject("asdf");
            var mesh1 = new Mesh("mesh1");
            var mesh2 = new Mesh("mesh2");
            var node = new Node("node");
            var mesh3 = new Mesh("mesh3");
            var light = new Light("light");
            obj.ConnectSrcObject(mesh1);
            obj.ConnectSrcObject(mesh2);
            obj.ConnectSrcObject(node);
            obj.ConnectSrcObject(mesh3);
            obj.ConnectSrcObject(light);

            // require:
            Assert.AreEqual(5, obj.GetSrcObjectCount());
            Assert.AreSame(mesh1, obj.GetSrcObject(0));
            Assert.AreSame(mesh2, obj.GetSrcObject(1));
            Assert.AreSame(node, obj.GetSrcObject(2));
            Assert.AreSame(mesh3, obj.GetSrcObject(3));
            Assert.AreSame(light, obj.GetSrcObject(4));

            // then:
            Assert.AreEqual(3, obj.GetSrcObjectCount<Mesh>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Light>());
            Assert.AreEqual(4, obj.GetSrcObjectCount<NodeAttribute>());
        }

        [Test]
        public void FbxObject_TypedGetSrcObject_GetsObjectOfThatType()
        {
            // given:
            var obj = new FbxObject("asdf");
            var mesh1 = new Mesh("mesh1");
            var mesh2 = new Mesh("mesh2");
            var node = new Node("node");
            var mesh3 = new Mesh("mesh3");
            var light = new Light("light");
            obj.ConnectSrcObject(mesh1);
            obj.ConnectSrcObject(mesh2);
            obj.ConnectSrcObject(node);
            obj.ConnectSrcObject(mesh3);
            obj.ConnectSrcObject(light);

            // require:
            Assert.AreEqual(5, obj.GetSrcObjectCount());
            Assert.AreSame(mesh1, obj.GetSrcObject(0));
            Assert.AreSame(mesh2, obj.GetSrcObject(1));
            Assert.AreSame(node, obj.GetSrcObject(2));
            Assert.AreSame(mesh3, obj.GetSrcObject(3));
            Assert.AreSame(light, obj.GetSrcObject(4));

            Assert.AreEqual(3, obj.GetSrcObjectCount<Mesh>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Light>());
            Assert.AreEqual(4, obj.GetSrcObjectCount<NodeAttribute>());

            // then:
            Assert.AreSame(mesh1, obj.GetSrcObject<Mesh>());
            Assert.AreSame(mesh1, obj.GetSrcObject<Mesh>(0));
            Assert.AreSame(mesh2, obj.GetSrcObject<Mesh>(1));
            Assert.AreSame(mesh3, obj.GetSrcObject<Mesh>(2));
            Assert.AreSame(node, obj.GetSrcObject<Node>());
            Assert.AreSame(node, obj.GetSrcObject<Node>(0));
            Assert.AreSame(light, obj.GetSrcObject<Light>());
            Assert.AreSame(light, obj.GetSrcObject<Light>(0));
            Assert.AreSame(mesh1, obj.GetSrcObject<NodeAttribute>());
            Assert.AreSame(mesh1, obj.GetSrcObject<NodeAttribute>(0));
            Assert.AreSame(mesh2, obj.GetSrcObject<NodeAttribute>(1));
            Assert.AreSame(mesh3, obj.GetSrcObject<NodeAttribute>(2));
            Assert.AreSame(light, obj.GetSrcObject<NodeAttribute>(3));
        }

        [Test]
        public void FbxObject_TypedDisconnectAllSrcObject_DisconnectsAllSrcObjectOfThatType()
        {
            // given:
            var obj = new FbxObject("asdf");
            var mesh1 = new Mesh("mesh1");
            var node = new Node("node");
            var mesh2 = new Mesh("mesh2");
            obj.ConnectSrcObject(mesh1);
            obj.ConnectSrcObject(node);
            obj.ConnectSrcObject(mesh2);

            // require:
            Assert.AreEqual(3, obj.GetSrcObjectCount());
            Assert.AreSame(mesh1, obj.GetSrcObject(0));
            Assert.AreSame(node, obj.GetSrcObject(1));
            Assert.AreSame(mesh2, obj.GetSrcObject(2));

            Assert.AreEqual(2, obj.GetSrcObjectCount<Mesh>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());

            Assert.AreEqual(1, mesh1.GetDstObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreEqual(1, mesh2.GetDstObjectCount());

            // when:
            obj.DisconnectAllSrcObject<Mesh>();

            // then:
            Assert.AreEqual(1, obj.GetSrcObjectCount());
            Assert.AreSame(node, obj.GetSrcObject());
            Assert.AreSame(node, obj.GetSrcObject(0));

            Assert.AreEqual(0, obj.GetSrcObjectCount<Mesh>());

            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());
            Assert.AreSame(node, obj.GetSrcObject<Node>());
            Assert.AreSame(node, obj.GetSrcObject<Node>(0));

            Assert.AreEqual(0, mesh1.GetDstObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreEqual(0, mesh2.GetDstObjectCount());
        }

        [Test]
        public void FbxObject_TypedDisconnectAllSrcObjectWithInheritance_DisconnectsAllSrcObjectOfThatType()
        {
            // given:
            var obj = new FbxObject("asdf");
            var mesh1 = new Mesh("mesh1");
            var node = new Node("node");
            var light = new Light("light");
            obj.ConnectSrcObject(mesh1);
            obj.ConnectSrcObject(node);
            obj.ConnectSrcObject(light);

            // require:
            Assert.AreEqual(3, obj.GetSrcObjectCount());
            Assert.AreSame(mesh1, obj.GetSrcObject(0));
            Assert.AreSame(node, obj.GetSrcObject(1));
            Assert.AreSame(light, obj.GetSrcObject(2));

            Assert.AreEqual(1, obj.GetSrcObjectCount<Mesh>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());
            Assert.AreEqual(1, obj.GetSrcObjectCount<Light>());
            Assert.AreEqual(2, obj.GetSrcObjectCount<NodeAttribute>());

            Assert.AreEqual(1, mesh1.GetDstObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreEqual(1, light.GetDstObjectCount());

            // when:
            obj.DisconnectAllSrcObject<NodeAttribute>();

            // then:
            Assert.AreEqual(1, obj.GetSrcObjectCount());
            Assert.AreSame(node, obj.GetSrcObject());
            Assert.AreSame(node, obj.GetSrcObject(0));

            Assert.AreEqual(0, obj.GetSrcObjectCount<Mesh>());
            Assert.AreEqual(0, obj.GetSrcObjectCount<Light>());
            Assert.AreEqual(0, obj.GetSrcObjectCount<NodeAttribute>());

            Assert.AreEqual(1, obj.GetSrcObjectCount<Node>());
            Assert.AreSame(node, obj.GetSrcObject<Node>());
            Assert.AreSame(node, obj.GetSrcObject<Node>(0));

            Assert.AreEqual(0, mesh1.GetDstObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreEqual(0, light.GetDstObjectCount());
        }
    }
}
