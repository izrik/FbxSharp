using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxPose : FbxObject
    {
        public FbxPose(String name="")
            : base(name)
        {
            PoseInfos = new CollectionView<FbxPoseInfo, FbxPoseInfo>(poseInfos, eh => poseInfos.CollectionChanged += eh);
        }

        #region Public Member Functions

        readonly ChangeNotifyList<FbxPoseInfo> poseInfos = new ChangeNotifyList<FbxPoseInfo>();
        public readonly CollectionView<FbxPoseInfo, FbxPoseInfo> PoseInfos;

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
            return poseInfos.Count;
        }

        public int Add(FbxNode pNode, FbxMatrix pMatrix, bool pLocalMatrix=false/*, bool pMultipleBindPose=true*/)
        {
            var match = poseInfos.FindIndex(pi => pi.Node == pNode);
            if (match >= 0)
            {
                if (poseInfos[match].Matrix != pMatrix)
                    return -1;
                return match;
            }

            var p = new FbxPoseInfo(pNode, pMatrix, pLocalMatrix);
            poseInfos.Add(p);

            return poseInfos.IndexOf(p);
        }

        public void Remove(int pIndex)
        {
            poseInfos.RemoveAt(pIndex);
        }

        public FbxNode GetNode(int pIndex)
        {
            return poseInfos[pIndex].Node;
        }

        public FbxMatrix GetMatrix(int pIndex)
        {
            return poseInfos[pIndex].Matrix;
        }

        public bool IsLocalMatrix(int pIndex)
        {
            return poseInfos[pIndex].MatrixIsLocal;
        }

        #endregion
    }
}

