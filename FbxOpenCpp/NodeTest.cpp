
#include "common.h"

using namespace std;

void RootNode_AddChild_AddsConnection()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxScene* scene = FbxScene::Create(manager, "TheScene");
    FbxNode* root = scene->GetRootNode();
    FbxNode* node2 = FbxNode::Create(manager, "ChildNode");

    // require:
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
    FbxNull* nulla = FbxNull::Create(manager, "Nulla");

    // require:
    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(0, node->GetNodeAttributeCount());
    AssertEqual(NULL, node->GetNodeAttribute());
    AssertEqual(0, nulla->GetSrcObjectCount());
    AssertEqual(0, nulla->GetDstObjectCount());
    AssertEqual(0, nulla->GetSrcPropertyCount());
    AssertEqual(0, nulla->GetDstPropertyCount());

    // when:
    node->SetNodeAttribute(nulla);

    // then:
    AssertEqual(1, node->GetSrcObjectCount());
    AssertEqual(nulla, node->GetSrcObject(0));
    AssertEqual(0, node->GetDstObjectCount());
    AssertEqual(0, node->GetSrcPropertyCount());
    AssertEqual(0, node->GetDstPropertyCount());
    AssertEqual(1, node->GetNodeAttributeCount());
    AssertEqual(nulla, node->GetNodeAttribute());
    AssertEqual(0, nulla->GetSrcObjectCount());
    AssertEqual(1, nulla->GetDstObjectCount());
    AssertEqual(node, nulla->GetDstObject(0));
    AssertEqual(0, nulla->GetSrcPropertyCount());
    AssertEqual(0, nulla->GetDstPropertyCount());
}

void NodeTest::RegisterTestCases()
{
    AddTestCase(RootNode_AddChild_AddsConnection);
    AddTestCase(Node_SetNodeAttribute_SetsNodeAttribute);
}

