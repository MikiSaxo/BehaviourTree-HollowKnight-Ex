
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The Log class is a type of TreeNode that logs a specified message to the Unity console.
    /// When the node is updated, it outputs the message and returns a success state.
    /// </summary>
    class Log : TreeNode
    {
        public string Text { get; set; }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            Debug.Log(Text);

            return TreeNodeState.Success;
        }
    }
}
