
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

void NodeTransformsTest::RegisterTestCases()
{
    AddTestCase(Node_CalcGlobalTransformFromCreatedState_ReturnsIdentity);
    AddTestCase(Node_CalcGlobalTransformWithTranslation_ReturnsTranslation);
    AddTestCase(Node_CalcGlobalTransformWithRotation_ReturnsRotation);
    AddTestCase(Node_CalcGlobalTransformWithScale_ReturnsScale);
}

