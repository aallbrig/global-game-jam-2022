using System.Collections.Generic;

namespace Core.AI.BehaviorTrees.BuildingBlocks
{
    public abstract class Composite : Behavior, IAddChild
    {
        protected readonly List<Behavior> Children;
        protected int CurrentIndex;

        protected Composite(List<Behavior> children) => Children = children ?? new List<Behavior>();
        public void AddChild(Behavior childBehavior) => Children.Add(childBehavior);

        protected override void Initialize() => CurrentIndex = 0;
        public int ChildrenCount() => Children.Count;
    }
}