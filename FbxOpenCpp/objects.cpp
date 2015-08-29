
#include <iostream>
#include <fbxsdk.h>
#include "common.h"
#include <set>
#include <iomanip>
#include "Collector.h"
#include <algorithm>

using namespace std;

bool sort_by_id(FbxObject* a, FbxObject* b)
{
    if (a == NULL)
    {
        cout << "sort_by_id a is NULL" << endl;
    }
    if (b == NULL)
    {
        cout << "sort_by_id b is NULL" << endl;
    }

    if (a == NULL && b == NULL) return false;
    if (a == NULL) return false;
    if (b == NULL) return true;

    return (a->GetUniqueID() < b->GetUniqueID());
}

void PrintObjectGraph(FbxObject* obj)
{
    Collector c;

    c.Visit(obj);

    cout << endl;

    vector<FbxObject*>& objs = c.Objects;
    sort(objs.begin(), objs.end(), sort_by_id);

    vector<FbxObject*>::iterator it;
    for (it = objs.begin(); it != objs.end(); ++it)
    {
        PrintObject(*it);
    }
}

void PrintObjectID(FbxObject* obj)
{
    if (obj == NULL)
        cout << "<<null>>";
    else
        cout <<
            "$" << obj->GetUniqueID() << ", " <<
            obj->GetRuntimeClassId().GetName() << ", " <<
            quote(obj->GetName());
}

std::string id(FbxObject* obj)
{
    if (obj == NULL) return "<<null>>";

    std::stringstream ss;
    ss <<   "$" << obj->GetUniqueID() << ", " <<
            obj->GetRuntimeClassId().GetName() << ", " <<
            quote(obj->GetName());

    return ss.str();
}

void PrintPropertyID(FbxProperty* prop)
{
    if (prop == NULL)
        cout << "<<null>>";
    else if (!prop->IsValid())
    {
        cout << "<<invalid>>";
    }
    else
    {
        FbxObject* pobj = prop->GetFbxObject();
        PrintObjectID(pobj);
        cout << " -> " << quote(prop->GetName()) << " : " << prop->GetPropertyDataType();
    }
}

