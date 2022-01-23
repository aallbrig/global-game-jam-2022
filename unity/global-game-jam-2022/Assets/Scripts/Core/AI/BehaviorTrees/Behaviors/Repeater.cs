using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees.Behaviors
{
    public class Repeater : Decorator
    {
        private readonly int _repeatCount;
        private int _currentCount;
        public Repeater(Behavior child, int repeatCount) : base(child) =>
            _repeatCount = repeatCount;

        protected override void Initialize() => _currentCount = 0;
        protected override Status Execute()
        {
            if (_currentCount >= _repeatCount) return Status.Success;

            switch (Child.Evaluate())
            {
                case Status.Success:
                    _currentCount++;
                    CurrentStatus = Status.Running;
                    break;
                case Status.Failure:
                    CurrentStatus = Status.Failure;
                    break;
                case Status.Running:
                    CurrentStatus = Status.Running;
                    break;
            }

            return CurrentStatus;
        }
    }
}