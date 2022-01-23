using Core.AI.BehaviorTrees;
using Core.AI.BehaviorTrees.Behaviors;
using NUnit.Framework;
using Tests.EditMode.Core.AI.BehaviorTrees.TestDoubles;

namespace Tests.EditMode.Core.AI.BehaviorTrees
{
    public class BehaviorTreeBuilderUnitTests
    {
        [Test]
        public void BTBuilder_RequiresAtLeastOneBehavior_ToBeBuilt()
        {
            var sut = new BehaviorTreeBuilder();

            var result = sut.Build();

            Assert.IsNull(result);
        }

        [Test]
        public void BTBuilder_CanBuildSelectorsAndAddChildren()
        {
            var sut = new BehaviorTreeBuilder();

            var result = sut
                .SelectorStart()
                .AddChild(new BehaviorFake())
                .AddChild(new BehaviorFake())
                .AddChild(new BehaviorFake())
                .SelectorEnd()
                .Build();

            Assert.IsTrue(result.RootBehavior is Selector);
            Assert.AreEqual(3, ((Selector) result.RootBehavior).ChildrenCount());
        }

        [Test]
        public void BTBuilder_CanBuildSequencesAndAddChildren()
        {
            var sut = new BehaviorTreeBuilder();

            var result = sut
                .SequenceStart()
                .AddChild(new BehaviorFake())
                .AddChild(new BehaviorFake())
                .AddChild(new BehaviorFake())
                .SequenceEnd()
                .Build();

            Assert.IsTrue(result.RootBehavior is Sequence);
            Assert.AreEqual(3, ((Sequence) result.RootBehavior).ChildrenCount());
        }
    }
}