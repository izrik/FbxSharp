
#ifndef __FBXOPENCPP_COMMON_H
#define __FBXOPENCPP_COMMON_H

#include <iostream>
#include <fbxsdk.h>

void PrintObject(FbxObject* obj, const char* prefix="");

void PrintScene(FbxScene* obj, const char* prefix="");

void PrintAnimLayer(FbxAnimLayer* animLayer, const char* prefix="");
void PrintAnimStack(FbxAnimStack* animStack, const char* prefix="");
void PrintAnimCurve(FbxAnimCurve* animCurve, const char* prefix="");
void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode, const char* prefix="");
void PrintDeformer(FbxDeformer* deformer, const char* prefix="");
void PrintNode(FbxNode* node, const char* prefix="");
void PrintNodeAttribute(FbxNodeAttribute* nodeAttribute, const char* prefix="");
void PrintCamera(FbxCamera* camera, const char* prefix="");
void PrintLight(FbxLight* light, const char* prefix="");
void PrintMesh(FbxMesh* mesh, const char* prefix="");
void PrintNull(FbxNull* null, const char* prefix="");
void PrintSkeleton(FbxSkeleton* skeleton, const char* prefix="");
void PrintPose(FbxPose* pose, const char* prefix="");
void PrintSubDeformer(FbxSubDeformer* subDeformer, const char* prefix="");
void PrintSurfaceMaterial(FbxSurfaceMaterial* surfaceMaterial, const char* prefix="");
void PrintSurfaceLambert(FbxSurfaceLambert* surfaceLambert, const char* prefix="");
void PrintSurfacePhong(FbxSurfacePhong* surfacePhong, const char* prefix="");
void PrintTexture(FbxTexture* texture, const char* prefix="");
void PrintVideo(FbxVideo* video, const char* prefix="");

void PrintProperty(FbxProperty* prop, const char* prefix="");

std::ostream& operator<<(std::ostream& os, const FbxDouble2& value);
std::ostream& operator<<(std::ostream& os, const FbxDouble3& value);
std::ostream& operator<<(std::ostream& os, const FbxDouble4& value);

FbxScene* Load(const char* filename, FbxManager* manager=NULL);

#endif // __FBXOPENCPP_COMMON_H
