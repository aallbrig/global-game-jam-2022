using System.Collections;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayMode.Utilities
{
    public class PrefabTester
    {
        public static IEnumerator PrefabExists(IExaminePrefabs examiner)
        {
            var sut = Object.Instantiate(Resources.Load<GameObject>(examiner.PrefabLocation), TestLocation.Next());

            yield return null;

            Assert.NotNull(sut);
        }
    }
}