using System.Collections;
using Core.Environment;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.PrefabTests.Environment
{
    public class FloorPrefab
    {
        private const string PrefabLocation = "Prefabs/Environment/Standard Floor";

        [UnityTest]
        public IEnumerator FloorPrefab_AffordsANavMesh_ForNavMeshAgents()
        {
            var testLocation = TestLocation.Next();
            var floorPrefab = Object.Instantiate(Resources.Load<GameObject>(PrefabLocation), testLocation);
            var sut = floorPrefab.transform.GetComponent<IProvideNavMeshSurface>();

            yield return new WaitForEndOfFrame();

            Assert.NotNull(sut.NavMeshSurface);
        }
    }
}