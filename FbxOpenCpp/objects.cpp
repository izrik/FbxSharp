
#include <iostream>
#include <fbxsdk.h>
#include "common.h"

using namespace std;

void PrintObjectID(FbxObject* obj)
{
    if (obj == NULL)
        cout << "<<null>>";
    else
        cout <<
            obj->GetUniqueID() << ", " <<
            obj->GetRuntimeClassId().GetName() << ", " <<
            obj->GetName();
}

void PrintObject(FbxObject* obj, const char* prefix)
{
    char prefixn[1024];
    if (prefix == NULL || *prefix == 0)
    {
        sprintf(prefixn, "%lli", obj->GetUniqueID());
        prefix = prefixn;
    }

//    char mm[1024];
//    sprintf(mm, "%p", (void*)obj);
//    cout << prefix << ".Pointer = " << mm << endl;
    cout << prefix << ".Name = " << obj->GetName() << endl;
    cout << prefix << ".ClassId = " << obj->GetRuntimeClassId().GetName() << endl;
    cout << prefix << ".UniqueId = " << obj->GetUniqueID() << endl;
    cout << prefix << ".NumSrcObjects = " << obj->GetSrcObjectCount() << endl;
    int i;
    for (i = 0; i < obj->GetSrcObjectCount(); i++)
    {
        char n[1024];
//        sprintf(n, "%s.SrcObj[%i]", prefix, i);
//        PrintObject(obj->GetSrcObject(i), n);
        FbxObject* srcObj = obj->GetSrcObject(i);
        cout << prefix << ".SrcObject ";
        PrintObjectID(srcObj);
        cout << endl;
    }
    cout << prefix << ".NumDstObjects = " << obj->GetDstObjectCount() << endl;
    for (i = 0; i < obj->GetDstObjectCount(); i++)
    {
        char n[1024];
//        sprintf(n, "%s.SrcObj[%i]", prefix, i);
//        PrintObject(obj->GetSrcObject(i), n);
        FbxObject* dstObj = obj->GetDstObject(i);
        cout << prefix << ".DstObject ";
        PrintObjectID(dstObj);
        cout << endl;
    }

    FbxProperty prop = obj->GetFirstProperty();
    int n = 0;
    while (prop.IsValid())
    {
        n++;
        prop = obj->GetNextProperty(prop);
    }
    cout << prefix << ".Propreties = " << n << endl;

    prop = obj->GetFirstProperty();
    n = 0;
    while (prop.IsValid())
    {
        char nn[1024];
        sprintf(nn, "%s.Property[%i]", prefix, n);
        PrintProperty(&prop, nn);
        n++;
        prop = obj->GetNextProperty(prop);
    }

    cout << prefix << ".NumSrcProperties = " << obj->GetSrcPropertyCount() << endl;
    cout << prefix << ".NumDstProperties = " << obj->GetDstPropertyCount() << endl;
    if (obj->RootProperty.IsValid())
    {
        char nn[1024];
        sprintf(nn, "%s.RootProperty", prefix);
        PrintProperty(&obj->RootProperty, nn);
    }
    
    if (obj->Is<FbxScene>())
        PrintScene(dynamic_cast<FbxScene*>(obj), prefix);
    else if (obj->Is<FbxAnimLayer>())
        PrintAnimLayer(dynamic_cast<FbxAnimLayer*>(obj), prefix);
    else if (obj->Is<FbxAnimStack>())
        PrintAnimStack(dynamic_cast<FbxAnimStack*>(obj), prefix);
    else if (obj->Is<FbxAnimCurve>())
        PrintAnimCurve(dynamic_cast<FbxAnimCurve*>(obj), prefix);
    else if (obj->Is<FbxAnimCurveNode>())
        PrintAnimCurveNode(dynamic_cast<FbxAnimCurveNode*>(obj), prefix);
    else if (obj->Is<FbxDeformer>())
        PrintDeformer(dynamic_cast<FbxDeformer*>(obj), prefix);
    else if (obj->Is<FbxNode>())
        PrintNode(dynamic_cast<FbxNode*>(obj), prefix);
    else if (obj->Is<FbxNodeAttribute>())
        PrintNodeAttribute(dynamic_cast<FbxNodeAttribute*>(obj), prefix);
    else if (obj->Is<FbxPose>())
        PrintPose(dynamic_cast<FbxPose*>(obj), prefix);
    else if (obj->Is<FbxSubDeformer>())
        PrintSubDeformer(dynamic_cast<FbxSubDeformer*>(obj), prefix);
    else if (obj->Is<FbxSurfaceMaterial>())
        PrintSurfaceMaterial(dynamic_cast<FbxSurfaceMaterial*>(obj), prefix);
    else if (obj->Is<FbxTexture>())
        PrintTexture(dynamic_cast<FbxTexture*>(obj), prefix);
    else if (obj->Is<FbxVideo>())
        PrintVideo(dynamic_cast<FbxVideo*>(obj), prefix);
    else
        cout << "Unknown object class: " << obj->GetRuntimeClassId().GetName() << endl;
}



