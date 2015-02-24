
#include <iostream>

//#include "assimp/Importer.hpp"
//#include "assimp/postprocess.h"
//#include "assimp/scene.h"
//#include "assimp/cimport.h"

#include <fbxsdk.h>

using namespace std;

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

int main (int argc, char *argv[])
{
//    aiLogStream ailog;
//    ailog = aiGetPredefinedLogStream(aiDefaultLogStream_STDOUT,NULL);
//    aiAttachLogStream(&ailog);

//    Assimp::Importer importer;
//
    const char* filename = "model.fbx";
//    char dirname[1024];
//    getcwd(dirname, 1024);
//    cout << "current directory: " << dirname << endl;
//    cout << "Loading file with assimp" << endl;
//    const aiScene* scene = importer.ReadFile(
//        filename,
//        aiProcess_Triangulate | aiProcess_JoinIdenticalVertices);
//
//    cout << "file loaded" << endl;
//    bool hasAnimations = scene->HasAnimations();
//    cout << "..." << endl;
//    int numAnimations = scene->mNumAnimations;
//    cout << "..." << endl;
//    cout << numAnimations << " animations" << endl;









    cout << endl;

    cout << "Loading file with fbxsdk" << endl;
    




    FbxManager* pManager = FbxManager::Create();
    FbxScene* pScene = FbxScene::Create(pManager, "My Scene");

    int lFileMajor, lFileMinor, lFileRevision;
    int lSDKMajor,  lSDKMinor,  lSDKRevision;
    //int lFileFormat = -1;
    int i, lAnimStackCount;
    bool lStatus;
    char lPassword[1024];

    // Get the file version number generate by the FBX SDK.
    FbxManager::GetFileFormatVersion(lSDKMajor, lSDKMinor, lSDKRevision);

    // Create an importer.
    FbxImporter* lImporter = FbxImporter::Create(pManager,"");

    // Initialize the importer by providing a filename.
    const bool lImportStatus = lImporter->Initialize(filename, -1, pManager->GetIOSettings());
    lImporter->GetFileVersion(lFileMajor, lFileMinor, lFileRevision);

    if( !lImportStatus )
    {
        FBXSDK_printf("Call to FbxImporter::Initialize() failed.\n");
        FBXSDK_printf("Error returned: %s\n\n", lImporter->GetStatus().GetErrorString());

//        if (lImporter->GetLastErrorID() == FbxIOBase::eFileVersionNotSupportedYet ||
//            lImporter->GetLastErrorID() == FbxIOBase::eFileVersionNotSupportedAnymore)
//        {
            FBXSDK_printf("FBX file format version for this FBX SDK is %d.%d.%d\n", lSDKMajor, lSDKMinor, lSDKRevision);
            FBXSDK_printf("FBX file format version for file '%s' is %d.%d.%d\n\n", filename, lFileMajor, lFileMinor, lFileRevision);
//        }

        return false;
    }

    lImporter->Import(pScene);

    printf("file version info: %i.%i.%i\n", lFileMajor, lFileMinor, lFileRevision);
    PrintObject(pScene);

//    // get the number of animation stacks
//    int numStacks = pScene->GetSrcObjectCount(FBX_TYPE(FbxAnimStack));
//    cout << "num stacks: " << numStacks << endl;
//    int n = 0;
//    // get the nth animation stack
//    FbxAnimStack* pAnimStack = FbxCast<FbxAnimStack>(pScene->GetSrcObject(FBX_TYPE(FbxAnimStack), n));
//    // get the number of animation layers
//    int numAnimLayers = pAnimStack->GetMemberCount(FBX_TYPE(FbxAnimLayer));
//    cout << "num layers: " << numAnimLayers << endl;
//    // get the nth animation layer
//    FbxAnimLayer* lAnimLayer = pAnimStack->GetMember(FBX_TYPE(FbxAnimLayer), n);

    return 0;
}

