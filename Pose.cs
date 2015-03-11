using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Pose : FbxObject
    {
        public bool IsBindPose;
        public bool IsRestPose
        {
            get { return !IsBindPose; }
        }

        public List<PoseNode> PoseNodes = new List<PoseNode>();

        public struct PoseNode
        {
            public PoseNode(Node node, Matrix matrix, bool isLocalMatrix=false)
            {
                Node = node;
                Matrix = matrix;
                IsLocalMatrix = isLocalMatrix;
            }

            public readonly Node Node;
            public readonly Matrix Matrix;
            public readonly bool IsLocalMatrix;
        }
    }
}

