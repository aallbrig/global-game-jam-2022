using Core.AI.BehaviorTrees.Behaviors;
using Core.AI.BehaviorTrees.BuildingBlocks;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles;

namespace Tests.EditMode.Core.AI.BehaviorTrees.Behaviors
{
    public class RepeaterUnitTests
    {
        [Test]
        public void Repeaters_CanRepeatAnAction_MultipleTimes()
        {
            var spy = new BehaviorSpy(() => Behavior.Status.Success);
            var sut = new Repeater(spy, 3);


            for (var i = 0; i < 1000; i++)
            {
                var status = sut.Evaluate();
                if (status == Behavior.Status.Success) break;
            }

            Assert.AreEqual(3, spy.InitializeMethodCallCount);
            Assert.AreEqual(3, spy.ExecuteMethodCallCount);
            Assert.AreEqual(3, spy.TerminateMethodCallCount);
        }
    }
}