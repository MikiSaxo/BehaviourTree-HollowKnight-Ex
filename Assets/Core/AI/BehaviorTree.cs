using System.Collections.Generic;
using UnityEngine;
namespace Core.AI
{
    /// <summary>
    /// The BehaviorTree class manages the execution of a behavior tree.
    /// It holds the root node and a blackboard for storing key-value pairs.
    /// The tree is updated every frame, starting from the root node.
    /// </summary>
    public class BehaviorTree : MonoBehaviour
    {
        public TreeNode Root { get; set; }
        
        private Dictionary<string, float> _blackboard = new Dictionary<string, float>();

        private void Awake()
        {
            _blackboard = new Dictionary<string, float>();
        }

        private void Update()
        {
            if (Root != null)
            {
                Root.Update(this, gameObject);
            }
            else
            {
                Debug.LogWarning("Root is null");
            }
        }

        public void WriteBlackboard(string name, float value)
        {
            _blackboard[name] = value;
        }

        public float ReadBlackboard(string name)
        {
            return _blackboard.GetValueOrDefault(name, 0);
        }

        internal void SetRepeater(Repeater repeater)
        {
        }
    }
}
