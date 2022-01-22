using System;
using System.Collections;
using MonoBehaviors;
using MonoBehaviors.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests.PlayMode.Input
{
    [RequireComponent(typeof(BoxCollider))]
    public class SpyPlayerInteractableObject : MonoBehaviour, IPlayerInteractable {}

    public class SpyPlayerServices : IPlayerVerbProvider
    {
        public Action<Vector2> OnConstantLocomotion;
        public Action<IPlayerInteractable> OnInteract;
        public Action<Vector3> OnMoveToLocation;
        public Action<Ray> OnDetectInteractable;
        public IPlayerInteractable PlayerInteractable;

        public void ConstantLocomotion(Vector2 normalizedDirection) => OnConstantLocomotion?.Invoke(normalizedDirection);
        public void MoveToLocation(Vector3 destination) => OnMoveToLocation?.Invoke(destination);
        public void Interact(IPlayerInteractable playerInteractable) => OnInteract?.Invoke(playerInteractable);
        public bool DetectInteractable(Ray screenPointToRay, out IPlayerInteractable playerInteractable)
        {
            playerInteractable = PlayerInteractable;
            OnDetectInteractable?.Invoke(screenPointToRay);
            return true;
        }
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

        [UnityTest]
        public IEnumerator PlayerIntention_KnowsToInteract_WithInteractableObjects()
        {
            var called = false;
            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            var sut = new GameObject().AddComponent<PlayerIntentions>();
            var interactableObject = new GameObject().AddComponent<SpyPlayerInteractableObject>();
            var spy = new SpyPlayerServices
            {
                OnInteract = _ => called = true,
                PlayerInteractable = interactableObject
            };
            var camera = new GameObject().AddComponent<Camera>();
            sut.PlayerService = spy;
            sut.Camera = camera;
            yield return null;

            var worldToScreenPoint = camera.WorldToScreenPoint(interactableObject.transform.position);
            BeginTouch(pointer.deviceId, worldToScreenPoint);
            EndTouch(pointer.deviceId, worldToScreenPoint);

            Assert.IsTrue(called);
        }
    }
}