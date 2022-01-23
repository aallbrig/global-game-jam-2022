using System;

namespace Core.AI.BehaviorTrees.BuildingBlocks
{
    public class TaskAction : Behavior
    {
        private readonly Func<Status> _action;
        private readonly Action _setup;
        private readonly Action _teardown;
        public TaskAction(Func<Status> action, Action setup = null, Action teardown = null)
        {
            _action = action;
            _setup = setup;
            _teardown = teardown;
        }

        protected override void Initialize() => _setup?.Invoke();

        protected override Status Execute()
        {
            CurrentStatus = _action.Invoke();
            return CurrentStatus;
        }

        protected override void Terminate() => _teardown?.Invoke();
    }
}