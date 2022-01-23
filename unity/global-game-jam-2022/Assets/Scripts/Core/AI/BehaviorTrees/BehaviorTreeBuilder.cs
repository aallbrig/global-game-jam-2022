using System.Collections.Generic;
using Core.AI.BehaviorTrees.Behaviors;
using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees
{
    public class BehaviorTreeBuilder : IProvideBehaviorTree
    {
        private Behavior _currentBehavior;
        private Behavior _rootNode;

        public BehaviorTree Build() =>
            // I choose to allow empty "build" by declaring that this method can return null
            _rootNode == default ? null : new BehaviorTree(_rootNode);

        private void AssignRootIfUndefined()
        {
            if (_rootNode == default && _currentBehavior != default)
                _rootNode = _currentBehavior;
        }

        public BehaviorTreeBuilder SelectorStart()
        {
            _currentBehavior = new Selector(new List<Behavior>());
            return this;
        }

        public BehaviorTreeBuilder SelectorEnd()
        {
            AssignRootIfUndefined();
            return this;
        }

        public BehaviorTreeBuilder AddChild(Behavior childBehavior)
        {
            if (_currentBehavior is IAddChild acceptsChild)
                acceptsChild.AddChild(childBehavior);
            // What happens if it isn't?

            return this;
        }
        public BehaviorTreeBuilder SequenceStart()
        {
            _currentBehavior = new Sequence(new List<Behavior>());
            return this;
        }
        public BehaviorTreeBuilder SequenceEnd()
        {
            AssignRootIfUndefined();
            return this;
        }
    }
}