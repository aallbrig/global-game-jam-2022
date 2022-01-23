using System;

namespace Core.AI.FiniteStateMachines
{
    public interface ITransition
    {
        public bool IsValid();
        public IState NextState();
        public void OnTransition();
    }

    public class Transition : ITransition
    {
        private readonly Func<bool> _isValid;
        private readonly Func<IState> _nextState;
        private readonly Action _onTransition;
        public Transition(Func<bool> isValid, Func<IState> nextState)
        {
            _isValid = isValid;
            _nextState = nextState;
        }
        public Transition(Func<bool> isValid, Func<IState> nextState, Action onTransition)
        {
            _isValid = isValid;
            _nextState = nextState;
            _onTransition = onTransition;
        }
        public bool IsValid() => _isValid();
        public IState NextState() => _nextState();
        public void OnTransition() => _onTransition?.Invoke();
    }
}