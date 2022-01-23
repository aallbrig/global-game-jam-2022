using Core.AI.FiniteStateMachines;
using NUnit.Framework;
using Tests.EditMode.Core.AI.FiniteStateMachines.TestDoubles;
using Tests.EditMode.Core.AI.FiniteStateMachines.Utilities;

namespace Tests.EditMode.Core.AI.FiniteStateMachines
{
    public class StateUnitTests
    {
        [Test]
        public void States_ExposesListOfTransitions_ForUpdating()
        {
            var sut = new State(null);

            sut.Transitions.Add(new FakeTransition());

            Assert.IsTrue(sut.Transitions.Count > 0);
        }
        [Test]
        public void States_AffordAbilityToSet_EnterCommand()
        {
            var called = false;
            var sut = new State(() => called = true, () => {}, () => {});

            StateTestHarness.RunState(sut);

            Assert.IsTrue(called);
        }

        [Test]
        public void States_AffordAbilityToSet_ExecuteCommand()
        {
            var called = false;
            var sut = new State(() => called = true);

            StateTestHarness.RunState(sut);

            Assert.IsTrue(called);
        }

        [Test]
        public void States_AffordAbilityToSet_ExitCommand()
        {
            var called = false;
            var sut = new State(() => {}, () => {}, () => called = true);

            StateTestHarness.RunState(sut);

            Assert.IsTrue(called);
        }
    }
}