void PrintScene(FbxScene* scene, const char* prefix)
{
    int i;
    char n[1024];

    cout << prefix << ".NumGenericNodes = " << scene->GetCharacterCount() << endl;
    cout << prefix << ".NumCharacters = " << scene->GetCharacterCount() << endl;
    cout << prefix << ".NumCharacterPoses = " << scene->GetCharacterPoseCount() << endl;
    cout << prefix << ".NumPoses = " << scene->GetPoseCount() << endl;
    for (i = 0; i < scene->GetPoseCount(); i++)
    {
        sprintf(n, "%s.Pose[%i]", prefix, i);
        PrintObject(scene->GetPose(i), n);
    }
    cout << prefix << ".NumMaterials = " << scene->GetMaterialCount() << endl;
    for (i = 0; i < scene->GetMaterialCount(); i++)
    {
        sprintf(n, "%s.Material[%i]", prefix, i);
        PrintObject(scene->GetMaterial(i), n);
    }
    cout << prefix << ".NumTextures = " << scene->GetTextureCount() << endl;
    for (i = 0; i < scene->GetTextureCount(); i++)
    {
        sprintf(n, "%s.Texture[%i]", prefix, i);
        PrintObject(scene->GetTexture(i), n);
    }
    cout << prefix << ".NumNodes = " << scene->GetNodeCount() << endl;
    for (i = 0; i < scene->GetNodeCount(); i++)
    {
        sprintf(n, "%s.Node[%i]", prefix, i);
        PrintObject(scene->GetNode(i), n);
    }
    cout << prefix << ".NumGeometry = " << scene->GetGeometryCount() << endl;
    for (i = 0; i < scene->GetGeometryCount(); i++)
    {
        sprintf(n, "%s.Geometry[%i]", prefix, i);
        PrintObject(scene->GetGeometry(i), n);
    }
    cout << prefix << ".NumVideo = " << scene->GetVideoCount() << endl;
    for (i = 0; i < scene->GetVideoCount(); i++)
    {
        sprintf(n, "%s.Video[%i]", prefix, i);
        PrintObject(scene->GetVideo(i), n);
    }

    cout << prefix << ".RootNode = ";
    PrintObjectID(scene->GetRootNode());
    cout << endl;
}

void PrintAnimLayer(FbxAnimLayer* animLayer, const char* prefix)
{
    throw "Not Implemented";
}

void PrintAnimStack(FbxAnimStack* animStack, const char* prefix)
{
    throw "Not Implemented";
}

void PrintAnimCurve(FbxAnimCurve* animCurve, const char* prefix)
{
    throw "Not Implemented";
}

void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode, const char* prefix)
{
    throw "Not Implemented";
}

void PrintDeformer(FbxDeformer* deformer, const char* prefix)
{
    throw "Not Implemented";
}

void PrintNode(FbxNode* node, const char* prefix)
{

    cout << prefix << ".Parent = ";
    PrintObjectID(node->GetParent());
    cout << endl;

    cout << prefix << ".NumChildren = " << node->GetChildCount() << endl;
    int i;
    for (i = 0; i < node->GetChildCount(); i++)
    {
        cout << prefix << ".Child[" << i << "] = ";
        PrintObjectID(node->GetParent());
        cout << endl;
    }
    
    throw "Not Implemented";
}

