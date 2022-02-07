using System.Collections;
using Core.Environment;
using MonoBehaviors.Environment;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.PrefabTests.Environment
{
    public class WallPrefab
    {
        private const string PrefabLocation = "Prefabs/Environment/Standard Wall";
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