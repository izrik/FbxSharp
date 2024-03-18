
#include "Collector.h"

#include <algorithm>
#include <iostream>

using namespace std;

void Collector::Visit(FbxObject* obj, std::vector<FbxObject*>* visited)
{

    if (obj == NULL) return;

    if (std::find(visited->begin(), visited->end(), obj) != visited->end()) return;
    
    if (!obj->Is<FbxScene>() &&
        !obj->Is<FbxAnimLayer>() &&
        !obj->Is<FbxAnimStack>() &&
        !obj->Is<FbxAnimCurve>() &&
        !obj->Is<FbxAnimCurveNode>() &&
        !obj->Is<FbxSkin>() &&
        !obj->Is<FbxNode>() &&
        !obj->Is<FbxMesh>() &&
        !obj->Is<FbxPose>() &&
        !obj->Is<FbxCluster>() &&
        !obj->Is<FbxSurfaceMaterial>() &&
        !obj->Is<FbxTexture>() &&
        !obj->Is<FbxCamera>() &&
        !obj->Is<FbxLight>() &&
        !obj->Is<FbxNull>() &&
        !obj->Is<FbxSkeleton>() &&
        !obj->Is<FbxVideo>())
    {
        std::cout << "Unknown object class: " << obj->GetRuntimeClassId().GetName() << std::endl;
        return;
    }

    visited->push_back(obj);

//    cout << "adding object "; PrintObjectID(obj); cout << endl;

    Visit(obj->GetDocument(), visited);
    Visit(obj->GetRootDocument(), visited);
    Visit(obj->GetScene(), visited);

    int i;
    for (i = 0; i < obj->GetSrcObjectCount(); i++)
    {
        Visit(obj->GetSrcObject(i), visited);
    }
    for (i = 0; i < obj->GetDstObjectCount(); i++)
    {
        Visit(obj->GetDstObject(i), visited);
    }


    FbxProperty prop = obj->GetFirstProperty();
    while (prop.IsValid())
    {
        for (i = 0; i < prop.GetSrcObjectCount(); i++)
        {
            FbxObject* srcObj = prop.GetSrcObject(i);
            Visit(srcObj, visited);
        }
        for (i = 0; i < prop.GetDstObjectCount(); i++)
        {
            FbxObject* dstObj = prop.GetDstObject(i);
            Visit(dstObj, visited);
        }

        // TODO: object references in properties
        // TODO: object references in src and dst properties

        prop = obj->GetNextProperty(prop);
    }

    prop = obj->RootProperty;
    for (i = 0; i < prop.GetSrcObjectCount(); i++)
    {
        FbxObject* srcObj = prop.GetSrcObject(i);
        Visit(srcObj, visited);
    }
    for (i = 0; i < prop.GetDstObjectCount(); i++)
    {
        FbxObject* dstObj = prop.GetDstObject(i);
        Visit(dstObj, visited);
    }

//    cout << "branching object "; PrintObjectID(obj); cout << endl;

    if (obj->Is<FbxCollection>())
        VisitCollection(FbxCast<FbxCollection>(obj), visited);
    else if (obj->Is<FbxAnimCurve>())
        VisitAnimCurve(FbxCast<FbxAnimCurve>(obj), visited);
    else if (obj->Is<FbxAnimCurveNode>())
        VisitAnimCurveNode(FbxCast<FbxAnimCurveNode>(obj), visited);
    else if (obj->Is<FbxDeformer>())
        VisitDeformer(FbxCast<FbxDeformer>(obj), visited);
    else if (obj->Is<FbxNode>())
        VisitNode(FbxCast<FbxNode>(obj), visited);
    else if (obj->Is<FbxNodeAttribute>())
        VisitNodeAttribute(FbxCast<FbxNodeAttribute>(obj), visited);
    else if (obj->Is<FbxPose>())
        VisitPose(FbxCast<FbxPose>(obj), visited);
    else if (obj->Is<FbxSubDeformer>())
        VisitSubDeformer(FbxCast<FbxSubDeformer>(obj), visited);
    else if (obj->Is<FbxSurfaceMaterial>())
        VisitSurfaceMaterial(FbxCast<FbxSurfaceMaterial>(obj), visited);
    else if (obj->Is<FbxTexture>())
        VisitTexture(FbxCast<FbxTexture>(obj), visited);
    else if (obj->Is<FbxVideo>())
        VisitVideo(FbxCast<FbxVideo>(obj), visited);

//    cout << "added object "; PrintObjectID(obj); cout << endl;
}