void PrintNodeAttribute(FbxNodeAttribute* obj, const char* prefix)
{
    throw "Not Implemented";
    if (obj->Is<FbxCamera>())
        PrintCamera(dynamic_cast<FbxCamera*>(obj), prefix);
    else if (obj->Is<FbxLight>())
        PrintLight(dynamic_cast<FbxLight*>(obj), prefix);
    else if (obj->Is<FbxMesh>())
        PrintMesh(dynamic_cast<FbxMesh*>(obj), prefix);
    else if (obj->Is<FbxNull>())
        PrintNull(dynamic_cast<FbxNull*>(obj), prefix);
    else if (obj->Is<FbxSkeleton>())
        PrintSkeleton(dynamic_cast<FbxSkeleton*>(obj), prefix);
    else
        cout << "Unknown node attribute class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintCamera(FbxCamera* camera, const char* prefix)
{
    throw "Not Implemented";
}

void PrintLight(FbxLight* light, const char* prefix)
{
    throw "Not Implemented";
}

void PrintMesh(FbxMesh* mesh, const char* prefix)
{
    throw "Not Implemented";
}

void PrintNull(FbxNull* null, const char* prefix)
{
    throw "Not Implemented";
}

void PrintSkeleton(FbxSkeleton* skeleton, const char* prefix)
{
    throw "Not Implemented";
}

void PrintPose(FbxPose* pose, const char* prefix)
{
    cout << prefix << ".IsBindPose = " << pose->IsBindPose() << endl;
    cout << prefix << ".IsRestPose = " << pose->IsRestPose() << endl;
    cout << prefix << ".Count = " << pose->GetCount() << endl;
    int i;
    for (i = 0; i < pose->GetCount(); i++)
    {
        cout << prefix << ".Node[" << i << "] = ";
        PrintObjectID(pose->GetNode(i));
        cout << endl;
        cout << prefix << ".Node[" << i << "].IsLocalMatrix = " << pose->IsLocalMatrix(i) << endl;
    }
}

void PrintSubDeformer(FbxSubDeformer* subDeformer, const char* prefix)
{
    throw "Not Implemented";
}

void PrintSurfaceMaterial(FbxSurfaceMaterial* obj, const char* prefix)
{
    cout << prefix << ".ShadingModel = " << obj->ShadingModel.Get().Buffer() << endl;
    cout << prefix << ".MultiLayer = " << obj->MultiLayer.Get() << endl;
    
    if (obj->Is<FbxSurfaceLambert>())
        PrintSurfaceLambert(dynamic_cast<FbxSurfaceLambert*>(obj), prefix);
    else
        cout << "Unknown surface material class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfaceLambert(FbxSurfaceLambert* obj, const char* prefix)
{
    FbxDouble3 s;

    s = obj->Emissive.Get();
    cout << prefix << ".Emissive = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".EmissiveFactor = " << obj->EmissiveFactor.Get() << endl;
    s = obj->Ambient.Get();
    cout << prefix << ".Ambient = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".AmbientFactor = " << obj->AmbientFactor.Get() << endl;
    s = obj->Diffuse.Get();
    cout << prefix << ".Diffuse = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".DiffuseFactor = " << obj->DiffuseFactor.Get() << endl;
    s = obj->NormalMap.Get();
    cout << prefix << ".NormalMap = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    s = obj->Bump.Get();
    cout << prefix << ".Bump = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".BumpFactor = " << obj->BumpFactor.Get() << endl;
    s = obj->TransparentColor.Get();
    cout << prefix << ".TransparentColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".TransparencyFactor = " << obj->TransparencyFactor.Get() << endl;
    s = obj->DisplacementColor.Get();
    cout << prefix << ".DisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".DisplacementFactor = " << obj->DisplacementFactor.Get() << endl;
    s = obj->VectorDisplacementColor.Get();
    cout << prefix << ".VectorDisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".VectorDisplacementFactor = " << obj->VectorDisplacementFactor.Get() << endl;

    if (obj->Is<FbxSurfacePhong>())
        PrintSurfacePhong(dynamic_cast<FbxSurfacePhong*>(obj), prefix);
    else
        cout << "Unknown surface lambert class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfacePhong(FbxSurfacePhong* obj, const char* prefix)
{
    FbxDouble3 s = obj->Specular.Get();
    cout << prefix << ".Specular = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".SpecularFactor = " << obj->SpecularFactor.Get() << endl;
    cout << prefix << ".Shininess = " << obj->Shininess.Get() << endl;
    s = obj->Reflection.Get();
    cout << prefix << ".Reflection = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << prefix << ".ReflectionFactor = " << obj->ReflectionFactor.Get() << endl;
}

void PrintVideo(FbxVideo* obj, const char* prefix)
{
    throw "Not Implemented";
}


