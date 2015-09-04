

#include <iostream>
#include <fbxsdk.h>
#include "common.h"
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

void PrintProperty(FbxProperty* prop, bool indent)
{
    const char * prefix = indent ? "            " : "        ";

    cout << prefix << "Name = " << prop->GetName() << endl;
    FbxDataType type = prop->GetPropertyDataType();
    cout << prefix << "Type = " << type.GetName() << " (" << GetTypeName(type.GetType()) << ")" << endl;
    cout << prefix << "HierName = " << prop->GetHierarchicalName() << endl;
    cout << prefix << "Label = " << prop->GetLabel() << endl;

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
    FbxDouble2 v2;
    FbxDouble3 v3;
    FbxDouble4 v4;
    std::string s;
    std::stringstream ss;

    bool printValue = true;

    switch (type.GetType())
    {
        case eFbxUndefined:
            printValue = false;
            break;
        case eFbxChar:
            ch = prop->Get<char>();
            snprintf(n, sizeof(n), "%i ('%c')", (int)ch, ch);
            break;
        case eFbxUChar:
            uch = prop->Get<unsigned char>();
            snprintf(n, sizeof(n), "%i ('%c')", (unsigned int)uch, uch);
            break;
        case eFbxShort:
            sh = prop->Get<short>();
            snprintf(n, sizeof(n), "%i", (int)sh);
            break;
        case eFbxUShort:
            ush = prop->Get<unsigned short>();
            snprintf(n, sizeof(n), "%ui", (unsigned int)ush);
            break;
        case eFbxUInt:
            ui = prop->Get<unsigned int>();
            snprintf(n, sizeof(n), "%ui", ui);
            break;
        case eFbxLongLong:
            ll = prop->Get<long long>();
            snprintf(n, sizeof(n), "%lli", ll);
            break;
        case eFbxULongLong:
            ull = prop->Get<unsigned long long>();
            snprintf(n, sizeof(n), "%llu", ull);
            break;
        case eFbxHalfFloat:
            printValue = false;
            break;
        case eFbxBool:
            b = prop->Get<bool>();
            if (b)
                snprintf(n, sizeof(n), "true");
            else
                snprintf(n, sizeof(n), "false");
            break;
        case eFbxInt:
            i = prop->Get<int>();
            snprintf(n, sizeof(n), "%i", i);
            break;
        case eFbxFloat:
            f = prop->Get<float>();
            snprintf(n, sizeof(n), "%f", f);
            break;
        case eFbxDouble:
            d = prop->Get<double>();
            snprintf(n, sizeof(n), "%lf", d);
            break;
        case eFbxDouble2:
            v2 = prop->Get<FbxDouble2>();
            snprintf(n, sizeof(n), "%lf, %lf", v2[0], v2[1]);
            break;
        case eFbxDouble3:
            v3 = prop->Get<FbxDouble3>();
            snprintf(n, sizeof(n), "%lf, %lf, %lf", v3[0], v3[1], v3[2]);
            break;
        case eFbxDouble4:
            v4 = prop->Get<FbxDouble4>();
            snprintf(n, sizeof(n), "%lf, %lf, %lf, %lf", v4[0], v4[1], v4[2], v4[3]);
            break;
        case eFbxDouble4x4:
        case eFbxEnum:
            printValue = false;
            break;
        case eFbxString:
            fstr = prop->Get<FbxString>();
            snprintf(n, sizeof(n), "%s", fstr.Buffer());
            s = (fstr.Buffer());
            s = quote(s.c_str());
            snprintf(n, sizeof(n), "%s", s.c_str());
            break;
        case eFbxTime:
            ss << prop->Get<FbxTime>();
            snprintf(n, sizeof(n), "%s", ss.str().c_str());
            break;
        case eFbxReference:
//            FbxObject* obj;
//            obj = prop->Get<FbxObject*>();
//            cout << prefix << ".Value = " << obj->GetRuntimeClassId().GetName() << ", uid=" << obj->GetUniqueID() << endl;
//            break;
        case eFbxBlob:
        case eFbxDistance:
        case eFbxDateTime:
        case eFbxTypeCount:
            printValue = false;
            break;
    }
    if (printValue)
    {
        cout << prefix << "Value = " << n << endl;
    }


    cout << prefix << "SrcObjectCount = " << prop->GetSrcObjectCount() << endl;
    for (i = 0; i < prop->GetSrcObjectCount(); i++)
    {
        FbxObject* srcObj = prop->GetSrcObject(i);
        cout << prefix << "    #" << i << " ";
        PrintObjectID(srcObj);
        cout << endl;
    }
    cout << prefix << "DstObjectCount = " << prop->GetDstObjectCount() << endl;
    for (i = 0; i < prop->GetDstObjectCount(); i++)
    {
        FbxObject* dstObj = prop->GetDstObject(i);
        cout << prefix << "    #" << i << " ";
        PrintObjectID(dstObj);
        cout << endl;
    }
    cout << prefix << "SrcPropertyCount = " << prop->GetSrcPropertyCount() << endl;
    for (i = 0; i < prop->GetSrcPropertyCount(); i++)
    {
        FbxProperty prop2 = prop->GetSrcProperty(i);
        cout << prefix << "    #" << i << " ";
        PrintPropertyID(&prop2);
        cout << endl;
    }
    cout << prefix << "DstPropertyCount = " << prop->GetDstPropertyCount() << endl;
    for (i = 0; i < prop->GetDstPropertyCount(); i++)
    {
        FbxProperty prop2 = prop->GetDstProperty(i);
        cout << prefix << "    #" << i << " ";
        PrintPropertyID(&prop2);
        cout << endl;
    }

    cout << prefix << "IsAnimated() = " << prop->IsAnimated() << endl;
    cout << prefix << "IsRoot() = " << prop->IsRoot() << endl;

    cout << prefix << "GetParent() = ";
    FbxProperty parentProp = prop->GetParent();
    PrintPropertyID(&parentProp);
    cout << endl;

    cout << prefix << "GetChild() = ";
    FbxProperty childProp = prop->GetChild();
    PrintPropertyID(&childProp);
    cout << endl;

    cout << prefix << "GetSibling() = ";
    FbxProperty nextProp = prop->GetSibling();
    PrintPropertyID(&nextProp);
    cout << endl;

    i = 0;
    FbxProperty descendent = prop->GetFirstDescendent();
    while (descendent.IsValid())
    {
        i++;
        FbxProperty descendent2 = prop->GetNextDescendent(descendent);
        descendent = descendent2;
    }

    cout << prefix << "Descendents: " << i << endl;
    if (i > 0)
    {
        cout << prefix << "GetFirstDescendent() = ";
        descendent = prop->GetFirstDescendent();
        PrintPropertyID(&parentProp);
        cout << endl;

        while (descendent.IsValid())
        {
            FbxProperty descendent2 = prop->GetNextDescendent(descendent);
            descendent = descendent2;

            if (descendent.IsValid())
            {
                cout << prefix << "GetNextDescendent() = ";
                PrintPropertyID(&parentProp);
                cout << endl;
            }
        }
    }
}