void PrintObject(FbxObject* obj, bool branch, bool printProperties)
{
    cout << "$"; PrintObjectID(obj); cout << endl;  // extra $ for easy text search
    cout << "    Name = " << quote(obj->GetName()) << endl;
    cout << "      GetNameWithoutNameSpacePrefix = " << quote(obj->GetNameWithoutNameSpacePrefix()) << endl;
    cout << "      GetNameWithNameSpacePrefix = " << quote(obj->GetNameWithNameSpacePrefix()) << endl;
    cout << "      GetInitialName = " << quote(obj->GetInitialName()) << endl;
    cout << "      GetNameSpaceOnly = " << quote(obj->GetNameSpaceOnly()) << endl;
    FbxArray<FbxString*> namespaces = obj->GetNameSpaceArray(':');
    cout << "      GetNameSpaceArray (" << namespaces.GetCount() << ")" << endl;
    int i;
    for (i = 0; i < namespaces.GetCount(); i++)
    {
        FbxString* ns = namespaces.GetAt(i);
        cout << "        # " << i << " " << quote(*ns) << endl;
    }
    cout << "      GetNameOnly = " << quote(obj->GetNameOnly()) << endl;
    cout << "      GetNameSpacePrefix = " << quote(obj->GetNameSpacePrefix()) << endl;
    cout << "    ClassId = " << obj->GetRuntimeClassId().GetName() << endl;
    cout << "    UniqueId = " << obj->GetUniqueID() << endl;
    cout << "    GetScene() = "; PrintObjectID(obj->GetScene()); cout << endl;
    cout << "    GetDocument() = "; PrintObjectID(obj->GetDocument()); cout << endl;
    cout << "    GetRootDocument() = "; PrintObjectID(obj->GetRootDocument()); cout << endl;

    if (printProperties)
    {
        cout << "    SrcObjectCount = " << obj->GetSrcObjectCount() << endl;
        for (i = 0; i < obj->GetSrcObjectCount(); i++)
        {
            FbxObject* srcObj = obj->GetSrcObject(i);
            cout << "        #" << i << " ";
            PrintObjectID(srcObj);
            cout << endl;
        }
        cout << "    DstObjectCount = " << obj->GetDstObjectCount() << endl;
        for (i = 0; i < obj->GetDstObjectCount(); i++)
        {
            FbxObject* dstObj = obj->GetDstObject(i);
            cout << "        #" << i << " ";
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
        cout << "    Properties " << n << endl;

        prop = obj->GetFirstProperty();
        n = 0;
        while (prop.IsValid())
        {
            cout << "        #" << n << " ";
            PrintPropertyID(&prop); cout << endl;
            PrintProperty(&prop, true);
            n++;
            prop = obj->GetNextProperty(prop);
        }

        cout << "    SrcPropertyCount = " << obj->GetSrcPropertyCount() << endl;
        for (i = 0; i < obj->GetSrcPropertyCount(); i++)
        {
            FbxProperty prop = obj->GetSrcProperty(i);
            cout << "        #" << i << " ";
            PrintPropertyID(&prop);
            cout << endl;
        }
        cout << "    DstPropertyCount = " << obj->GetDstPropertyCount() << endl;
        for (i = 0; i < obj->GetDstPropertyCount(); i++)
        {
            FbxProperty prop = obj->GetDstProperty(i);
            cout << "        #" << i << " ";
            PrintPropertyID(&prop);
            cout << endl;
        }
        if (obj->RootProperty.IsValid())
        {
            cout << "    RootProperty ";
            PrintPropertyID(&obj->RootProperty); cout << endl; 
            PrintProperty(&obj->RootProperty);
        }
    }

    if (branch)
    {
        if (obj->Is<FbxCollection>())
            PrintCollection(FbxCast<FbxCollection>(obj));
        else if (obj->Is<FbxAnimCurve>())
            PrintAnimCurve(FbxCast<FbxAnimCurve>(obj));
        else if (obj->Is<FbxAnimCurveNode>())
            PrintAnimCurveNode(FbxCast<FbxAnimCurveNode>(obj));
        else if (obj->Is<FbxDeformer>())
            PrintDeformer(FbxCast<FbxDeformer>(obj));
        else if (obj->Is<FbxNode>())
            PrintNode(FbxCast<FbxNode>(obj));
        else if (obj->Is<FbxNodeAttribute>())
            PrintNodeAttribute(FbxCast<FbxNodeAttribute>(obj));
        else if (obj->Is<FbxPose>())
            PrintPose(FbxCast<FbxPose>(obj));
        else if (obj->Is<FbxSubDeformer>())
            PrintSubDeformer(FbxCast<FbxSubDeformer>(obj));
        else if (obj->Is<FbxSurfaceMaterial>())
            PrintSurfaceMaterial(FbxCast<FbxSurfaceMaterial>(obj));
        else if (obj->Is<FbxTexture>())
            PrintTexture(FbxCast<FbxTexture>(obj));
        else if (obj->Is<FbxVideo>())
            PrintVideo(FbxCast<FbxVideo>(obj));
        else
            cout << "Unknown object class: " << obj->GetRuntimeClassId().GetName() << endl;
    }

    cout << endl;
}



void PrintScene(FbxScene* scene)
{
    int i;

    cout << "    GenericNodeCount = " << scene->GetGenericNodeCount() << endl;
    cout << "    CharacterCount = " << scene->GetCharacterCount() << endl;
    cout << "    CharacterPoseCount = " << scene->GetCharacterPoseCount() << endl;
    cout << "    PoseCount = " << scene->GetPoseCount() << endl;
    for (i = 0; i < scene->GetPoseCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetPose(i));
        cout << endl;
    }
    cout << "    MaterialCount = " << scene->GetMaterialCount() << endl;
    for (i = 0; i < scene->GetMaterialCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetMaterial(i));
        cout << endl;
    }
    cout << "    TextureCount = " << scene->GetTextureCount() << endl;
    for (i = 0; i < scene->GetTextureCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetTexture(i));
        cout << endl;
    }
    cout << "    NodeCount = " << scene->GetNodeCount() << endl;
    for (i = 0; i < scene->GetNodeCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetNode(i));
        cout << endl;
    }
    cout << "    GeometryCount = " << scene->GetGeometryCount() << endl;
    for (i = 0; i < scene->GetGeometryCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetGeometry(i));
        cout << endl;
    }
    cout << "    VideoCount = " << scene->GetVideoCount() << endl;
    for (i = 0; i < scene->GetVideoCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetVideo(i));
        cout << endl;
    }

    cout << "    RootNode ";
    PrintObjectID(scene->GetRootNode());
    cout << endl;

    cout << "    GetCurrentAnimationStack() = ";
    PrintObjectID(scene->GetCurrentAnimationStack());
    cout << endl;
}

void PrintAnimLayer(FbxAnimLayer* al)
{
    cout << "        Weight: " << al->Weight.Get() << endl;
    cout << "        Mute: " << al->Mute.Get() << endl;
    cout << "        Solo: " << al->Solo.Get() << endl;
    cout << "        Lock: " << al->Lock.Get() << endl;
    cout << "        Color: " << al->Color.Get() << endl;
    //cout << "        BlendMode: " << al->BlendMode.Get() << endl;
    //cout << "        RotationAccumulationMode: " << al->RotationAccumulationMode.Get() << endl;
    //cout << "        ScaleAccumulationMode: " << al->ScaleAccumulationMode.Get() << endl;

    // blend mode bypass
}

