using System;

namespace FbxSharp
{
    public class FbxAnimLayer : FbxCollection
    {
        public FbxAnimLayer(string name="")
            : base(name)
        {
        }

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

        public FbxPropertyT<double>    Weight                      = new FbxPropertyT<double>("Weight");
        public FbxPropertyT<bool>      Mute                        = new FbxPropertyT<bool>("Mute");
        public FbxPropertyT<bool>      Solo                        = new FbxPropertyT<bool>("Solo");
        public FbxPropertyT<bool>      Lock                        = new FbxPropertyT<bool>("Lock");
        public FbxPropertyT<FbxVector3>   Color                       = new FbxPropertyT<FbxVector3>("Color");
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

        public FbxAnimCurveNode CreateCurveNode(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "AnimLayer::";
        }
    }
}

