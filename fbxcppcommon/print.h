
#ifndef __FBXCPPTESTS_PRINT_H
#define __FBXCPPTESTS_PRINT_H

#include <fbxsdk.h>

void PrintAnimCurve(FbxAnimCurve* animCurve);
void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode);
void PrintAnimLayer(FbxAnimLayer* animLayer);
void PrintAnimStack(FbxAnimStack* animStack);
void PrintCamera(FbxCamera* camera);
void PrintCollection(FbxCollection* col);
void PrintDeformer(FbxDeformer* deformer);
void PrintDocument(FbxDocument* doc);
void PrintGeometry(FbxGeometry* geometry);
void PrintGeometryBase(FbxGeometryBase* geometryBase);
void PrintLayer(FbxLayer* layer);
void PrintLayerContainer(FbxLayerContainer* layerContainer);
void PrintLight(FbxLight* light);
void PrintMesh(FbxMesh* mesh);
void PrintNode(FbxNode* node);
void PrintNodeAttribute(FbxNodeAttribute* nodeAttribute);
void PrintNull(FbxNull* null);
void PrintObject(FbxObject* obj, bool branch=true, bool printProperties=true);
void PrintObjectGraph(FbxObject* obj);
void PrintObjectID(FbxObject* obj);
void PrintPose(FbxPose* pose);
void PrintProperty(FbxProperty* prop, bool indent=false);
void PrintPropertyID(FbxProperty* prop);
void PrintScene(FbxScene* obj);
void PrintSkeleton(FbxSkeleton* skeleton);
void PrintSubDeformer(FbxSubDeformer* subDeformer);
void PrintSurfaceLambert(FbxSurfaceLambert* surfaceLambert);
void PrintSurfaceMaterial(FbxSurfaceMaterial* surfaceMaterial);
void PrintSurfacePhong(FbxSurfacePhong* surfacePhong);
void PrintTexture(FbxTexture* texture);
void PrintVideo(FbxVideo* video);

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

std::string quote(const char* s);

std::string ToString(const FbxLocalTime& value);

#endif // __FBXCPPTESTS_PRINT_H
