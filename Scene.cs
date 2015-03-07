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
        public Node RootNode { get; protected set; }

        public Node GetRootNode()
        {
            return RootNode;
        }
    }
}

