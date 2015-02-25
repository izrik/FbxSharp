using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Scene : Document
    {
        public Scene()
        {
            RootNode = new Node();
            Nodes.Add(RootNode);
        }

        public List<Node> Nodes = new List<Node>();
        public Node RootNode { get; protected set; }
    }
}

