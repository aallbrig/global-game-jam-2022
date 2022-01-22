using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviors.UI
{
    public class MainMenuInteractions : MonoBehaviour, IMainMenuInteractions
    {
        public GameConfiguration configuration;
        public void StartGame()
        {
            SceneManager.LoadScene(configuration.levelOne.sceneName, LoadSceneMode.Single);
        }

        private void Start()
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        }
    }
}