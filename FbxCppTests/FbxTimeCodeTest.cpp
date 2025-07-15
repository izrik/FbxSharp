
#include "Tests.h"

using namespace std;

void FbxTimeCode_Constants()
{
    // expect:
    AssertEqual(141120L, FBXSDK_TC_MILLISECOND);
    AssertEqual(141120000L, FBXSDK_TC_SECOND);
    AssertEqual(46186158L, FBXSDK_TC_LEGACY_MILLISECOND);
    AssertEqual(46186158000L, FBXSDK_TC_LEGACY_SECOND);
}

void FbxTimeCodeTest::RegisterTestCases()
{
    AddTestCase(FbxTimeCode_Constants);
}

