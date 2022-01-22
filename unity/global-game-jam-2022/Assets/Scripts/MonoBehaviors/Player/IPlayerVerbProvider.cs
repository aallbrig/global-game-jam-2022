using UnityEngine;

namespace MonoBehaviors.Player
{
    public interface IPlayerVerbProvider
    {
        public void ConstantLocomotion(Vector2 normalizedDirection);
        public void Interact(IPlayerInteractable playerInteractable);
        bool DetectInteractable(Ray screenPointToRay, out IPlayerInteractable playerInteractable);
    }
}