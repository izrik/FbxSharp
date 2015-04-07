using System;

namespace FbxSharp
{
    public class AnimationLayer : Collection
    {
        #region Public Types

        public enum EBlendMode
        {
            eBlendAdditive,
            eBlendOverride,
            eBlendOverridePassthrough
        }

        public enum ERotationAccumulationMode
        {
            eRotationByLayer,
            eRotationByChannel
        }

        public enum EScaleAccumulationMode
        {
            eScaleMultiply,
            eScaleAdditive
        }

        #endregion

        #region Public Member Functions

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Attributes

        public PropertyT<double>    Weight                      = new PropertyT<double>("Weight");
        public PropertyT<bool>      Mute                        = new PropertyT<bool>("Mute");
        public PropertyT<bool>      Solo                        = new PropertyT<bool>("Solo");
        public PropertyT<bool>      Lock                        = new PropertyT<bool>("Lock");
        public PropertyT<Vector3>   Color                       = new PropertyT<Vector3>("Color");
//        public PropertyT<FbxEnum>   BlendMode                   = new PropertyT<FbxEnum>("BlendMode");
//        public PropertyT<FbxEnum>   RotationAccumulationMode    = new PropertyT<FbxEnum>("RotationAccumulationMode");
//        public PropertyT<FbxEnum>   ScaleAccumulationMode       = new PropertyT<FbxEnum>("ScaleAccumulationMode");

        #endregion

        #region BlendModeBypass Functions

        public void SetBlendModeBypass(/*EFbxType pType,*/ bool pState)
        {
            throw new NotImplementedException();
        }

        public bool GetBlendModeBypass(/*EFbxType pType*/)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CurveNode Management

        public AnimationCurveNode CreateCurveNode(Property pProperty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

