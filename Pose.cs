using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Pose : FbxObject
    {
        public Pose(String name="")
            : base(name)
        {
        }

        #region Public Member Functions

        readonly List<PoseInfo> PoseInfos = new List<PoseInfo>();

        struct PoseInfo
        {
            public PoseInfo(Node node, Matrix matrix, bool matrixIsLocal=false)
            {
                Node = node;
                Matrix = matrix;
                MatrixIsLocal = matrixIsLocal;
            }

            public readonly Node Node;
            public readonly Matrix Matrix;
            public readonly bool MatrixIsLocal;
        }

        public void SetIsBindPose(bool pIsBindPose)
        {
            isBindPose = pIsBindPose;
        }

        bool isBindPose;
        public bool IsBindPose()
        {
            return isBindPose;
        }

        public bool IsRestPose()
        {
            return !IsBindPose();
        }

        public int GetCount()
        {
            return PoseInfos.Count;
        }

        public int Add(Node pNode, Matrix pMatrix, bool pLocalMatrix=false/*, bool pMultipleBindPose=true*/)
        {
            var match = PoseInfos.FindIndex(pi => pi.Node == pNode);
            if (match >= 0)
            {
                if (PoseInfos[match].Matrix != pMatrix)
                    return -1;
                return match;
            }

            var p = new PoseInfo(pNode, pMatrix, pLocalMatrix);
            PoseInfos.Add(p);

            return PoseInfos.IndexOf(p);
        }

        public void Remove(int pIndex)
        {
            PoseInfos.RemoveAt(pIndex);
        }

        public Node GetNode(int pIndex)
        {
            return PoseInfos[pIndex].Node;
        }

        public Matrix GetMatrix(int pIndex)
        {
            return PoseInfos[pIndex].Matrix;
        }

        public bool IsLocalMatrix(int pIndex)
        {
            return PoseInfos[pIndex].MatrixIsLocal;
        }

        #endregion
    }
}

