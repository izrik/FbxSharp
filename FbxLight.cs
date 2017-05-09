using System;

namespace FbxSharp
{
    public class FbxLight : NodeAttribute
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

        public void SetShadowTexture(Texture pTexture)
        {
            throw new NotImplementedException();
        }

        public Texture GetShadowTexture()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        public PropertyT<EType>             LightType                       = new PropertyT<EType>          ("LightType");
        public PropertyT<bool>              CastLight                       = new PropertyT<bool>           ("CastLightOnObject");
        public PropertyT<bool>              DrawVolumetricLight             = new PropertyT<bool>           ("DrawVolumetricLight");
        public PropertyT<bool>              DrawGroundProjection            = new PropertyT<bool>           ("DrawGroundProjection");
        public PropertyT<bool>              DrawFrontFacingVolumetricLight  = new PropertyT<bool>           ("DrawFrontFacingVolumetricLight");
        public PropertyT<double>            Intensity                       = new PropertyT<double>         ("Intensity");
        public PropertyT<double>            InnerAngle                      = new PropertyT<double>         ("InnerAngle");
        public PropertyT<double>            OuterAngle                      = new PropertyT<double>         ("OuterAngle");
        public PropertyT<double>            Fog                             = new PropertyT<double>         ("Fog");
        public PropertyT<EDecayType>        DecayType                       = new PropertyT<EDecayType>     ("DecayType");
        public PropertyT<double>            DecayStart                      = new PropertyT<double>         ("DecayStart");
        public PropertyT<string>            FileName                        = new PropertyT<string>         ("FileName");
        public PropertyT<bool>              EnableNearAttenuation           = new PropertyT<bool>           ("EnableNearAttenuation");
        public PropertyT<double>            NearAttenuationStart            = new PropertyT<double>         ("NearAttenuationStart");
        public PropertyT<double>            NearAttenuationEnd              = new PropertyT<double>         ("NearAttenuationEnd");
        public PropertyT<bool>              EnableFarAttenuation            = new PropertyT<bool>           ("EnableFarAttenuation");
        public PropertyT<double>            FarAttenuationStart             = new PropertyT<double>         ("FarAttenuationStart");
        public PropertyT<double>            FarAttenuationEnd               = new PropertyT<double>         ("FarAttenuationEnd");
        public PropertyT<bool>              CastShadows                     = new PropertyT<bool>           ("CastShadows");
        public PropertyT<Vector3>           ShadowColor                     = new PropertyT<Vector3>        ("ShadowColor");
        public PropertyT<EAreaLightShape>   AreaLightShape                  = new PropertyT<EAreaLightShape>("AreaLightShape");
        public PropertyT<float>             LeftBarnDoor                    = new PropertyT<float>          ("LeftBarnDoor");
        public PropertyT<float>             RightBarnDoor                   = new PropertyT<float>          ("RightBarnDoor");
        public PropertyT<float>             TopBarnDoor                     = new PropertyT<float>          ("TopBarnDoor");
        public PropertyT<float>             BottomBarnDoor                  = new PropertyT<float>          ("BottomBarnDoor");
        public PropertyT<bool>              EnableBarnDoor                  = new PropertyT<bool>           ("EnableBarnDoor");

        #endregion
    }
}