void PrintAnimStack(FbxAnimStack* animStack)
{
    cout << "    GetLocalTimeSpan() = " << animStack->GetLocalTimeSpan() << endl;
    cout << "    GetReferenceTimeSpan() = " << animStack->GetReferenceTimeSpan() << endl;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eTangentAuto) == FbxAnimCurveDef::eTangentAuto) os << "eTangentAuto";
    if ((value & FbxAnimCurveDef::eTangentTCB) == FbxAnimCurveDef::eTangentTCB) os << "eTangentTCB";
    if ((value & FbxAnimCurveDef::eTangentUser) == FbxAnimCurveDef::eTangentUser) os << "eTangentUser";
    if ((value & FbxAnimCurveDef::eTangentGenericBreak) == FbxAnimCurveDef::eTangentGenericBreak) os << "eTangentGenericBreak";
    if ((value & FbxAnimCurveDef::eTangentBreak) == FbxAnimCurveDef::eTangentBreak) os << "eTangentBreak";
    if ((value & FbxAnimCurveDef::eTangentAutoBreak) == FbxAnimCurveDef::eTangentAutoBreak) os << "eTangentAutoBreak";
    if ((value & FbxAnimCurveDef::eTangentGenericClamp) == FbxAnimCurveDef::eTangentGenericClamp) os << "eTangentGenericClamp";
    if ((value & FbxAnimCurveDef::eTangentGenericTimeIndependent) == FbxAnimCurveDef::eTangentGenericTimeIndependent) os << "eTangentGenericTimeIndependent";
    if ((value & FbxAnimCurveDef::eTangentGenericClampProgressive) == FbxAnimCurveDef::eTangentGenericClampProgressive) os << "eTangentGenericClampProgressive";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EInterpolationType& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eInterpolationConstant) == FbxAnimCurveDef::eInterpolationConstant) os << "eInterpolationConstant";
    if ((value & FbxAnimCurveDef::eInterpolationLinear) == FbxAnimCurveDef::eInterpolationLinear) os << "eInterpolationLinear";
    if ((value & FbxAnimCurveDef::eInterpolationCubic) == FbxAnimCurveDef::eInterpolationCubic) os << "eInterpolationCubic";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EWeightedMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eWeightedAll) == FbxAnimCurveDef::eWeightedAll)
    {
        os << "eWeightedAll";
    }
    else if ((value & FbxAnimCurveDef::eWeightedRight) == FbxAnimCurveDef::eWeightedRight)
    {
        os << "eWeightedRight";
    }
    else if ((value & FbxAnimCurveDef::eWeightedNextLeft) == FbxAnimCurveDef::eWeightedNextLeft)
    {
        os << "eWeightedNextLeft";
    }
    else
    {
        os << "eWeightedNone";
    }
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EConstantMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eConstantNext) == FbxAnimCurveDef::eConstantNext) os << "eConstantNext";
    else os << "eConstantStandard";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EVelocityMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eVelocityAll) == FbxAnimCurveDef::eVelocityAll) os << "eVelocityAll";
    else if ((value & FbxAnimCurveDef::eVelocityRight) == FbxAnimCurveDef::eVelocityRight) os << "eVelocityRight";
    else if ((value & FbxAnimCurveDef::eVelocityNextLeft) == FbxAnimCurveDef::eVelocityNextLeft) os << "eVelocityNextLeft";
    else os << "eVelocityNone";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentVisibility& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eTangentShowBoth) == FbxAnimCurveDef::eTangentShowBoth) os << "eTangentShowBoth";
    else if ((value & FbxAnimCurveDef::eTangentShowLeft) == FbxAnimCurveDef::eTangentShowLeft) os << "eTangentShowLeft";
    else if ((value & FbxAnimCurveDef::eTangentShowRight) == FbxAnimCurveDef::eTangentShowRight) os << "eTangentShowRight";
    else os << "eTangentShowNone";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EDataIndex& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eRightSlope) == FbxAnimCurveDef::eRightSlope) os << "eRightSlope";
    if ((value & FbxAnimCurveDef::eNextLeftSlope) == FbxAnimCurveDef::eNextLeftSlope) os << "eNextLeftSlope";
    if ((value & FbxAnimCurveDef::eWeights) == FbxAnimCurveDef::eWeights) os << "eWeights";
    //if ((value & FbxAnimCurveDef::eRightWeight) == FbxAnimCurveDef::eRightWeight) os << "eRightWeight";
    if ((value & FbxAnimCurveDef::eNextLeftWeight) == FbxAnimCurveDef::eNextLeftWeight) os << "eNextLeftWeight";
    if ((value & FbxAnimCurveDef::eVelocity) == FbxAnimCurveDef::eVelocity) os << "eVelocity";
    //if ((value & FbxAnimCurveDef::eRightVelocity) == FbxAnimCurveDef::eRightVelocity) os << "eRightVelocity";
    if ((value & FbxAnimCurveDef::eNextLeftVelocity) == FbxAnimCurveDef::eNextLeftVelocity) os << "eNextLeftVelocity";
    //if ((value & FbxAnimCurveDef::eTCBTension) == FbxAnimCurveDef::eTCBTension) os << "eTCBTension";
    //if ((value & FbxAnimCurveDef::eTCBContinuity) == FbxAnimCurveDef::eTCBContinuity) os << "eTCBContinuity";
    //if ((value & FbxAnimCurveDef::eTCBBias) == FbxAnimCurveDef::eTCBBias) os << "eTCBBias";
    return os;
}

std::ostream& operator<<(std::ostream& os, FbxAnimCurveKey& value)
{
    os << value.GetValue() << ", "
        << value.GetInterpolation() << ", "
        << value.GetTangentMode() << ", "
        << value.GetTangentWeightMode() << ", "
        << value.GetTangentVelocityMode() << ", "
        << value.GetConstantMode() << ", "
        << value.GetTangentVisibility() << ", "
        << "Break: " << value.GetBreak() << ", "
        << "DataFloat: "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)0) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)1) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)2) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)3) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)4) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)5);
    return os;
}

void PrintAnimCurveKey(int i, FbxTime time, FbxAnimCurveKey key)
{
    cout << "        #" << i << ": " << time << ", " << key << endl;
    if (time != key.GetTime())
    {
        cout << "-------- times don't match: " << time << " != " << key.GetTime() << endl;
    }
}

