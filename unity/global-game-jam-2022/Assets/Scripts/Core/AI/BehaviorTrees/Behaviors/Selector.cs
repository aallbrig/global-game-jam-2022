using System.Collections.Generic;
using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees.Behaviors
{
    public class Selector : Composite
    {
        public Selector(List<Behavior> children) : base(children) {}

        protected override Status Execute()
        {
            var currentChild = Children[CurrentIndex];
            var childStatus = currentChild.Evaluate();

            if (childStatus != Status.Failure)
                CurrentStatus = childStatus;
            else
                CurrentStatus = ++CurrentIndex == Children.Count ? Status.Failure : Status.Running;

            return CurrentStatus;
        }
    }
}