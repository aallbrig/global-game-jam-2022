using Core.AI.BehaviorTrees.BuildingBlocks;

namespace Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles
{
    public class BehaviorFake : Behavior
    {
        protected override void Initialize() {}
        protected override Status Execute() => Status.Success;
        protected override void Terminate() {}
    }
}