void Collector::VisitScene(FbxScene* scene, std::vector<FbxObject*>* visited)
{
    // GenericNodeCount
    // CharacterCount
    // CharacterPoseCount

    int i;
    for (i = 0; i < scene->GetPoseCount(); i++)
    {
        Visit(scene->GetPose(i), visited);
    }
    for (i = 0; i < scene->GetMaterialCount(); i++)
    {
        Visit(scene->GetMaterial(i), visited);
    }
    for (i = 0; i < scene->GetTextureCount(); i++)
    {
        Visit(scene->GetTexture(i), visited);
    }
    for (i = 0; i < scene->GetNodeCount(); i++)
    {
        Visit(scene->GetNode(i), visited);
    }
    for (i = 0; i < scene->GetGeometryCount(); i++)
    {
        Visit(scene->GetGeometry(i), visited);
    }
    for (i = 0; i < scene->GetVideoCount(); i++)
    {
        Visit(scene->GetVideo(i), visited);
    }

    if (scene->GetRootNode() != NULL)
    {
        Visit(scene->GetRootNode(), visited);
    }

    // other stuff
}

void Collector::VisitNode(FbxNode* node, std::vector<FbxObject*>* visited)
{
    Visit(node->GetParent(), visited);

    int i;
    for (i = 0; i < node->GetChildCount(); i++)
    {
        Visit(node->GetChild(i), visited);
    }

    if (node->GetTarget() != NULL)
    {
        Visit(node->GetTarget(), visited);
    }
    if (node->GetTargetUp() != NULL)
    {
        Visit(node->GetTargetUp(), visited);
    }

    for (i = 0; i < node->GetNodeAttributeCount(); i++)
    {
        Visit(node->GetNodeAttributeByIndex(i), visited);
    }

    for (i = 0; i < node->GetMaterialCount(); i++)
    {
        Visit(node->GetMaterial(i), visited);
    }
}

void Collector::VisitNodeAttribute(FbxNodeAttribute* obj, std::vector<FbxObject*>* visited)
{
    Visit(obj->GetNode(), visited);

    if (obj->Is<FbxCamera>())
        VisitCamera(FbxCast<FbxCamera>(obj), visited);
    else if (obj->Is<FbxLight>())
        VisitLight(FbxCast<FbxLight>(obj), visited);
    else if (obj->Is<FbxLayerContainer>())
        VisitLayerContainer(FbxCast<FbxLayerContainer>(obj), visited);
    else if (obj->Is<FbxNull>())
        VisitNull(FbxCast<FbxNull>(obj), visited);
    else if (obj->Is<FbxSkeleton>())
        VisitSkeleton(FbxCast<FbxSkeleton>(obj), visited);
}

