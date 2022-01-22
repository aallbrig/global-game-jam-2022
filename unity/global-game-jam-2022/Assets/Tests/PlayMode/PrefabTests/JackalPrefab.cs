using System.Collections;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.PrefabTests
{
    public class JackalPrefab
    {
        private const string PrefabLocation = "Prefabs/Jackal";

        [UnityTest]
        public IEnumerator Prefab_Spawnable()
        {
            var sut = Object.Instantiate(Resources.Load<GameObject>(PrefabLocation), TestLocation.Next());
            
            yield return null;

            Assert.NotNull(sut);
        }
    }
}