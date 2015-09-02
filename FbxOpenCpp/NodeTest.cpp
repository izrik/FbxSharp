
#include "Tests.h"

using namespace std;

void RootNode_AddChild_AddsConnection()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node2 = FbxNode::Create(manager, "ChildNode");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(root, scene->GetSrcObject());
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));

    AssertEqual(0, root->GetSrcObjectCount());
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(0, node2->GetDstObjectCount());

    // when:
    root->AddChild(node2);

    // then:
    AssertEqual(1, root->GetSrcObjectCount());
    AssertEqual(node2, root->GetSrcObject(0));
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(2, node2->GetDstObjectCount());
    AssertEqual(root, node2->GetDstObject(0));
    AssertEqual(scene, node2->GetDstObject(1));
}

void Node_SetNodeAttribute_SetsNodeAttribute()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "Node");
    FbxNull* nullattr = FbxNull::Create(manager, "nullattr");

    // require:
    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(0, node->GetNodeAttributeCount());
    AssertEqual(NULL, node->GetNodeAttribute());
    AssertEqual(-1, node->GetDefaultNodeAttributeIndex());

    AssertEqual(0, nullattr->GetSrcObjectCount());
    AssertEqual(0, nullattr->GetDstObjectCount());
    AssertEqual(0, nullattr->GetSrcPropertyCount());
    AssertEqual(0, nullattr->GetDstPropertyCount());
    AssertEqual(0, nullattr->GetNodeCount());

    // when:
    node->SetNodeAttribute(nullattr);

    // then:
    AssertEqual(1, node->GetSrcObjectCount());
    AssertEqual(nullattr, node->GetSrcObject(0));
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(1, node->GetNodeAttributeCount());
    AssertEqual(nullattr, node->GetNodeAttribute());
    AssertEqual(0, node->GetDefaultNodeAttributeIndex());
    AssertEqual(nullattr, node->GetNodeAttributeByIndex(0));

    AssertEqual(0, nullattr->GetSrcObjectCount());
    AssertEqual(1, nullattr->GetDstObjectCount());
    AssertEqual(node, nullattr->GetDstObject(0));
    AssertEqual(0, nullattr->GetSrcPropertyCount());
    AssertEqual(0, nullattr->GetDstPropertyCount());
    AssertEqual(1, nullattr->GetNodeCount());
    AssertEqual(node, nullattr->GetNode());
    AssertEqual(node, nullattr->GetNode(0));
}

void Node_AddChild_AddsChild()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node1 = FbxNode::Create(manager, "Node1");
    FbxNode* node2 = FbxNode::Create(manager, "Node2");

    // require:
    AssertEqual(0, node1->GetSrcObjectCount());
    AssertEqual(0, node1->GetDstObjectCount());
    AssertEqual(0, node1->GetSrcPropertyCount());
    AssertEqual(0, node1->GetDstPropertyCount());
    AssertEqual(0, node1->GetChildCount());
    AssertEqual(NULL, node1->GetParent());

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(0, node2->GetDstObjectCount());
    AssertEqual(0, node2->GetSrcPropertyCount());
    AssertEqual(0, node2->GetDstPropertyCount());
    AssertEqual(0, node2->GetChildCount());
    AssertEqual(NULL, node1->GetParent());

    // when:
    node1->AddChild(node2);

    // then:
    AssertEqual(1, node1->GetSrcObjectCount());
    AssertEqual(node2, node1->GetSrcObject(0));
    AssertEqual(0, node1->GetDstObjectCount());
    AssertEqual(0, node1->GetSrcPropertyCount());
    AssertEqual(0, node1->GetDstPropertyCount());
    AssertEqual(1, node1->GetChildCount());
    AssertEqual(node2, node1->GetChild(0));
    AssertEqual(NULL, node1->GetParent());

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(1, node2->GetDstObjectCount());
    AssertEqual(node1, node2->GetDstObject(0));
    AssertEqual(0, node2->GetSrcPropertyCount());
    AssertEqual(0, node2->GetDstPropertyCount());
    AssertEqual(0, node2->GetChildCount());
    AssertEqual(node1, node2->GetParent());
}

