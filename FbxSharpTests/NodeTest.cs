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
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(root, scene.GetSrcObject());
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));

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
            var nullattr = new Null("nullattr");

            // require:
            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());
            Assert.AreEqual(0, node.GetNodeAttributeCount());
            Assert.AreEqual(null, node.GetNodeAttribute());
            Assert.AreEqual(-1, node.GetDefaultNodeAttributeIndex());

            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(0, nullattr.GetDstObjectCount());
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());
            Assert.AreEqual(0, nullattr.GetNodeCount());

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
            Assert.AreEqual(0, node.GetDefaultNodeAttributeIndex());
            Assert.AreEqual(nullattr, node.GetNodeAttributeByIndex(0));

            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(1, nullattr.GetDstObjectCount());
            Assert.AreEqual(node, nullattr.GetDstObject(0));
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());
            Assert.AreEqual(1, nullattr.GetNodeCount());
            Assert.AreEqual(node, nullattr.GetNode());
            Assert.AreEqual(node, nullattr.GetNode(0));
        }

        [Test]
        public void Node_AddChild_AddsChild()
        {
            // given:
            var node1 = new Node("Node1");
            var node2 = new Node("Node2");

            // require:
            Assert.AreEqual(0, node1.GetSrcObjectCount());
            Assert.AreEqual(0, node1.GetDstObjectCount());
            Assert.AreEqual(0, node1.GetSrcPropertyCount());
            Assert.AreEqual(0, node1.GetDstPropertyCount());
            Assert.AreEqual(0, node1.GetChildCount());
            Assert.AreEqual(null, node1.GetParent());

            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(0, node2.GetDstObjectCount());
            Assert.AreEqual(0, node2.GetSrcPropertyCount());
            Assert.AreEqual(0, node2.GetDstPropertyCount());
            Assert.AreEqual(0, node2.GetChildCount());
            Assert.AreEqual(null, node1.GetParent());

            // when:
            node1.AddChild(node2);

            // then:
            Assert.AreEqual(1, node1.GetSrcObjectCount());
            Assert.AreEqual(node2, node1.GetSrcObject(0));
            Assert.AreEqual(0, node1.GetDstObjectCount());
            Assert.AreEqual(0, node1.GetSrcPropertyCount());
            Assert.AreEqual(0, node1.GetDstPropertyCount());
            Assert.AreEqual(1, node1.GetChildCount());
            Assert.AreEqual(node2, node1.GetChild(0));
            Assert.AreEqual(null, node1.GetParent());

            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(1, node2.GetDstObjectCount());
            Assert.AreEqual(node1, node2.GetDstObject(0));
            Assert.AreEqual(0, node2.GetSrcPropertyCount());
            Assert.AreEqual(0, node2.GetDstPropertyCount());
            Assert.AreEqual(0, node2.GetChildCount());
            Assert.AreEqual(node1, node2.GetParent());
        }

        [Test]
        public void RootNode_AddChild_AddsNodeSubtree()
        {
            // given:
            var scene = new Scene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new Node("ChildNode");
            var node3 = new Node("ChildNode");
            node2.AddChild(node3);

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));

            Assert.AreEqual(0, root.GetSrcObjectCount());
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));
            Assert.AreEqual(0, root.GetChildCount());
            Assert.AreEqual(scene, root.GetScene());

            Assert.AreEqual(1, node2.GetSrcObjectCount());
            Assert.AreEqual(node3, node2.GetSrcObject(0));
            Assert.AreEqual(0, node2.GetDstObjectCount());
            Assert.AreEqual(1, node2.GetChildCount());
            Assert.AreEqual(node3, node2.GetChild(0));
            Assert.AreEqual(null, node2.GetParent());
            Assert.AreEqual(null, node2.GetScene());

            Assert.AreEqual(0, node3.GetSrcObjectCount());
            Assert.AreEqual(1, node3.GetDstObjectCount());
            Assert.AreEqual(node2, node3.GetDstObject(0));
            Assert.AreEqual(0, node3.GetChildCount());
            Assert.AreEqual(node2, node3.GetParent());
            Assert.AreEqual(null, node3.GetScene());

            // when:
            root.AddChild(node2);

            // then:
            Assert.AreEqual(5, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(node2, scene.GetSrcObject(3));
            Assert.AreEqual(node3, scene.GetSrcObject(4));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(3, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));
            Assert.AreEqual(node2, scene.GetNode(1));
            Assert.AreEqual(node3, scene.GetNode(2));

            Assert.AreEqual(1, root.GetSrcObjectCount());
            Assert.AreEqual(node2, root.GetSrcObject(0));
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));
            Assert.AreEqual(1, root.GetChildCount());
            Assert.AreEqual(node2, root.GetChild(0));
            Assert.AreEqual(scene, root.GetScene());

            Assert.AreEqual(1, node2.GetSrcObjectCount());
            Assert.AreEqual(node3, node2.GetSrcObject(0));
            Assert.AreEqual(2, node2.GetDstObjectCount());
            Assert.AreEqual(root, node2.GetDstObject(0));
            Assert.AreEqual(scene, node2.GetDstObject(1));
            Assert.AreEqual(1, node2.GetChildCount());
            Assert.AreEqual(node3, node2.GetChild(0));
            Assert.AreEqual(root, node2.GetParent());
            Assert.AreEqual(scene, node2.GetScene());

            Assert.AreEqual(0, node3.GetSrcObjectCount());
            Assert.AreEqual(2, node3.GetDstObjectCount());
            Assert.AreEqual(node2, node3.GetDstObject(0));
            Assert.AreEqual(scene, node3.GetDstObject(1));
            Assert.AreEqual(0, node3.GetChildCount());
            Assert.AreEqual(node2, node3.GetParent());
            Assert.AreEqual(scene, node3.GetScene());
        }

        [Test]
        public void RootNode_AddSrcObject_AddsChild()
        {
            // given:
            var scene = new Scene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new Node("ChildNode");

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(root, scene.GetSrcObject());
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));

            Assert.AreEqual(0, root.GetSrcObjectCount());
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));

            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(0, node2.GetDstObjectCount());
            Assert.AreEqual(null, node2.GetScene());

            // when:
            root.ConnectSrcObject(node2);

            // then:
            Assert.AreEqual(4, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(node2, scene.GetSrcObject(3));
            Assert.AreEqual(root, scene.GetSrcObject());
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(2, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));
            Assert.AreEqual(node2, scene.GetNode(1));

            Assert.AreEqual(1, root.GetSrcObjectCount());
            Assert.AreEqual(node2, root.GetSrcObject(0));
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));

            Assert.AreEqual(0, node2.GetSrcObjectCount());
            Assert.AreEqual(2, node2.GetDstObjectCount());
            Assert.AreEqual(root, node2.GetDstObject(0));
            Assert.AreEqual(scene, node2.GetDstObject(1));
            Assert.AreEqual(scene, node2.GetScene());
        }

        [Test]
        public void Node_AddSrcObject_SetsNodeAttribute()
        {
            // given:
            var node = new Node("Node");
            var nullattr = new Null("nullattr");

            // require:
            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());
            Assert.AreEqual(0, node.GetNodeAttributeCount());
            Assert.AreEqual(null, node.GetNodeAttribute());
            Assert.AreEqual(-1, node.GetDefaultNodeAttributeIndex());

            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(0, nullattr.GetDstObjectCount());
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());
            Assert.AreEqual(0, nullattr.GetNodeCount());

            // when:
            node.ConnectSrcObject(nullattr);

            // then:
            Assert.AreEqual(1, node.GetSrcObjectCount());
            Assert.AreEqual(nullattr, node.GetSrcObject(0));
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());
            Assert.AreEqual(1, node.GetNodeAttributeCount());
            Assert.AreEqual(null, node.GetNodeAttribute());
            Assert.AreEqual(-1, node.GetDefaultNodeAttributeIndex());
            Assert.AreEqual(nullattr, node.GetNodeAttributeByIndex(0));

            Assert.AreEqual(0, nullattr.GetSrcObjectCount());
            Assert.AreEqual(1, nullattr.GetDstObjectCount());
            Assert.AreEqual(node, nullattr.GetDstObject(0));
            Assert.AreEqual(0, nullattr.GetSrcPropertyCount());
            Assert.AreEqual(0, nullattr.GetDstPropertyCount());
            Assert.AreEqual(1, nullattr.GetNodeCount());
            Assert.AreEqual(node, nullattr.GetNode());
            Assert.AreEqual(node, nullattr.GetNode(0));
        }
    }
}
