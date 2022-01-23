using System;
using Core.AI.FiniteStateMachines;

namespace Tests.EditMode.Core.AI.FiniteStateMachines.TestDoubles
{

    public class SpyTransition : ITransition
    {
        private readonly Func<bool> _isValid;
        private readonly Func<IState> _nextState;
        private readonly Action _onTransition;
        public SpyTransition(Func<bool> isValid, Func<IState> nextState, Action onTransition)
        {
            _isValid = isValid;
            _nextState = nextState;
            _onTransition = onTransition;
        }
        public bool IsValid() => _isValid();
        public IState NextState() => _nextState();
        public void OnTransition() => _onTransition();
    }
}