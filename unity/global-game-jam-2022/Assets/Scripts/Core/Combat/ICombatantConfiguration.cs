using System.Collections.Generic;

namespace Core.Combat
{
    public interface ICombatantConfiguration
    {
        public List<Weapon> Weapons { get; }
        public List<Ammunition> Ammo { get; }

        public Health Health { get; }
    }
}