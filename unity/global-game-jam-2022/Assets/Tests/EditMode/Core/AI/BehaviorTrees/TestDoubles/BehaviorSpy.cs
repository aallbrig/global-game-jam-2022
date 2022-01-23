using System;
using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles
{
    public class BehaviorSpy : Behavior
    {

        private readonly Func<Status> _desiredExecuteStatus;
        public int ExecuteMethodCallCount;
        public bool ExecuteMethodCalled;
        public int InitializeMethodCallCount;
        public bool InitializeMethodCalled;
        public int TerminateMethodCallCount;
        public bool TerminateMethodCalled;
        public BehaviorSpy(Func<Status> desiredExecuteStatus) => _desiredExecuteStatus = desiredExecuteStatus;

        protected override Status Execute()
        {
            ExecuteMethodCallCount++;
            ExecuteMethodCalled = true;
            CurrentStatus = _desiredExecuteStatus.Invoke();
            return CurrentStatus;
        }

        protected override void Terminate()
        {
            TerminateMethodCallCount++;
            TerminateMethodCalled = true;
        }

        protected override void Initialize()
        {
            InitializeMethodCallCount++;
            InitializeMethodCalled = true;
        }
    }
}