bool PrintAllCurveKeys = false;

void PrintAnimCurve(FbxAnimCurve* animCurve)
{
    cout << "    KeyGetCount() = " << animCurve->KeyGetCount() << endl;
    if (animCurve->KeyGetCount() <= 6 || PrintAllCurveKeys)
    {
        int i;
        for (i = 0; i < animCurve->KeyGetCount(); i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
    }
    else
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
        cout << "        ..." << endl;
        for (i = animCurve->KeyGetCount() - 3; i < animCurve->KeyGetCount(); i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
    }
}

void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode)
{
    cout << "    IsAnimated(pRecurse: false) = " << animCurveNode->IsAnimated(false) << endl;
    cout << "    IsAnimated(pRecurse: true) = " << animCurveNode->IsAnimated(true) << endl;
    FbxTimeSpan interval;
    animCurveNode->GetAnimationInterval(interval);
    cout << "    GetAnimationInterval() = " << interval << endl;
    cout << "    IsComposite() = " << animCurveNode->IsComposite() << endl;
    cout << "    GetChannelsCount() = " << animCurveNode->GetChannelsCount() << endl;
    int i;
    int j;
    for (i = 0; i < animCurveNode->GetChannelsCount(); i++)
    {
        cout << "        #" << i << ": " << quote(animCurveNode->GetChannelName(i).Buffer()) << endl;
        cout << "            GetCurveCount() = " << animCurveNode->GetCurveCount(i) << endl;
        for (j = 0; j < animCurveNode->GetCurveCount(i); j++)
        {
            cout << "                #" << j << ": ";
            PrintObjectID(animCurveNode->GetCurve(i, j));
            cout << endl;
        }
    }
}

