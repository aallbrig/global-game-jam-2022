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
        public void Interact(IInteractable interactable);
        bool DetectInteractable(Ray screenPointToRay, out IInteractable interactable);
    }

    public class FakePlayerService : IPlayerVerbProvider
    {

        public void ConstantLocomotion(Vector2 normalizedDirection) {}
        public void MoveToLocation(Vector3 destination) {}
        public void Interact(IInteractable interactable) {}
        public bool DetectInteractable(Ray screenPointToRay, out IInteractable interactable)
        {
            interactable = null;
            var hits = Physics.RaycastAll(screenPointToRay, 1000);
            foreach (var hit in hits)
            {
                var maybeInteractable = hit.transform.GetComponent<IInteractable>();
                if (maybeInteractable != null)
                {
                    interactable = maybeInteractable;
                    return true;
                }
            }
            return false;
        }
    }

    public interface IInteractable {}

    public class PlayerIntentions : MonoBehaviour
    {
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
            EmitIntention();
        }

        private void EmitIntention()
        {
            if (swipe.distance > 1) PlayerService.ConstantLocomotion(swipe.vectorNormalized);
            if (PlayerService.DetectInteractable(Camera.ScreenPointToRay(end.position), out var interactable)) PlayerService.Interact(interactable);
        }
    }
}