void RootNode_AddChild_AddsNodeSubtree()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node2 = FbxNode::Create(manager, "ChildNode");
    FbxNode* node3 = FbxNode::Create(manager, "ChildNode");
    node2->AddChild(node3);

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));

    AssertEqual(0, root->GetSrcObjectCount());
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));
    AssertEqual(0, root->GetChildCount());
    AssertEqual(scene, root->GetScene());

    AssertEqual(1, node2->GetSrcObjectCount());
    AssertEqual(node3, node2->GetSrcObject(0));
    AssertEqual(0, node2->GetDstObjectCount());
    AssertEqual(1, node2->GetChildCount());
    AssertEqual(node3, node2->GetChild(0));
    AssertEqual(NULL, node2->GetParent());
    AssertEqual(NULL, node2->GetScene());

    AssertEqual(0, node3->GetSrcObjectCount());
    AssertEqual(1, node3->GetDstObjectCount());
    AssertEqual(node2, node3->GetDstObject(0));
    AssertEqual(0, node3->GetChildCount());
    AssertEqual(node2, node3->GetParent());
    AssertEqual(NULL, node3->GetScene());

    // when:
    root->AddChild(node2);

    // then:
    AssertEqual(5, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(node2, scene->GetSrcObject(3));
    AssertEqual(node3, scene->GetSrcObject(4));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(3, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));
    AssertEqual(node2, scene->GetNode(1));
    AssertEqual(node3, scene->GetNode(2));

    AssertEqual(1, root->GetSrcObjectCount());
    AssertEqual(node2, root->GetSrcObject(0));
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));
    AssertEqual(1, root->GetChildCount());
    AssertEqual(node2, root->GetChild(0));
    AssertEqual(scene, root->GetScene());

    AssertEqual(1, node2->GetSrcObjectCount());
    AssertEqual(node3, node2->GetSrcObject(0));
    AssertEqual(2, node2->GetDstObjectCount());
    AssertEqual(root, node2->GetDstObject(0));
    AssertEqual(scene, node2->GetDstObject(1));
    AssertEqual(1, node2->GetChildCount());
    AssertEqual(node3, node2->GetChild(0));
    AssertEqual(root, node2->GetParent());
    AssertEqual(scene, node2->GetScene());

    AssertEqual(0, node3->GetSrcObjectCount());
    AssertEqual(2, node3->GetDstObjectCount());
    AssertEqual(node2, node3->GetDstObject(0));
    AssertEqual(scene, node3->GetDstObject(1));
    AssertEqual(0, node3->GetChildCount());
    AssertEqual(node2, node3->GetParent());
    AssertEqual(scene, node3->GetScene());
}

void RootNode_AddSrcObject_AddsChild()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node2 = FbxNode::Create(manager, "ChildNode");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(root, scene->GetSrcObject());
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));

    AssertEqual(0, root->GetSrcObjectCount());
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(0, node2->GetDstObjectCount());
    AssertEqual(NULL, node2->GetScene());

    // when:
    root->ConnectSrcObject(node2);

    // then:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(node2, scene->GetSrcObject(3));
    AssertEqual(root, scene->GetSrcObject());
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(2, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));
    AssertEqual(node2, scene->GetNode(1));

    AssertEqual(1, root->GetSrcObjectCount());
    AssertEqual(node2, root->GetSrcObject(0));
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));

    AssertEqual(0, node2->GetSrcObjectCount());
    AssertEqual(2, node2->GetDstObjectCount());
    AssertEqual(root, node2->GetDstObject(0));
    AssertEqual(scene, node2->GetDstObject(1));
    AssertEqual(scene, node2->GetScene());
}

