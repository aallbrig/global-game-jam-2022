using System;
using System.Collections.Generic;
using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Core.AI.BehaviorTrees
{
    public class BehaviorTree
    {
        public BehaviorTree(Behavior rootNode) =>
            // The root node can't be a leaf node?
            // Or is the concept of having the root node be composite very important?
            // For now, I will only care that the root node is a behavior
            RootBehavior = rootNode ?? throw new ArgumentNullException(nameof(rootNode));

        public Behavior RootBehavior { get; }

        public void Tick() =>
            // DESIGN DECISION: when a BT re-evaluates, should it pick up from where it left off?
            // (aka remember the current node?)
            // ...because right now, it just sorta executes the whole thing
            RootBehavior.Evaluate();

        struct BehaviorLevel
        {
            public int Level;
            public Behavior Behavior;
        }

        public string PrintTree()
        {
            var stringRepresentation = "Behavior Tree\n";
            var behaviorStack = new Stack<BehaviorLevel>();
            behaviorStack.Push(new BehaviorLevel { Level = 0, Behavior = RootBehavior });
            while (behaviorStack.Count != 0)
            {
                var nextBehaviorLevel = behaviorStack.Pop();
                var typeFullName = nextBehaviorLevel.Behavior.GetType().ToString();
                var typeLastBit = typeFullName.Substring(typeFullName.LastIndexOf('.') + 1);
                stringRepresentation += $"{new string('-', nextBehaviorLevel.Level)} {typeLastBit}\n";
                if (nextBehaviorLevel.Behavior is Composite nextComposite)
                {
                    for (var i = nextComposite.Children.Count - 1; i >= 0; i--)
                    {
                        behaviorStack.Push(new BehaviorLevel{ Level = nextBehaviorLevel.Level + 1, Behavior = nextComposite.Children[i]});
                    }
                }
            }
            return stringRepresentation;
        }
    }
}