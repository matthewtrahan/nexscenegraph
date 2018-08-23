﻿using System;
using System.Collections.Generic;

namespace Veldrid.SceneGraph
{
    public class Node
    {
        public Guid Id { get; private set; }

        private Node Parent { get; set; }
        private List<Node> Children;

        public Node(Node parent = null)
        {
            Id = Guid.NewGuid();

            Parent = parent;
            Children = new List<Node>();
            
            parent?.Children.Add(this);
        }

        public void Add(Node node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        internal virtual void Accept(DrawVisitor drawVisitor)
        {
            foreach (var child in Children)
            {
                child.Accept(drawVisitor);
            }
        }
    }
}