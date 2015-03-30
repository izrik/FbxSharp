
#include "Tests.h"

using namespace std;

void GeometryBase_InitControlPoints_InitsControlPoints()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometryBase* gb = FbxGeometryBase::Create(manager, "");

    // require:
    AssertEqual(0, gb->GetControlPointsCount());

    // when:
    gb->InitControlPoints(4);

    // then:
    AssertEqual(4, gb->GetControlPointsCount());

    // when:
    gb->InitControlPoints(20);

    // then:
    AssertEqual(20, gb->GetControlPointsCount());

    // when:
    gb->InitControlPoints(3);

    // then:
    AssertEqual(3, gb->GetControlPointsCount());
}

void GeometryBase_SetControlPointAt_SetsControlPoint()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxGeometryBase* gb = FbxGeometryBase::Create(manager, "");
    gb->InitControlPoints(4);

    // require:
    AssertEqual(4, gb->GetControlPointsCount());
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(0));
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(1));
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(2));
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(3));

    // when:
    gb->SetControlPointAt(FbxVector4(1.2, 3.4, 5.6, 7.8), 2);

    // then:
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(0));
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(1));
    AssertEqual(FbxVector4(1.2, 3.4, 5.6, 7.8), gb->GetControlPointAt(2));
    AssertEqual(FbxVector4(0, 0, 0, 0), gb->GetControlPointAt(3));
}

void GeometryBaseTest::RegisterTestCases()
{
    AddTestCase(GeometryBase_InitControlPoints_InitsControlPoints);
    AddTestCase(GeometryBase_SetControlPointAt_SetsControlPoint);
}

