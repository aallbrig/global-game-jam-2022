using System;
using Core.Touch;
using Generated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviors
{
    public interface IPlayerVerbProvider
    {
        public void ConstantLocomotion(Vector2 normalizedDirection);
        public void MoveToLocation(Vector3 destination);
    }
    public class PlayerIntentions : MonoBehaviour
    {
        public IPlayerVerbProvider PlayerService { get; set; }
        private PlayerControls _controls;
        private TouchInteraction _end;
        private TouchInteraction _start;
        private Swipe _swipe;

        private void Awake() => _controls = new PlayerControls();
        private void Start()
        {
            PlayerService ??= GetComponent<IPlayerVerbProvider>();
            if (PlayerService == null) throw new ArgumentNullException(nameof(PlayerService));
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
            EmitIntention();
        }

        private void EmitIntention()
        {
            if (_swipe.Distance > 1) PlayerService.ConstantLocomotion(_swipe.VectorNormalized);
            // else raycast into environment and see what is under the tap
            else PlayerService.MoveToLocation(_end.Position);
        }
    }
}