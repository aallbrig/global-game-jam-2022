using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees.Behaviors
{
    public class Inverter : Decorator
    {
        public Inverter(Behavior child) : base(child) {}

        protected override Status Execute()
        {
            var childStatus = Child.Evaluate();
            switch (childStatus)
            {
                case Status.Success:
                    CurrentStatus = Status.Failure;
                    break;
                case Status.Failure:
                    CurrentStatus = Status.Success;
                    break;
                default:
                    CurrentStatus = childStatus;
                    break;
            }
            return CurrentStatus;
        }
    }
}