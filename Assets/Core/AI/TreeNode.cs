
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The TreeNode class represents a node in a behavior tree.
    /// It can have child nodes and manages their execution.
    /// The state of the node is determined by the state of its children.
    /// </summary>
    public class TreeNode
    {
        public List<TreeNode> Children { get; set; }
        private TreeNodeState State { get; set; }

        public void Add(TreeNode node)
        {
            Children.Add(node);
        }

        public virtual TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (Children.Count > 0)
            {
                State = Children[0].Update(tree, owner);
            }
            return State;
        }

        public void Reset()
        {
            ResetInternal();
            State = TreeNodeState.Idle;

            if (Children != null)
            {
                foreach (var item in Children)
                {
                    item.Reset();
                }
            }
        }

        protected virtual void ResetInternal()
        {

        }
    }

    public enum TreeNodeState
    {
        Idle,
        Success,
        Failed,
        Running
    }

}
