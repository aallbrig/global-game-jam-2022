using System;
using UnityEngine;
using UnityEngine.AI;

namespace MonoBehaviors.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour, ILocomotion
    {
        public static Vector3 DirectionFromCameraPerspective(Transform cameraTransform, Vector2 swipeInput)
        {
            var perspectiveForward = cameraTransform.forward.normalized;
            var perspectiveRight = cameraTransform.right.normalized;
            return perspectiveForward * swipeInput.y + perspectiveRight * swipeInput.x;
        }
        public Camera Camera { get; set; }
        [SerializeField] private Vector3 direction = Vector3.zero;
        [SerializeField] private NavMeshAgent agent;
        private void Start()
        {
            agent ??= GetComponent<NavMeshAgent>();
            if (agent == null) throw new ArgumentNullException(nameof(agent));
            Camera ??= Camera.main;
            Camera ??= new GameObject().AddComponent<Camera>();
        }
        private void Update()
        {
            if (direction == Vector3.zero) return;

            agent.destination = transform.position + direction * 2;
        }

        public void ConstantLocomotion(Vector2 normalizedDirection)
        {
            if (normalizedDirection == null) throw new ArgumentNullException(nameof(normalizedDirection));

            var directionFromCameraPerspective = DirectionFromCameraPerspective(Camera.transform, normalizedDirection);
            direction = directionFromCameraPerspective;
        }
    }
}