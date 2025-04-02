
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The Repeater class is a type of TreeNode that repeats its child node a specified number of times.
    /// If the RepeatCount is -1, it repeats indefinitely.
    /// It resets the child node after each iteration and returns a success state when the repeat count is reached.
    /// </summary>
    public class Repeater : TreeNode
    {
        public int RepeatCount = -1;
        private int _currentCount;

        public Repeater()
        {
            Children = new List<TreeNode>();
        }

        protected override void ResetInternal()
        {
            _currentCount = 0;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (Children.Count == 0)
            {
                return TreeNodeState.Success;
            }

            while (RepeatCount == -1 || _currentCount < RepeatCount)
            {
                TreeNodeState childState = Children[0].Update(tree, owner);

                if (childState == TreeNodeState.Running)
                {
                    return TreeNodeState.Running;
                }

                if (childState == TreeNodeState.Failed)
                {
                    return TreeNodeState.Failed;
                }

                _currentCount++;
                Children[0].Reset();
            }

            return TreeNodeState.Success;
        }
    }
}
