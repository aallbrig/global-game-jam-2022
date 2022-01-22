using System.Collections;
using MonoBehaviors;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests.PlayMode.Input
{
    public class InputManagerTests : InputTestFixture
    {
        [UnityTest]
        public IEnumerator InputManager_CanCalculateNormalizedVector_OnSwipeInput()
        {
            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            var sut = new GameObject().AddComponent<InputManager>();
            yield return null;

            BeginTouch(pointer.deviceId, Vector2.up);
            EndTouch(pointer.deviceId, Vector2.down);

            Assert.AreEqual(sut.Swipe.VectorNormalized, Vector2.down);
        }
    }
}