void PrintDeformer(FbxDeformer* deformer)
{
    cout << "PrintDeformer: Not Implemented" << endl;
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

void PrintNode(FbxNode* node)
{

    cout << "    Parent = ";
    PrintObjectID(node->GetParent());
    cout << endl;

    cout << "    ChildCount " << node->GetChildCount() << endl;
    int i;
    for (i = 0; i < node->GetChildCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(node->GetChild(i));
        cout << endl;
    }

    cout << "    Target = ";
    PrintObjectID(node->GetTarget());
    cout << endl;
    cout << "    PostTargetRotation = " << node->GetPostTargetRotation() << endl;
    cout << "    TargetUp = ";
    PrintObjectID(node->GetTargetUp());
    cout << endl;
    cout << "    TargetUpVector = " << node->GetTargetUpVector() << endl;

    cout << "    NodeAttribute = ";
    PrintObjectID(node->GetNodeAttribute());
    cout << endl;
    cout << "    NumNodeAttributes = " << node->GetNodeAttributeCount() << endl;

    FbxTransform::EInheritType inhtype;
    node->GetTransformationInheritType(inhtype);
    cout << "    TransformationInheritType = " << inhtype << endl;

    cout << "    GetCharacterLinkCount() = " << node->GetCharacterLinkCount() << endl;

    cout << "    GetMaterialCount() = " << node->GetMaterialCount() << endl;
    for (i = 0; i < node->GetMaterialCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(node->GetMaterial(i));
        cout << endl;
    }

    cout << "    LclTranslation = " << node->LclTranslation.Get() << endl;
    cout << "    LclRotation = " << node->LclRotation.Get() << endl;
    cout << "    LclScaling = " << node->LclScaling.Get() << endl;
    cout << "    Visibility = " << node->Visibility.Get() << endl;
    cout << "    VisibilityInheritance = " << node->VisibilityInheritance.Get() << endl;
    cout << "    QuaternionInterpolate = " << node->QuaternionInterpolate.Get() << endl;
    cout << "    RotationOffset = " << node->RotationOffset.Get() << endl;
    cout << "    RotationPivot = " << node->RotationPivot.Get() << endl;
    cout << "    ScalingOffset = " << node->ScalingOffset.Get() << endl;
    cout << "    ScalingPivot = " << node->ScalingPivot.Get() << endl;
    cout << "    TranslationActive = " << node->TranslationActive.Get() << endl;
    cout << "    TranslationMin = " << node->TranslationMin.Get() << endl;
    cout << "    TranslationMax = " << node->TranslationMax.Get() << endl;
    cout << "    TranslationMinX = " << node->TranslationMinX.Get() << endl;
    cout << "    TranslationMinY = " << node->TranslationMinY.Get() << endl;
    cout << "    TranslationMinZ = " << node->TranslationMinZ.Get() << endl;
    cout << "    TranslationMaxX = " << node->TranslationMaxX.Get() << endl;
    cout << "    TranslationMaxY = " << node->TranslationMaxY.Get() << endl;
    cout << "    TranslationMaxZ = " << node->TranslationMaxZ.Get() << endl;
    cout << "    RotationOrder = " << node->RotationOrder.Get() << endl;
    cout << "    RotationSpaceForLimitOnly = " << node->RotationSpaceForLimitOnly.Get() << endl;
    cout << "    RotationStiffnessX = " << node->RotationStiffnessX.Get() << endl;
    cout << "    RotationStiffnessY = " << node->RotationStiffnessY.Get() << endl;
    cout << "    RotationStiffnessZ = " << node->RotationStiffnessZ.Get() << endl;
    cout << "    AxisLen = " << node->AxisLen.Get() << endl;
    cout << "    PreRotation = " << node->PreRotation.Get() << endl;
    cout << "    PostRotation = " << node->PostRotation.Get() << endl;
    cout << "    RotationActive = " << node->RotationActive.Get() << endl;
    cout << "    RotationMin = " << node->RotationMin.Get() << endl;
    cout << "    RotationMax = " << node->RotationMax.Get() << endl;
    cout << "    RotationMinX = " << node->RotationMinX.Get() << endl;
    cout << "    RotationMinY = " << node->RotationMinY.Get() << endl;
    cout << "    RotationMinZ = " << node->RotationMinZ.Get() << endl;
    cout << "    RotationMaxX = " << node->RotationMaxX.Get() << endl;
    cout << "    RotationMaxY = " << node->RotationMaxY.Get() << endl;
    cout << "    RotationMaxZ = " << node->RotationMaxZ.Get() << endl;
    cout << "    InheritType = " << node->InheritType.Get() << endl;
    cout << "    ScalingActive = " << node->ScalingActive.Get() << endl;
    cout << "    ScalingMin = " << node->ScalingMin.Get() << endl;
    cout << "    ScalingMax = " << node->ScalingMax.Get() << endl;
    cout << "    ScalingMinX = " << node->ScalingMinX.Get() << endl;
    cout << "    ScalingMinY = " << node->ScalingMinY.Get() << endl;
    cout << "    ScalingMinZ = " << node->ScalingMinZ.Get() << endl;
    cout << "    ScalingMaxX = " << node->ScalingMaxX.Get() << endl;
    cout << "    ScalingMaxY = " << node->ScalingMaxY.Get() << endl;
    cout << "    ScalingMaxZ = " << node->ScalingMaxZ.Get() << endl;
    cout << "    GeometricTranslation = " << node->GeometricTranslation.Get() << endl;
    cout << "    GeometricRotation = " << node->GeometricRotation.Get() << endl;
    cout << "    GeometricScaling = " << node->GeometricScaling.Get() << endl;
    cout << "    MinDampRangeX = " << node->MinDampRangeX.Get() << endl;
    cout << "    MinDampRangeY = " << node->MinDampRangeY.Get() << endl;
    cout << "    MinDampRangeZ = " << node->MinDampRangeZ.Get() << endl;
    cout << "    MaxDampRangeX = " << node->MaxDampRangeX.Get() << endl;
    cout << "    MaxDampRangeY = " << node->MaxDampRangeY.Get() << endl;
    cout << "    MaxDampRangeZ = " << node->MaxDampRangeZ.Get() << endl;
    cout << "    MinDampStrengthX = " << node->MinDampStrengthX.Get() << endl;
    cout << "    MinDampStrengthY = " << node->MinDampStrengthY.Get() << endl;
    cout << "    MinDampStrengthZ = " << node->MinDampStrengthZ.Get() << endl;
    cout << "    MaxDampStrengthX = " << node->MaxDampStrengthX.Get() << endl;
    cout << "    MaxDampStrengthY = " << node->MaxDampStrengthY.Get() << endl;
    cout << "    MaxDampStrengthZ = " << node->MaxDampStrengthZ.Get() << endl;
    cout << "    PreferedAngleX = " << node->PreferedAngleX.Get() << endl;
    cout << "    PreferedAngleY = " << node->PreferedAngleY.Get() << endl;
    cout << "    PreferedAngleZ = " << node->PreferedAngleZ.Get() << endl;
    cout << "    LookAtProperty = " << node->LookAtProperty.Get() << endl;
    cout << "    UpVectorProperty = " << node->UpVectorProperty.Get() << endl;
    cout << "    Show = " << node->Show.Get() << endl;
    cout << "    NegativePercentShapeSupport = " << node->NegativePercentShapeSupport.Get() << endl;
    cout << "    DefaultAttributeIndex = " << node->DefaultAttributeIndex.Get() << endl;
    cout << "    Freeze = " << node->Freeze.Get() << endl;
    cout << "    LODBox = " << node->LODBox.Get() << endl;

    cout << "    GetVisibility() = " << node->GetVisibility() << endl;
    cout << "    GetShadingMode() = " << node->GetShadingMode() << endl;

    // pivot management
    //throw "Not Implemented";

}

void PrintNodeAttribute(FbxNodeAttribute* obj)
{
    if (obj->Is<FbxCamera>())
        PrintCamera(FbxCast<FbxCamera>(obj));
    else if (obj->Is<FbxLight>())
        PrintLight(FbxCast<FbxLight>(obj));
    else if (obj->Is<FbxLayerContainer>())
        PrintLayerContainer(FbxCast<FbxLayerContainer>(obj));
    else if (obj->Is<FbxNull>())
        PrintNull(FbxCast<FbxNull>(obj));
    else if (obj->Is<FbxSkeleton>())
        PrintSkeleton(FbxCast<FbxSkeleton>(obj));
    else
        cout << "Unknown node attribute class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintCamera(FbxCamera* camera)
{
    cout << "PrintCamera: Not Implemented" << endl;
}

void PrintLight(FbxLight* light)
{
    cout << "PrintLight: Not Implemented" << endl;
}

void PrintLayerContainer(FbxLayerContainer* layerContainer)
{
    cout << "    GetLayerCount() = " << layerContainer->GetLayerCount() << endl;
    int i;
    for (i = 0; i < layerContainer->GetLayerCount(); i++)
    {
        cout << "        #" << i << " " << endl;
        PrintLayer(layerContainer->GetLayer(i));
    }

    if (layerContainer->Is<FbxGeometryBase>())
        PrintGeometryBase(FbxCast<FbxGeometryBase>(layerContainer));
    else
        cout << "Unknown node attribute class: " << layerContainer->GetRuntimeClassId().GetName() << endl;
}



ostream& operator<<(ostream& os, const FbxLayerElement::EMappingMode& value)
{
    switch (value)
    {
    case FbxLayerElement::eNone: os << "eNone"; break;
    case FbxLayerElement::eByControlPoint: os << "eByControlPoint"; break;
    case FbxLayerElement::eByPolygonVertex: os << "eByPolygonVertex"; break;
    case FbxLayerElement::eByPolygon: os << "eByPolygon"; break;
    case FbxLayerElement::eByEdge: os << "eByEdge"; break;
    case FbxLayerElement::eAllSame:  os << "eAllSame"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}
ostream& operator<<(ostream& os, const FbxLayerElement::EReferenceMode& value)
{
    switch (value)
    {
    case FbxLayerElement::eDirect: os << "eDirect"; break;
    case FbxLayerElement::eIndex: os << "eIndex"; break;
    case FbxLayerElement::eIndexToDirect: os << "eIndexToDirect"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}

std::string ToString(const FbxLayerElement* value)
{
    std:string s;
    if (value == NULL)
       s = "<<null>>";
    else
    {
        stringstream ss;
        ss <<
            value->GetName() << ", " <<
            value->GetMappingMode() << ", " <<
            value->GetReferenceMode();
        s = ss.str();
    }
    return s;
}

void PrintLayerTextures(FbxLayerElementTexture* tex, const char* type)
{
    cout << "            GetTextures(" << type << ") = " << ToString(tex) << endl;

    if (tex == NULL) return;

    int i;
    FbxLayerElementArrayTemplate<FbxTexture*>& tarray = tex->GetDirectArray();
    for (i = 0; i < tarray.GetCount(); i++)
    {
        cout << "                #" << i << " ";
        PrintObjectID(tarray.GetAt(i));
        cout << endl;
    }
}

void PrintLayer(FbxLayer* layer)
{
    cout << "            GetNormals() = " << ToString(layer->GetNormals()) << endl;
    cout << "            GetTangents() = " << ToString(layer->GetTangents()) << endl;
    cout << "            GetBinormals() = " << ToString(layer->GetBinormals()) << endl;

    FbxLayerElementMaterial* mats = layer->GetMaterials();
    cout << "            GetMaterials() = " << ToString(mats) << endl;
    int i;
    if (mats != NULL)
    {
        FbxLayerElementTemplate<FbxSurfaceMaterial*>* _mats = mats;
        FbxLayerElementArrayTemplate<FbxSurfaceMaterial*>& marray = _mats->GetDirectArray();
        for (i = 0; i < marray.GetCount(); i++)
        {
            cout << "                #" << i << " ";
            PrintObjectID(marray.GetAt(i));
            cout << endl;
        }
    }

    cout << "            GetPolygonGroups() = " << ToString(layer->GetPolygonGroups()) << endl;
    cout << "            GetUVs() = " << ToString(layer->GetUVs()) << endl;
    cout << "            GetUVSetCount() = " << layer->GetUVSetCount() << endl;
//    cout << "            GetUVSetChannels() = " << ToString(layer->GetUVSetChannels()) << endl;
//    cout << "            GetUVSets() = " << ToString(layer->GetUVSets()) << endl;
    cout << "            GetVertexColors() = " << ToString(layer->GetVertexColors()) << endl;
    cout << "            GetSmoothing() = " << ToString(layer->GetSmoothing()) << endl;
    cout << "            GetVertexCrease() = " << ToString(layer->GetVertexCrease()) << endl;
    cout << "            GetEdgeCrease() = " << ToString(layer->GetEdgeCrease()) << endl;
    cout << "            GetHole() = " << ToString(layer->GetHole()) << endl;
    cout << "            GetUserData() = " << ToString(layer->GetUserData()) << endl;
    cout << "            GetVisibility() = " << ToString(layer->GetVisibility()) << endl;

    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureEmissive), "eTextureEmissive");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureEmissiveFactor), "eTextureEmissiveFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureAmbient), "eTextureAmbient");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureAmbientFactor), "eTextureAmbientFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureDiffuseFactor), "eTextureDiffuseFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureSpecular), "eTextureSpecular");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureNormalMap), "eTextureNormalMap");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureSpecularFactor), "eTextureSpecularFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureShininess), "eTextureShininess");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureBump), "eTextureBump");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureTransparency), "eTextureTransparency");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureTransparencyFactor), "eTextureTransparencyFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureReflection), "eTextureReflection");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureReflectionFactor), "eTextureReflectionFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureDisplacement), "eTextureDisplacement");
}

