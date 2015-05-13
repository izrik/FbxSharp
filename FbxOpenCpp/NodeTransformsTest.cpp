
#include "Tests.h"

using namespace std;

void Node_CalcGlobalTransformFromCreatedState_ReturnsIdentity()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix expected = FbxMatrix(t, r, s);

    // when:
    FbxAMatrix actual = node->EvaluateGlobalTransform();

    // then:
    AssertEqual(expected, actual);
}

void Node_CalcGlobalTransformWithTranslation_ReturnsTranslation()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxVector4 t = FbxVector4(2, 3, 4);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix expected = FbxMatrix(t, r, s);
    node->LclTranslation.Set(t);

    // when:
    FbxAMatrix actual = node->EvaluateGlobalTransform();

    // then:
    AssertEqual(expected, actual);
}

void Node_CalcGlobalTransformWithRotation_ReturnsRotation()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(22, 33, 44);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix expected = FbxMatrix(t, r, s);
    node->LclRotation.Set(r);

    // when:
    FbxAMatrix actual = node->EvaluateGlobalTransform();

    // then:
    AssertEqual(expected, actual);
}

void Node_CalcGlobalTransformWithScale_ReturnsScale()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(5, 6, 7);
    FbxMatrix expected = FbxMatrix(t, r, s);
    node->LclScaling.Set(s);

    // when:
    FbxAMatrix actual = node->EvaluateGlobalTransform();

    // then:
    AssertEqual(expected, actual);
}

void NodesInHierarchy_CalcGlobalTransformWithTranslationAndWithRotation_ReturnsRotatedThenTranslated()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node1 = FbxNode::Create(manager, "node1");
    FbxNode* node2 = FbxNode::Create(manager, "node2");
    node1->AddChild(node2);
    FbxVector4 t = FbxVector4(2, 3, 4);
    FbxVector4 r = FbxVector4(45, 0, 0);
    node1->LclTranslation.Set(t);
    node2->LclRotation.Set(r);

    // when:
    FbxAMatrix actual = node1->EvaluateGlobalTransform();

    // then:
    AssertEqual(1.000000f, actual.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 0), 0.000001f);
    AssertEqual(1.000000f, actual.Get(1, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 1), 0.000001f);
    AssertEqual(1.000000f, actual.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 3), 0.000001f);
    AssertEqual(2.000000f, actual.Get(3, 0), 0.000001f);
    AssertEqual(3.000000f, actual.Get(3, 1), 0.000001f);
    AssertEqual(4.000000f, actual.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, actual.Get(3, 3), 0.000001f);

    // when:
    actual = node2->EvaluateGlobalTransform();

    // then:
    AssertEqual(1.000000f, actual.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 0), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 0), 0.000001f);
    AssertEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 3), 0.000001f);
    AssertEqual(2.000000f, actual.Get(3, 0), 0.000001f);
    AssertEqual(3.000000f, actual.Get(3, 1), 0.000001f);
    AssertEqual(4.000000f, actual.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, actual.Get(3, 3), 0.000001f);
}

void NodesInHierarchy_CalcGlobalTransformWithRotationAndWithTranslation_ReturnsTranslatedThenRotated()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node1 = FbxNode::Create(manager, "node1");
    FbxNode* node2 = FbxNode::Create(manager, "node2");
    node1->AddChild(node2);
    FbxVector4 t = FbxVector4(2, 3, 4);
    FbxVector4 r = FbxVector4(45, 0, 0);
    node1->LclRotation.Set(r);
    node2->LclTranslation.Set(t);

    // when:
    FbxAMatrix actual = node1->EvaluateGlobalTransform();

    // then:
    AssertEqual(1.000000f, actual.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 0), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 0), 0.000001f);
    AssertEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(3, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(3, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, actual.Get(3, 3), 0.000001f);

    // when:
    actual = node2->EvaluateGlobalTransform();

    // then:
    AssertEqual(1.000000f, actual.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 0), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 0), 0.000001f);
    AssertEqual(-0.707107f,actual.Get(2, 1), 0.000001f);
    AssertEqual(0.707107f, actual.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, actual.Get(2, 3), 0.000001f);
    AssertEqual(2.000000f, actual.Get(3, 0), 0.000001f);
    AssertEqual(-0.707107f,actual.Get(3, 1), 0.000001f);
    AssertEqual(4.949748f, actual.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, actual.Get(3, 3), 0.000001f);
}

