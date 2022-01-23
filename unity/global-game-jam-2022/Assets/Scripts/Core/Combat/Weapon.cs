namespace Core.Combat
{
    public class Weapon
    {
        private readonly Ammunition _ammo;
        public Weapon(Ammunition ammo) => _ammo = ammo;

        public void Fire()
        {
            // default implementation that can be overridden
            if (!_ammo.Empty()) _ammo.Decrease();
        }
    }
}