using Core.AI.FiniteStateMachines;

namespace Tests.EditMode.Core.AI.FiniteStateMachines.Utilities
{
    public static class StateTestHarness
    {
        public static void RunState(IState state)
        {
            state.Enter();
            state.Execute();
            state.Exit();
        }
    }
}