﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class ChessProblemNode
    {
        ChessProblemState state;
        int depth;
        ChessProblemNode parent;

        public ChessProblemNode()
        {
            this.state = new ChessProblemState();
            this.depth = 0;
            this.parent = null;
        }
        public ChessProblemNode(ChessProblemState state)
        {
            this.state = state;
            this.depth = 0;
            this.parent = null;
        }
        public ChessProblemNode(ChessProblemNode parent)
        {
            this.state = (ChessProblemState)parent.state.Clone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public ChessProblemNode Parent { get { return parent; } }
        public ChessProblemState State { get { return this.state; } }
        public int Depth { get { return depth; } }
        public bool IsTerminalNode { get { return state.IsGoalState(); } }

        public List<ChessProblemNode> GetAllChildren()
        {
            List<ChessProblemNode> children = new List<ChessProblemNode>();

            int xLength = this.state.GetXLength;
            int yLength = this.state.GetYLength;

            for (int i = 1; i < xLength - 1; i++)
            {
                for (int u = 1; u < yLength - 1; u++)
                {
                    for (int dir = 0; dir < 8; dir++)
                    {
                        Direction8 direction = (Direction8)dir;

                        ChessProblemNode childNode = new ChessProblemNode(this);
                        if (childNode.state.ApplyOperator(i, u, direction))
                            children.Add(childNode);
                    }
                }
            }
            return children;
        }

        public override bool Equals(object obj)
        {
            ChessProblemNode other = (ChessProblemNode)obj;
            return this.state.Equals(other.state);
        }

        public override string ToString()
        {
            return state.ToString();
        }

    }
}
