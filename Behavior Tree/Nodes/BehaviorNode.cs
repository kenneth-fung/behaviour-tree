using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public abstract class BehaviorNode
    {
        public enum NodeState { FAILURE, SUCCESS, RUNNING }

        public BehaviorNode Parent { get; set; }

        public Blackboard Blackboard { get; set; }

        public abstract NodeState Execute();
    }
}
