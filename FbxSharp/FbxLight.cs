using System;

namespace FbxSharp
{
    public class FbxLight : FbxNodeAttribute
    {
        public FbxLight(string name = "")
            : base(name)
        {
            LightType = FbxPropertyT<EType>.StaticInit(this, "LightType",
                default, false);
            CastLight = FbxPropertyT<bool>.StaticInit(this,
                "CastLightOnObject", false, false);
            DrawVolumetricLight = FbxPropertyT<bool>.StaticInit(this,
                "DrawVolumetricLight", false, false);
            DrawGroundProjection = FbxPropertyT<bool>.StaticInit(this,
                "DrawGroundProjection", false, false);
            DrawFrontFacingVolumetricLight = FbxPropertyT<bool>.StaticInit(
                this, "DrawFrontFacingVolumetricLight", false, false);
            Intensity = FbxPropertyT<double>.StaticInit(this, "Intensity",
                0.0, false);
            InnerAngle = FbxPropertyT<double>.StaticInit(this, "InnerAngle",
                0.0, false);
            OuterAngle = FbxPropertyT<double>.StaticInit(this, "OuterAngle",
                0.0, false);
            Fog = FbxPropertyT<double>.StaticInit(this, "Fog", 0.0, false);
            DecayType = FbxPropertyT<EDecayType>.StaticInit(this, "DecayType",
                default, false);
            DecayStart = FbxPropertyT<double>.StaticInit(this, "DecayStart",
                0.0, false);
            FileName = FbxPropertyT<string>.StaticInit(this, "FileName", "",
                false);
            EnableNearAttenuation = FbxPropertyT<bool>.StaticInit(this,
                "EnableNearAttenuation", false, false);
            NearAttenuationStart = FbxPropertyT<double>.StaticInit(this,
                "NearAttenuationStart", 0.0, false);
            NearAttenuationEnd = FbxPropertyT<double>.StaticInit(this,
                "NearAttenuationEnd", 0.0, false);
            EnableFarAttenuation = FbxPropertyT<bool>.StaticInit(this,
                "EnableFarAttenuation", false, false);
            FarAttenuationStart = FbxPropertyT<double>.StaticInit(this,
                "FarAttenuationStart", 0.0, false);
            FarAttenuationEnd = FbxPropertyT<double>.StaticInit(this,
                "FarAttenuationEnd", 0.0, false);
            CastShadows = FbxPropertyT<bool>.StaticInit(this, "CastShadows",
                false, false);
            ShadowColor = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ShadowColor", FbxVector3.Zero, false);
            AreaLightShape = FbxPropertyT<EAreaLightShape>.StaticInit(this,
                "AreaLightShape", default, false);
            LeftBarnDoor = FbxPropertyT<float>.StaticInit(this,
                "LeftBarnDoor", 0f, false);
            RightBarnDoor = FbxPropertyT<float>.StaticInit(this,
                "RightBarnDoor", 0f, false);
            TopBarnDoor = FbxPropertyT<float>.StaticInit(this, "TopBarnDoor",
                0f, false);
            BottomBarnDoor = FbxPropertyT<float>.StaticInit(this,
                "BottomBarnDoor", 0f, false);
            EnableBarnDoor = FbxPropertyT<bool>.StaticInit(this,
                "EnableBarnDoor", false, false);
        }

        #region implemented abstract members of NodeAttribute

        public override EAttributeType AttributeType {
            get {
                return EAttributeType.Light;
            }
        }

        #endregion

        #region Light Properties

        public enum EType
        {
            ePoint,
            eDirectional,
            eSpot,
            eArea,
            eVolume,
        }

        public enum EDecayType
        {
            eNone,
            eLinear,
            eQuadratic,
            eCubic,
        }

        public enum EAreaLightShape
        {
            eRactangle,
            eSphere,
        }

        public void SetShadowTexture(FbxTexture pTexture)
        {
            throw new NotImplementedException();
        }

        public FbxTexture GetShadowTexture()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        public FbxPropertyT<EType> LightType;
        public FbxPropertyT<bool> CastLight;
        public FbxPropertyT<bool> DrawVolumetricLight;
        public FbxPropertyT<bool> DrawGroundProjection;
        public FbxPropertyT<bool> DrawFrontFacingVolumetricLight;
        public FbxPropertyT<double> Intensity;
        public FbxPropertyT<double> InnerAngle;
        public FbxPropertyT<double> OuterAngle;
        public FbxPropertyT<double> Fog;
        public FbxPropertyT<EDecayType> DecayType;
        public FbxPropertyT<double> DecayStart;
        public FbxPropertyT<string> FileName;
        public FbxPropertyT<bool> EnableNearAttenuation;
        public FbxPropertyT<double> NearAttenuationStart;
        public FbxPropertyT<double> NearAttenuationEnd;
        public FbxPropertyT<bool> EnableFarAttenuation;
        public FbxPropertyT<double> FarAttenuationStart;
        public FbxPropertyT<double> FarAttenuationEnd;
        public FbxPropertyT<bool> CastShadows;
        public FbxPropertyT<FbxVector3> ShadowColor;
        public FbxPropertyT<EAreaLightShape> AreaLightShape;
        public FbxPropertyT<float> LeftBarnDoor;
        public FbxPropertyT<float> RightBarnDoor;
        public FbxPropertyT<float> TopBarnDoor;
        public FbxPropertyT<float> BottomBarnDoor;
        public FbxPropertyT<bool> EnableBarnDoor;

        #endregion
    }
}

