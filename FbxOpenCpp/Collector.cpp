
#include "Collector.h"
#include "common.h"

using namespace std;

void Collector::Visit(FbxObject* obj)
{

    if (obj == NULL) return;

    if (std::find(Objects.begin(), Objects.end(), obj) != Objects.end()) return;
    
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

    Objects.push_back(obj);

//    cout << "adding object "; PrintObjectID(obj); cout << endl;

    int i;
    for (i = 0; i < obj->GetSrcObjectCount(); i++)
    {
        Visit(obj->GetSrcObject(i));
    }
    for (i = 0; i < obj->GetDstObjectCount(); i++)
    {
        Visit(obj->GetDstObject(i));
    }


    FbxProperty prop = obj->GetFirstProperty();
    while (prop.IsValid())
    {
        for (i = 0; i < prop.GetSrcObjectCount(); i++)
        {
            FbxObject* srcObj = prop.GetSrcObject(i);
            Visit(srcObj);
        }
        for (i = 0; i < prop.GetDstObjectCount(); i++)
        {
            FbxObject* dstObj = prop.GetDstObject(i);
            Visit(dstObj);
        }

        // TODO: object references in properties
        // TODO: object references in src and dst properties

        prop = obj->GetNextProperty(prop);
    }

    prop = obj->RootProperty;
    for (i = 0; i < prop.GetSrcObjectCount(); i++)
    {
        FbxObject* srcObj = prop.GetSrcObject(i);
        Visit(srcObj);
    }
    for (i = 0; i < prop.GetDstObjectCount(); i++)
    {
        FbxObject* dstObj = prop.GetDstObject(i);
        Visit(dstObj);
    }

//    cout << "branching object "; PrintObjectID(obj); cout << endl;

    if (obj->Is<FbxCollection>())
        VisitCollection(dynamic_cast<FbxCollection*>(obj));
    else if (obj->Is<FbxAnimCurve>())
        VisitAnimCurve(dynamic_cast<FbxAnimCurve*>(obj));
    else if (obj->Is<FbxAnimCurveNode>())
        VisitAnimCurveNode(dynamic_cast<FbxAnimCurveNode*>(obj));
    else if (obj->Is<FbxDeformer>())
        VisitDeformer(dynamic_cast<FbxDeformer*>(obj));
    else if (obj->Is<FbxNode>())
        VisitNode(dynamic_cast<FbxNode*>(obj));
    else if (obj->Is<FbxNodeAttribute>())
        VisitNodeAttribute(dynamic_cast<FbxNodeAttribute*>(obj));
    else if (obj->Is<FbxPose>())
        VisitPose(dynamic_cast<FbxPose*>(obj));
    else if (obj->Is<FbxSubDeformer>())
        VisitSubDeformer(dynamic_cast<FbxSubDeformer*>(obj));
    else if (obj->Is<FbxSurfaceMaterial>())
        VisitSurfaceMaterial(dynamic_cast<FbxSurfaceMaterial*>(obj));
    else if (obj->Is<FbxTexture>())
        VisitTexture(dynamic_cast<FbxTexture*>(obj));
    else if (obj->Is<FbxVideo>())
        VisitVideo(dynamic_cast<FbxVideo*>(obj));

//    cout << "added object "; PrintObjectID(obj); cout << endl;
}

void Collector::VisitScene(FbxScene* scene)
{
    // GenericNodeCount
    // CharacterCount
    // CharacterPoseCount

    int i;
    for (i = 0; i < scene->GetPoseCount(); i++)
    {
        Visit(scene->GetPose(i));
    }
    for (i = 0; i < scene->GetMaterialCount(); i++)
    {
        Visit(scene->GetMaterial(i));
    }
    for (i = 0; i < scene->GetTextureCount(); i++)
    {
        Visit(scene->GetTexture(i));
    }
    for (i = 0; i < scene->GetNodeCount(); i++)
    {
        Visit(scene->GetNode(i));
    }
    for (i = 0; i < scene->GetGeometryCount(); i++)
    {
        Visit(scene->GetGeometry(i));
    }
    for (i = 0; i < scene->GetVideoCount(); i++)
    {
        Visit(scene->GetVideo(i));
    }

    if (scene->GetRootNode() != NULL)
    {
        Visit(scene->GetRootNode());
    }

    // other stuff
}

void Collector::VisitNode(FbxNode* node)
{
    Visit(node->GetParent());

    int i;
    for (i = 0; i < node->GetChildCount(); i++)
    {
        Visit(node->GetChild(i));
    }

    if (node->GetTarget() != NULL)
    {
        Visit(node->GetTarget());
    }
    if (node->GetTargetUp() != NULL)
    {
        Visit(node->GetTargetUp());
    }

    for (i = 0; i < node->GetNodeAttributeCount(); i++)
    {
        Visit(node->GetNodeAttributeByIndex(i));
    }

    for (i = 0; i < node->GetMaterialCount(); i++)
    {
        Visit(node->GetMaterial(i));
    }
}

void Collector::VisitNodeAttribute(FbxNodeAttribute* obj)
{
    Visit(obj->GetNode());

    if (obj->Is<FbxCamera>())
        VisitCamera(dynamic_cast<FbxCamera*>(obj));
    else if (obj->Is<FbxLight>())
        VisitLight(dynamic_cast<FbxLight*>(obj));
    else if (obj->Is<FbxLayerContainer>())
        VisitLayerContainer(dynamic_cast<FbxLayerContainer*>(obj));
    else if (obj->Is<FbxNull>())
        VisitNull(dynamic_cast<FbxNull*>(obj));
    else if (obj->Is<FbxSkeleton>())
        VisitSkeleton(dynamic_cast<FbxSkeleton*>(obj));
}

