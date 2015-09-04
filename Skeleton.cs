using System;

namespace FbxSharp
{
    public class Skeleton : NodeAttribute
    {
        public override EAttributeType GetAttributeType()
        {
            return EAttributeType.Skeleton;
        }

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

        Color? _limbNodeColor;
        public Color LimbNodeColor
        {
            get { return _limbNodeColor.HasValue ? _limbNodeColor.Value : LimbNodeColorDefaultValue; }
            set { _limbNodeColor = value; }
        }
        public bool IsLimbNodeColorSet { get { return _limbNodeColor.HasValue; } }
        public Color LimbNodeColorDefaultValue { get { return new Color(new Vector3(0.8f,0.8f,0.8f)); } }

        public bool IsSkeletonRoot { get; protected set; }

        #endregion

        #region Property Names

        public const string sSize = "";
        public const string sLimbLength = "";

        #endregion

        #region Property Default Values

        public const double sDefaultSize = 100;
        public const double sDefaultLimbLength = 1;

        public readonly PropertyT<double> Size = new PropertyT<double>("Size");
        public readonly PropertyT<double> LimbLength = new PropertyT<double>("LimbLength");

        #endregion
    }
}

