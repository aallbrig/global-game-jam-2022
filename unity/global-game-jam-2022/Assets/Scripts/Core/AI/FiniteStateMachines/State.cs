using System;
using System.Collections.Generic;

namespace Core.AI.FiniteStateMachines
{
    public interface IState
    {
        public string Id { get; }

        public List<ITransition> Transitions { get; }

        public void Enter();
        public void Execute();
        public void Exit();
    }

    public class State : IState
    {
        private readonly Action _onEnter;
        private readonly Action _onExecute;
        private readonly Action _onExit;
        private string _id;
        private List<ITransition> _transitions;

        public State(Action onExecute)
        {
            _id = GenerateId();
            _onExecute = onExecute;
        }
        public State(Action onEnter, Action onExecute, Action onExit)
        {
            _id = GenerateId();
            _onEnter = onEnter;
            _onExecute = onExecute;
            _onExit = onExit;
        }
        public void Enter() => _onEnter?.Invoke();
        public void Execute() => _onExecute();
        public void Exit() => _onExit?.Invoke();

        public List<ITransition> Transitions => _transitions ??= new List<ITransition>();

        public string Id => _id ??= GenerateId();

        public static string GenerateId() => Guid.NewGuid().ToString();
    }
}