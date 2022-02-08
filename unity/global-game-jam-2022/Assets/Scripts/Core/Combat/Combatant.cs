using System.Collections.Generic;

namespace Core.Combat
{

    public class Combatant
    {
        public Weapon CurrentWeapon;
        private readonly List<Weapon> _weapons;
        private readonly List<Ammunition> _ammunition;

        public Combatant(ICombatantConfiguration config)
        {
            _weapons = config.Weapons;
            _ammunition = config.Ammo;
            if (_weapons.Count > 0) CurrentWeapon = _weapons[0];
        }

        public void AddAmmo(Ammunition ammo) => _ammunition.Add(ammo);
        public void AddWeapon(Weapon weapon) => _weapons.Add(weapon);
        public void Equip(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }
}