void Collector::VisitSurfaceMaterial(FbxSurfaceMaterial* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitSurfaceLambert(FbxSurfaceLambert* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitSurfacePhong(FbxSurfacePhong* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitMesh(FbxMesh* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitGeometry(FbxGeometry* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
    int i;
    for (i = 0; i < obj->GetDeformerCount(); i++)
    {
        Visit(obj->GetDeformer(i), visited);
    }

    // geometry weighted map
    // shape

    if (obj->Is<FbxMesh>())
        VisitMesh(FbxCast<FbxMesh>(obj), visited);
}

void Collector::VisitGeometryBase(FbxGeometryBase* obj, std::vector<FbxObject*>* visited)
{
    // TODO: geometry elements

    if (obj->Is<FbxGeometry>())
        VisitGeometry(FbxCast<FbxGeometry>(obj), visited);
}

void VisitLayerElementTexture(Collector* c, FbxLayerElementTexture* tex, std::vector<FbxObject*>* visited)
{
    if (tex == NULL) return;

    FbxLayerElementArrayTemplate<FbxTexture*>* tarray = &tex->GetDirectArray();

    int i;
    for (i = 0; i < tarray->GetCount(); i++)
    {
        c->Visit(tarray->GetAt(i), visited);
    }
}

void Collector::VisitLayerContainer(FbxLayerContainer* layerContainer, std::vector<FbxObject*>* visited)
{
    int j;
    for (j = 0; j < layerContainer->GetLayerCount(); j++)
    {
        FbxLayer* layer = layerContainer->GetLayer(j);

        int i;
        FbxLayerElementMaterial* mats = layer->GetMaterials();
        if (mats != NULL)
        {
            FbxLayerElementTemplate<FbxSurfaceMaterial*>* _mats = mats;
            FbxLayerElementArrayTemplate<FbxSurfaceMaterial*>& marray = _mats->GetDirectArray();
            for (i = 0; i < marray.GetCount(); i++)
            {
                Visit(marray.GetAt(i), visited);
            }
        }

        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureEmissive), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureEmissiveFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureAmbient), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureAmbientFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureDiffuseFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureSpecular), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureNormalMap), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureSpecularFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureShininess), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureBump), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureTransparency), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureTransparencyFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureReflection), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureReflectionFactor), visited);
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureDisplacement), visited);
    }

    if (layerContainer->Is<FbxGeometryBase>())
        VisitGeometryBase(FbxCast<FbxGeometryBase>(layerContainer), visited);
}

void Collector::VisitDocument(FbxDocument* obj, std::vector<FbxObject*>* visited)
{
    int i;
    for (i = 0; i < obj->GetRootMemberCount(); i++)
    {
        Visit(obj->GetRootMember(i), visited);
    }

    if (obj->GetDocumentInfo() != NULL)
    {
        Visit(obj->GetDocumentInfo(), visited);
    }

    if (obj->Is<FbxScene>())
        VisitScene(FbxCast<FbxScene>(obj), visited);
}

void Collector::VisitCollection(FbxCollection* obj, std::vector<FbxObject*>* visited)
{
    int i;
    for (i = 0; i < obj->GetMemberCount(); i++)
    {
        Visit(obj->GetMember(i), visited);
    }


    if (obj->Is<FbxDocument>())
        VisitDocument(FbxCast<FbxDocument>(obj), visited);
    else if (obj->Is<FbxAnimStack>())
        VisitAnimStack(FbxCast<FbxAnimStack>(obj), visited);
    else if (obj->Is<FbxAnimLayer>())
        VisitAnimLayer(FbxCast<FbxAnimLayer>(obj), visited);
}

