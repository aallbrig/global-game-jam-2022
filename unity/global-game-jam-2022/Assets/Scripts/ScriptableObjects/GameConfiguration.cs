using System;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class SceneAsset
    {
        public string sceneName;
    }

    [Serializable]
    public class ExternalUrl
    {
        public string url;
    }
    [CreateAssetMenu(fileName = "New game configuration", menuName = "GGJ22/GameConfiguration", order = 0)]
    public class GameConfiguration : ScriptableObject
    {
        public SceneAsset mainMenu;
        public SceneAsset levelOne;
        public SceneAsset levelTwo;
        public SceneAsset levelThree;
        public SceneAsset levelFour;
        public SceneAsset credits;
        public SceneAsset testbed;
        public ExternalUrl sourceCodeUrl;
    }
}