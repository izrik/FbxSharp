using System;

namespace FbxSharp
{
    public class FbxAnimLayer : FbxCollection
    {
        public FbxAnimLayer(string name = "")
            : base(name)
        {
            Weight = FbxPropertyT<double>.StaticInit(this, "Weight", null,
                default, false);
            Mute = FbxPropertyT<bool>.StaticInit(this, "Mute", null, default,
                false);
            Solo = FbxPropertyT<bool>.StaticInit(this, "Solo", null, default,
                false);
            Lock = FbxPropertyT<bool>.StaticInit(this, "Lock", null, default,
                false);
            Color = FbxPropertyT<FbxVector3>.StaticInit(this, "Color", null,
                default, false);
            // BlendMode
            // RotationAccumulationMode
            // ScaleAccumulationMode
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

        public readonly FbxPropertyT<double> Weight;
        public readonly FbxPropertyT<bool> Mute;
        public readonly FbxPropertyT<bool> Solo;
        public readonly FbxPropertyT<bool> Lock;
        public readonly FbxPropertyT<FbxVector3> Color;
        // public readonly PropertyT<FbxEnum> BlendMode;
        // public readonly PropertyT<FbxEnum> RotationAccumulationMode;
        // public readonly PropertyT<FbxEnum> ScaleAccumulationMode;

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

