using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class NodeTest : TestBase
    {
        [Test]
        public void RootNode_AddChild_AddsConnection()
        {
            // given:
            var scene = new FbxScene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new FbxNode("ChildNode");

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
            var node = new FbxNode("Node");
            var nullattr = new FbxNull("nullattr");

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
            var node1 = new FbxNode("Node1");
            var node2 = new FbxNode("Node2");

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
            var scene = new FbxScene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new FbxNode("ChildNode");
            var node3 = new FbxNode("ChildNode");
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
            var scene = new FbxScene("TheScene");
            var root = scene.GetRootNode();
            var node2 = new FbxNode("ChildNode");

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
            var node = new FbxNode("Node");
            var nullattr = new FbxNull("nullattr");

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

        [Test]
        public void Node_Create_HasProperties()
        {
            // given:
            var node = new FbxNode("");
            FbxProperty prop;

            // then:
            Assert.AreEqual(71, CountProperties(node));
            Assert.AreEqual(0, node.GetSrcPropertyCount());
            Assert.AreEqual(0, node.GetDstPropertyCount());

            prop = node.FindProperty("QuaternionInterpolate");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.QuaternionInterpolate);
            Assert.True(node.QuaternionInterpolate.IsValid());
            Assert.AreEqual("QuaternionInterpolate", node.QuaternionInterpolate.GetName());
            Assert.AreSame(prop, node.QuaternionInterpolate);

            prop = node.FindProperty("RotationOffset");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationOffset);
            Assert.True(node.RotationOffset.IsValid());
            Assert.AreEqual("RotationOffset", node.RotationOffset.GetName());
            Assert.AreSame(prop, node.RotationOffset);

            prop = node.FindProperty("RotationPivot");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationPivot);
            Assert.True(node.RotationPivot.IsValid());
            Assert.AreEqual("RotationPivot", node.RotationPivot.GetName());
            Assert.AreSame(prop, node.RotationPivot);

            prop = node.FindProperty("ScalingOffset");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingOffset);
            Assert.True(node.ScalingOffset.IsValid());
            Assert.AreEqual("ScalingOffset", node.ScalingOffset.GetName());
            Assert.AreSame(prop, node.ScalingOffset);

            prop = node.FindProperty("ScalingPivot");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingPivot);
            Assert.True(node.ScalingPivot.IsValid());
            Assert.AreEqual("ScalingPivot", node.ScalingPivot.GetName());
            Assert.AreSame(prop, node.ScalingPivot);

            prop = node.FindProperty("TranslationActive");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationActive);
            Assert.True(node.TranslationActive.IsValid());
            Assert.AreEqual("TranslationActive", node.TranslationActive.GetName());
            Assert.AreSame(prop, node.TranslationActive);

            prop = node.FindProperty("TranslationMin");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMin);
            Assert.True(node.TranslationMin.IsValid());
            Assert.AreEqual("TranslationMin", node.TranslationMin.GetName());
            Assert.AreSame(prop, node.TranslationMin);

            prop = node.FindProperty("TranslationMax");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMax);
            Assert.True(node.TranslationMax.IsValid());
            Assert.AreEqual("TranslationMax", node.TranslationMax.GetName());
            Assert.AreSame(prop, node.TranslationMax);

            prop = node.FindProperty("TranslationMinX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMinX);
            Assert.True(node.TranslationMinX.IsValid());
            Assert.AreEqual("TranslationMinX", node.TranslationMinX.GetName());
            Assert.AreSame(prop, node.TranslationMinX);

            prop = node.FindProperty("TranslationMinY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMinY);
            Assert.True(node.TranslationMinY.IsValid());
            Assert.AreEqual("TranslationMinY", node.TranslationMinY.GetName());
            Assert.AreSame(prop, node.TranslationMinY);

            prop = node.FindProperty("TranslationMinZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMinZ);
            Assert.True(node.TranslationMinZ.IsValid());
            Assert.AreEqual("TranslationMinZ", node.TranslationMinZ.GetName());
            Assert.AreSame(prop, node.TranslationMinZ);

            prop = node.FindProperty("TranslationMaxX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMaxX);
            Assert.True(node.TranslationMaxX.IsValid());
            Assert.AreEqual("TranslationMaxX", node.TranslationMaxX.GetName());
            Assert.AreSame(prop, node.TranslationMaxX);

            prop = node.FindProperty("TranslationMaxY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMaxY);
            Assert.True(node.TranslationMaxY.IsValid());
            Assert.AreEqual("TranslationMaxY", node.TranslationMaxY.GetName());
            Assert.AreSame(prop, node.TranslationMaxY);

            prop = node.FindProperty("TranslationMaxZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.TranslationMaxZ);
            Assert.True(node.TranslationMaxZ.IsValid());
            Assert.AreEqual("TranslationMaxZ", node.TranslationMaxZ.GetName());
            Assert.AreSame(prop, node.TranslationMaxZ);

            prop = node.FindProperty("RotationOrder");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationOrder);
            Assert.True(node.RotationOrder.IsValid());
            Assert.AreEqual("RotationOrder", node.RotationOrder.GetName());
            Assert.AreSame(prop, node.RotationOrder);

            prop = node.FindProperty("RotationSpaceForLimitOnly");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationSpaceForLimitOnly);
            Assert.True(node.RotationSpaceForLimitOnly.IsValid());
            Assert.AreEqual("RotationSpaceForLimitOnly", node.RotationSpaceForLimitOnly.GetName());
            Assert.AreSame(prop, node.RotationSpaceForLimitOnly);

            prop = node.FindProperty("RotationStiffnessX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationStiffnessX);
            Assert.True(node.RotationStiffnessX.IsValid());
            Assert.AreEqual("RotationStiffnessX", node.RotationStiffnessX.GetName());
            Assert.AreSame(prop, node.RotationStiffnessX);

            prop = node.FindProperty("RotationStiffnessY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationStiffnessY);
            Assert.True(node.RotationStiffnessY.IsValid());
            Assert.AreEqual("RotationStiffnessY", node.RotationStiffnessY.GetName());
            Assert.AreSame(prop, node.RotationStiffnessY);

            prop = node.FindProperty("RotationStiffnessZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationStiffnessZ);
            Assert.True(node.RotationStiffnessZ.IsValid());
            Assert.AreEqual("RotationStiffnessZ", node.RotationStiffnessZ.GetName());
            Assert.AreSame(prop, node.RotationStiffnessZ);

            prop = node.FindProperty("AxisLen");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.AxisLen);
            Assert.True(node.AxisLen.IsValid());
            Assert.AreEqual("AxisLen", node.AxisLen.GetName());
            Assert.AreSame(prop, node.AxisLen);

            prop = node.FindProperty("PreRotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.PreRotation);
            Assert.True(node.PreRotation.IsValid());
            Assert.AreEqual("PreRotation", node.PreRotation.GetName());
            Assert.AreSame(prop, node.PreRotation);

            prop = node.FindProperty("PostRotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.PostRotation);
            Assert.True(node.PostRotation.IsValid());
            Assert.AreEqual("PostRotation", node.PostRotation.GetName());
            Assert.AreSame(prop, node.PostRotation);

            prop = node.FindProperty("RotationActive");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationActive);
            Assert.True(node.RotationActive.IsValid());
            Assert.AreEqual("RotationActive", node.RotationActive.GetName());
            Assert.AreSame(prop, node.RotationActive);

            prop = node.FindProperty("RotationMin");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMin);
            Assert.True(node.RotationMin.IsValid());
            Assert.AreEqual("RotationMin", node.RotationMin.GetName());
            Assert.AreSame(prop, node.RotationMin);

            prop = node.FindProperty("RotationMax");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMax);
            Assert.True(node.RotationMax.IsValid());
            Assert.AreEqual("RotationMax", node.RotationMax.GetName());
            Assert.AreSame(prop, node.RotationMax);

            prop = node.FindProperty("RotationMinX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMinX);
            Assert.True(node.RotationMinX.IsValid());
            Assert.AreEqual("RotationMinX", node.RotationMinX.GetName());
            Assert.AreSame(prop, node.RotationMinX);

            prop = node.FindProperty("RotationMinY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMinY);
            Assert.True(node.RotationMinY.IsValid());
            Assert.AreEqual("RotationMinY", node.RotationMinY.GetName());
            Assert.AreSame(prop, node.RotationMinY);

            prop = node.FindProperty("RotationMinZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMinZ);
            Assert.True(node.RotationMinZ.IsValid());
            Assert.AreEqual("RotationMinZ", node.RotationMinZ.GetName());
            Assert.AreSame(prop, node.RotationMinZ);

            prop = node.FindProperty("RotationMaxX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMaxX);
            Assert.True(node.RotationMaxX.IsValid());
            Assert.AreEqual("RotationMaxX", node.RotationMaxX.GetName());
            Assert.AreSame(prop, node.RotationMaxX);

            prop = node.FindProperty("RotationMaxY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMaxY);
            Assert.True(node.RotationMaxY.IsValid());
            Assert.AreEqual("RotationMaxY", node.RotationMaxY.GetName());
            Assert.AreSame(prop, node.RotationMaxY);

            prop = node.FindProperty("RotationMaxZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.RotationMaxZ);
            Assert.True(node.RotationMaxZ.IsValid());
            Assert.AreEqual("RotationMaxZ", node.RotationMaxZ.GetName());
            Assert.AreSame(prop, node.RotationMaxZ);

            prop = node.FindProperty("InheritType");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.InheritType);
            Assert.True(node.InheritType.IsValid());
            Assert.AreEqual("InheritType", node.InheritType.GetName());
            Assert.AreSame(prop, node.InheritType);

            prop = node.FindProperty("ScalingActive");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingActive);
            Assert.True(node.ScalingActive.IsValid());
            Assert.AreEqual("ScalingActive", node.ScalingActive.GetName());
            Assert.AreSame(prop, node.ScalingActive);

            prop = node.FindProperty("ScalingMin");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMin);
            Assert.True(node.ScalingMin.IsValid());
            Assert.AreEqual("ScalingMin", node.ScalingMin.GetName());
            Assert.AreSame(prop, node.ScalingMin);

            prop = node.FindProperty("ScalingMax");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMax);
            Assert.True(node.ScalingMax.IsValid());
            Assert.AreEqual("ScalingMax", node.ScalingMax.GetName());
            Assert.AreSame(prop, node.ScalingMax);

            prop = node.FindProperty("ScalingMinX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMinX);
            Assert.True(node.ScalingMinX.IsValid());
            Assert.AreEqual("ScalingMinX", node.ScalingMinX.GetName());
            Assert.AreSame(prop, node.ScalingMinX);

            prop = node.FindProperty("ScalingMinY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMinY);
            Assert.True(node.ScalingMinY.IsValid());
            Assert.AreEqual("ScalingMinY", node.ScalingMinY.GetName());
            Assert.AreSame(prop, node.ScalingMinY);

            prop = node.FindProperty("ScalingMinZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMinZ);
            Assert.True(node.ScalingMinZ.IsValid());
            Assert.AreEqual("ScalingMinZ", node.ScalingMinZ.GetName());
            Assert.AreSame(prop, node.ScalingMinZ);

            prop = node.FindProperty("ScalingMaxX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMaxX);
            Assert.True(node.ScalingMaxX.IsValid());
            Assert.AreEqual("ScalingMaxX", node.ScalingMaxX.GetName());
            Assert.AreSame(prop, node.ScalingMaxX);

            prop = node.FindProperty("ScalingMaxY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMaxY);
            Assert.True(node.ScalingMaxY.IsValid());
            Assert.AreEqual("ScalingMaxY", node.ScalingMaxY.GetName());
            Assert.AreSame(prop, node.ScalingMaxY);

            prop = node.FindProperty("ScalingMaxZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.ScalingMaxZ);
            Assert.True(node.ScalingMaxZ.IsValid());
            Assert.AreEqual("ScalingMaxZ", node.ScalingMaxZ.GetName());
            Assert.AreSame(prop, node.ScalingMaxZ);

            prop = node.FindProperty("GeometricTranslation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.GeometricTranslation);
            Assert.True(node.GeometricTranslation.IsValid());
            Assert.AreEqual("GeometricTranslation", node.GeometricTranslation.GetName());
            Assert.AreSame(prop, node.GeometricTranslation);

            prop = node.FindProperty("GeometricRotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.GeometricRotation);
            Assert.True(node.GeometricRotation.IsValid());
            Assert.AreEqual("GeometricRotation", node.GeometricRotation.GetName());
            Assert.AreSame(prop, node.GeometricRotation);

            prop = node.FindProperty("GeometricScaling");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.GeometricScaling);
            Assert.True(node.GeometricScaling.IsValid());
            Assert.AreEqual("GeometricScaling", node.GeometricScaling.GetName());
            Assert.AreSame(prop, node.GeometricScaling);

            prop = node.FindProperty("MinDampRangeX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampRangeX);
            Assert.True(node.MinDampRangeX.IsValid());
            Assert.AreEqual("MinDampRangeX", node.MinDampRangeX.GetName());
            Assert.AreSame(prop, node.MinDampRangeX);

            prop = node.FindProperty("MinDampRangeY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampRangeY);
            Assert.True(node.MinDampRangeY.IsValid());
            Assert.AreEqual("MinDampRangeY", node.MinDampRangeY.GetName());
            Assert.AreSame(prop, node.MinDampRangeY);

            prop = node.FindProperty("MinDampRangeZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampRangeZ);
            Assert.True(node.MinDampRangeZ.IsValid());
            Assert.AreEqual("MinDampRangeZ", node.MinDampRangeZ.GetName());
            Assert.AreSame(prop, node.MinDampRangeZ);

            prop = node.FindProperty("MaxDampRangeX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampRangeX);
            Assert.True(node.MaxDampRangeX.IsValid());
            Assert.AreEqual("MaxDampRangeX", node.MaxDampRangeX.GetName());
            Assert.AreSame(prop, node.MaxDampRangeX);

            prop = node.FindProperty("MaxDampRangeY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampRangeY);
            Assert.True(node.MaxDampRangeY.IsValid());
            Assert.AreEqual("MaxDampRangeY", node.MaxDampRangeY.GetName());
            Assert.AreSame(prop, node.MaxDampRangeY);

            prop = node.FindProperty("MaxDampRangeZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampRangeZ);
            Assert.True(node.MaxDampRangeZ.IsValid());
            Assert.AreEqual("MaxDampRangeZ", node.MaxDampRangeZ.GetName());
            Assert.AreSame(prop, node.MaxDampRangeZ);

            prop = node.FindProperty("MinDampStrengthX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampStrengthX);
            Assert.True(node.MinDampStrengthX.IsValid());
            Assert.AreEqual("MinDampStrengthX", node.MinDampStrengthX.GetName());
            Assert.AreSame(prop, node.MinDampStrengthX);

            prop = node.FindProperty("MinDampStrengthY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampStrengthY);
            Assert.True(node.MinDampStrengthY.IsValid());
            Assert.AreEqual("MinDampStrengthY", node.MinDampStrengthY.GetName());
            Assert.AreSame(prop, node.MinDampStrengthY);

            prop = node.FindProperty("MinDampStrengthZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MinDampStrengthZ);
            Assert.True(node.MinDampStrengthZ.IsValid());
            Assert.AreEqual("MinDampStrengthZ", node.MinDampStrengthZ.GetName());
            Assert.AreSame(prop, node.MinDampStrengthZ);

            prop = node.FindProperty("MaxDampStrengthX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampStrengthX);
            Assert.True(node.MaxDampStrengthX.IsValid());
            Assert.AreEqual("MaxDampStrengthX", node.MaxDampStrengthX.GetName());
            Assert.AreSame(prop, node.MaxDampStrengthX);

            prop = node.FindProperty("MaxDampStrengthY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampStrengthY);
            Assert.True(node.MaxDampStrengthY.IsValid());
            Assert.AreEqual("MaxDampStrengthY", node.MaxDampStrengthY.GetName());
            Assert.AreSame(prop, node.MaxDampStrengthY);

            prop = node.FindProperty("MaxDampStrengthZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.MaxDampStrengthZ);
            Assert.True(node.MaxDampStrengthZ.IsValid());
            Assert.AreEqual("MaxDampStrengthZ", node.MaxDampStrengthZ.GetName());
            Assert.AreSame(prop, node.MaxDampStrengthZ);

            prop = node.FindProperty("PreferedAngleX");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.PreferedAngleX);
            Assert.True(node.PreferedAngleX.IsValid());
            Assert.AreEqual("PreferedAngleX", node.PreferedAngleX.GetName());
            Assert.AreSame(prop, node.PreferedAngleX);

            prop = node.FindProperty("PreferedAngleY");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.PreferedAngleY);
            Assert.True(node.PreferedAngleY.IsValid());
            Assert.AreEqual("PreferedAngleY", node.PreferedAngleY.GetName());
            Assert.AreSame(prop, node.PreferedAngleY);

            prop = node.FindProperty("PreferedAngleZ");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.PreferedAngleZ);
            Assert.True(node.PreferedAngleZ.IsValid());
            Assert.AreEqual("PreferedAngleZ", node.PreferedAngleZ.GetName());
            Assert.AreSame(prop, node.PreferedAngleZ);

            prop = node.FindProperty("LookAtProperty");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.LookAtProperty);
            Assert.True(node.LookAtProperty.IsValid());
            Assert.AreEqual("LookAtProperty", node.LookAtProperty.GetName());
            Assert.AreSame(prop, node.LookAtProperty);

            prop = node.FindProperty("UpVectorProperty");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.UpVectorProperty);
            Assert.True(node.UpVectorProperty.IsValid());
            Assert.AreEqual("UpVectorProperty", node.UpVectorProperty.GetName());
            Assert.AreSame(prop, node.UpVectorProperty);

            prop = node.FindProperty("Show");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.Show);
            Assert.True(node.Show.IsValid());
            Assert.AreEqual("Show", node.Show.GetName());
            Assert.AreSame(prop, node.Show);

            prop = node.FindProperty("NegativePercentShapeSupport");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.NegativePercentShapeSupport);
            Assert.True(node.NegativePercentShapeSupport.IsValid());
            Assert.AreEqual("NegativePercentShapeSupport", node.NegativePercentShapeSupport.GetName());
            Assert.AreSame(prop, node.NegativePercentShapeSupport);

            prop = node.FindProperty("DefaultAttributeIndex");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.DefaultAttributeIndex);
            Assert.True(node.DefaultAttributeIndex.IsValid());
            Assert.AreEqual("DefaultAttributeIndex", node.DefaultAttributeIndex.GetName());
            Assert.AreSame(prop, node.DefaultAttributeIndex);

            prop = node.FindProperty("Freeze");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.Freeze);
            Assert.True(node.Freeze.IsValid());
            Assert.AreEqual("Freeze", node.Freeze.GetName());
            Assert.AreSame(prop, node.Freeze);

            prop = node.FindProperty("LODBox");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.LODBox);
            Assert.True(node.LODBox.IsValid());
            Assert.AreEqual("LODBox", node.LODBox.GetName());
            Assert.AreSame(prop, node.LODBox);

            prop = node.FindProperty("Lcl Translation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.LclTranslation);
            Assert.True(node.LclTranslation.IsValid());
            Assert.AreEqual("Lcl Translation", node.LclTranslation.GetName());
            Assert.AreSame(prop, node.LclTranslation);

            prop = node.FindProperty("Lcl Rotation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.LclRotation);
            Assert.True(node.LclRotation.IsValid());
            Assert.AreEqual("Lcl Rotation", node.LclRotation.GetName());
            Assert.AreSame(prop, node.LclRotation);

            prop = node.FindProperty("Lcl Scaling");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.LclScaling);
            Assert.True(node.LclScaling.IsValid());
            Assert.AreEqual("Lcl Scaling", node.LclScaling.GetName());
            Assert.AreSame(prop, node.LclScaling);

            prop = node.FindProperty("Visibility");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.Visibility);
            Assert.True(node.Visibility.IsValid());
            Assert.AreEqual("Visibility", node.Visibility.GetName());
            Assert.AreSame(prop, node.Visibility);

            prop = node.FindProperty("Visibility Inheritance");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(node.VisibilityInheritance);
            Assert.True(node.VisibilityInheritance.IsValid());
            Assert.AreEqual("Visibility Inheritance", node.VisibilityInheritance.GetName());
            Assert.AreSame(prop, node.VisibilityInheritance);
        }

        [Test]
        public void Node_AddMaterial_SetsMaterialScene()
        {
            // given:
            var scene = new FbxScene("");
            var root = scene.GetRootNode();
            var node = new FbxNode("");
            var mat = new FbxSurfacePhong("");

            root.AddChild(node);

            // require:
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
            Assert.AreEqual(2, node.GetDstObjectCount());
            Assert.AreEqual(root, node.GetDstObject(0));
            Assert.AreEqual(scene, node.GetDstObject(1));
            Assert.AreEqual(scene, node.GetScene());
            Assert.AreEqual(0, node.GetMaterialCount());

            Assert.AreEqual(0, mat.GetSrcObjectCount());
            Assert.AreEqual(0, mat.GetDstObjectCount());
            Assert.AreEqual(null, mat.GetScene());

            // when:
            node.AddMaterial(mat);

            // then:
            Assert.AreEqual(5, scene.GetSrcObjectCount());
            Assert.AreEqual(mat, scene.GetSrcObject(4));
            Assert.AreEqual(2, scene.GetNodeCount());
            Assert.AreEqual(scene.GetRootNode(), scene.GetNode(0));
            Assert.AreEqual(node, scene.GetNode(1));

            Assert.AreEqual(1, node.GetSrcObjectCount());
            Assert.AreEqual(mat, node.GetSrcObject(0));
            Assert.AreEqual(1, node.GetMaterialCount());
            Assert.AreEqual(mat, node.GetMaterial(0));

            Assert.AreEqual(0, mat.GetSrcObjectCount());
            Assert.AreEqual(2, mat.GetDstObjectCount());
            Assert.AreEqual(node, mat.GetDstObject(0));
            Assert.AreEqual(scene, mat.GetDstObject(1));
            Assert.AreEqual(scene, mat.GetScene());
        }

        [Test]
        public void Node_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxNode("asdf");

            // then:
            Assert.AreEqual("Model::", obj.GetNameSpacePrefix());
        }
    }
}
