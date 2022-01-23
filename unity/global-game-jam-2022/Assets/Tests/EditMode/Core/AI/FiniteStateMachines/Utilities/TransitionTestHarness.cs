using Core.AI.FiniteStateMachines;

namespace Tests.EditMode.Core.AI.FiniteStateMachines.Utilities
{
    public static class TransitionTestHarness
    {
        public static IState RunTransition(ITransition transition)
        {
            transition.OnTransition();
            return transition.IsValid() ? transition.NextState() : null;
        }
    }
}