void Node_AddSrcObject_SetsNodeAttribute()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "Node");
    FbxNull* nullattr = FbxNull::Create(manager, "nullattr");

    // require:
    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(0, node->GetNodeAttributeCount());
    AssertEqual(NULL, node->GetNodeAttribute());
    AssertEqual(-1, node->GetDefaultNodeAttributeIndex());

    AssertEqual(0, nullattr->GetSrcObjectCount());
    AssertEqual(0, nullattr->GetDstObjectCount());
    AssertEqual(0, nullattr->GetSrcPropertyCount());
    AssertEqual(0, nullattr->GetDstPropertyCount());
    AssertEqual(0, nullattr->GetNodeCount());

    // when:
    node->ConnectSrcObject(nullattr);

    // then:
    AssertEqual(1, node->GetSrcObjectCount());
    AssertEqual(nullattr, node->GetSrcObject(0));
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(1, node->GetNodeAttributeCount());
    AssertEqual(NULL, node->GetNodeAttribute());
    AssertEqual(-1, node->GetDefaultNodeAttributeIndex());
    AssertEqual(nullattr, node->GetNodeAttributeByIndex(0));

    AssertEqual(0, nullattr->GetSrcObjectCount());
    AssertEqual(1, nullattr->GetDstObjectCount());
    AssertEqual(node, nullattr->GetDstObject(0));
    AssertEqual(0, nullattr->GetSrcPropertyCount());
    AssertEqual(0, nullattr->GetDstPropertyCount());
    AssertEqual(1, nullattr->GetNodeCount());
    AssertEqual(node, nullattr->GetNode());
    AssertEqual(node, nullattr->GetNode(0));
}

