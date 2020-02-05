
#ifndef __FBXCPPTESTS_FILEIO_H
#define __FBXCPPTESTS_FILEIO_H

#include <fbxsdk.h>

FbxScene* Load(const char* filename, FbxManager* manager=NULL);
void Save(const char* filename, FbxScene* scene, bool ascii);
void LoadAndPrint(const char* filename);

#endif // __FBXCPPTESTS_FILEIO_H