void NodesInHierarchy_CalcGlobalTransform_ChildsIsTimesParent()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node1 = FbxNode::Create(manager, "node1");
    FbxNode* node2 = FbxNode::Create(manager, "node2");
    node1->AddChild(node2);
    FbxVector4 r1 = FbxVector4(45, 0, 0);
    FbxVector4 r2 = FbxVector4(0, 60, 0);
    node1->LclRotation.Set(r1);
    node2->LclRotation.Set(r2);

    // when:
    FbxAMatrix g1 = node1->EvaluateGlobalTransform();
    FbxAMatrix g2 = node2->EvaluateGlobalTransform();
    FbxAMatrix l1 = node1->EvaluateLocalTransform();
    FbxAMatrix l2 = node2->EvaluateLocalTransform();

    AssertEqual(l1.Get(0, 0), g1.Get(0, 0), 0.000001f);
    AssertEqual(l1.Get(0, 1), g1.Get(0, 1), 0.000001f);
    AssertEqual(l1.Get(0, 2), g1.Get(0, 2), 0.000001f);
    AssertEqual(l1.Get(0, 3), g1.Get(0, 3), 0.000001f);
    AssertEqual(l1.Get(1, 0), g1.Get(1, 0), 0.000001f);
    AssertEqual(l1.Get(1, 1), g1.Get(1, 1), 0.000001f);
    AssertEqual(l1.Get(1, 2), g1.Get(1, 2), 0.000001f);
    AssertEqual(l1.Get(1, 3), g1.Get(1, 3), 0.000001f);
    AssertEqual(l1.Get(2, 0), g1.Get(2, 0), 0.000001f);
    AssertEqual(l1.Get(2, 1), g1.Get(2, 1), 0.000001f);
    AssertEqual(l1.Get(2, 2), g1.Get(2, 2), 0.000001f);
    AssertEqual(l1.Get(2, 3), g1.Get(2, 3), 0.000001f);
    AssertEqual(l1.Get(3, 0), g1.Get(3, 0), 0.000001f);
    AssertEqual(l1.Get(3, 1), g1.Get(3, 1), 0.000001f);
    AssertEqual(l1.Get(3, 2), g1.Get(3, 2), 0.000001f);
    AssertEqual(l1.Get(3, 3), g1.Get(3, 3), 0.000001f);

    FbxAMatrix m = l1 * l2;
    AssertEqual(m.Get(0, 0), g2.Get(0, 0), 0.000001f);
    AssertEqual(m.Get(0, 1), g2.Get(0, 1), 0.000001f);
    AssertEqual(m.Get(0, 2), g2.Get(0, 2), 0.000001f);
    AssertEqual(m.Get(0, 3), g2.Get(0, 3), 0.000001f);
    AssertEqual(m.Get(1, 0), g2.Get(1, 0), 0.000001f);
    AssertEqual(m.Get(1, 1), g2.Get(1, 1), 0.000001f);
    AssertEqual(m.Get(1, 2), g2.Get(1, 2), 0.000001f);
    AssertEqual(m.Get(1, 3), g2.Get(1, 3), 0.000001f);
    AssertEqual(m.Get(2, 0), g2.Get(2, 0), 0.000001f);
    AssertEqual(m.Get(2, 1), g2.Get(2, 1), 0.000001f);
    AssertEqual(m.Get(2, 2), g2.Get(2, 2), 0.000001f);
    AssertEqual(m.Get(2, 3), g2.Get(2, 3), 0.000001f);
    AssertEqual(m.Get(3, 0), g2.Get(3, 0), 0.000001f);
    AssertEqual(m.Get(3, 1), g2.Get(3, 1), 0.000001f);
    AssertEqual(m.Get(3, 2), g2.Get(3, 2), 0.000001f);
    AssertEqual(m.Get(3, 3), g2.Get(3, 3), 0.000001f);
}

void NodeTransformsTest::RegisterTestCases()
{
    AddTestCase(Node_CalcGlobalTransformFromCreatedState_ReturnsIdentity);
    AddTestCase(Node_CalcGlobalTransformWithTranslation_ReturnsTranslation);
    AddTestCase(Node_CalcGlobalTransformWithRotation_ReturnsRotation);
    AddTestCase(Node_CalcGlobalTransformWithScale_ReturnsScale);
    AddTestCase(NodesInHierarchy_CalcGlobalTransformWithTranslationAndWithRotation_ReturnsRotatedThenTranslated);
    AddTestCase(NodesInHierarchy_CalcGlobalTransformWithRotationAndWithTranslation_ReturnsTranslatedThenRotated);
    AddTestCase(NodesInHierarchy_CalcGlobalTransform_ChildsIsTimesParent);
}

