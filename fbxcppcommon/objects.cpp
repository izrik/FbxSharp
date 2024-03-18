
#include <iostream>
#include <fbxsdk.h>
#include <set>
#include <iomanip>
#include <algorithm>
#include <sstream>

#include "Collector.h"
#include "print.h"

using namespace std;

bool sort_by_id(FbxObject* a, FbxObject* b)
{
    if (a == NULL)
    {
        cout << "sort_by_id a is NULL" << endl;
    }
    if (b == NULL)
    {
        cout << "sort_by_id b is NULL" << endl;
    }

    if (a == NULL && b == NULL) return false;
    if (a == NULL) return false;
    if (b == NULL) return true;

    return (a->GetUniqueID() < b->GetUniqueID());
}

std::string id(FbxObject* obj)
{
    if (obj == NULL) return "<<null>>";

    std::stringstream ss;
    ss <<   "$" << obj->GetUniqueID() << ", " <<
            obj->GetRuntimeClassId().GetName() << ", " <<
            quote(obj->GetName());

    return ss.str();
}

int CountProperties(FbxObject* obj)
{
    FbxProperty prop = obj->GetFirstProperty();
    int n = 0;
    while (prop.IsValid())
    {
        n++;
        prop = obj->GetNextProperty(prop);
    }

    return n;
}

FbxProperty GetPropertyByIndex(FbxObject* obj, int index)
{
    FbxProperty prop = obj->GetFirstProperty();
    int n = 0;
    while (prop.IsValid())
    {
        if (n == index)
            return prop;

        n++;
        prop = obj->GetNextProperty(prop);
    }

    prop = FbxProperty();
    return prop;
}


