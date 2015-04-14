
#include "Tests.h"

using namespace std;

void Node_CalcTransformFromCreatedState_ReturnsIdentity()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxNode* node = FbxNode::Create(manager, "");
    FbxAMatrix expected = FbxAMatrix();
    FbxAMatrix actual;

    // when:
    actual = node->EvaluateGlobalTransform();

    // then:
    AssertEqual(expected, actual);
}

void NodeTransformsTest::RegisterTestCases()
{
    AddTestCase(Node_CalcTransformFromCreatedState_ReturnsIdentity);
}

