using Core.AI.FiniteStateMachines;
using NUnit.Framework;
using Tests.EditMode.Core.AI.FiniteStateMachines.TestDoubles;
using Tests.EditMode.Core.AI.FiniteStateMachines.Utilities;

namespace Tests.EditMode.Core.AI.FiniteStateMachines
{
    public class TransitionUnitTests
    {
        [Test]
        public void Transitions_ReturnNextState_WhenIsValidIsTrue()
        {
            var fakeState = new FakeState();
            var sut = new Transition(() => true, () => fakeState);

            var result = TransitionTestHarness.RunTransition(sut);

            Assert.AreSame(fakeState.Id, result?.Id);
        }

        [Test]
        public void Transitions_NoResult_WhenIsValidIsFalse()
        {
            var sut = new Transition(() => false, () => new FakeState());

            var result = TransitionTestHarness.RunTransition(sut);

            Assert.IsNull(result);
        }
    }
}