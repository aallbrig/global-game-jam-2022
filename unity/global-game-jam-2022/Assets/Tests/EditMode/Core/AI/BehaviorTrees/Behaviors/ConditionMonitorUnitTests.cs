using System;
using Core.AI.BehaviorTrees.Behaviors;
using Core.AI.BehaviorTrees.BuildingBlocks;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles;
using Tests.EditMode.Core.AI.BehaviorTrees.Utilities;

namespace Tests.EditMode.Core.AI.BehaviorTrees.Behaviors
{
    public class ConditionMonitorUnitTests
    {
        [Test]
        public void ConditionMonitor_RunsChildBehavior_WhenPredicateIsTrue()
        {
            var spy = new BehaviorSpy(() => Behavior.Status.Success);
            var predicate = new Func<bool>(() => true);
            var sut = new ConditionMonitor(new Condition(predicate), spy);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.IsTrue(spy.ExecuteMethodCalled);
            Assert.AreEqual(Behavior.Status.Success, sut.CurrentStatus);
        }

        [Test]
        public void ConditionMonitor_Fails_WhenPredicateIsFalse()
        {
            var fake = new BehaviorFake();
            var predicate = new Func<bool>(() => false);
            var sut = new ConditionMonitor(new Condition(predicate), fake);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.AreEqual(Behavior.Status.Failure, sut.CurrentStatus);
        }
    }
}