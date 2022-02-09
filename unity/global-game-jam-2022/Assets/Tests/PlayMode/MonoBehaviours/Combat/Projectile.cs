using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests.PlayMode.MonoBehaviours.Combat
{
    public class Projectile
    {
        [UnityTest]
        public IEnumerator ProjectileWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}