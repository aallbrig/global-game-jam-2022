using Core.AI.BehaviorTrees;
using Core.AI.BehaviorTrees.BuildingBlocks;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles;

namespace Tests.EditMode.Core.AI.BehaviorTrees
{
    public class BehaviorTreeUnitTests
    {
        [Test]
        public void BehaviorTrees_CanBeTicked()
        {
            var spyBehavior = new BehaviorSpy(() => Behavior.Status.Success);
            var sut = new BehaviorTree(spyBehavior);

            sut.Tick();

            Assert.IsTrue(spyBehavior.InitializeMethodCalled);
            Assert.IsTrue(spyBehavior.ExecuteMethodCalled);
            Assert.IsTrue(spyBehavior.TerminateMethodCalled);
        }
    }
}