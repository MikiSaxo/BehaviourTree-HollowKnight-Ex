using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The CheckBlackboard class is a type of TreeNode that checks a value in the behavior tree's blackboard.
    /// If the value associated with the specified key matches the expected value, the node succeeds.
    /// Otherwise, the node fails.
    /// </summary>
    public class CheckBlackboard : TreeNode
    {
        public int Value;
        public string Name;

        public CheckBlackboard()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (tree.ReadBlackboard(Name) == Value)
            {
                return TreeNodeState.Success;
            }
            
            return TreeNodeState.Failed;
        }
    }
}