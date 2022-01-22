using System.Collections;
using NUnit.Framework;
using Tests.PlayMode.Utilities;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.SceneTests
{
    public class LevelOneTests
    {
        private const string TargetScene = "Pillar of Autumn";

        public static string[] ExpectedGameElements =
        {
            "Player"
        };

        private GameObject FindGameObjectByName(string name) => GameObject.Find(name);

        [UnityTest]
        public IEnumerator TheSceneFeaturesTheseElements(
            [ValueSource(nameof(ExpectedGameElements))]
            string gameObjectName
        )
        {
            yield return SceneLoader.LoadTargetScene(TargetScene);

            var sut = FindGameObjectByName(gameObjectName);

            Assert.NotNull(sut);
        }
    }
}