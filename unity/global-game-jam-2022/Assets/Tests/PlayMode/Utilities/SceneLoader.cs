using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tests.PlayMode.Utilities
{
    public static class SceneLoader
    {
        private const float TimeLimit = 1000 * 120; // one minute max
        private static bool WithinTimeLimit(float startTime) => Time.time - startTime < TimeLimit;
        public static IEnumerator LoadTargetScene(string targetSceneName, Action<Scene> callback, bool reload = false)
        {
            var currentScene = SceneManager.GetActiveScene();
            if (!reload && currentScene.name == targetSceneName)
                yield break;
            var startTime = Time.time;
            var sceneAsync = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive);
            while (sceneAsync.isDone == false && WithinTimeLimit(startTime)) yield return null;
            if (sceneAsync.isDone) callback(SceneManager.GetSceneByName(targetSceneName));
        }
    }
}