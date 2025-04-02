
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// The Wait class is a type of TreeNode that waits for a specified amount of time before succeeding.
    /// It keeps track of the start time and checks if the elapsed time has reached the specified timer.
    /// </summary>
    class Wait : TreeNode
    {
        public float Timer { get; set; }
        private float _startTime;

        protected override void ResetInternal()
        {
            _startTime = Time.time;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (Time.time - _startTime >= Timer)
            {
                return TreeNodeState.Success;
            }
            return TreeNodeState.Running;
        }
    }
}
