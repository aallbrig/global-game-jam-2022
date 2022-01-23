using System;

namespace Core.AI.BehaviorTrees.BuildingBlocks
{
    public class Condition : Behavior
    {
        private readonly Func<bool> _predicate;
        public Condition(Func<bool> predicate) => _predicate = predicate;
        protected override Status Execute() => _predicate.Invoke() ? Status.Success : Status.Failure;
    }
}