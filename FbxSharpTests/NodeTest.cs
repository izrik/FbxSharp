using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class NodeTest
    {
        [Test]
        public void RootNode_AddChild_AddsConnection()
        {
            // given:
            var scene = new Scene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new Node("ChildNode");

            // require:
            Assert.AreEqual(0, root.GetSrcObjectCount());
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));
            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(0, node2.GetDstObjectCount());

            // when:
            root.AddChild(node2);

            // then:
            Assert.AreEqual(1, root.GetSrcObjectCount());
            Assert.AreEqual(node2, root.GetSrcObject(0));
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));

            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(2, node2.GetDstObjectCount());
            Assert.AreEqual(root, node2.GetDstObject(0));
            Assert.AreEqual(scene, node2.GetDstObject(1));
        }

        [Test]
        public void Node_SetNodeAttribute_SetsNodeAttribute()
        {
            // given:
            var node = new Node("Node");
            var nullattr = new Null("Nulla");

            // require:
            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());
            Assert.AreEqual(0, node.GetNodeAttributeCount());
            Assert.AreEqual(null, node.GetNodeAttribute());
            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(0, nullattr.GetDstObjectCount());
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());

            // when:
            node.SetNodeAttribute(nullattr);

            // then:
            Assert.AreEqual(1, node.GetSrcObjectCount());
            Assert.AreEqual(nullattr, node.GetSrcObject(0));
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());
            Assert.AreEqual(1, node.GetNodeAttributeCount());
            Assert.AreEqual(nullattr, node.GetNodeAttribute());
            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(1, nullattr.GetDstObjectCount());
            Assert.AreEqual(node, nullattr.GetDstObject(0));
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());
        }
    }
}

//  "->"   "."
//  /(\w+)::Create/    "new $1"
//  "*"  ""
//  "Assert.AreEqual"    "Assert.AreEqual"
//  delete FbxManager lines
//  /Fbx(Scene|Node|Null)/  "$1"
//  /(\s\s+)(Scene|Node|Null)/  "$1var"
//  "(manager, "    "("