namespace Core.Combat
{
    public abstract class Ammunition
    {
        public abstract void Decrease();
        public abstract bool Empty();
        public abstract void Reload();
        public abstract float Damage();
        public void DealDamage(Health healthSystem) => healthSystem.ReceiveDamage(Damage());
    }
}