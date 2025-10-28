using System;

namespace FbxSharp
{
    /// <summary>
    /// This node attribute contains the properties of a null node.
    /// </summary>
    public class FbxNull : FbxNodeAttribute
    {
        public FbxNull(string name = "")
            : base(name)
        {
            Size = FbxPropertyT<double>.StaticInit(this, "Size", sDefaultSize,
                false);
            Look = FbxPropertyT<ELook>.StaticInit(this, "Look", sDefaultLook,
                false);
        }


        #region Public Member Functions

        // TODO:
        // public override FbxClassId GetClassId() => new FbxClassId();

        // TODO:
        // public override FbxNodeAttribute.EAttributeType GetAttributeType() =>
        //     EAttributeType.Null;

        [NotSdk]
        public override EAttributeType AttributeType => EAttributeType.Null;

        public void Reset()
        {
            Size.Set(sDefaultSize);
            Look.Set(sDefaultLook);
        }

        #endregion

        #region Public Attributes

        public readonly FbxPropertyT<double> Size;
        public readonly FbxPropertyT<ELook> Look;

        #endregion

        #region Null Node Properties

        public enum ELook
        {
            eNone,
            eCross,
        }

        public double GetSizeDefaultValue()
        {
            return sDefaultSize;
        }

        #endregion

        #region Property Names

        public static readonly string sSize = "Size";
        public static readonly string sLook = "Look";

        #endregion

        #region Property Default Values

        public static readonly double sDefaultSize = 100;

        public static readonly ELook sDefaultLook = ELook.eCross;

        #endregion
    }
}

