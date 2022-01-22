using Core.Touch;
using Generated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviors
{
    public class InputManager : MonoBehaviour
    {
        private PlayerControls _controls;
        private TouchInteraction _end;
        private TouchInteraction _start;
        private Swipe _swipe;

        public Swipe Swipe { get; private set; }

        private void Awake() => _controls = new PlayerControls();
        private void Start()
        {
            _controls.Gameplay.Press.started += OnTouchInteractionStarted;
            _controls.Gameplay.Press.canceled += OnTouchInteractionStopped;
        }
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Enable();

        private void OnTouchInteractionStarted(InputAction.CallbackContext context)
        {
            _start = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());
            Debug.Log(_start);
        }

        private void OnTouchInteractionStopped(InputAction.CallbackContext context)
        {
            _end = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());
            _swipe = Swipe.Of(_start, _end);
            Swipe = _swipe;
        }
    }
}