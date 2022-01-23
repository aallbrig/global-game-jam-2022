using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees.Behaviors
{
    public class ConditionMonitor : Decorator
    {
        private readonly Condition _condition;
        public ConditionMonitor(Condition condition, Behavior child) : base(child) => _condition = condition;

        protected override Status Execute()
        {
            var conditionStatus = _condition.Evaluate();
            CurrentStatus = conditionStatus == Status.Success ? Child.Evaluate() : Status.Failure;
            return CurrentStatus;
        }
    }
}