void Collector::VisitSurfaceMaterial(FbxSurfaceMaterial* obj)
{
    // nothing to do
}

void Collector::VisitSurfaceLambert(FbxSurfaceLambert* obj)
{
    // nothing to do
}

void Collector::VisitSurfacePhong(FbxSurfacePhong* obj)
{
    // nothing to do
}

void Collector::VisitMesh(FbxMesh* obj)
{
    // nothing to do
}

void Collector::VisitGeometry(FbxGeometry* obj)
{
    // nothing to do
    int i;
    for (i = 0; i < obj->GetDeformerCount(); i++)
    {
        Visit(obj->GetDeformer(i));
    }

    // geometry weighted map
    // shape

    if (obj->Is<FbxMesh>())
        VisitMesh(dynamic_cast<FbxMesh*>(obj));
}

void Collector::VisitGeometryBase(FbxGeometryBase* obj)
{
    // TODO: geometry elements

    if (obj->Is<FbxGeometry>())
        VisitGeometry(dynamic_cast<FbxGeometry*>(obj));
}

void VisitLayerElementTexture(Collector* c, FbxLayerElementTexture* tex)
{
    if (tex == NULL) return;

    FbxLayerElementArrayTemplate<FbxTexture*>* tarray = &tex->GetDirectArray();

    int i;
    for (i = 0; i < tarray->GetCount(); i++)
    {
        c->Visit(tarray->GetAt(i));
    }
}

void Collector::VisitLayerContainer(FbxLayerContainer* layerContainer)
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
                Visit(marray.GetAt(i));
            }
        }

        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureEmissive));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureEmissiveFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureAmbient));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureAmbientFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureDiffuseFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureSpecular));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureNormalMap));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureSpecularFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureShininess));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureBump));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureTransparency));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureTransparencyFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureReflection));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureReflectionFactor));
        VisitLayerElementTexture(this, layer->GetTextures(FbxLayerElement::eTextureDisplacement));
    }

    if (layerContainer->Is<FbxGeometryBase>())
        VisitGeometryBase(dynamic_cast<FbxGeometryBase*>(layerContainer));
}

void Collector::VisitDocument(FbxDocument* obj)
{
    int i;
    for (i = 0; i < obj->GetRootMemberCount(); i++)
    {
        Visit(obj->GetRootMember(i));
    }

    if (obj->GetDocumentInfo() != NULL)
    {
        Visit(obj->GetDocumentInfo());
    }

    if (obj->Is<FbxScene>())
        VisitScene(dynamic_cast<FbxScene*>(obj));
}

void Collector::VisitCollection(FbxCollection* obj)
{
    int i;
    for (i = 0; i < obj->GetMemberCount(); i++)
    {
        Visit(obj->GetMember(i));
    }


    if (obj->Is<FbxDocument>())
        VisitDocument(dynamic_cast<FbxDocument*>(obj));
    else if (obj->Is<FbxAnimStack>())
        VisitAnimStack(dynamic_cast<FbxAnimStack*>(obj));
    else if (obj->Is<FbxAnimLayer>())
        VisitAnimLayer(dynamic_cast<FbxAnimLayer*>(obj));
}

void Collector::VisitAnimLayer(FbxAnimLayer* obj)
{
    // nothing to do
}

void Collector::VisitAnimStack(FbxAnimStack* obj)
{
    // nothing to do
}

void Collector::VisitAnimCurve(FbxAnimCurve* obj)
{
    // nothing to do
}

void Collector::VisitAnimCurveNode(FbxAnimCurveNode* obj)
{
    int i;
    int j;

    for (i = 0; i < obj->GetChannelsCount(); i++)
    {
        for (j = 0; j < obj->GetCurveCount(i); j++)
        {
            FbxAnimCurve* curve = obj->GetCurve(i, j);
            Visit(curve);
        }
    }
}

void Collector::VisitDeformer(FbxDeformer* obj)
{
    cout << "VisitDeformer: Not Implemented" << endl;
}


void Collector::VisitPose(FbxPose* pose)
{
    int i;
    for (i = 0; i < pose->GetCount(); i++)
    {
        Visit(pose->GetNode(i));
    }
}

void Collector::VisitSubDeformer(FbxSubDeformer* obj)
{
    cout << "VisitSubDeformer: Not Implemented" << endl;
}

void Collector::VisitTexture(FbxTexture* obj)
{
    // nothing to do
}

void Collector::VisitVideo(FbxVideo* obj)
{
    cout << "VisitVideo: Not Implemented" << endl;
}

void Collector::VisitCamera(FbxCamera* obj)
{
    cout << "VisitCamera: Not Implemented" << endl;
}

void Collector::VisitLight(FbxLight* obj)
{
    cout << "VisitLight: Not Implemented" << endl;
}

void Collector::VisitNull(FbxNull* obj)
{
    // nothing to do
}

void Collector::VisitSkeleton(FbxSkeleton* obj)
{
    cout << "VisitSkeleton: Not Implemented" << endl;
}

