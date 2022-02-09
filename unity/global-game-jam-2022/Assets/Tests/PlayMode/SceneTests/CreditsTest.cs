using System.Collections;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.PlayMode.SceneTests
{
    public class CreditsTest
    {
        private const string TargetScene = "Credits";

        public static string[] ExpectedGameElements =
        {
            "Credits"
        };

        private GameObject FindGameObjectByName(string name) => GameObject.Find(name);

        [UnityTest]
        public IEnumerator TheSceneFeaturesTheseElements(
            [ValueSource(nameof(ExpectedGameElements))]
            string gameObjectName
        )
        {
            Scene sut;
            yield return SceneLoader.LoadTargetScene(TargetScene, scene => sut = scene);

            Assert.NotNull(GameObject.Find(gameObjectName));
        }
    }
}