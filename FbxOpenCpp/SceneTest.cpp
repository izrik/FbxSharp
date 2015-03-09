
#include "common.h"

using namespace std;

void Scene_AddNode_AddsNode()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* node = FbxNode::Create(manager, "ChildNode");

    // require:
    AssertEqual(3, scene->GetSrcObjectCount());
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(scene->GetRootNode(), scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(scene->GetRootNode(), scene->GetNode(0));

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(NULL, node->GetScene());

    // when:
    scene->AddNode(node);

    // then:
    AssertEqual(4, scene->GetSrcObjectCount());
    AssertEqual(0, scene->GetDstObjectCount());
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
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
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
    AssertEqual(0, scene->GetDstObjectCount());
    AssertEqual(root, scene->GetSrcObject(0));
    AssertEqual(&scene->GetGlobalSettings(), scene->GetSrcObject(1));
    AssertEqual(scene->GetAnimationEvaluator(), scene->GetSrcObject(2));
    AssertEqual(1, scene->GetNodeCount());
    AssertEqual(root, scene->GetNode(0));

    AssertNotEqual(NULL, root);
    AssertEqual(0, root->GetSrcObjectCount());
    AssertEqual(1, root->GetDstObjectCount());
    AssertEqual(scene, root->GetDstObject(0));
    AssertEqual(scene, root->GetScene());
    AssertEqual(0, root->GetChildCount());

}

void SceneTest::RegisterTestCases()
{
    AddTestCase(Scene_AddNode_AddsNode);
    AddTestCase(RootNode_AddChildNode_AddsNodeToScene);
    AddTestCase(Scene_Create_HasRootNode);
}

