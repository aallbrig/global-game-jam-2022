using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Tests.EditMode.Core.AI.BehaviorTrees.Utilities
{
    public static class BehaviorTestHarness
    {
        // "1000" is arbitrary
        private const int LoopLimit = 1000;

        public static void RunToComplete(Behavior behavior)
        {
            // for loop (instead of a while loop) to protect me from my code ^_^
            for (var i = 0; i < LoopLimit; i++)
            {
                var status = behavior.Evaluate();
                if (status != Behavior.Status.Running) break;
            }
        }
    }
}