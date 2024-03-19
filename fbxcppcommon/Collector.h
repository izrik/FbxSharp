
#ifndef __FBXCPPTESTS_COLLECTOR_H
#define __FBXCPPTESTS_COLLECTOR_H

#include <vector>
#include <fbxsdk.h>

class Collector;
void VisitLayerElementTexture(Collector* c, FbxLayerElementTexture* tex, std::vector<FbxObject*>* visited);

class Collector
{
public:
    void Visit(FbxObject* obj);
    void VisitScene(FbxScene* obj);
    void VisitNode(FbxNode* obj);
    void VisitNodeAttribute(FbxNodeAttribute* obj);
    void VisitSurfaceMaterial(FbxSurfaceMaterial* obj);
    void VisitSurfaceLambert(FbxSurfaceLambert* obj);
    void VisitSurfacePhong(FbxSurfacePhong* obj);
    void VisitMesh(FbxMesh* obj);
    void VisitGeometry(FbxGeometry* obj);
    void VisitGeometryBase(FbxGeometryBase* obj);
    void VisitLayerContainer(FbxLayerContainer* obj);
    void VisitDocument(FbxDocument* obj);
    void VisitCollection(FbxCollection* obj);
    void VisitAnimLayer(FbxAnimLayer* obj);
    void VisitAnimStack(FbxAnimStack* obj);
    void VisitAnimCurve(FbxAnimCurve* obj);
    void VisitAnimCurveNode(FbxAnimCurveNode* obj);
    void VisitDeformer(FbxDeformer* obj);
    void VisitPose(FbxPose* obj);
    void VisitSubDeformer(FbxSubDeformer* obj);
    void VisitTexture(FbxTexture* obj);
    void VisitVideo(FbxVideo* obj);
    void VisitCamera(FbxCamera* obj);
    void VisitLight(FbxLight* obj);
    void VisitNull(FbxNull* obj);
    void VisitSkeleton(FbxSkeleton* obj);

    void Visit(FbxObject* obj, std::vector<FbxObject*>* visited);
    void VisitScene(FbxScene* obj, std::vector<FbxObject*>* visited);
    void VisitNode(FbxNode* obj, std::vector<FbxObject*>* visited);
    void VisitNodeAttribute(FbxNodeAttribute* obj, std::vector<FbxObject*>* visited);
    void VisitSurfaceMaterial(FbxSurfaceMaterial* obj, std::vector<FbxObject*>* visited);
    void VisitSurfaceLambert(FbxSurfaceLambert* obj, std::vector<FbxObject*>* visited);
    void VisitSurfacePhong(FbxSurfacePhong* obj, std::vector<FbxObject*>* visited);
    void VisitMesh(FbxMesh* obj, std::vector<FbxObject*>* visited);
    void VisitGeometry(FbxGeometry* obj, std::vector<FbxObject*>* visited);
    void VisitGeometryBase(FbxGeometryBase* obj, std::vector<FbxObject*>* visited);
    void VisitLayerContainer(FbxLayerContainer* obj, std::vector<FbxObject*>* visited);
    void VisitDocument(FbxDocument* obj, std::vector<FbxObject*>* visited);
    void VisitCollection(FbxCollection* obj, std::vector<FbxObject*>* visited);
    void VisitAnimLayer(FbxAnimLayer* obj, std::vector<FbxObject*>* visited);
    void VisitAnimStack(FbxAnimStack* obj, std::vector<FbxObject*>* visited);
    void VisitAnimCurve(FbxAnimCurve* obj, std::vector<FbxObject*>* visited);
    void VisitAnimCurveNode(FbxAnimCurveNode* obj, std::vector<FbxObject*>* visited);
    void VisitDeformer(FbxDeformer* obj, std::vector<FbxObject*>* visited);
    void VisitPose(FbxPose* obj, std::vector<FbxObject*>* visited);
    void VisitSubDeformer(FbxSubDeformer* obj, std::vector<FbxObject*>* visited);
    void VisitTexture(FbxTexture* obj, std::vector<FbxObject*>* visited);
    void VisitVideo(FbxVideo* obj, std::vector<FbxObject*>* visited);
    void VisitCamera(FbxCamera* obj, std::vector<FbxObject*>* visited);
    void VisitLight(FbxLight* obj, std::vector<FbxObject*>* visited);
    void VisitNull(FbxNull* obj, std::vector<FbxObject*>* visited);
    void VisitSkeleton(FbxSkeleton* obj, std::vector<FbxObject*>* visited);
};


#endif // __FBXCPPTESTS_COLLECTOR_H

