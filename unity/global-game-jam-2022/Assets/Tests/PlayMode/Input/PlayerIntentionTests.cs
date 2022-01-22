using System;
using System.Collections;
using Core.Touch;
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

    public class PlayerIntentionTests
    {
        [UnityTest]
        public IEnumerator PlayerIntentions_InterpretsSwipe()
        {
            var called = false;
            var sut = new GameObject().AddComponent<PlayerIntentions>();
            var spy = new SpyPlayerServices {OnConstantLocomotion = _ => called = true};
            sut.PlayerService = spy;
            yield return null;
            
            InputManager.TriggerSwipe(Swipe.Of(TouchInteraction.Of(Vector2.up), TouchInteraction.Of(Vector2.down)));

            Assert.IsTrue(called);
        }

        [UnityTest]
        public IEnumerator PlayerIntentions_InterpretsTap()
        {
            var called = false;
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

            var screenPoint = sut.Camera.WorldToScreenPoint(interactableObject.transform.position);
            var touchInteraction = TouchInteraction.Of(screenPoint);
            InputManager.TriggerTap(touchInteraction);

            Assert.IsTrue(called);
        }
    }
}