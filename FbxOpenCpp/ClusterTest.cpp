
#include "Tests.h"

using namespace std;

void Cluster_SetLink_SetsLink()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxCluster* cluster = FbxCluster::Create(manager, "");
    FbxNode* node = FbxNode::Create(manager, "");

    // require:
    AssertEqual(0, cluster->GetSrcObjectCount());
    AssertEqual(0, cluster->GetDstObjectCount());
    AssertNull(cluster->GetLink());

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(0, node->GetDstObjectCount());

    // when:
    cluster->SetLink(node);

    // then:
    AssertEqual(1, cluster->GetSrcObjectCount());
    AssertEqual(node, cluster->GetSrcObject(0));
    AssertEqual(0, cluster->GetDstObjectCount());
    AssertEqual(node, cluster->GetLink());

    AssertEqual(0, node->GetSrcObjectCount());
    AssertEqual(1, node->GetDstObjectCount());
    AssertEqual(cluster, node->GetDstObject(0));
}

void ClusterTest::RegisterTestCases()
{
    AddTestCase(Cluster_SetLink_SetsLink);
}

