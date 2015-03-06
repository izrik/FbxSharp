
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

const char* ToString(const FbxTransform::EInheritType& value)
{
    switch (value)
    {
        case FbxTransform::eInheritRrSs:    return "eInheritRrSs";
        case FbxTransform::eInheritRSrs:    return "eInheritRSrs";
        case FbxTransform::eInheritRrs:     return "eInheritRrs";
    }

    return "<<unknown EInheritType>>";
}

ostream& operator<<(ostream& os, const FbxTransform::EInheritType& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const EFbxQuatInterpMode& value)
{
    switch (value)
    {
        case eQuatInterpOff:              return "eQuatInterpOff";
        case eQuatInterpClassic:          return "eQuatInterpClassic";
        case eQuatInterpSlerp:            return "eQuatInterpSlerp";
        case eQuatInterpCubic:            return "eQuatInterpCubic";
        case eQuatInterpTangentDependent: return "eQuatInterpTangentDependent";
        case eQuatInterpCount:            return "eQuatInterpCount";
    }

    return "<<unknown EFbxQuatInterpMode>>";
}

ostream& operator<<(ostream& os, const EFbxQuatInterpMode& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const EFbxRotationOrder& value)
{
    switch (value)
    {
        case eEulerXYZ:   return "eEulerXYZ";
        case eEulerXZY:   return "eEulerXZY";
        case eEulerYZX:   return "eEulerYZX";
        case eEulerYXZ:   return "eEulerYXZ";
        case eEulerZXY:   return "eEulerZXY";
        case eEulerZYX:   return "eEulerZYX";
        case eSphericXYZ: return "eSphericXYZ";
    }

    return "<<unknown EFbxRotationOrder>>";
}

ostream& operator<<(ostream& os, const EFbxRotationOrder& value)
{
    os << ToString(value);
    return os;
}

ostream& operator<<(ostream& os, const FbxObject*& value)
{
    if (value == NULL)
        os << "<<null>>";
    else
        os <<
            value->GetUniqueID() << ", " <<
            value->GetRuntimeClassId().GetName() << ", " <<
            value->GetName();
    return os;
}


const char* ToString(const FbxNode::EShadingMode& value)
{
    switch (value)
    {
        case FbxNode::eHardShading:    return "eHardShading";
        case FbxNode::eWireFrame:      return "eWireFrame";
        case FbxNode::eFlatShading:    return "eFlatShading";
        case FbxNode::eLightShading:   return "eLightShading";
        case FbxNode::eTextureShading: return "eTextureShading";
        case FbxNode::eFullShading:    return "eFullShading";
    }

    return "<<unknown EShadingMode>>";
}