bool PrintAllControlPoints = false;

void PrintGeometryBase(FbxGeometryBase* geometryBase)
{
    int count = geometryBase->GetControlPointsCount();
    cout << "    GetControlPointsCount() = " << count << endl;

    if (count <= 6 || PrintAllControlPoints)
    {
        int i;
        for (i = 0; i < count; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "                #" << i << ": " << cp << endl;
        }
    }
    else
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "        #" << i << ": " << cp << endl;
        }
        cout << "        ..." << endl;
        for (i = count - 3; i < count; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "        #" << i << ": " << cp << endl;
        }
    }

    if (geometryBase->Is<FbxGeometry>())
        PrintGeometry(FbxCast<FbxGeometry>(geometryBase));
    else
        cout << "Unknown node attribute class: " << geometryBase->GetRuntimeClassId().GetName() << endl;
}

void PrintGeometry(FbxGeometry* geometry)
{
    if (geometry->Is<FbxMesh>())
        PrintMesh(FbxCast<FbxMesh>(geometry));
    else
        cout << "Unknown node attribute class: " << geometry->GetRuntimeClassId().GetName() << endl;
}

void PrintMesh(FbxMesh* mesh)
{
    cout << "    GetPolygonCount() = " << mesh->GetPolygonCount() << endl;
}

