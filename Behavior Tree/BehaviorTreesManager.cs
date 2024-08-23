using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public class BehaviorTreesManager
    {
        public enum TreeFunction
        {
            NONE
        }

        public TreeFunction ActiveTree { get; private set; }

        private Dictionary<TreeFunction, BehaviorTree> functionToTreesDictionary;

        public BehaviorTreesManager(
            Dictionary<TreeFunction, BehaviorTree> functionToTreesDictionary,
            TreeFunction startTree)
        {
            this.functionToTreesDictionary = functionToTreesDictionary;

            ActiveTree = startTree;
            functionToTreesDictionary[ActiveTree].Enter();
        }

        public void UpdateActiveTree()
        {
            if (ActiveTree != TreeFunction.NONE)
            {
                functionToTreesDictionary[ActiveTree].Update();
            }
        }

        public void SwitchActiveTree(TreeFunction newTree)
        {
            if (ActiveTree != TreeFunction.NONE)
            {
                functionToTreesDictionary[ActiveTree].Exit();
            }

            ActiveTree = newTree;

            if (ActiveTree != TreeFunction.NONE)
            {
                functionToTreesDictionary[ActiveTree].Enter();
            }
        }
    }
}
