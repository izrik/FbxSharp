
#include "properties.h"

#include <iostream>
#include <fbxsdk.h>
#include <stdio.h>

using namespace std;


const char* GetTypeName(EFbxType tid)
{
    switch (tid)
    {
        case eFbxUndefined: return "eFbxUndefined";
        case eFbxChar:      return "eFbxChar";
        case eFbxUChar:     return "eFbxUChar";
        case eFbxShort:     return "eFbxShort";
        case eFbxUShort:    return "eFbxUShort";
        case eFbxUInt:      return "eFbxUInt";
        case eFbxLongLong:  return "eFbxLongLong";
        case eFbxULongLong: return "eFbxULongLong";
        case eFbxHalfFloat: return "eFbxHalfFloat";
        case eFbxBool:      return "eFbxBool";
        case eFbxInt:       return "eFbxInt";
        case eFbxFloat:     return "eFbxFloat";
        case eFbxDouble:    return "eFbxDouble";
        case eFbxDouble2:   return "eFbxDouble2";
        case eFbxDouble3:   return "eFbxDouble3";
        case eFbxDouble4:   return "eFbxDouble4";
        case eFbxDouble4x4: return "eFbxDouble4x4";
        case eFbxEnum:      return "eFbxEnum";
        case eFbxString:    return "eFbxString";
        case eFbxTime:      return "eFbxTime";
        case eFbxReference: return "eFbxReference";
        case eFbxBlob:      return "eFbxBlob";
        case eFbxDistance:  return "eFbxDistance";
        case eFbxDateTime:  return "eFbxDateTime";
        case eFbxTypeCount: return "eFbxTypeCount";
    }

    return "<<unknown>>";
}
