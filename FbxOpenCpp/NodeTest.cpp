
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

void NodeTest::RegisterTestCases()
{
    AddTestCase(RootNode_AddChild_AddsConnection);
    AddTestCase(Node_SetNodeAttribute_SetsNodeAttribute);
    AddTestCase(Node_AddChild_AddsChild);
    AddTestCase(RootNode_AddChild_AddsNodeSubtree);
    AddTestCase(RootNode_AddSrcObject_AddsChild);
    AddTestCase(Node_AddSrcObject_SetsNodeAttribute);
}

