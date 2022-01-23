using Core.AI.FiniteStateMachines;

namespace Tests.EditMode.Core.AI.FiniteStateMachines.TestDoubles
{
    public class FakeTransition : ITransition
    {
        public bool IsValid() => true;
        public IState NextState() => new FakeState();
        public void OnTransition() {}
    }
}