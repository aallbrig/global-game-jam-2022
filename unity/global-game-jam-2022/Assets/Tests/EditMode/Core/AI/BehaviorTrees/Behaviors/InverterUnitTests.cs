using Core.AI.BehaviorTrees.Behaviors;
using Core.AI.BehaviorTrees.BuildingBlocks;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles;
using Tests.EditMode.Core.AI.BehaviorTrees.Utilities;

namespace Tests.EditMode.Core.AI.BehaviorTrees.Behaviors
{
    public class InverterUnitTests
    {
        [Test]
        public void Inverter_ReturnSuccess_WhenChildFails()
        {
            var spy = new BehaviorSpy(() => Behavior.Status.Failure);
            var sut = new Inverter(spy);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.AreEqual(Behavior.Status.Success, sut.CurrentStatus);
        }

        [Test]
        public void Inverter_ReturnFailure_WhenChildSucceeds()
        {
            var spy = new BehaviorSpy(() => Behavior.Status.Success);
            var sut = new Inverter(spy);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.AreEqual(Behavior.Status.Failure, sut.CurrentStatus);
        }

        [Test]
        public void Inverter_ReturnsRunning_WhenChildReturnsRunning()
        {
            var spy = new BehaviorSpy(() => Behavior.Status.Running);
            var sut = new Inverter(spy);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.AreEqual(Behavior.Status.Running, sut.CurrentStatus);
        }
    }
}