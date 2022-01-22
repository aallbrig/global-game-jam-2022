using System.Collections;
using UnityEngine.SceneManagement;

namespace Tests.PlayMode.Utilities
{
    public static class SceneLoader
    {
        public static IEnumerator LoadTargetScene(string targetSceneName)
        {
            var currentScene = SceneManager.GetActiveScene();
            var sceneAsync = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Single);

            while (sceneAsync.isDone == false) yield return null;
            if (currentScene.name == targetSceneName)
            {
                var sceneAsyncUnload = SceneManager.UnloadSceneAsync(currentScene);
                while (sceneAsyncUnload.isDone == false) yield return null;
            }
        }

    }
}