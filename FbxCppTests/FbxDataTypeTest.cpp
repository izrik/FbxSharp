
#include "Tests.h"

using namespace std;

void FbxDataType_DefaultConstructor_AttributesSet()
{
    // when:
    FbxDataType dt = FbxDataType::Create("int", EFbxType::eFbxInt);
    // then:
    AssertTrue(dt.Valid());
    AssertEqual("int", dt.GetName());
    AssertEqual(EFbxType::eFbxInt, dt.GetType());
}

void FbxDataType_OperatorEquals_MatchesSelfButNotIdenticalObjects()
{
    // when:
    FbxDataType dt1 = FbxDataType::Create("int", EFbxType::eFbxInt);
    FbxDataType dt2 = FbxDataType::Create("int", EFbxType::eFbxInt);

    // then:
    AssertTrue(dt1.Valid());
    AssertTrue(dt2.Valid());
    AssertEqual(dt1.GetName(), dt2.GetName());
    AssertEqual(dt1.GetType(), dt2.GetType());
    AssertEqual(dt1, dt1);
    AssertEqual(dt1, dt1);
    AssertTrue(dt1 == dt1);
    AssertTrue(dt2 == dt2);
    AssertFalse(dt1 != dt1);
    AssertFalse(dt2 != dt2);
    AssertNotEqual(FbxIntDT, dt1);
    AssertNotEqual(FbxIntDT, dt2);
    AssertFalse(FbxIntDT == dt1);
    AssertFalse(FbxIntDT == dt2);
    AssertTrue(FbxIntDT != dt1);
    AssertTrue(FbxIntDT != dt2);
    AssertNotEqual(dt1, dt2);
    AssertFalse(dt1 == dt2);
    AssertTrue(dt1 != dt2);
}

void FbxDataType_FbxGetDataTypeFromEnum_YieldsCorrectDataType()
{
    // expect:
    AssertEqual(FbxUndefinedDT, FbxGetDataTypeFromEnum(EFbxType::eFbxUndefined));
    AssertEqual(FbxCharDT, FbxGetDataTypeFromEnum(EFbxType::eFbxChar));
    AssertEqual(FbxUCharDT, FbxGetDataTypeFromEnum(EFbxType::eFbxUChar));
    AssertEqual(FbxShortDT, FbxGetDataTypeFromEnum(EFbxType::eFbxShort));
    AssertEqual(FbxUShortDT, FbxGetDataTypeFromEnum(EFbxType::eFbxUShort));
    AssertEqual(FbxUIntDT, FbxGetDataTypeFromEnum(EFbxType::eFbxUInt));
    AssertEqual(FbxLongLongDT, FbxGetDataTypeFromEnum(EFbxType::eFbxLongLong));
    AssertEqual(FbxULongLongDT, FbxGetDataTypeFromEnum(EFbxType::eFbxULongLong));
    AssertEqual(FbxHalfFloatDT, FbxGetDataTypeFromEnum(EFbxType::eFbxHalfFloat));
    AssertEqual(FbxBoolDT, FbxGetDataTypeFromEnum(EFbxType::eFbxBool));
    AssertEqual(FbxIntDT, FbxGetDataTypeFromEnum(EFbxType::eFbxInt));
    AssertEqual(FbxFloatDT, FbxGetDataTypeFromEnum(EFbxType::eFbxFloat));
    AssertEqual(FbxDoubleDT, FbxGetDataTypeFromEnum(EFbxType::eFbxDouble));
    AssertEqual(FbxDouble2DT, FbxGetDataTypeFromEnum(EFbxType::eFbxDouble2));
    AssertEqual(FbxDouble3DT, FbxGetDataTypeFromEnum(EFbxType::eFbxDouble3));
    AssertEqual(FbxDouble4DT, FbxGetDataTypeFromEnum(EFbxType::eFbxDouble4));
    AssertEqual(FbxDouble4x4DT, FbxGetDataTypeFromEnum(EFbxType::eFbxDouble4x4));
    AssertEqual(FbxEnumDT, FbxGetDataTypeFromEnum(EFbxType::eFbxEnum));
    AssertEqual(FbxEnumDT, FbxGetDataTypeFromEnum(EFbxType::eFbxEnumM));
    AssertEqual(FbxStringDT, FbxGetDataTypeFromEnum(EFbxType::eFbxString));
    AssertEqual(FbxTimeDT, FbxGetDataTypeFromEnum(EFbxType::eFbxTime));
    AssertEqual(FbxReferenceDT, FbxGetDataTypeFromEnum(EFbxType::eFbxReference));
    AssertEqual(FbxBlobDT, FbxGetDataTypeFromEnum(EFbxType::eFbxBlob));
    AssertEqual(FbxDistanceDT, FbxGetDataTypeFromEnum(EFbxType::eFbxDistance));
    AssertEqual(FbxDateTimeDT, FbxGetDataTypeFromEnum(EFbxType::eFbxDateTime));
}

void FbxDataTypeTest::RegisterTestCases()
{
    AddTestCase(FbxDataType_DefaultConstructor_AttributesSet);
    AddTestCase(FbxDataType_OperatorEquals_MatchesSelfButNotIdenticalObjects);
    AddTestCase(FbxDataType_FbxGetDataTypeFromEnum_YieldsCorrectDataType);
}

