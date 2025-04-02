using System.Collections.Generic;
using Core.Character;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The SetBlackboard class is a type of TreeNode that writes a specified value to the behavior tree's blackboard.
    /// When the node is updated, it sets the value associated with the specified key and returns a success state.
    /// </summary>
    public class SetBlackboard : TreeNode
    {
        public string Name;
        public float Value;

        public SetBlackboard()
        {
            Children = new List<TreeNode>();
        }
        
        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            tree.WriteBlackboard(Name, Value);

            return TreeNodeState.Success;
        }
    }
}