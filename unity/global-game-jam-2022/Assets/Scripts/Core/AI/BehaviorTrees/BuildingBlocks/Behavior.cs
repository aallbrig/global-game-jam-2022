namespace Core.AI.BehaviorTrees.BuildingBlocks
{

    public abstract class Behavior
    {
        // Order matters. Don't have "Running" at the top of the list of statuses
        public enum Status
        {
            Success,
            Failure,
            Running
        }

        public Status CurrentStatus { get; protected set; }

        protected virtual void Initialize() {}
        protected abstract Status Execute();
        protected virtual void Terminate() {}

        public Status Evaluate()
        {
            if (CurrentStatus != Status.Running) Initialize();
            CurrentStatus = Execute();
            if (CurrentStatus != Status.Running) Terminate();
            return CurrentStatus;
        }
    }
}