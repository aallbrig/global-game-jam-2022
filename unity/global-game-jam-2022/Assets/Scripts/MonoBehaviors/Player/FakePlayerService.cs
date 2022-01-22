using UnityEngine;

namespace MonoBehaviors.Player
{
    public class FakePlayerService : IPlayerVerbProvider
    {

        public void ConstantLocomotion(Vector2 normalizedDirection) {}
        public void Interact(IPlayerInteractable playerInteractable) {}
        public bool DetectInteractable(Ray screenPointToRay, out IPlayerInteractable playerInteractable)
        {
            playerInteractable = null;
            var hits = Physics.RaycastAll(screenPointToRay, 1000);
            foreach (var hit in hits)
            {
                var maybeInteractable = hit.transform.GetComponent<IPlayerInteractable>();
                if (maybeInteractable != null)
                {
                    playerInteractable = maybeInteractable;
                    return true;
                }
            }
            return false;
        }
    }
}