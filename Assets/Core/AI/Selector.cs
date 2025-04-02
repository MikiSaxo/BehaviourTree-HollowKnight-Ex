using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The Selector class is a type of composite node in a behavior tree.
    /// It iterates through its child nodes until one of them succeeds.
    /// If a child node succeeds, the Selector node succeeds and stops evaluating further children.
    /// If all child nodes fail, the Selector node fails.
    /// </summary>
    public class Selector : TreeNode
    {
        int _currentChildIndex;

        public Selector()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            while (_currentChildIndex < Children.Count)
            {
                TreeNodeState childState = Children[_currentChildIndex].Update(tree, owner);

                switch (childState)
                {
                    case TreeNodeState.Success:
                    {
                        Reset();
                        return TreeNodeState.Success;
                    }
                    
                    case TreeNodeState.Running:
                        return TreeNodeState.Running;
                    
                    case TreeNodeState.Failed:
                        _currentChildIndex++;
                        break;
                }
            }
    
            Reset();
            return TreeNodeState.Failed;
        }

        protected override void ResetInternal()
        {
            _currentChildIndex = 0;
        }
    }
}