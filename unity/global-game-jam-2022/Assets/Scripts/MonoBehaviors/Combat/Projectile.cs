using Core.Combat;
using UnityEngine;

namespace MonoBehaviors.Combat
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        public Vector3 projectileVector = Vector3.zero;
        public float speed = 10;
        public Transform projectileTransform;

        private void Start()
        {
            projectileTransform ??= GetComponent<Transform>();
        }
    
        private void Update() => Move(Time.deltaTime);

        public void Move(float deltaTime)
        {
            if (NormalizedDirection == Vector3.zero) return;

            var newDestination = projectileTransform.position + NormalizedDirection * speed;
            Vector3.Lerp(projectileTransform.position, newDestination, deltaTime);
        }

        public Vector3 NormalizedDirection => projectileVector;

        public void SetVector(Vector3 normalizedVector) => projectileVector = normalizedVector;
    }
}