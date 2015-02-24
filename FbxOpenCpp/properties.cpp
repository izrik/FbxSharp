

#include <iostream>
#include <fbxsdk.h>
#include "common.h"

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

void PrintProperty(FbxProperty* prop, const char* prefix)
{
    cout << prefix << ".Name = " << prop->GetName() << endl;
    FbxDataType type = prop->GetPropertyDataType();
    cout << prefix << ".Type = " << type.GetName() << " (" << GetTypeName(type.GetType()) << ")" << endl;
    cout << prefix << ".HierName = " << prop->GetHierarchicalName() << endl;
    cout << prefix << ".Label = " << prop->GetLabel() << endl;

    char n[1024];
    int i;
    for (i = 0; i < 1024; i++)
    {
        n[i] = 0;
    }
    char ch;
    unsigned char uch;
    unsigned int ui;
    short sh;
    unsigned short ush;
    long long ll;
    unsigned long long ull;
    bool b;
    float f;
    double d;
    FbxString fstr;
    switch (type.GetType())
    {
        case eFbxUndefined:
            break;
        case eFbxChar:
            ch = prop->Get<char>();
            sprintf(n, "%i ('%c')", (int)ch, ch);
            break;
        case eFbxUChar:
            uch = prop->Get<unsigned char>();
            sprintf(n, "%i ('%c')", (unsigned int)uch, uch);
            break;
        case eFbxShort:
            sh = prop->Get<short>();
            sprintf(n, "%i", (int)sh);
            break;
        case eFbxUShort:
            ush = prop->Get<unsigned short>();
            sprintf(n, "%ui", (unsigned int)ush);
            break;
        case eFbxUInt:
            ui = prop->Get<unsigned int>();
            sprintf(n, "%ui", ui);
            break;
        case eFbxLongLong:
            ll = prop->Get<long long>();
            sprintf(n, "%lli", ll);
            break;
        case eFbxULongLong:
            ull = prop->Get<unsigned long long>();
            sprintf(n, "%llu", ull);
            break;
        case eFbxHalfFloat:
            break;
        case eFbxBool:
            b = prop->Get<bool>();
            if (b)
                sprintf(n, "true");
            else
                sprintf(n, "true");
            break;
        case eFbxInt:
            i = prop->Get<int>();
            sprintf(n, "%i", i);
            break;
        case eFbxFloat:
            f = prop->Get<float>();
            sprintf(n, "%f", f);
            break;
        case eFbxDouble:
            d = prop->Get<double>();
            sprintf(n, "%lf", d);
            break;
        case eFbxDouble2:
        case eFbxDouble3:
        case eFbxDouble4:
        case eFbxDouble4x4:
        case eFbxEnum:
            break;
        case eFbxString:
            fstr = prop->Get<FbxString>();
            sprintf(n, "%s", fstr.Buffer());
            break;
        case eFbxTime:
        case eFbxReference:
//            FbxObject* obj;
//            obj = prop->Get<FbxObject*>();
//            cout << prefix << ".Value = " << obj->GetRuntimeClassId().GetName() << ", uid=" << obj->GetUniqueID() << endl;
//            break;
        case eFbxBlob:
        case eFbxDistance:
        case eFbxDateTime:
        case eFbxTypeCount:
            break;
    }
    if (n[0])
    {
        cout << prefix << ".Value = " << n << endl;
    }
}