using System;
using System.Collections;
using MonoBehaviors.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.MonoBehaviours.UI
{
    public class SpyMainMenuInteractions : IMainMenuInteractions
    {
        public Action OnStartGame = () => {};
        public Action OnViewSource = () => {};
        public void StartGame() => OnStartGame.Invoke();
        public void ViewSource() => OnViewSource.Invoke();
    }

    public class MainMenuUnitTests
    {
        [UnityTest]
        public IEnumerator MainMenu_CanStartGame()
        {
            var called = false;
            var sut = new GameObject().AddComponent<MainMenu>();
            sut.Interactions = new SpyMainMenuInteractions {OnStartGame = () => called = true};
            yield return null;

            sut.StartGame();

            Assert.IsTrue(called);
        }

        [UnityTest]
        public IEnumerator MainMenu_CanViewSourceCodeRepository()
        {
            var called = false;
            var sut = new GameObject().AddComponent<MainMenu>();
            sut.Interactions = new SpyMainMenuInteractions {OnViewSource = () => called = true};
            yield return null;

            sut.ViewSource();

            Assert.IsTrue(called);
        }
    }
}