void PrintObjectID(FbxObject* obj)
{
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

const char* GetTypeName(EFbxType tid)
{
    switch (tid)
    {
        case eFbxUndefined: return "eFbxUndefined";
        case eFbxChar:      return "eFbxChar";
        case eFbxUChar:     return "eFbxUChar";
        case eFbxShort:     return "eFbxShort";
        case eFbxUShort:    return "eFbxUShort";
        case eFbxUInt:      return "eFbxUInt";
        case eFbxLongLong:  return "eFbxLongLong";
        case eFbxULongLong: return "eFbxULongLong";
        case eFbxHalfFloat: return "eFbxHalfFloat";
        case eFbxBool:      return "eFbxBool";
        case eFbxInt:       return "eFbxInt";
        case eFbxFloat:     return "eFbxFloat";
        case eFbxDouble:    return "eFbxDouble";
        case eFbxDouble2:   return "eFbxDouble2";
        case eFbxDouble3:   return "eFbxDouble3";
        case eFbxDouble4:   return "eFbxDouble4";
        case eFbxDouble4x4: return "eFbxDouble4x4";
        case eFbxEnum:      return "eFbxEnum";
        case eFbxString:    return "eFbxString";
        case eFbxTime:      return "eFbxTime";
        case eFbxReference: return "eFbxReference";
        case eFbxBlob:      return "eFbxBlob";
        case eFbxDistance:  return "eFbxDistance";
        case eFbxDateTime:  return "eFbxDateTime";
        case eFbxTypeCount: return "eFbxTypeCount";
    }

    return "<<unknown>>";
}

void PrintProperty(FbxProperty* prop, const char* prefix)
{
    cout << prefix << ".Name = " << prop->GetName() << endl;
    FbxDataType type = prop->GetPropertyDataType();
    cout << prefix << ".Type = " << type.GetName() << " (" << GetTypeName(type.GetType()) << ")" << endl;
    cout << prefix << ".HierName = " << prop->GetHierarchicalName() << endl;
    cout << prefix << ".Label = " << prop->GetLabel() << endl;

    char n[1024];
    int i;
    for (i = 0; i < 1024; i++)
    {
        n[i] = 0;
    }
    char ch;
    unsigned char uch;
    unsigned int ui;
    short sh;
    unsigned short ush;
    long long ll;
    unsigned long long ull;
    bool b;
    float f;
    double d;
    FbxString fstr;
    switch (type.GetType())
    {
        case eFbxUndefined:
            break;
        case eFbxChar:
            ch = prop->Get<char>();
            sprintf(n, "%i ('%c')", (int)ch, ch);
            break;
        case eFbxUChar:
            uch = prop->Get<unsigned char>();
            sprintf(n, "%i ('%c')", (unsigned int)uch, uch);
            break;
        case eFbxShort:
            sh = prop->Get<short>();
            sprintf(n, "%i", (int)sh);
            break;
        case eFbxUShort:
            ush = prop->Get<unsigned short>();
            sprintf(n, "%ui", (unsigned int)ush);
            break;
        case eFbxUInt:
            ui = prop->Get<unsigned int>();
            sprintf(n, "%ui", ui);
            break;
        case eFbxLongLong:
            ll = prop->Get<long long>();
            sprintf(n, "%lli", ll);
            break;
        case eFbxULongLong:
            ull = prop->Get<unsigned long long>();
            sprintf(n, "%llu", ull);
            break;
        case eFbxHalfFloat:
            break;
        case eFbxBool:
            b = prop->Get<bool>();
            if (b)
                sprintf(n, "true");
            else
                sprintf(n, "true");
            break;
        case eFbxInt:
            i = prop->Get<int>();
            sprintf(n, "%i", i);
            break;
        case eFbxFloat:
            f = prop->Get<float>();
            sprintf(n, "%f", f);
            break;
        case eFbxDouble:
            d = prop->Get<double>();
            sprintf(n, "%lf", d);
            break;
        case eFbxDouble2:
        case eFbxDouble3:
        case eFbxDouble4:
        case eFbxDouble4x4:
        case eFbxEnum:
            break;
        case eFbxString:
            fstr = prop->Get<FbxString>();
            sprintf(n, "%s", fstr.Buffer());
            break;
        case eFbxTime:
        case eFbxReference:
//            FbxObject* obj;
//            obj = prop->Get<FbxObject*>();
//            cout << prefix << ".Value = " << obj->GetRuntimeClassId().GetName() << ", uid=" << obj->GetUniqueID() << endl;
//            break;
        case eFbxBlob:
        case eFbxDistance:
        case eFbxDateTime:
        case eFbxTypeCount:
            break;
    }
    if (n[0])
    {
        cout << prefix << ".Value = " << n << endl;
    }
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

ostream& operator<<(ostream& os, const FbxDouble2& value)
{
    os << value[0] << ", " << value[1];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble3& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble4& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2] << ", " << value[3];
    return os;
}

const char* ToString(const FbxFileTexture::ETextureUse6& value)
{
    switch (value)
    {
        case FbxFileTexture::eTEXTURE_USE_6_STANDARD:                   return "eTEXTURE_USE_6_STANDARD";
        case FbxFileTexture::eTEXTURE_USE_6_SPHERICAL_REFLEXION_MAP:    return "eTEXTURE_USE_6_SPHERICAL_REFLEXION_MAP";
        case FbxFileTexture::eTEXTURE_USE_6_SPHERE_REFLEXION_MAP:       return "eTEXTURE_USE_6_SPHERE_REFLEXION_MAP";
        case FbxFileTexture::eTEXTURE_USE_6_SHADOW_MAP:                 return "eTEXTURE_USE_6_SHADOW_MAP";
        case FbxFileTexture::eTEXTURE_USE_6_LIGHT_MAP:                  return "eTEXTURE_USE_6_LIGHT_MAP";
        case FbxFileTexture::eTEXTURE_USE_6_BUMP_NORMAL_MAP:            return "eTEXTURE_USE_6_BUMP_NORMAL_MAP";
    }

    return "<<unknown ETextureUse6>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::ETextureUse6& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EUnifiedMappingType& value)
{
    switch (value)
    {
        case FbxFileTexture::eUMT_UV:           return "eUMT_UV";
        case FbxFileTexture::eUMT_XY:           return "eUMT_XY";
        case FbxFileTexture::eUMT_YZ:           return "eUMT_YZ";
        case FbxFileTexture::eUMT_XZ:           return "eUMT_XZ";
        case FbxFileTexture::eUMT_SPHERICAL:    return "eUMT_SPHERICAL";
        case FbxFileTexture::eUMT_CYLINDRICAL:  return "eUMT_CYLINDRICAL";
        case FbxFileTexture::eUMT_ENVIRONMENT:  return "eUMT_ENVIRONMENT";
        case FbxFileTexture::eUMT_PROJECTION:   return "eUMT_PROJECTION";
        case FbxFileTexture::eUMT_BOX:          return "eUMT_BOX";
        case FbxFileTexture::eUMT_FACE:         return "eUMT_FACE";
        case FbxFileTexture::eUMT_NO_MAPPING:   return "eUMT_NO_MAPPING";
    }

    return "<<unknown EUnifiedMappingType>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EUnifiedMappingType& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EWrapMode& value)
{
    switch (value)
    {
        case FbxFileTexture::eRepeat:   return "eRepeat";
        case FbxFileTexture::eClamp:    return "eClampXY";
    }

    return "<<unknown EWrapMode>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EWrapMode& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EBlendMode& value)
{
    switch (value)
    {
        case FbxFileTexture::eTranslucent:  return "eTranslucent";
        case FbxFileTexture::eAdditive:     return "eAdditive";
        case FbxFileTexture::eModulate:     return "eModulate";
        case FbxFileTexture::eModulate2:    return "eModulate2";
        case FbxFileTexture::eOver:         return "eOver";
    }

    return "<<unknown EBlendMode>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EBlendMode& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EAlphaSource& value)
{
    switch (value)
    {
        case FbxFileTexture::eNone:         return "eNone";
        case FbxFileTexture::eRGBIntensity: return "eRGBIntensity";
        case FbxFileTexture::eBlack:        return "eBlack";
    }

    return "<<unknown EAlphaSource>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EAlphaSource& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EMappingType& value)
{
    switch (value)
    {
        case FbxFileTexture::eNull:         return "eNull";
        case FbxFileTexture::ePlanar:       return "ePlanar";
        case FbxFileTexture::eSpherical:    return "eSpherical";
        case FbxFileTexture::eCylindrical:  return "eCylindrical";
        case FbxFileTexture::eBox:          return "eBox";
        case FbxFileTexture::eFace:         return "eFace";
        case FbxFileTexture::eUV:           return "eUV";
        case FbxFileTexture::eEnvironment:  return "eEnvironment";
    }

    return "<<unknown EMappingType>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EMappingType& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::EPlanarMappingNormal& value)
{
    switch (value)
    {
        case FbxFileTexture::ePlanarNormalX:    return "ePlanarNormalX";
        case FbxFileTexture::ePlanarNormalY:    return "ePlanarNormalY";
        case FbxFileTexture::ePlanarNormalZ:    return "ePlanarNormalZ";
    }

    return "<<unknown EPlanarMappingNormal>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::EPlanarMappingNormal& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const FbxFileTexture::ETextureUse& value)
{
    switch (value)
    {
        case FbxFileTexture::eStandard:                 return "eStandard";
        case FbxFileTexture::eShadowMap:                return "eShadowMap";
        case FbxFileTexture::eLightMap:                 return "eLightMap";
        case FbxFileTexture::eSphericalReflectionMap:   return "eSphericalReflectionMap";
        case FbxFileTexture::eSphereReflectionMap:      return "eSphereReflectionMap";
        case FbxFileTexture::eBumpNormalMap:            return "eBumpNormalMap";
    }

    return "<<unknown ETextureUse>>";
}

ostream& operator<<(ostream& os, const FbxFileTexture::ETextureUse& value)
{
    os << ToString(value);
    return os;
}

void PrintTexture(FbxTexture* obj, const char* prefix)
{
    cout << prefix << ".TextureTypeUse = " << obj->TextureTypeUse.Get() << endl;
    cout << prefix << ".Alpha = " << obj->Alpha.Get() << endl;
    cout << prefix << ".CurrentMappingType = " << obj->CurrentMappingType.Get() << endl;
    cout << prefix << ".WrapModeU = " << obj->WrapModeU.Get() << endl;
    cout << prefix << ".WrapModeV = " << obj->WrapModeV.Get() << endl;
    cout << prefix << ".UVSwap? " << obj->UVSwap.Get() << endl;
    cout << prefix << ".PremultiplyAlpha? " << obj->PremultiplyAlpha.Get() << endl;
    cout << prefix << ".Translation = " << obj->Translation.Get() << endl;
    cout << prefix << ".Rotation = " << obj->Rotation.Get() << endl;
    cout << prefix << ".Scaling = " << obj->Scaling.Get() << endl;
    cout << prefix << ".RotationPivot = " << obj->RotationPivot.Get() << endl;
    cout << prefix << ".ScalingPivot = " << obj->ScalingPivot.Get() << endl;
    cout << prefix << ".CurrentTextureBlendMode = " << obj->CurrentTextureBlendMode.Get() << endl;
    cout << prefix << ".UVSet = " << obj->UVSet.Get().Buffer() << endl;
    
    cout << prefix << ".AlphaSource = " << obj->GetAlphaSource() << endl;

    cout << prefix << ".CroppingLeft = " << obj->GetCroppingLeft() << endl;
    cout << prefix << ".CroppingTop = " << obj->GetCroppingTop() << endl;
    cout << prefix << ".CroppingRight = " << obj->GetCroppingRight() << endl;
    cout << prefix << ".CroppingBottom = " << obj->GetCroppingBottom() << endl;
    
    cout << prefix << ".MappingType = " << obj->GetMappingType() << endl;
    cout << prefix << ".PlanarMappingNormal = " << obj->GetPlanarMappingNormal() << endl;
    cout << prefix << ".TextureUse = " << obj->GetTextureUse() << endl;
    cout << prefix << ".BlendMode = " << obj->GetBlendMode() << endl;
}

void PrintVideo(FbxVideo* obj, const char* prefix)
{
    throw "Not Implemented";
}


