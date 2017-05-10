using System;

namespace FbxSharp
{
    public class FbxLight : FbxNodeAttribute
    {
        public FbxLight(string name="")
            : base(name)
        {
            Properties.Add(LightType);
            Properties.Add(CastLight);
            Properties.Add(DrawVolumetricLight);
            Properties.Add(DrawGroundProjection);
            Properties.Add(DrawFrontFacingVolumetricLight);
            Properties.Add(Color);
            Properties.Add(Intensity);
            Properties.Add(InnerAngle);
            Properties.Add(OuterAngle);
            Properties.Add(Fog);
            Properties.Add(DecayType);
            Properties.Add(DecayStart);
            Properties.Add(FileName);
            Properties.Add(EnableNearAttenuation);
            Properties.Add(NearAttenuationStart);
            Properties.Add(NearAttenuationEnd);
            Properties.Add(EnableFarAttenuation);
            Properties.Add(FarAttenuationStart);
            Properties.Add(FarAttenuationEnd);
            Properties.Add(CastShadows);
            Properties.Add(ShadowColor);
            Properties.Add(AreaLightShape);
            Properties.Add(LeftBarnDoor);
            Properties.Add(RightBarnDoor);
            Properties.Add(TopBarnDoor);
            Properties.Add(BottomBarnDoor);
            Properties.Add(EnableBarnDoor);
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

        public FbxPropertyT<EType>             LightType                       = new FbxPropertyT<EType>          ("LightType");
        public FbxPropertyT<bool>              CastLight                       = new FbxPropertyT<bool>           ("CastLightOnObject");
        public FbxPropertyT<bool>              DrawVolumetricLight             = new FbxPropertyT<bool>           ("DrawVolumetricLight");
        public FbxPropertyT<bool>              DrawGroundProjection            = new FbxPropertyT<bool>           ("DrawGroundProjection");
        public FbxPropertyT<bool>              DrawFrontFacingVolumetricLight  = new FbxPropertyT<bool>           ("DrawFrontFacingVolumetricLight");
        public FbxPropertyT<double>            Intensity                       = new FbxPropertyT<double>         ("Intensity");
        public FbxPropertyT<double>            InnerAngle                      = new FbxPropertyT<double>         ("InnerAngle");
        public FbxPropertyT<double>            OuterAngle                      = new FbxPropertyT<double>         ("OuterAngle");
        public FbxPropertyT<double>            Fog                             = new FbxPropertyT<double>         ("Fog");
        public FbxPropertyT<EDecayType>        DecayType                       = new FbxPropertyT<EDecayType>     ("DecayType");
        public FbxPropertyT<double>            DecayStart                      = new FbxPropertyT<double>         ("DecayStart");
        public FbxPropertyT<string>            FileName                        = new FbxPropertyT<string>         ("FileName");
        public FbxPropertyT<bool>              EnableNearAttenuation           = new FbxPropertyT<bool>           ("EnableNearAttenuation");
        public FbxPropertyT<double>            NearAttenuationStart            = new FbxPropertyT<double>         ("NearAttenuationStart");
        public FbxPropertyT<double>            NearAttenuationEnd              = new FbxPropertyT<double>         ("NearAttenuationEnd");
        public FbxPropertyT<bool>              EnableFarAttenuation            = new FbxPropertyT<bool>           ("EnableFarAttenuation");
        public FbxPropertyT<double>            FarAttenuationStart             = new FbxPropertyT<double>         ("FarAttenuationStart");
        public FbxPropertyT<double>            FarAttenuationEnd               = new FbxPropertyT<double>         ("FarAttenuationEnd");
        public FbxPropertyT<bool>              CastShadows                     = new FbxPropertyT<bool>           ("CastShadows");
        public FbxPropertyT<FbxVector3>           ShadowColor                     = new FbxPropertyT<FbxVector3>        ("ShadowColor");
        public FbxPropertyT<EAreaLightShape>   AreaLightShape                  = new FbxPropertyT<EAreaLightShape>("AreaLightShape");
        public FbxPropertyT<float>             LeftBarnDoor                    = new FbxPropertyT<float>          ("LeftBarnDoor");
        public FbxPropertyT<float>             RightBarnDoor                   = new FbxPropertyT<float>          ("RightBarnDoor");
        public FbxPropertyT<float>             TopBarnDoor                     = new FbxPropertyT<float>          ("TopBarnDoor");
        public FbxPropertyT<float>             BottomBarnDoor                  = new FbxPropertyT<float>          ("BottomBarnDoor");
        public FbxPropertyT<bool>              EnableBarnDoor                  = new FbxPropertyT<bool>           ("EnableBarnDoor");

        #endregion
    }
}

