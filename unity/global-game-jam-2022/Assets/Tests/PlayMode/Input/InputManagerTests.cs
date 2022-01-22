using System.Collections;
using Core.Touch;
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
        public IEnumerator InputManager_DetectsSwipes()
        {
            Swipe recordedSwipe = null;
            InputManager.SwipeOccurred += swipe => recordedSwipe = swipe;
            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            var sut = new GameObject().AddComponent<InputManager>();
            yield return null;

            BeginTouch(pointer.deviceId, Vector2.up * 2);
            EndTouch(pointer.deviceId, Vector2.zero);

            Assert.NotNull(recordedSwipe);
            Assert.AreEqual(2, recordedSwipe.distance);
            Assert.AreEqual(Vector2.down, recordedSwipe.vectorNormalized);
        }

        [UnityTest]
        public IEnumerator InputManager_DetectsTaps()
        {
            TouchInteraction recordedTap = null;
            InputManager.TapOccurred += tap => recordedTap = tap;
            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            var sut = new GameObject().AddComponent<InputManager>();
            yield return null;

            BeginTouch(pointer.deviceId, Vector2.zero);
            EndTouch(pointer.deviceId, Vector2.zero);

            Assert.NotNull(recordedTap);
            Assert.AreEqual(Vector2.zero, recordedTap.position);
        }
    }
}