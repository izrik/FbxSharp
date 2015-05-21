using System;

namespace FbxSharp
{
    public class Camera : NodeAttribute
    {
        public Camera(string name="")
            : base(name)
        {
        }

        #region implemented abstract members of NodeAttribute

        public override EAttributeType AttributeType {
            get {
                return EAttributeType.Camera;
            }
        }

        #endregion
    }
}

