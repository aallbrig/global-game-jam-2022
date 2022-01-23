using System.Collections;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests.PlayMode.PrefabTests
{
    public class PlayerPrefab : InputTestFixture
    {
        private const string PrefabLocation = "Prefabs/Player";
        private const string TestPlatform = "Prefabs/Test Platform";

        [UnityTest]
        public IEnumerator PlayerPrefab_RespondsToDownwardSwipe()
        {
            var testLocation = TestLocation.Next();
            var floor = Object.Instantiate(Resources.Load<GameObject>(TestPlatform), testLocation);
            floor.GetComponent<NavMeshSurface>().BuildNavMesh();
            var sut = Object.Instantiate(Resources.Load<GameObject>(PrefabLocation), testLocation);

            InputSystem.AddDevice<Touchscreen>();
            var pointer = InputSystem.AddDevice<Pointer>();
            yield return null;

            var positionA = sut.transform.position;
            BeginTouch(pointer.deviceId, Vector2.up * 2);
            EndTouch(pointer.deviceId, Vector2.zero);
            yield return null;

            yield return new WaitForSeconds(0.25f);
            var positionB = sut.transform.position;

            Assert.IsTrue(Vector3.Distance(positionA, positionB) > 0);
        }
    }
}