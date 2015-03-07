using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Scene : Document
    {
        public Scene(string name="")
        {
            RootNode = new Node();
            Nodes.Add(RootNode);
        }

        public List<Node> Nodes = new List<Node>();

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
    }
}

