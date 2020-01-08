
#include "Tests.h"

using namespace std;

void AnimCurveNodeTest_Create_NoChannels()
{
    // given:
    FbxManager* manager = FbxManager::Create();

    // when:
    FbxAnimCurveNode* acn = FbxAnimCurveNode::Create(manager, "");

    // then:
    AssertEqual(0, acn->GetChannelsCount());
    AssertEqual(1, CountProperties(acn));
}

void AnimCurveNodeTest_AddChannel_TwoPropertiesOneChannel()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurveNode* acn = FbxAnimCurveNode::Create(manager, "");

    // require:
    AssertEqual(0, acn->GetChannelsCount());
    AssertEqual(1, CountProperties(acn));

    // when:
    acn->AddChannel<float>("channel1", 0.0f);

    // then:
    AssertEqual(2, CountProperties(acn));
    AssertEqual(1, acn->GetChannelsCount());
    AssertEqual(0, acn->GetCurveCount(0));

    FbxProperty prop = acn->GetFirstProperty();
    AssertTrue(prop.IsValid());
    prop = acn->GetNextProperty(prop);
    AssertTrue(prop.IsValid());
    AssertEqual("channel1", prop.GetName());
}

void AnimCurveNodeTest_ConnectToChannel_AddsSrcConnection()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurveNode* acn = FbxAnimCurveNode::Create(manager, "acn");
    FbxAnimCurve* ac = FbxAnimCurve::Create(manager, "ac");
    acn->AddChannel<float>("channel1", 0.0f);

    // require:
    AssertEqual(2, CountProperties(acn));
    AssertEqual(1, acn->GetChannelsCount());
    AssertEqual(0, acn->GetCurveCount(0));

    // when:
    acn->ConnectToChannel(ac, 0U);

    // then:
    AssertEqual(2, CountProperties(acn));
    AssertEqual(1, acn->GetChannelsCount());
    AssertEqual(1, acn->GetCurveCount(0));
    AssertEqual(1, ac->GetDstPropertyCount());
    AssertEqual("channel1", ac->GetDstProperty(0).GetName());
    FbxProperty prop = acn->GetFirstProperty();
    AssertTrue(prop.IsValid());
    prop = acn->GetNextProperty(prop);
    AssertTrue(prop.IsValid());
    AssertEqual(1, prop.GetSrcObjectCount());
    AssertEqual(ac, prop.GetSrcObject(0));
}

void FbxAnimCurveNode_Create_HasNamespacePrefix()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxAnimCurveNode* obj = FbxAnimCurveNode::Create(manager, "asdf");

    // then:
    AssertEqual("AnimCurveNode::", obj->GetNameSpacePrefix());
}

void AnimCurveNodeTest::RegisterTestCases()
{
    AddTestCase(AnimCurveNodeTest_Create_NoChannels);
    AddTestCase(AnimCurveNodeTest_AddChannel_TwoPropertiesOneChannel);
    AddTestCase(AnimCurveNodeTest_ConnectToChannel_AddsSrcConnection);
    AddTestCase(FbxAnimCurveNode_Create_HasNamespacePrefix);
}

