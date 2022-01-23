using System;
using UnityEngine;
using UnityEngine.AI;

namespace MonoBehaviors.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour, IPlayerVerbProvider
    {
        [SerializeField] private Vector3 direction = Vector3.zero;
        [SerializeField] private NavMeshAgent agent;
        private void Start()
        {
            agent ??= GetComponent<NavMeshAgent>();
            if (agent == null) throw new ArgumentNullException(nameof(agent));
        }
        private void Update()
        {
            if (direction == Vector3.zero) return;

            agent.destination = transform.position + direction * 2;
        }

        public void ConstantLocomotion(Vector2 normalizedDirection)
        {
            direction = new Vector3(normalizedDirection.x, 0, normalizedDirection.y);
        }
        public void Interact(IPlayerInteractable playerInteractable) {}
        public bool DetectInteractable(Ray screenPointToRay, out IPlayerInteractable playerInteractable)
        {
            playerInteractable = null;
            return false;
        }
    }
}