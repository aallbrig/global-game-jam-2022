using System;

namespace Core.AI.BehaviorTrees.BuildingBlocks
{
    public abstract class Decorator : Behavior, IAddChild
    {
        protected Behavior Child;
        protected Decorator(Behavior child) =>
            // A child is required to exist
            Child = child ?? throw new ArgumentNullException(nameof(child));

        public void AddChild(Behavior childBehavior) => Child = childBehavior;
    }
}