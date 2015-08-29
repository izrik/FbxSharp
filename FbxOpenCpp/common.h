
#ifndef __FBXOPENCPP_COMMON_H
#define __FBXOPENCPP_COMMON_H

#include <iostream>
#include <fbxsdk.h>
#include <vector>
#include <string>
#include <sstream>

void PrintObjectGraph(FbxObject* obj);

void PrintObjectID(FbxObject* obj);
std::string id(FbxObject* obj);
void PrintPropertyID(FbxProperty* prop);

void PrintObject(FbxObject* obj, bool branch=true, bool printProperties=true);

void PrintScene(FbxScene* obj);

void PrintAnimLayer(FbxAnimLayer* animLayer);
void PrintAnimStack(FbxAnimStack* animStack);
void PrintAnimCurve(FbxAnimCurve* animCurve);
void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode);
void PrintDeformer(FbxDeformer* deformer);
void PrintNode(FbxNode* node);
void PrintNodeAttribute(FbxNodeAttribute* nodeAttribute);
void PrintCamera(FbxCamera* camera);
void PrintLight(FbxLight* light);
void PrintLayerContainer(FbxLayerContainer* layerContainer);
void PrintLayer(FbxLayer* layer);
void PrintGeometryBase(FbxGeometryBase* geometryBase);
void PrintGeometry(FbxGeometry* geometry);
void PrintMesh(FbxMesh* mesh);
void PrintNull(FbxNull* null);
void PrintSkeleton(FbxSkeleton* skeleton);
void PrintPose(FbxPose* pose);
void PrintSubDeformer(FbxSubDeformer* subDeformer);
void PrintSurfaceMaterial(FbxSurfaceMaterial* surfaceMaterial);
void PrintSurfaceLambert(FbxSurfaceLambert* surfaceLambert);
void PrintSurfacePhong(FbxSurfacePhong* surfacePhong);
void PrintTexture(FbxTexture* texture);
void PrintVideo(FbxVideo* video);
void PrintCollection(FbxCollection* col);
void PrintDocument(FbxDocument* doc);

void PrintProperty(FbxProperty* prop, bool indent=false);

int CountProperties(FbxObject* obj);

std::ostream& operator<<(std::ostream& os, const FbxDouble2& value);
std::ostream& operator<<(std::ostream& os, const FbxDouble3& value);
std::ostream& operator<<(std::ostream& os, const FbxDouble4& value);
std::ostream& operator<<(std::ostream& os, const FbxDataType& value);
std::ostream& operator<<(std::ostream& os, const EFbxType& value);
std::ostream& operator<<(std::ostream& os, const FbxTime& value);
std::ostream& operator<<(std::ostream& os, const FbxTimeSpan& value);
std::ostream& operator<<(std::ostream& os, const FbxMatrix& value);
std::ostream& operator<<(std::ostream& os, const FbxAMatrix& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentMode& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EInterpolationType& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EWeightedMode& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EConstantMode& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EVelocityMode& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentVisibility& value);
std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EDataIndex& value);


FbxScene* Load(const char* filename, FbxManager* manager=NULL);
void Save(const char* filename, FbxScene* scene);

std::string quote(const char* s);

#endif // __FBXOPENCPP_COMMON_H