ostream& operator<<(ostream& os, const FbxNode::EShadingMode& value)
{
    os << ToString(value);
    return os;
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
        PrintObjectID(node->GetChild(i));
        cout << endl;
    }

    cout << prefix << ".Target = ";
    PrintObjectID(node->GetTarget());
    cout << endl;
    cout << prefix << ".PostTargetRotation = " << node->GetPostTargetRotation() << endl;
    cout << prefix << ".TargetUp = ";
    PrintObjectID(node->GetTargetUp());
    cout << endl;
    cout << prefix << ".TargetUpVector = " << node->GetTargetUpVector() << endl;

    cout << prefix << ".NodeAttribute = ";
    PrintObjectID(node->GetNodeAttribute());
    cout << endl;
    cout << prefix << ".NumNodeAttributes = " << node->GetNodeAttributeCount() << endl;

    FbxTransform::EInheritType inhtype;
    node->GetTransformationInheritType(inhtype);
    cout << prefix << ".TransformationInheritType = " << inhtype << endl;

    cout << prefix << ".GetCharacterLinkCount() = " << node->GetCharacterLinkCount() << endl;

    cout << prefix << ".GetMaterialCount() = " << node->GetMaterialCount() << endl;

    cout << prefix << ".LclTranslation" << node->LclTranslation.Get() << endl;
    cout << prefix << ".LclRotation" << node->LclRotation.Get() << endl;
    cout << prefix << ".LclScaling" << node->LclScaling.Get() << endl;
    cout << prefix << ".Visibility" << node->Visibility.Get() << endl;
    cout << prefix << ".VisibilityInheritance" << node->VisibilityInheritance.Get() << endl;
    cout << prefix << ".QuaternionInterpolate" << node->QuaternionInterpolate.Get() << endl;
    cout << prefix << ".RotationOffset" << node->RotationOffset.Get() << endl;
    cout << prefix << ".RotationPivot" << node->RotationPivot.Get() << endl;
    cout << prefix << ".ScalingOffset" << node->ScalingOffset.Get() << endl;
    cout << prefix << ".ScalingPivot" << node->ScalingPivot.Get() << endl;
    cout << prefix << ".TranslationActive" << node->TranslationActive.Get() << endl;
    cout << prefix << ".TranslationMin" << node->TranslationMin.Get() << endl;
    cout << prefix << ".TranslationMax" << node->TranslationMax.Get() << endl;
    cout << prefix << ".TranslationMinX" << node->TranslationMinX.Get() << endl;
    cout << prefix << ".TranslationMinY" << node->TranslationMinY.Get() << endl;
    cout << prefix << ".TranslationMinZ" << node->TranslationMinZ.Get() << endl;
    cout << prefix << ".TranslationMaxX" << node->TranslationMaxX.Get() << endl;
    cout << prefix << ".TranslationMaxY" << node->TranslationMaxY.Get() << endl;
    cout << prefix << ".TranslationMaxZ" << node->TranslationMaxZ.Get() << endl;
    cout << prefix << ".RotationOrder" << node->RotationOrder.Get() << endl;
    cout << prefix << ".RotationSpaceForLimitOnly" << node->RotationSpaceForLimitOnly.Get() << endl;
    cout << prefix << ".RotationStiffnessX" << node->RotationStiffnessX.Get() << endl;
    cout << prefix << ".RotationStiffnessY" << node->RotationStiffnessY.Get() << endl;
    cout << prefix << ".RotationStiffnessZ" << node->RotationStiffnessZ.Get() << endl;
    cout << prefix << ".AxisLen" << node->AxisLen.Get() << endl;
    cout << prefix << ".PreRotation" << node->PreRotation.Get() << endl;
    cout << prefix << ".PostRotation" << node->PostRotation.Get() << endl;
    cout << prefix << ".RotationActive" << node->RotationActive.Get() << endl;
    cout << prefix << ".RotationMin" << node->RotationMin.Get() << endl;
    cout << prefix << ".RotationMax" << node->RotationMax.Get() << endl;
    cout << prefix << ".RotationMinX" << node->RotationMinX.Get() << endl;
    cout << prefix << ".RotationMinY" << node->RotationMinY.Get() << endl;
    cout << prefix << ".RotationMinZ" << node->RotationMinZ.Get() << endl;
    cout << prefix << ".RotationMaxX" << node->RotationMaxX.Get() << endl;
    cout << prefix << ".RotationMaxY" << node->RotationMaxY.Get() << endl;
    cout << prefix << ".RotationMaxZ" << node->RotationMaxZ.Get() << endl;
    cout << prefix << ".InheritType" << node->InheritType.Get() << endl;
    cout << prefix << ".ScalingActive" << node->ScalingActive.Get() << endl;
    cout << prefix << ".ScalingMin" << node->ScalingMin.Get() << endl;
    cout << prefix << ".ScalingMax" << node->ScalingMax.Get() << endl;
    cout << prefix << ".ScalingMinX" << node->ScalingMinX.Get() << endl;
    cout << prefix << ".ScalingMinY" << node->ScalingMinY.Get() << endl;
    cout << prefix << ".ScalingMinZ" << node->ScalingMinZ.Get() << endl;
    cout << prefix << ".ScalingMaxX" << node->ScalingMaxX.Get() << endl;
    cout << prefix << ".ScalingMaxY" << node->ScalingMaxY.Get() << endl;
    cout << prefix << ".ScalingMaxZ" << node->ScalingMaxZ.Get() << endl;
    cout << prefix << ".GeometricTranslation" << node->GeometricTranslation.Get() << endl;
    cout << prefix << ".GeometricRotation" << node->GeometricRotation.Get() << endl;
    cout << prefix << ".GeometricScaling" << node->GeometricScaling.Get() << endl;
    cout << prefix << ".MinDampRangeX" << node->MinDampRangeX.Get() << endl;
    cout << prefix << ".MinDampRangeY" << node->MinDampRangeY.Get() << endl;
    cout << prefix << ".MinDampRangeZ" << node->MinDampRangeZ.Get() << endl;
    cout << prefix << ".MaxDampRangeX" << node->MaxDampRangeX.Get() << endl;
    cout << prefix << ".MaxDampRangeY" << node->MaxDampRangeY.Get() << endl;
    cout << prefix << ".MaxDampRangeZ" << node->MaxDampRangeZ.Get() << endl;
    cout << prefix << ".MinDampStrengthX" << node->MinDampStrengthX.Get() << endl;
    cout << prefix << ".MinDampStrengthY" << node->MinDampStrengthY.Get() << endl;
    cout << prefix << ".MinDampStrengthZ" << node->MinDampStrengthZ.Get() << endl;
    cout << prefix << ".MaxDampStrengthX" << node->MaxDampStrengthX.Get() << endl;
    cout << prefix << ".MaxDampStrengthY" << node->MaxDampStrengthY.Get() << endl;
    cout << prefix << ".MaxDampStrengthZ" << node->MaxDampStrengthZ.Get() << endl;
    cout << prefix << ".PreferedAngleX" << node->PreferedAngleX.Get() << endl;
    cout << prefix << ".PreferedAngleY" << node->PreferedAngleY.Get() << endl;
    cout << prefix << ".PreferedAngleZ" << node->PreferedAngleZ.Get() << endl;
    cout << prefix << ".LookAtProperty" << node->LookAtProperty.Get() << endl;
    cout << prefix << ".UpVectorProperty" << node->UpVectorProperty.Get() << endl;
    cout << prefix << ".Show" << node->Show.Get() << endl;
    cout << prefix << ".NegativePercentShapeSupport" << node->NegativePercentShapeSupport.Get() << endl;
    cout << prefix << ".DefaultAttributeIndex" << node->DefaultAttributeIndex.Get() << endl;
    cout << prefix << ".Freeze" << node->Freeze.Get() << endl;
    cout << prefix << ".LODBox" << node->LODBox.Get() << endl;

    cout << prefix << ".GetVisibility()" << node->GetVisibility() << endl;
    cout << prefix << ".GetShadingMode()" << node->GetShadingMode() << endl;

    // pivot management
    //throw "Not Implemented";

}

void PrintNodeAttribute(FbxNodeAttribute* obj, const char* prefix)
{
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


