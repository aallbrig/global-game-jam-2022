using System;
using Core.AI.BehaviorTrees.BuildingBlocks;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.Utilities;

namespace Tests.EditMode.Core.AI.BehaviorTrees.BuildingBlocks
{
    public class ActionUnitTests
    {
        [Test]
        public void ActionBehaviors_DeferExecutionDetailsToCaller()
        {
            var spyCalled = false;
            var spyAction = new Func<Behavior.Status>(() =>
            {
                spyCalled = true;
                return Behavior.Status.Success;
            });
            var sut = new TaskAction(spyAction);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.IsTrue(spyCalled);
        }

        [Test]
        public void ActionBehaviors_OptionallyAllowCustomSetupLogic()
        {
            var spyCalled = false;
            var spySetup = new Action(() => spyCalled = true);
            var sut = new TaskAction(() => Behavior.Status.Success, spySetup);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.IsTrue(spyCalled);
        }

        [Test]
        public void ActionBehaviors_OptionallyAllowCustomTeardownLogic()
        {
            var spyCalled = false;
            var spyTeardown = new Action(() => spyCalled = true);
            var sut = new TaskAction(() => Behavior.Status.Success, null, spyTeardown);

            BehaviorTestHarness.RunToComplete(sut);

            Assert.IsTrue(spyCalled);
        }
    }
}