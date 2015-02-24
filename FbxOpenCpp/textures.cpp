

#include <iostream>
#include <fbxsdk.h>
#include "common.h"

using namespace std;

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
