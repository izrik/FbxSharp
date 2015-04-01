using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class Scene : Document
    {
        public Scene(string name="")
            : base(name)
        {
            RootNode = new Node();

            Poses = SrcObjects.CreateCollectionView<Pose>();
            Materials = SrcObjects.CreateCollectionView<SurfaceMaterial>();
            Textures = SrcObjects.CreateCollectionView<Texture>();
            Nodes = SrcObjects.CreateCollectionView<Node>();

            SrcObjects.Add(new GlobalSettings());
            SetAnimationEvaluator(new AnimEvaluator());
        }

        #region Pose Management

        public readonly CollectionView<Pose> Poses;

        public int GetPoseCount()
        {
            return Poses.Count;
        }

        public Pose GetPose(int pIndex)
        {
            return Poses[pIndex];
        }

        public bool AddPose(Pose pPose)
        {
            if (this.Poses.Contains(pPose)) return false;

            this.ConnectSrcObject(pPose);

            return true;
        }

        public bool RemovePose(Pose pPose)
        {
            return this.DisconnectSrcObject(pPose);
        }

        public bool RemovePose(int pIndex)
        {
            return RemovePose(Poses[pIndex]);
        }

        #endregion

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

        #region Material Access

        public readonly CollectionView<SurfaceMaterial> Materials;

        public int GetMaterialCount()
        {
            return Materials.Count;
        }

        public SurfaceMaterial GetMaterial(int pIndex)
        {
            return Materials[pIndex];
        }

        public SurfaceMaterial GetMaterial(string pName)
        {
            return Materials.FirstOrDefault(m => m.Name == pName);
        }

        public bool AddMaterial(SurfaceMaterial pMaterial)
        {
            ConnectSrcObject(pMaterial);
            return true;
        }

        public bool RemoveMaterial(SurfaceMaterial pMaterial)
        {
            return DisconnectSrcObject(pMaterial);
        }

        #endregion

        #region Texture Access

        public readonly CollectionView<Texture> Textures;

        public int GetTextureCount()
        {
            return Textures.Count;
        }

        public Texture GetTexture(int pIndex)
        {
            return Textures[pIndex];
        }

        public Texture GetTexture(string pName)
        {
            return Textures.FirstOrDefault(t => t.Name == pName);
        }

        public bool AddTexture(Texture pTexture)
        {
            ConnectSrcObject(pTexture);
            return true;
        }

        public bool RemoveTexture(Texture pTexture)
        {
            return DisconnectSrcObject(pTexture);
        }

        #endregion

        #region Node Tree Access

        public CollectionView<Node> Nodes;

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

