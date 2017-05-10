using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SceneTest : TestBase
    {
        [Test]
        public void Scene_AddNode_AddsNode()
        {
            // given:
            var scene = new FbxScene("TheScene");
            var node = new FbxNode("ChildNode");

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
            var scene = new FbxScene("TheScene");
            var root = scene.GetRootNode();
            var node = new FbxNode("ChildNode");

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
            var scene = new FbxScene("Scene1");
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

        [Test]
        public void Scene_Create_HasZeroPoses()
        {
            // given:

            // when:
            var scene = new FbxScene("Scene1");

            // then:
            Assert.AreEqual(0, scene.GetPoseCount());
        }

        [Test]
        public void Scene_AddPose_AddsPose()
        {
            // given:
            var scene = new FbxScene("Scene");
            var pose = new FbxPose("Pose");

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(0, scene.GetPoseCount());

            Assert.AreEqual(0, pose.GetSrcObjectCount());
            Assert.AreEqual(0, pose.GetDstObjectCount());
            Assert.AreEqual(null, pose.GetScene());

            // when:
            scene.AddPose(pose);

            // then:
            Assert.AreEqual(4, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(pose, scene.GetSrcObject(3));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetPoseCount());
            Assert.AreEqual(pose, scene.GetPose(0));

            Assert.AreEqual(0, pose.GetSrcObjectCount());
            Assert.AreEqual(1, pose.GetDstObjectCount());
            Assert.AreEqual(scene, pose.GetDstObject(0));
            Assert.AreEqual(scene, pose.GetScene());
        }

        [Test]
        public void Scene_ConnectSrcObject_AddsPose()
        {
            // given:
            var scene = new FbxScene("Scene");
            var pose = new FbxPose("Pose");

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(0, scene.GetPoseCount());

            Assert.AreEqual(0, pose.GetSrcObjectCount());
            Assert.AreEqual(0, pose.GetDstObjectCount());
            Assert.AreEqual(null, pose.GetScene());

            // when:
            scene.ConnectSrcObject(pose);

            // then:
            Assert.AreEqual(4, scene.GetSrcObjectCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetSrcObject(0));
            Assert.AreEqual(scene.GetGlobalSettings(), scene.GetSrcObject(1));
            Assert.AreEqual(scene.GetAnimationEvaluator(), scene.GetSrcObject(2));
            Assert.AreEqual(pose, scene.GetSrcObject(3));
            Assert.AreEqual(0, scene.GetDstObjectCount());
            Assert.AreEqual(1, scene.GetPoseCount());
            Assert.AreEqual(pose, scene.GetPose(0));

            Assert.AreEqual(0, pose.GetSrcObjectCount());
            Assert.AreEqual(1, pose.GetDstObjectCount());
            Assert.AreEqual(scene, pose.GetDstObject(0));
            Assert.AreEqual(scene, pose.GetScene());
        }

        [Test]
        public void Scene_Create_HasProperties()
        {
            // given:
            var scene = new FbxScene("");
            FbxProperty prop;

            // then:
            Assert.AreEqual(2, CountProperties(scene));
            Assert.AreEqual(0, scene.GetSrcPropertyCount());
            Assert.AreEqual(0, scene.GetDstPropertyCount());

            prop = scene.FindProperty("SourceObject");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(scene.Roots);
            Assert.True(scene.Roots.IsValid());
            Assert.AreEqual("SourceObject", scene.Roots.GetName());
            Assert.AreSame(prop, scene.Roots);

            prop = scene.FindProperty("ActiveAnimStackName");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(scene.ActiveAnimStackName);
            Assert.True(scene.ActiveAnimStackName.IsValid());
            Assert.AreEqual("ActiveAnimStackName", scene.ActiveAnimStackName.GetName());
            Assert.AreSame(prop, scene.ActiveAnimStackName);
        }

        [Test]
        public void Document_Create_HasProperties()
        {
            // given:
            var doc = new FbxDocument("");
            FbxProperty prop;

            // then:
            Assert.AreEqual(2, CountProperties(doc));
            Assert.AreEqual(0, doc.GetSrcPropertyCount());
            Assert.AreEqual(0, doc.GetDstPropertyCount());

            prop = doc.FindProperty("SourceObject");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(doc.Roots);
            Assert.True(doc.Roots.IsValid());
            Assert.AreEqual("SourceObject", doc.Roots.GetName());
            Assert.AreSame(prop, doc.Roots);

            prop = doc.FindProperty("ActiveAnimStackName");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(doc.ActiveAnimStackName);
            Assert.True(doc.ActiveAnimStackName.IsValid());
            Assert.AreEqual("ActiveAnimStackName", doc.ActiveAnimStackName.GetName());
            Assert.AreSame(prop, doc.ActiveAnimStackName);
        }

        [Test]
        public void Scene_AddObjectWithSrcObjects_AddsAllSrcObjects()
        {
            // given:
            var scene = new FbxScene("s");
            var node = new FbxNode("n");
            var m1 = new FbxMesh("m1");
            var m2 = new FbxMesh("m2");
            var v = new FbxVideo("v");
            var c = new FbxCluster("c");
            var n2 = new FbxNode("n2");
            var c2 = new FbxCluster("c2");

            node.ConnectSrcObject(m1);
            node.ConnectSrcObject(m2);
            node.ConnectSrcObject(v);
            node.ConnectSrcObject(c);
            c.ConnectSrcObject(n2);;
            n2.ConnectSrcObject(c2);

            // require:
            Assert.AreEqual(3, scene.GetSrcObjectCount());

            Assert.AreEqual(4, node.GetSrcObjectCount());
            Assert.AreSame(m1, node.GetSrcObject(0));
            Assert.AreSame(m2, node.GetSrcObject(1));
            Assert.AreSame(v, node.GetSrcObject(2));
            Assert.AreSame(c, node.GetSrcObject(3));
            Assert.AreEqual(0, node.GetDstObjectCount());
            Assert.Null(node.GetScene());

            Assert.AreEqual(0, m1.GetSrcObjectCount());
            Assert.AreEqual(1, m1.GetDstObjectCount());
            Assert.AreSame(node, m1.GetDstObject(0));
            Assert.Null(m1.GetScene());

            Assert.AreEqual(0, m2.GetSrcObjectCount());
            Assert.AreEqual(1, m2.GetDstObjectCount());
            Assert.AreSame(node, m2.GetDstObject(0));
            Assert.Null(m2.GetScene());

            Assert.AreEqual(0, v.GetSrcObjectCount());
            Assert.AreEqual(1, v.GetDstObjectCount());
            Assert.AreSame(node, v.GetDstObject(0));
            Assert.Null(v.GetScene());

            Assert.AreEqual(1, c.GetSrcObjectCount());
            Assert.AreSame(n2, c.GetSrcObject());;
            Assert.AreEqual(1, c.GetDstObjectCount());
            Assert.AreSame(node, c.GetDstObject(0));
            Assert.Null(c.GetScene());

            Assert.AreEqual(1, n2.GetSrcObjectCount());
            Assert.AreSame(c2, n2.GetSrcObject());;
            Assert.AreEqual(1, n2.GetDstObjectCount());
            Assert.AreSame(c, n2.GetDstObject(0));
            Assert.Null(n2.GetScene());

            Assert.AreEqual(0, c2.GetSrcObjectCount());
            Assert.AreEqual(1, c2.GetDstObjectCount());
            Assert.AreSame(n2, c2.GetDstObject(0));
            Assert.Null(c2.GetScene());

            // when:
            scene.ConnectSrcObject(node);

            // then:
            Assert.AreEqual(10, scene.GetSrcObjectCount());
            Assert.AreSame(node, scene.GetSrcObject(3));
            Assert.AreSame(m1, scene.GetSrcObject(4));
            Assert.AreSame(m2, scene.GetSrcObject(5));
            Assert.AreSame(v, scene.GetSrcObject(6));
            Assert.AreSame(c, scene.GetSrcObject(7));
            Assert.AreSame(n2, scene.GetSrcObject(8));
            Assert.AreSame(c2, scene.GetSrcObject(9));

            Assert.AreEqual(4, node.GetSrcObjectCount());
            Assert.AreSame(m1, node.GetSrcObject(0));
            Assert.AreSame(m2, node.GetSrcObject(1));
            Assert.AreSame(v, node.GetSrcObject(2));
            Assert.AreSame(c, node.GetSrcObject(3));
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreSame(scene, node.GetDstObject(0));
            Assert.AreSame(scene, node.GetScene());

            Assert.AreEqual(0, m1.GetSrcObjectCount());
            Assert.AreEqual(2, m1.GetDstObjectCount());
            Assert.AreSame(node, m1.GetDstObject(0));
            Assert.AreSame(scene, m1.GetDstObject(1));
            Assert.AreSame(scene, m1.GetScene());

            Assert.AreEqual(0, m2.GetSrcObjectCount());
            Assert.AreEqual(2, m2.GetDstObjectCount());
            Assert.AreSame(node, m2.GetDstObject(0));
            Assert.AreSame(scene, m2.GetDstObject(1));
            Assert.AreSame(scene, m2.GetScene());

            Assert.AreEqual(0, v.GetSrcObjectCount());
            Assert.AreEqual(2, v.GetDstObjectCount());
            Assert.AreSame(node, v.GetDstObject(0));
            Assert.AreSame(scene, v.GetDstObject(1));
            Assert.AreSame(scene, v.GetScene());

            Assert.AreEqual(1, c.GetSrcObjectCount());
            Assert.AreSame(n2, c.GetSrcObject(0));
            Assert.AreEqual(2, c.GetDstObjectCount());
            Assert.AreSame(node, c.GetDstObject(0));
            Assert.AreSame(scene, c.GetDstObject(1));
            Assert.AreSame(scene, c.GetScene());

            Assert.AreEqual(1, n2.GetSrcObjectCount());
            Assert.AreSame(c2, n2.GetSrcObject());;
            Assert.AreEqual(2, n2.GetDstObjectCount());
            Assert.AreSame(c, n2.GetDstObject(0));
            Assert.AreSame(scene, n2.GetDstObject(1));
            Assert.AreSame(scene, n2.GetScene());

            Assert.AreEqual(0, c2.GetSrcObjectCount());
            Assert.AreEqual(2, c2.GetDstObjectCount());
            Assert.AreSame(n2, c2.GetDstObject(0));
            Assert.AreSame(scene, c2.GetDstObject(1));
            Assert.AreSame(scene, c2.GetScene());
        }

        [Test]
        public void Scene_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxScene("asdf");

            // then:
            Assert.AreEqual("Scene::", obj.GetNameSpacePrefix());
        }
    }
}
