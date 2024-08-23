using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public abstract class DecoratorNode : BehaviorNode
    {
        public BehaviorNode Child;

        public DecoratorNode(BehaviorNode child)
        {
            Child = child;
            child.Parent = this;
        }
    }
}
