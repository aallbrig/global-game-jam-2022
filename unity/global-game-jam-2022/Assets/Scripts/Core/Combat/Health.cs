using UnityEngine;

namespace Core.Combat
{
    public class Health
    {

        public Health(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        private float MaxHealth { get; }

        public float CurrentHealth { get; private set; }

        public void ReceiveDamage(float damage) => CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
    }
}