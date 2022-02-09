using UnityEngine;

namespace Core.Combat
{
    public interface IProjectile
    {
        public Vector3 NormalizedDirection { get; }
        public void SetVector(Vector3 normalizedVector);
        public void Move(float deltaTime);
    }
}