using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SceneTest
    {
        [Test]
        public void Scene_AddNode_AddsNode()
        {
            // given:
            var scene = new Scene("TheScene");
            var node = new Node("ChildNode");

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetNodeCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetNode(0));

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(null, node.GetScene());

            // when:
            scene.AddNode(node);

            // then:
            Assert.AreEqual(4, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(node, scene.GetSrcObject(3));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(2, scene.GetNodeCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetNode(0));
            Assert.AreEqual(node, scene.GetNode(1));

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreEqual(scene, node.GetDstObject(0));
            Assert.AreEqual(scene, node.GetScene());
        }

        [Test]
        public void RootNode_AddChildNode_AddsNodeToScene()
        {
            // given:
            var scene = new Scene("TheScene");
            var root = scene.GetRootNode();
            var node = new Node("ChildNode");

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
            Assert.AreEqual(scene, root.GetScene());

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.AreEqual(null, node.GetScene());

            // when:
            root.AddChild(node);

            // then:
            Assert.AreEqual(4, scene.GetSrcObjectCount());
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(node, scene.GetSrcObject(3));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(2, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));
            Assert.AreEqual(node, scene.GetNode(1));

            Assert.AreEqual(1, root.GetSrcObjectCount());
            Assert.AreEqual(node, root.GetSrcObject(0));
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));
            Assert.AreEqual(scene, root.GetScene());

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(2, node.GetDstObjectCount());
            Assert.AreEqual(root, node.GetDstObject(0));
            Assert.AreEqual(scene, node.GetDstObject(1));
            Assert.AreEqual(scene, node.GetScene());
        }

        [Test]
        public void Scene_Create_HasRootNode()
        {
            // given:

            // when:
            var scene = new Scene("Scene1");
            var root = scene.GetRootNode();

            // then:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(root, scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetNodeCount());
            Assert.AreEqual(root, scene.GetNode(0));

            Assert.AreNotEqual(null, root);
            Assert.AreEqual(0, root.GetSrcObjectCount());
            Assert.AreEqual(1, root.GetDstObjectCount());
            Assert.AreEqual(scene, root.GetDstObject(0));
            Assert.AreEqual(scene, root.GetScene());
            Assert.AreEqual(0, root.GetChildCount());
        }
    }
}
