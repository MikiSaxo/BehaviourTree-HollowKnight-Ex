using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The Sequence class is a type of composite node in a behavior tree.
    /// It iterates through its child nodes in order until one of them fails.
    /// If a child node fails, the Sequence node fails and stops evaluating further children.
    /// If all child nodes succeed, the Sequence node succeeds.
    /// </summary>
    public class Sequence : TreeNode
    {
        int _currentChildIndex;

        public Sequence()
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
                    case TreeNodeState.Failed:
                    {
                        Reset();   
                        return TreeNodeState.Failed;
                    }
                    
                    case TreeNodeState.Running:
                        return TreeNodeState.Running;
                    
                    case TreeNodeState.Success:
                        _currentChildIndex++;
                        break;
                }
            }

            Reset();
            return TreeNodeState.Success;
        }

        
        protected override void ResetInternal()
        {
            _currentChildIndex = 0;
        }
    }
}
