using Core.Combat;
using Core.Combat.Ammo;
using NUnit.Framework;

namespace Tests.EditMode.Core.Combat
{
    public class WeaponSystemTests
    {
        [Test]
        public void WeaponCanFireAmmunition()
        {
            var ammo = new PistolRounds(new PistolRoundConfig(1, 1, 35));
            var sut = new Weapon(ammo);

            sut.Fire();

            Assert.IsTrue(ammo.Empty());

        }

        [Test]
        public void AmmoCapableOfDealingDamageToHealthSystem()
        {
            var sut = new PistolRounds(new PistolRoundConfig(1, 1, 35));
            var enemyHealth = new Health(100);

            sut.DealDamage(enemyHealth);

            Assert.AreEqual(65, enemyHealth.CurrentHealth);
        }
    }
}