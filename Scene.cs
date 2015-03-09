using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class Scene : Document
    {
        public Scene(string name="")
        {
            RootNode = new Node();

            Nodes = SrcObjects.CreateCollectionView<Node>();

            SrcObjects.Add(new GlobalSettings());
            SetAnimationEvaluator(new AnimEvaluator());
        }


        #region Global Settings

        public GlobalSettings GetGlobalSettings()
        {
            return (GlobalSettings)SrcObjects.FirstOrDefault(x => x is GlobalSettings);
        }

        #endregion

        #region Scene Animation Evaluation

        public void SetCurrentAnimationStack(AnimationStack pAnimStack)
        {
            throw new NotImplementedException();
        }

        public AnimationStack GetCurrentAnimationStack()
        {
            throw new NotImplementedException();
        }

        public void SetAnimationEvaluator(AnimEvaluator pEvaluator)
        {
            var current = GetAnimationEvaluator();
            if (current != null)
            {
                SrcObjects.Remove(current);
            }
            SrcObjects.Add(pEvaluator);
        }

        public AnimEvaluator GetAnimationEvaluator()
        {
            return (AnimEvaluator)SrcObjects.FirstOrDefault(x => x is AnimEvaluator);
        }

        #endregion

        #region Node Tree Access

        public SrcObjectCollectionView<Node> Nodes;

        Node _rootNode;
        public Node RootNode {
            get { return _rootNode; }
            protected set
            {
                if (value != _rootNode)
                {
                    if (_rootNode != null)
                    {
                        this.DisconnectSrcObject(_rootNode);
                    }

                    _rootNode = value;

                    if (_rootNode != null)
                    {
                        this.ConnectSrcObject(_rootNode);
                    }
                }
            }
        }

        public Node GetRootNode()
        {
            return RootNode;
        }

        #endregion

        #region Node Access

        public int GetNodeCount()
        {
            return Nodes.Count;
        }

        public Node GetNode(int pIndex)
        {
            return Nodes[pIndex];
        }

        public bool AddNode(Node pNode)
        {
            if (!Nodes.Contains(pNode))
            {
                ConnectSrcObject(pNode);
                foreach (var child in pNode.ChildNodes)
                {
                    AddNode(child);
                }
                return true;
            }

            return false;
        }

        public bool RemoveNode(Node pNode)
        {
            if (Nodes.Contains(pNode))
            {
                DisconnectSrcObject(pNode);
                foreach (var child in pNode.ChildNodes)
                {
                    RemoveNode(child);
                }
                return true;
            }

            return false;
        }


        #endregion
    }
}