void Node_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxProperty prop;

    // then:
    AssertEqual(71, CountProperties(node));
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());

    prop = node->FindProperty("QuaternionInterpolate");
    AssertTrue(prop.IsValid());
    AssertTrue(node->QuaternionInterpolate.IsValid());
    AssertEqual("QuaternionInterpolate", node->QuaternionInterpolate.GetName());

    prop = node->FindProperty("RotationOffset");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationOffset.IsValid());
    AssertEqual("RotationOffset", node->RotationOffset.GetName());

    prop = node->FindProperty("RotationPivot");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationPivot.IsValid());
    AssertEqual("RotationPivot", node->RotationPivot.GetName());

    prop = node->FindProperty("ScalingOffset");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingOffset.IsValid());
    AssertEqual("ScalingOffset", node->ScalingOffset.GetName());

    prop = node->FindProperty("ScalingPivot");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingPivot.IsValid());
    AssertEqual("ScalingPivot", node->ScalingPivot.GetName());

    prop = node->FindProperty("TranslationActive");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationActive.IsValid());
    AssertEqual("TranslationActive", node->TranslationActive.GetName());

    prop = node->FindProperty("TranslationMin");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMin.IsValid());
    AssertEqual("TranslationMin", node->TranslationMin.GetName());

    prop = node->FindProperty("TranslationMax");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMax.IsValid());
    AssertEqual("TranslationMax", node->TranslationMax.GetName());

    prop = node->FindProperty("TranslationMinX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMinX.IsValid());
    AssertEqual("TranslationMinX", node->TranslationMinX.GetName());

    prop = node->FindProperty("TranslationMinY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMinY.IsValid());
    AssertEqual("TranslationMinY", node->TranslationMinY.GetName());

    prop = node->FindProperty("TranslationMinZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMinZ.IsValid());
    AssertEqual("TranslationMinZ", node->TranslationMinZ.GetName());

    prop = node->FindProperty("TranslationMaxX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMaxX.IsValid());
    AssertEqual("TranslationMaxX", node->TranslationMaxX.GetName());

    prop = node->FindProperty("TranslationMaxY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMaxY.IsValid());
    AssertEqual("TranslationMaxY", node->TranslationMaxY.GetName());

    prop = node->FindProperty("TranslationMaxZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->TranslationMaxZ.IsValid());
    AssertEqual("TranslationMaxZ", node->TranslationMaxZ.GetName());

    prop = node->FindProperty("RotationOrder");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationOrder.IsValid());
    AssertEqual("RotationOrder", node->RotationOrder.GetName());

    prop = node->FindProperty("RotationSpaceForLimitOnly");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationSpaceForLimitOnly.IsValid());
    AssertEqual("RotationSpaceForLimitOnly", node->RotationSpaceForLimitOnly.GetName());

    prop = node->FindProperty("RotationStiffnessX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationStiffnessX.IsValid());
    AssertEqual("RotationStiffnessX", node->RotationStiffnessX.GetName());

    prop = node->FindProperty("RotationStiffnessY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationStiffnessY.IsValid());
    AssertEqual("RotationStiffnessY", node->RotationStiffnessY.GetName());

    prop = node->FindProperty("RotationStiffnessZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationStiffnessZ.IsValid());
    AssertEqual("RotationStiffnessZ", node->RotationStiffnessZ.GetName());

    prop = node->FindProperty("AxisLen");
    AssertTrue(prop.IsValid());
    AssertTrue(node->AxisLen.IsValid());
    AssertEqual("AxisLen", node->AxisLen.GetName());

    prop = node->FindProperty("PreRotation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->PreRotation.IsValid());
    AssertEqual("PreRotation", node->PreRotation.GetName());

    prop = node->FindProperty("PostRotation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->PostRotation.IsValid());
    AssertEqual("PostRotation", node->PostRotation.GetName());

    prop = node->FindProperty("RotationActive");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationActive.IsValid());
    AssertEqual("RotationActive", node->RotationActive.GetName());

    prop = node->FindProperty("RotationMin");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMin.IsValid());
    AssertEqual("RotationMin", node->RotationMin.GetName());

    prop = node->FindProperty("RotationMax");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMax.IsValid());
    AssertEqual("RotationMax", node->RotationMax.GetName());

    prop = node->FindProperty("RotationMinX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMinX.IsValid());
    AssertEqual("RotationMinX", node->RotationMinX.GetName());

    prop = node->FindProperty("RotationMinY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMinY.IsValid());
    AssertEqual("RotationMinY", node->RotationMinY.GetName());

    prop = node->FindProperty("RotationMinZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMinZ.IsValid());
    AssertEqual("RotationMinZ", node->RotationMinZ.GetName());

    prop = node->FindProperty("RotationMaxX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMaxX.IsValid());
    AssertEqual("RotationMaxX", node->RotationMaxX.GetName());

    prop = node->FindProperty("RotationMaxY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMaxY.IsValid());
    AssertEqual("RotationMaxY", node->RotationMaxY.GetName());

    prop = node->FindProperty("RotationMaxZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->RotationMaxZ.IsValid());
    AssertEqual("RotationMaxZ", node->RotationMaxZ.GetName());

    prop = node->FindProperty("InheritType");
    AssertTrue(prop.IsValid());
    AssertTrue(node->InheritType.IsValid());
    AssertEqual("InheritType", node->InheritType.GetName());

    prop = node->FindProperty("ScalingActive");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingActive.IsValid());
    AssertEqual("ScalingActive", node->ScalingActive.GetName());

    prop = node->FindProperty("ScalingMin");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMin.IsValid());
    AssertEqual("ScalingMin", node->ScalingMin.GetName());

    prop = node->FindProperty("ScalingMax");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMax.IsValid());
    AssertEqual("ScalingMax", node->ScalingMax.GetName());

    prop = node->FindProperty("ScalingMinX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMinX.IsValid());
    AssertEqual("ScalingMinX", node->ScalingMinX.GetName());

    prop = node->FindProperty("ScalingMinY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMinY.IsValid());
    AssertEqual("ScalingMinY", node->ScalingMinY.GetName());

    prop = node->FindProperty("ScalingMinZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMinZ.IsValid());
    AssertEqual("ScalingMinZ", node->ScalingMinZ.GetName());

    prop = node->FindProperty("ScalingMaxX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMaxX.IsValid());
    AssertEqual("ScalingMaxX", node->ScalingMaxX.GetName());

    prop = node->FindProperty("ScalingMaxY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMaxY.IsValid());
    AssertEqual("ScalingMaxY", node->ScalingMaxY.GetName());

    prop = node->FindProperty("ScalingMaxZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->ScalingMaxZ.IsValid());
    AssertEqual("ScalingMaxZ", node->ScalingMaxZ.GetName());

    prop = node->FindProperty("GeometricTranslation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->GeometricTranslation.IsValid());
    AssertEqual("GeometricTranslation", node->GeometricTranslation.GetName());

    prop = node->FindProperty("GeometricRotation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->GeometricRotation.IsValid());
    AssertEqual("GeometricRotation", node->GeometricRotation.GetName());

    prop = node->FindProperty("GeometricScaling");
    AssertTrue(prop.IsValid());
    AssertTrue(node->GeometricScaling.IsValid());
    AssertEqual("GeometricScaling", node->GeometricScaling.GetName());

    prop = node->FindProperty("MinDampRangeX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampRangeX.IsValid());
    AssertEqual("MinDampRangeX", node->MinDampRangeX.GetName());

    prop = node->FindProperty("MinDampRangeY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampRangeY.IsValid());
    AssertEqual("MinDampRangeY", node->MinDampRangeY.GetName());

    prop = node->FindProperty("MinDampRangeZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampRangeZ.IsValid());
    AssertEqual("MinDampRangeZ", node->MinDampRangeZ.GetName());

    prop = node->FindProperty("MaxDampRangeX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampRangeX.IsValid());
    AssertEqual("MaxDampRangeX", node->MaxDampRangeX.GetName());

    prop = node->FindProperty("MaxDampRangeY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampRangeY.IsValid());
    AssertEqual("MaxDampRangeY", node->MaxDampRangeY.GetName());

    prop = node->FindProperty("MaxDampRangeZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampRangeZ.IsValid());
    AssertEqual("MaxDampRangeZ", node->MaxDampRangeZ.GetName());

    prop = node->FindProperty("MinDampStrengthX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampStrengthX.IsValid());
    AssertEqual("MinDampStrengthX", node->MinDampStrengthX.GetName());

    prop = node->FindProperty("MinDampStrengthY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampStrengthY.IsValid());
    AssertEqual("MinDampStrengthY", node->MinDampStrengthY.GetName());

    prop = node->FindProperty("MinDampStrengthZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MinDampStrengthZ.IsValid());
    AssertEqual("MinDampStrengthZ", node->MinDampStrengthZ.GetName());

    prop = node->FindProperty("MaxDampStrengthX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampStrengthX.IsValid());
    AssertEqual("MaxDampStrengthX", node->MaxDampStrengthX.GetName());

    prop = node->FindProperty("MaxDampStrengthY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampStrengthY.IsValid());
    AssertEqual("MaxDampStrengthY", node->MaxDampStrengthY.GetName());

    prop = node->FindProperty("MaxDampStrengthZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->MaxDampStrengthZ.IsValid());
    AssertEqual("MaxDampStrengthZ", node->MaxDampStrengthZ.GetName());

    prop = node->FindProperty("PreferedAngleX");
    AssertTrue(prop.IsValid());
    AssertTrue(node->PreferedAngleX.IsValid());
    AssertEqual("PreferedAngleX", node->PreferedAngleX.GetName());

    prop = node->FindProperty("PreferedAngleY");
    AssertTrue(prop.IsValid());
    AssertTrue(node->PreferedAngleY.IsValid());
    AssertEqual("PreferedAngleY", node->PreferedAngleY.GetName());

    prop = node->FindProperty("PreferedAngleZ");
    AssertTrue(prop.IsValid());
    AssertTrue(node->PreferedAngleZ.IsValid());
    AssertEqual("PreferedAngleZ", node->PreferedAngleZ.GetName());

    prop = node->FindProperty("LookAtProperty");
    AssertTrue(prop.IsValid());
    AssertTrue(node->LookAtProperty.IsValid());
    AssertEqual("LookAtProperty", node->LookAtProperty.GetName());

    prop = node->FindProperty("UpVectorProperty");
    AssertTrue(prop.IsValid());
    AssertTrue(node->UpVectorProperty.IsValid());
    AssertEqual("UpVectorProperty", node->UpVectorProperty.GetName());

    prop = node->FindProperty("Show");
    AssertTrue(prop.IsValid());
    AssertTrue(node->Show.IsValid());
    AssertEqual("Show", node->Show.GetName());

    prop = node->FindProperty("NegativePercentShapeSupport");
    AssertTrue(prop.IsValid());
    AssertTrue(node->NegativePercentShapeSupport.IsValid());
    AssertEqual("NegativePercentShapeSupport", node->NegativePercentShapeSupport.GetName());

    prop = node->FindProperty("DefaultAttributeIndex");
    AssertTrue(prop.IsValid());
    AssertTrue(node->DefaultAttributeIndex.IsValid());
    AssertEqual("DefaultAttributeIndex", node->DefaultAttributeIndex.GetName());

    prop = node->FindProperty("Freeze");
    AssertTrue(prop.IsValid());
    AssertTrue(node->Freeze.IsValid());
    AssertEqual("Freeze", node->Freeze.GetName());

    prop = node->FindProperty("LODBox");
    AssertTrue(prop.IsValid());
    AssertTrue(node->LODBox.IsValid());
    AssertEqual("LODBox", node->LODBox.GetName());

    prop = node->FindProperty("Lcl Translation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->LclTranslation.IsValid());
    AssertEqual("Lcl Translation", node->LclTranslation.GetName());

    prop = node->FindProperty("Lcl Rotation");
    AssertTrue(prop.IsValid());
    AssertTrue(node->LclRotation.IsValid());
    AssertEqual("Lcl Rotation", node->LclRotation.GetName());

    prop = node->FindProperty("Lcl Scaling");
    AssertTrue(prop.IsValid());
    AssertTrue(node->LclScaling.IsValid());
    AssertEqual("Lcl Scaling", node->LclScaling.GetName());

    prop = node->FindProperty("Visibility");
    AssertTrue(prop.IsValid());
    AssertTrue(node->Visibility.IsValid());
    AssertEqual("Visibility", node->Visibility.GetName());

    prop = node->FindProperty("Visibility Inheritance");
    AssertTrue(prop.IsValid());
    AssertTrue(node->VisibilityInheritance.IsValid());
    AssertEqual("Visibility Inheritance", node->VisibilityInheritance.GetName());
}

void Node_AddMaterial_SetsMaterialScene()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxSurfacePhong* mat = FbxSurfacePhong::Create(manager, "");

    root->AddChild(node);

    // require:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(node, scene->GetSrcObject(3));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(2, scene->GetNodeCount());
    AssertEqual(scene->GetRootNode(), scene->GetNode(0));
    AssertEqual(node, scene->GetNode(1));

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(2, node->GetDstObjectCount());
    AssertEqual(root, node->GetDstObject(0));
    AssertEqual(scene, node->GetDstObject(1));
    AssertEqual(scene, node->GetScene());
    AssertEqual(0, node->GetMaterialCount());

    AssertEqual(0, mat->GetSrcObjectCount());
    AssertEqual(0, mat->GetDstObjectCount());
    AssertEqual(NULL, mat->GetScene());

    // when:
    node->AddMaterial(mat);

    // then:
    AssertEqual(5, scene->GetSrcObjectCount());
    AssertEqual(mat, scene->GetSrcObject(4));
    AssertEqual(2, scene->GetNodeCount());
    AssertEqual(scene->GetRootNode(), scene->GetNode(0));
    AssertEqual(node, scene->GetNode(1));

    AssertEqual(1, node->GetSrcObjectCount());
    AssertEqual(mat, node->GetSrcObject(0));
    AssertEqual(1, node->GetMaterialCount());
    AssertEqual(mat, node->GetMaterial(0));

    AssertEqual(0, mat->GetSrcObjectCount());
    AssertEqual(2, mat->GetDstObjectCount());
    AssertEqual(node, mat->GetDstObject(0));
    AssertEqual(scene, mat->GetDstObject(1));
    AssertEqual(scene, mat->GetScene());
}

void Node_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* obj = FbxNode::Create(manager, "asdf");

    // then:
    AssertEqual("Model::", obj->GetNameSpacePrefix());
}

void NodeTest::RegisterTestCases()
{
    AddTestCase(RootNode_AddChild_AddsConnection);
    AddTestCase(Node_SetNodeAttribute_SetsNodeAttribute);
    AddTestCase(Node_AddChild_AddsChild);
    AddTestCase(RootNode_AddChild_AddsNodeSubtree);
    AddTestCase(RootNode_AddSrcObject_AddsChild);
    AddTestCase(Node_AddSrcObject_SetsNodeAttribute);
    AddTestCase(Node_Create_HasProperties);
    AddTestCase(Node_AddMaterial_SetsMaterialScene);
    AddTestCase(Node_Create_HasNamespacePrefix);
}