void PrintNull(FbxNull* null)
{
}

void PrintSkeleton(FbxSkeleton* skeleton)
{
    cout << "PrintSkeleton: Not Implemented" << endl;
}

void PrintPose(FbxPose* pose)
{
    cout << "    IsBindPose = " << pose->IsBindPose() << endl;
    cout << "    IsRestPose = " << pose->IsRestPose() << endl;
    cout << "    Count = " << pose->GetCount() << endl;
    int i;
    for (i = 0; i < pose->GetCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(pose->GetNode(i));
        cout << endl;
        const FbxMatrix& m = pose->GetMatrix(i);
        cout << "            Matrix = " <<
            m.mData[0][0] << ", " << m.mData[0][1] << ", " <<
            m.mData[0][2] << ", " << m.mData[0][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[1][0] << ", " << m.mData[1][1] << ", " <<
            m.mData[1][2] << ", " << m.mData[1][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[2][0] << ", " << m.mData[2][1] << ", " <<
            m.mData[2][2] << ", " << m.mData[2][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[3][0] << ", " << m.mData[3][1] << ", " <<
            m.mData[3][2] << ", " << m.mData[3][3] << ", " << endl;
        cout << "            IsLocalMatrix = " <<
            pose->IsLocalMatrix(i) << endl;
    }
}

void PrintSubDeformer(FbxSubDeformer* subDeformer)
{
    cout << "PrintSubDeformer: Not Implemented" << endl;
}

void PrintSurfaceMaterial(FbxSurfaceMaterial* obj)
{
    cout << "    ShadingModel = " << obj->ShadingModel.Get().Buffer() << endl;
    cout << "    MultiLayer = " << obj->MultiLayer.Get() << endl;
    
    if (obj->Is<FbxSurfaceLambert>())
        PrintSurfaceLambert(FbxCast<FbxSurfaceLambert>(obj));
    else
        cout << "Unknown surface material class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfaceLambert(FbxSurfaceLambert* obj)
{
    FbxDouble3 s;

    s = obj->Emissive.Get();
    cout << "    Emissive = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    EmissiveFactor = " << obj->EmissiveFactor.Get() << endl;
    s = obj->Ambient.Get();
    cout << "    Ambient = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    AmbientFactor = " << obj->AmbientFactor.Get() << endl;
    s = obj->Diffuse.Get();
    cout << "    Diffuse = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    DiffuseFactor = " << obj->DiffuseFactor.Get() << endl;
    s = obj->NormalMap.Get();
    cout << "    NormalMap = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    s = obj->Bump.Get();
    cout << "    Bump = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    BumpFactor = " << obj->BumpFactor.Get() << endl;
    s = obj->TransparentColor.Get();
    cout << "    TransparentColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    TransparencyFactor = " << obj->TransparencyFactor.Get() << endl;
    s = obj->DisplacementColor.Get();
    cout << "    DisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    DisplacementFactor = " << obj->DisplacementFactor.Get() << endl;
    s = obj->VectorDisplacementColor.Get();
    cout << "    VectorDisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    VectorDisplacementFactor = " << obj->VectorDisplacementFactor.Get() << endl;

    if (obj->Is<FbxSurfacePhong>())
        PrintSurfacePhong(FbxCast<FbxSurfacePhong>(obj));
    else
        cout << "Unknown surface lambert class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfacePhong(FbxSurfacePhong* obj)
{
    FbxDouble3 s = obj->Specular.Get();
    cout << "    Specular = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    SpecularFactor = " << obj->SpecularFactor.Get() << endl;
    cout << "    Shininess = " << obj->Shininess.Get() << endl;
    s = obj->Reflection.Get();
    cout << "    Reflection = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    ReflectionFactor = " << obj->ReflectionFactor.Get() << endl;
}

void PrintVideo(FbxVideo* obj)
{
    cout << "PrintVideo: Not Implemented" << endl;
}

void PrintTexture(FbxTexture* tex)
{
    cout << "PrintTexture: Not Implemented" << endl;
}

void PrintCollection(FbxCollection* col)
{
    cout << "    GetMemberCount() = " << col->GetMemberCount() << endl;
    int i;
    for (i = 0; i < col->GetMemberCount(); i++)
    {
        cout << "        #" << i << ": ";
        PrintObjectID(col->GetMember(i));
        cout << endl;
    }

    if (col->Is<FbxAnimStack>())
        PrintAnimStack(FbxCast<FbxAnimStack>(col));
    else if (col->Is<FbxAnimLayer>())
        PrintAnimLayer(FbxCast<FbxAnimLayer>(col));
    else if (col->Is<FbxDocument>())
        PrintDocument(FbxCast<FbxDocument>(col));
    else
        cout << "Unknown surface lambert class: " << col->GetRuntimeClassId().GetName() << endl;
}

void PrintDocument(FbxDocument* doc)
{
    cout << "    GetRootMemberCount() = " << doc->GetRootMemberCount() << endl;
    int i;
    for (i = 0; i < doc->GetRootMemberCount(); i++)
    {
        cout << "        #" << i << ": ";
        PrintObjectID(doc->GetRootMember(i));
        cout << endl;
    }

    // obj->GetDocumentInfo()

    if (doc->Is<FbxScene>())
        PrintScene(FbxCast<FbxScene>(doc));
    else
        cout << "Unknown surface lambert class: " << doc->GetRuntimeClassId().GetName() << endl;

}

int CountProperties(FbxObject* obj)
{
    FbxProperty prop = obj->GetFirstProperty();
    int n = 0;
    while (prop.IsValid())
    {
        n++;
        prop = obj->GetNextProperty(prop);
    }

    return n;
}





std::string quote(const char* s)
{
    int i;
    stringstream ss;
    int n = strlen(s);

    ss << "\"";
    for (i = 0; i < n; i++)
    {
        char ch = s[i];
        if (isprint(ch))
            ss << ch;
        else
        {
            switch (ch)
            {
            case '\r': ss << "\\r"; break;
            case '\n': ss << "\\n"; break;
            case '\t': ss << "\\t"; break;
            default:
                ss << "\\x" << setw(2) << std::hex << (int)(unsigned char)ch;
            }
        }
    }
    ss << "\"";

    return ss.str();
}


std::ostream& operator<<(std::ostream& os, const FbxTime::EMode& value)
{
    switch (value)
    {
    case FbxTime::eDefaultMode   : os << "eDefaultMode"; break;
    case FbxTime::eFrames120     : os << "eFrames120"; break;
    case FbxTime::eFrames100     : os << "eFrames100"; break;
    case FbxTime::eFrames60      : os << "eFrames60"; break;
    case FbxTime::eFrames50      : os << "eFrames50"; break;
    case FbxTime::eFrames48      : os << "eFrames48"; break;
    case FbxTime::eFrames30      : os << "eFrames30"; break;
    case FbxTime::eFrames30Drop  : os << "eFrames30Drop"; break;
    case FbxTime::eNTSCDropFrame : os << "eNTSCDropFrame"; break;
    case FbxTime::eNTSCFullFrame : os << "eNTSCFullFrame"; break;
    case FbxTime::ePAL           : os << "ePAL"; break;
    case FbxTime::eFrames24      : os << "eFrames24"; break;
    case FbxTime::eFrames1000    : os << "eFrames1000"; break;
    case FbxTime::eFilmFullFrame : os << "eFilmFullFrame"; break;
    case FbxTime::eCustom        : os << "eCustom"; break;
    case FbxTime::eFrames96      : os << "eFrames96"; break;
    case FbxTime::eFrames72      : os << "eFrames72"; break;
    case FbxTime::eFrames59dot94 : os << "eFrames59dot94"; break;
    case FbxTime::eModesCount    : os << "eModesCount"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxTime& value)
{
    os << "[" << value.GetSecondDouble() << "s; " <<
                 value.GetSecondCount() << "s; " <<
                 value.GetFrameCount() << "f; " <<
                 FbxTime::GetGlobalTimeMode() << "tm]";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxTimeSpan& value)
{
    os << "(start: " << value.GetStart() << ", stop: " << value.GetStop() << ")";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxMatrix& value)
{
    os << "[ "
        << value.Get(0, 0) << ", "
        << value.Get(0, 1) << ", "
        << value.Get(0, 2) << ", "
        << value.Get(0, 3) << ", "
        << value.Get(1, 0) << ", "
        << value.Get(1, 1) << ", "
        << value.Get(1, 2) << ", "
        << value.Get(1, 3) << ", "
        << value.Get(2, 0) << ", "
        << value.Get(2, 1) << ", "
        << value.Get(2, 2) << ", "
        << value.Get(2, 3) << ", "
        << value.Get(3, 0) << ", "
        << value.Get(3, 1) << ", "
        << value.Get(3, 2) << ", "
        << value.Get(3, 3) << " ]";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAMatrix& value)
{
    os << "[ "
        << value.Get(0, 0) << ", "
        << value.Get(0, 1) << ", "
        << value.Get(0, 2) << ", "
        << value.Get(0, 3) << ", "
        << value.Get(1, 0) << ", "
        << value.Get(1, 1) << ", "
        << value.Get(1, 2) << ", "
        << value.Get(1, 3) << ", "
        << value.Get(2, 0) << ", "
        << value.Get(2, 1) << ", "
        << value.Get(2, 2) << ", "
        << value.Get(2, 3) << ", "
        << value.Get(3, 0) << ", "
        << value.Get(3, 1) << ", "
        << value.Get(3, 2) << ", "
        << value.Get(3, 3) << " ]";
    return os;
}
