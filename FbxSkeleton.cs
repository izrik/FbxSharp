using System;

namespace FbxSharp
{
    public class FbxSkeleton : FbxNodeAttribute
    {
        public override EAttributeType AttributeType { get { return EAttributeType.Skeleton; } }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public enum EType
        {
            Root,
            Limb,
            LimbNode,
            Effector //= Root,
        }

        #region  Skeleton Properties

        EType? _skeletonType;
        public EType SkeletonType
        {
            get { return _skeletonType.HasValue ? _skeletonType.Value : SkeletonTypeDefaultValue; }
            set { _skeletonType = value; }
        }
        public bool IsSkeletonTypeSet { get { return _skeletonType.HasValue; } }
        public EType SkeletonTypeDefaultValue { get { return EType.Root; } }

        public double LimbLengthDefaultValue { get { return sDefaultLimbLength; } }

        public double LimbNodeSizeDefaultValue { get { return sDefaultSize; } }

        FbxColor? _limbNodeColor;
        public FbxColor LimbNodeColor
        {
            get { return _limbNodeColor.HasValue ? _limbNodeColor.Value : LimbNodeColorDefaultValue; }
            set { _limbNodeColor = value; }
        }
        public bool IsLimbNodeColorSet { get { return _limbNodeColor.HasValue; } }
        public FbxColor LimbNodeColorDefaultValue { get { return new FbxColor(new FbxVector3(0.8f,0.8f,0.8f)); } }

        public bool IsSkeletonRoot { get; protected set; }

        #endregion

        #region Property Names

        public const string sSize = "";
        public const string sLimbLength = "";

        #endregion

        #region Property Default Values

        public const double sDefaultSize = 100;
        public const double sDefaultLimbLength = 1;

        public readonly FbxPropertyT<double> Size = new FbxPropertyT<double>("Size");
        public readonly FbxPropertyT<double> LimbLength = new FbxPropertyT<double>("LimbLength");

        #endregion
    }
}