void Collector::VisitAnimLayer(FbxAnimLayer* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitAnimStack(FbxAnimStack* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitAnimCurve(FbxAnimCurve* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitAnimCurveNode(FbxAnimCurveNode* obj, std::vector<FbxObject*>* visited)
{
    int i;
    int j;

    for (i = 0; i < obj->GetChannelsCount(); i++)
    {
        for (j = 0; j < obj->GetCurveCount(i); j++)
        {
            FbxAnimCurve* curve = obj->GetCurve(i, j);
            Visit(curve, visited);
        }
    }
}

void Collector::VisitDeformer(FbxDeformer* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitDeformer: Not Implemented" << endl;
}


void Collector::VisitPose(FbxPose* pose, std::vector<FbxObject*>* visited)
{
    int i;
    for (i = 0; i < pose->GetCount(); i++)
    {
        Visit(pose->GetNode(i), visited);
    }
}

void Collector::VisitSubDeformer(FbxSubDeformer* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitSubDeformer: Not Implemented" << endl;
}

void Collector::VisitTexture(FbxTexture* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitVideo(FbxVideo* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitVideo: Not Implemented" << endl;
}

void Collector::VisitCamera(FbxCamera* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitCamera: Not Implemented" << endl;
}

void Collector::VisitLight(FbxLight* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitLight: Not Implemented" << endl;
}

void Collector::VisitNull(FbxNull* obj, std::vector<FbxObject*>* visited)
{
    // nothing to do
}

void Collector::VisitSkeleton(FbxSkeleton* obj, std::vector<FbxObject*>* visited)
{
    cout << "VisitSkeleton: Not Implemented" << endl;
}
//
//
//void Collector::Visit(FbxObject* obj)
//{
//    std::vector<FbxObject*> visited;
//    Visit(obj, &visited);
//}
//
//void Collector::VisitScene(FbxScene* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitScene(obj, &visited);
//}
//
//void Collector::VisitNode(FbxNode* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitNode(obj, &visited);
//}
//
//void Collector::VisitNodeAttribute(FbxNodeAttribute* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitNodeAttribute(obj, &visited);
//}
//
//void Collector::VisitSurfaceMaterial(FbxSurfaceMaterial* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitSurfaceMaterial(obj, &visited);
//}
//
//void Collector::VisitSurfaceLambert(FbxSurfaceLambert* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitSurfaceLambert(obj, &visited);
//}
//
//void Collector::VisitSurfacePhong(FbxSurfacePhong* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitSurfacePhong(obj, &visited);
//}
//
//void Collector::VisitMesh(FbxMesh* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitMesh(obj, &visited);
//}
//
//void Collector::VisitGeometry(FbxGeometry* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitGeometry(obj, &visited);
//}
//
//void Collector::VisitGeometryBase(FbxGeometryBase* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitGeometryBase(obj, &visited);
//}
//
//void Collector::VisitLayerContainer(FbxLayerContainer* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitLayerContainer(obj, &visited);
//}
//
//void Collector::VisitDocument(FbxDocument* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitDocument(obj, &visited);
//}
//
//void Collector::VisitCollection(FbxCollection* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitCollection(obj, &visited);
//}
//
//void Collector::VisitAnimLayer(FbxAnimLayer* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitAnimLayer(obj, &visited);
//}
//
//void Collector::VisitAnimStack(FbxAnimStack* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitAnimStack(obj, &visited);
//}
//
//void Collector::VisitAnimCurve(FbxAnimCurve* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitAnimCurve(obj, &visited);
//}
//
//void Collector::VisitAnimCurveNode(FbxAnimCurveNode* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitAnimCurveNode(obj, &visited);
//}
//
//void Collector::VisitDeformer(FbxDeformer* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitDeformer(obj, &visited);
//}
//
//void Collector::VisitPose(FbxPose* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitPose(obj, &visited);
//}
//
//void Collector::VisitSubDeformer(FbxSubDeformer* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitSubDeformer(obj, &visited);
//}
//
//void Collector::VisitTexture(FbxTexture* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitTexture(obj, &visited);
//}
//
//void Collector::VisitVideo(FbxVideo* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitVideo(obj, &visited);
//}
//
//void Collector::VisitCamera(FbxCamera* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitCamera(obj, &visited);
//}
//
//void Collector::VisitLight(FbxLight* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitLight(obj, &visited);
//}
//
//void Collector::VisitNull(FbxNull* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitNull(obj, &visited);
//}
//
//void Collector::VisitSkeleton(FbxSkeleton* obj)
//{
//    std::vector<FbxObject*> visited;
//    VisitSkeleton(obj, &visited);
//}
