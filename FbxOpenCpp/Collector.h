
#ifndef __FBXOPENCPP_COLLECTOR_H
#define __FBXOPENCPP_COLLECTOR_H

#include <vector>
#include <fbxsdk.h>

class Collector
{
public:
    std::vector<FbxObject*> Objects;

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
};


#endif // __FBXOPENCPP_COLLECTOR_H

