
#include "Tests.h"

using namespace std;

void FbxDataType_DefaultConstructor_AttributesSet()
{
    // when:
    FbxDataType dt = FbxDataType::Create("int", EFbxType::eFbxInt);;
    // then:
    AssertTrue(dt.Valid());
    AssertEqual("int", dt.GetName());
    AssertEqual(EFbxType::eFbxInt, dt.GetType());
}

void FbxDataTypeTest::RegisterTestCases()
{
    AddTestCase(FbxDataType_DefaultConstructor_AttributesSet);
}

