
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
