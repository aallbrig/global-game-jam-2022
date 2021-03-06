using System;
using Core.Touch;
using Generated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviors
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private TouchInteraction end;
        [SerializeField] private TouchInteraction start;
        [SerializeField] private Swipe swipe;

        private PlayerControls _controls;


        private void Awake() => _controls = new PlayerControls();

        private void Start()
        {
            _controls.Gameplay.Press.started += OnTouchInteractionStarted;
            _controls.Gameplay.Press.canceled += OnTouchInteractionStopped;
        }

        private void OnEnable() => _controls.Enable();

        private void OnDisable()
        {
            _controls.Gameplay.Press.started -= OnTouchInteractionStarted;
            _controls.Gameplay.Press.canceled -= OnTouchInteractionStopped;
            _controls.Disable();
        }

        public static event Action<Swipe> SwipeOccurred;

        public static event Action<TouchInteraction> TapOccurred;

        public static void TriggerSwipe(Swipe swipe) => SwipeOccurred?.Invoke(swipe);
        public static void TriggerTap(TouchInteraction end) => TapOccurred?.Invoke(end);

        private void OnTouchInteractionStarted(InputAction.CallbackContext context) =>
            start = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());

        private void OnTouchInteractionStopped(InputAction.CallbackContext context)
        {
            end = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());
            swipe = Swipe.Of(start, end);

            if (swipe.distance > 1) TriggerSwipe(swipe);
            else TriggerTap(end);
        }
    }
}