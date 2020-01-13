
#include "Tests.h"

using namespace std;

void Scene_AddNode_AddsNode()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* node = FbxNode::Create(manager, "ChildNode");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(scene->GetRootNode(), scene->GetNode(0));

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(NULL, node->GetScene());

    // when:
    scene->AddNode(node);

    // then:
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
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(scene, node->GetDstObject(0));
    AssertEqual(scene, node->GetScene());
}

void RootNode_AddChildNode_AddsNodeToScene()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node = FbxNode::Create(manager, "ChildNode");

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
    AssertEqual(scene, root->GetScene());

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(NULL, node->GetScene());

    // when:
    root->AddChild(node);

    // then:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(node, scene->GetSrcObject(3));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(2, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));
    AssertEqual(node, scene->GetNode(1));

    AssertEqual(1, root->GetSrcObjectCount());
    AssertEqual(node, root->GetSrcObject(0));
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));
    AssertEqual(scene, root->GetScene());

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(2, node->GetDstObjectCount());
    AssertEqual(root, node->GetDstObject(0));
    AssertEqual(scene, node->GetDstObject(1));
    AssertEqual(scene, node->GetScene());
}

void Scene_Create_HasRootNode()
{
    // given:
    FbxManager* manager = FbxManager::Create();

    // when:
    FbxScene* scene = FbxScene::Create(manager, "Scene1");
    FbxNode* root = scene->GetRootNode();

    // then:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));

    AssertNotEqual(NULL, root);
    AssertEqual(0, root->GetSrcObjectCount());
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));
    AssertEqual(scene, root->GetScene());
    AssertEqual(0, root->GetChildCount());
}

void Scene_Create_HasZeroPoses()
{
    // given:
    FbxManager* manager = FbxManager::Create();

    // when:
    FbxScene* scene = FbxScene::Create(manager, "Scene1");

    // then:
    AssertEqual(0, scene->GetPoseCount());
}

void Scene_AddPose_AddsPose()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "Scene");
    FbxPose* pose = FbxPose::Create(manager, "Pose");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(0, scene->GetPoseCount());

    AssertEqual(0, pose->GetSrcObjectCount());
    AssertEqual(0, pose->GetDstObjectCount());
    AssertEqual(NULL, pose->GetScene());

    // when:
    scene->AddPose(pose);

    // then:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(pose, scene->GetSrcObject(3));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetPoseCount());
    AssertEqual(pose, scene->GetPose(0));

    AssertEqual(0, pose->GetSrcObjectCount());
    AssertEqual(1, pose->GetDstObjectCount());
    AssertEqual(scene, pose->GetDstObject(0));
    AssertEqual(scene, pose->GetScene());
}

void Scene_ConnectSrcObject_AddsPose()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "Scene");
    FbxPose* pose = FbxPose::Create(manager, "Pose");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(0, scene->GetPoseCount());

    AssertEqual(0, pose->GetSrcObjectCount());
    AssertEqual(0, pose->GetDstObjectCount());
    AssertEqual(NULL, pose->GetScene());

    // when:
    scene->ConnectSrcObject(pose);

    // then:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(pose, scene->GetSrcObject(3));
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(1, scene->GetPoseCount());
    AssertEqual(pose, scene->GetPose(0));

    AssertEqual(0, pose->GetSrcObjectCount());
    AssertEqual(1, pose->GetDstObjectCount());
    AssertEqual(scene, pose->GetDstObject(0));
    AssertEqual(scene, pose->GetScene());
}

void Scene_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "");
    FbxProperty prop;

    // then:
    AssertEqual(2, CountProperties(scene));
    AssertEqual(0, scene->GetSrcPropertyCount());
    AssertEqual(0, scene->GetDstPropertyCount());

    prop = scene->FindProperty("SourceObject");
    AssertTrue(prop.IsValid());
    AssertTrue(scene->Roots.IsValid());
    AssertEqual("SourceObject", scene->Roots.GetName());

    prop = scene->FindProperty("ActiveAnimStackName");
    AssertTrue(prop.IsValid());
    AssertTrue(scene->ActiveAnimStackName.IsValid());
    AssertEqual("ActiveAnimStackName", scene->ActiveAnimStackName.GetName());
}

void Document_Create_HasProperties()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxDocument* doc = FbxDocument::Create(manager, "");
    FbxProperty prop;

    // then:
    AssertEqual(2, CountProperties(doc));
    AssertEqual(0, doc->GetSrcPropertyCount());
    AssertEqual(0, doc->GetDstPropertyCount());

    prop = doc->FindProperty("SourceObject");
    AssertTrue(prop.IsValid());
    AssertTrue(doc->Roots.IsValid());
    AssertEqual("SourceObject", doc->Roots.GetName());

    prop = doc->FindProperty("ActiveAnimStackName");
    AssertTrue(prop.IsValid());
    AssertTrue(doc->ActiveAnimStackName.IsValid());
    AssertEqual("ActiveAnimStackName", doc->ActiveAnimStackName.GetName());
}

