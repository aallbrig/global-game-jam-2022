using Core.Touch;
using UnityEngine;

namespace MonoBehaviors.Player
{
    public class PlayerIntentions : MonoBehaviour
    {
        public IPlayerVerbProvider PlayerService { get; set; }

        public Camera Camera { get; set; }

        private void Start()
        {
            PlayerService ??= GetComponent<IPlayerVerbProvider>();
            PlayerService ??= new FakePlayerService();
            Camera ??= Camera.main;
            Camera ??= new GameObject().AddComponent<Camera>();
        }

        private void OnEnable()
        {
            InputManager.SwipeOccurred += HandleSwipe;
            InputManager.TapOccurred += HandleTap;
        }

        private void OnDisable()
        {
            InputManager.SwipeOccurred -= HandleSwipe;
            InputManager.TapOccurred -= HandleTap;
        }

        private void HandleTap(TouchInteraction end)
        {
            if (PlayerService.DetectInteractable(Camera.ScreenPointToRay(end.position), out var interactable))
                PlayerService.Interact(interactable);
        }

        private void HandleSwipe(Swipe swipe) => PlayerService.ConstantLocomotion(swipe.vectorNormalized);
    }
}