
#include <iostream>
#include <fbxsdk.h>
#include "common.h"

using namespace std;



ostream& operator<<(ostream& os, const FbxDouble2& value)
{
    os << value[0] << ", " << value[1];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble3& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble4& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2] << ", " << value[3];
    return os;
}

ostream& operator<<(ostream& os, const FbxDataType& value)
{
    os << value.GetName() << ":" << value.GetType();
    return os;
}

ostream& operator<<(ostream& os, const EFbxType& value)
{
    const char* s;
    switch (value)
    {
    case eFbxUndefined : s = "eFbxUndefined" ; break;
    case eFbxChar      : s = "eFbxChar"      ; break;
    case eFbxUChar     : s = "eFbxUChar"     ; break;
    case eFbxShort     : s = "eFbxShort"     ; break;
    case eFbxUShort    : s = "eFbxUShort"    ; break;
    case eFbxUInt      : s = "eFbxUInt"      ; break;
    case eFbxLongLong  : s = "eFbxLongLong"  ; break;
    case eFbxULongLong : s = "eFbxULongLong" ; break;
    case eFbxHalfFloat : s = "eFbxHalfFloat" ; break;
    case eFbxBool      : s = "eFbxBool"      ; break;
    case eFbxInt       : s = "eFbxInt"       ; break;
    case eFbxFloat     : s = "eFbxFloat"     ; break;
    case eFbxDouble    : s = "eFbxDouble"    ; break;
    case eFbxDouble2   : s = "eFbxDouble2"   ; break;
    case eFbxDouble3   : s = "eFbxDouble3"   ; break;
    case eFbxDouble4   : s = "eFbxDouble4"   ; break;
    case eFbxDouble4x4 : s = "eFbxDouble4x4" ; break;
    case eFbxEnum      : s = "eFbxEnum"      ; break;
    case eFbxString    : s = "eFbxString"    ; break;
    case eFbxTime      : s = "eFbxTime"      ; break;
    case eFbxReference : s = "eFbxReference" ; break;
    case eFbxBlob      : s = "eFbxBlob"      ; break;
    case eFbxDistance  : s = "eFbxDistance"  ; break;
    case eFbxDateTime  : s = "eFbxDateTime"  ; break;
    case eFbxTypeCount : s = "eFbxTypeCount" ; break;
    default: s = "<<unknown EFbxType>>"; break;
    }
    os << s;
    return os;
}

