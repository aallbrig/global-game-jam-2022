using System;
using System.Runtime.InteropServices;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviors.UI
{
    public class MainMenuInteractions : MonoBehaviour, IMainMenuInteractions
    {

        public GameConfiguration configuration;

        private void Start()
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        }
        public void StartGame() => SceneManager.LoadScene(configuration.levelOne.sceneName, LoadSceneMode.Single);
        public void ViewSource()
        {
            #if !UNITY_EDITOR && UNITY_WEBGL
                OpenURL(configuration.sourceCodeUrl.url);
            #endif
        }
        [DllImport("__Internal")] private static extern void OpenURL(string url);
    }
}