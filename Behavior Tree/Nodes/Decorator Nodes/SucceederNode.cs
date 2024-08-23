using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public class SucceederNode : DecoratorNode
    {
        public SucceederNode(BehaviorNode child) : base(child) { }

        public override NodeState Execute()
        {
            Child.Execute();
            return NodeState.SUCCESS;
        }
    }
}
