using UnityEngine;

namespace MonoBehaviors.Player
{
    public interface ILocomotion
    {
        public void ConstantLocomotion(Vector2 normalizedDirection);
    }
    public interface IPlayerVerbProvider
    {
        public void Interact(IPlayerInteractable playerInteractable);
        bool DetectInteractable(Ray screenPointToRay, out IPlayerInteractable playerInteractable);
    }
}