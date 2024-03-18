
#ifndef __FBXCPPTESTS_OBJECTS_H
#define __FBXCPPTESTS_OBJECTS_H

#include <fbxsdk.h>
#include <string>

bool sort_by_id(FbxObject* a, FbxObject* b);
std::string id(FbxObject* obj);
int CountProperties(FbxObject* obj);
FbxProperty GetPropertyByIndex(FbxObject* obj, int index);

#endif // __FBXCPPTESTS_OBJECTS_H
