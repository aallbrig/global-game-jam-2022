using System;
using Core.Touch;
using Generated;
using MonoBehaviors.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviors
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<Swipe> SwipeOccurred;
        public static event Action<TouchInteraction> TapOccurred;

        public static void TriggerSwipe(Swipe swipe) => SwipeOccurred?.Invoke(swipe);
        public static void TriggerTap(TouchInteraction end) => TapOccurred?.Invoke(end);
        [SerializeField] private TouchInteraction end;
        [SerializeField] private TouchInteraction start;
        [SerializeField] private Swipe swipe;

        private PlayerControls _controls;

        public IPlayerVerbProvider PlayerService { get; set; }

        public Camera Camera { get; set; }

        private void Awake() => _controls = new PlayerControls();

        private void Start()
        {
            PlayerService ??= GetComponent<IPlayerVerbProvider>();
            PlayerService ??= new FakePlayerService();
            Camera ??= Camera.main;
            Camera ??= new GameObject().AddComponent<Camera>();
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