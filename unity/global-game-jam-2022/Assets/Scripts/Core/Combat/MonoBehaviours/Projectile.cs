using UnityEngine;

namespace Core.Combat.MonoBehaviours
{
    public class Projectile : MonoBehaviour
    {
        public Vector3 projectileVector = Vector3.zero;
        public float speed = 10;

        private void Update() => Move();

        private void Move()
        {
            if (projectileVector == Vector3.zero) return;

            var projection = transform.position + projectileVector;
            var newPosition = Vector3.MoveTowards(transform.position, projection, speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}