using System;
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
    }
}