void Scene_AddObjectWithSrcObjects_AddsAllSrcObjects()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "s");
    FbxNode* node = FbxNode::Create(manager, "n");
    FbxMesh* m1 = FbxMesh::Create(manager, "m1");
    FbxMesh* m2 = FbxMesh::Create(manager, "m2");
    FbxVideo* v = FbxVideo::Create(manager, "v");
    FbxCluster* c = FbxCluster::Create(manager, "c");
    FbxNode* n2 = FbxNode::Create(manager, "n2");
    FbxCluster* c2 = FbxCluster::Create(manager, "c2");

    node->ConnectSrcObject(m1);
    node->ConnectSrcObject(m2);
    node->ConnectSrcObject(v);
    node->ConnectSrcObject(c);
    c->ConnectSrcObject(n2);;
    n2->ConnectSrcObject(c2);

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());

    AssertEqual(4, node->GetSrcObjectCount());
    AssertEqual(m1, node->GetSrcObject(0));
    AssertEqual(m2, node->GetSrcObject(1));
    AssertEqual(v, node->GetSrcObject(2));
    AssertEqual(c, node->GetSrcObject(3));
    AssertEqual(0, node->GetDstObjectCount());
    AssertNull(node->GetScene());

    AssertEqual(0, m1->GetSrcObjectCount());
    AssertEqual(1, m1->GetDstObjectCount());
    AssertEqual(node, m1->GetDstObject(0));
    AssertNull(m1->GetScene());

    AssertEqual(0, m2->GetSrcObjectCount());
    AssertEqual(1, m2->GetDstObjectCount());
    AssertEqual(node, m2->GetDstObject(0));
    AssertNull(m2->GetScene());

    AssertEqual(0, v->GetSrcObjectCount());
    AssertEqual(1, v->GetDstObjectCount());
    AssertEqual(node, v->GetDstObject(0));
    AssertNull(v->GetScene());

    AssertEqual(1, c->GetSrcObjectCount());
    AssertEqual(n2, c->GetSrcObject());;
    AssertEqual(1, c->GetDstObjectCount());
    AssertEqual(node, c->GetDstObject(0));
    AssertNull(c->GetScene());

    AssertEqual(1, n2->GetSrcObjectCount());
    AssertEqual(c2, n2->GetSrcObject());;
    AssertEqual(1, n2->GetDstObjectCount());
    AssertEqual(c, n2->GetDstObject(0));
    AssertNull(n2->GetScene());

    AssertEqual(0, c2->GetSrcObjectCount());
    AssertEqual(1, c2->GetDstObjectCount());
    AssertEqual(n2, c2->GetDstObject(0));
    AssertNull(c2->GetScene());

    // when:
    scene->ConnectSrcObject(node);

    // then:
    AssertEqual(10, scene->GetSrcObjectCount());
    AssertEqual(node, scene->GetSrcObject(3));
    AssertEqual(m1, scene->GetSrcObject(4));
    AssertEqual(m2, scene->GetSrcObject(5));
    AssertEqual(v, scene->GetSrcObject(6));
    AssertEqual(c, scene->GetSrcObject(7));
    AssertEqual(n2, scene->GetSrcObject(8));
    AssertEqual(c2, scene->GetSrcObject(9));

    AssertEqual(4, node->GetSrcObjectCount());
    AssertEqual(m1, node->GetSrcObject(0));
    AssertEqual(m2, node->GetSrcObject(1));
    AssertEqual(v, node->GetSrcObject(2));
    AssertEqual(c, node->GetSrcObject(3));
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(scene, node->GetDstObject(0));
    AssertEqual(scene, node->GetScene());

    AssertEqual(0, m1->GetSrcObjectCount());
    AssertEqual(2, m1->GetDstObjectCount());
    AssertEqual(node, m1->GetDstObject(0));
    AssertEqual(scene, m1->GetDstObject(1));
    AssertEqual(scene, m1->GetScene());

    AssertEqual(0, m2->GetSrcObjectCount());
    AssertEqual(2, m2->GetDstObjectCount());
    AssertEqual(node, m2->GetDstObject(0));
    AssertEqual(scene, m2->GetDstObject(1));
    AssertEqual(scene, m2->GetScene());

    AssertEqual(0, v->GetSrcObjectCount());
    AssertEqual(2, v->GetDstObjectCount());
    AssertEqual(node, v->GetDstObject(0));
    AssertEqual(scene, v->GetDstObject(1));
    AssertEqual(scene, v->GetScene());

    AssertEqual(1, c->GetSrcObjectCount());
    AssertEqual(n2, c->GetSrcObject(0));
    AssertEqual(2, c->GetDstObjectCount());
    AssertEqual(node, c->GetDstObject(0));
    AssertEqual(scene, c->GetDstObject(1));
    AssertEqual(scene, c->GetScene());

    AssertEqual(1, n2->GetSrcObjectCount());
    AssertEqual(c2, n2->GetSrcObject());;
    AssertEqual(2, n2->GetDstObjectCount());
    AssertEqual(c, n2->GetDstObject(0));
    AssertEqual(scene, n2->GetDstObject(1));
    AssertEqual(scene, n2->GetScene());

    AssertEqual(0, c2->GetSrcObjectCount());
    AssertEqual(2, c2->GetDstObjectCount());
    AssertEqual(n2, c2->GetDstObject(0));
    AssertEqual(scene, c2->GetDstObject(1));
    AssertEqual(scene, c2->GetScene());
}

void Scene_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* obj = FbxScene::Create(manager, "asdf");

    // then:
    AssertEqual("Scene::", obj->GetNameSpacePrefix());
}

void SceneTest::RegisterTestCases()
{
    AddTestCase(Scene_AddNode_AddsNode);
    AddTestCase(RootNode_AddChildNode_AddsNodeToScene);
    AddTestCase(Scene_Create_HasRootNode);
    AddTestCase(Scene_Create_HasZeroPoses);
    AddTestCase(Scene_AddPose_AddsPose);
    AddTestCase(Scene_ConnectSrcObject_AddsPose);
    AddTestCase(Scene_Create_HasProperties);
    AddTestCase(Document_Create_HasProperties);
    AddTestCase(Scene_AddObjectWithSrcObjects_AddsAllSrcObjects);
    AddTestCase(Scene_Create_HasNamespacePrefix);
}

