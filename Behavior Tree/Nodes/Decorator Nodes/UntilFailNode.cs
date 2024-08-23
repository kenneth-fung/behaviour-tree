using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public class UntilFailNode : DecoratorNode
    {
        public UntilFailNode(BehaviorNode child) : base(child) { }

        public override NodeState Execute()
        {
            NodeState result = Child.Execute();
            if (result == NodeState.FAILURE)
            {
                return NodeState.SUCCESS;
            }

            return NodeState.RUNNING;
        }
    }
}
