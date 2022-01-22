using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

namespace MonoBehaviors.UI
{
    public class MainMenuInteractions : MonoBehaviour, IMainMenuInteractions
    {
        [DllImport("__Internal")]
        private static extern void OpenURL(string url);

        public GameConfiguration configuration;
        public void StartGame() => SceneManager.LoadScene(configuration.levelOne.sceneName, LoadSceneMode.Single);
        public void ViewSource()
        {
            #if !UNITY_EDITOR && UNITY_WEBGL
                OpenURL(configuration.sourceCodeUrl.url);
            #endif
        }

        private void Start()
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        }
    }
}