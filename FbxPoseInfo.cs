using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FbxSharp
{
    public struct FbxPoseInfo
    {
        public FbxPoseInfo(FbxNode node, FbxMatrix matrix, bool matrixIsLocal = false)
        {
            Node = node;
            Matrix = matrix;
            MatrixIsLocal = matrixIsLocal;
        }

        public readonly FbxNode Node;
        public readonly FbxMatrix Matrix;
        public readonly bool MatrixIsLocal;
    }
}
