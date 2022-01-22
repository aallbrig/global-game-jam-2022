using System;
using System.Collections;
using MonoBehaviors;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests.PlayMode.Input
{
    public class SpyPlayerServices : IPlayerVerbProvider
    {
        public Action<Vector2> OnConstantLocomotion;
        public Action<IInteractable> OnInteract;
        public Action<Vector3> OnMoveToLocation;

        public void ConstantLocomotion(Vector2 normalizedDirection) => OnConstantLocomotion?.Invoke(normalizedDirection);
        public void MoveToLocation(Vector3 destination) => OnMoveToLocation?.Invoke(destination);
        public void Interact(IInteractable interactable) => OnInteract?.Invoke(interactable);
    }

    public class PlayerIntentionTests : InputTestFixture
    {
        [UnityTest]
        public IEnumerator InputManager_CanCalculateNormalizedVector_OnSwipeInput()
        {
            var called = false;
            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            var sut = new GameObject().AddComponent<PlayerIntentions>();
            var spy = new SpyPlayerServices {OnConstantLocomotion = _ => called = true};
            sut.PlayerService = spy;
            yield return null;

            BeginTouch(pointer.deviceId, Vector2.up * 2);
            EndTouch(pointer.deviceId, Vector2.down);

            Assert.IsTrue(called);
        }
    }
}