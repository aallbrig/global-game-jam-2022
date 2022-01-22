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

    public class FakePlayerService : IPlayerVerbProvider
    {

        public void ConstantLocomotion(Vector2 normalizedDirection) {}
        public void MoveToLocation(Vector3 destination) {}
    }
    public class PlayerIntentions : MonoBehaviour
    {
        public IPlayerVerbProvider PlayerService { get; set; }

        private PlayerControls _controls;
        [SerializeField] private TouchInteraction end;
        [SerializeField] private TouchInteraction start;
        [SerializeField] private Swipe swipe;

        private void Awake() => _controls = new PlayerControls();
        private void Start()
        {
            PlayerService ??= GetComponent<IPlayerVerbProvider>();
            PlayerService ??= new FakePlayerService();
            _controls.Gameplay.Press.started += OnTouchInteractionStarted;
            _controls.Gameplay.Press.canceled += OnTouchInteractionStopped;
        }
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Enable();

        private void OnTouchInteractionStarted(InputAction.CallbackContext context)
        {
            start = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());
        }

        private void OnTouchInteractionStopped(InputAction.CallbackContext context)
        {
            end = TouchInteraction.Of(_controls.Gameplay.Position.ReadValue<Vector2>());
            swipe = Swipe.Of(start, end);
            EmitIntention();
        }

        private void EmitIntention()
        {
            if (swipe.distance > 1) PlayerService.ConstantLocomotion(swipe.vectorNormalized);
            // else raycast into environment and see what is under the tap
            else PlayerService.MoveToLocation(end.position);
        }
    }
}