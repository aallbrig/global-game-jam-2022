using Core.Touch;
using UnityEngine;

namespace MonoBehaviors.Player
{
    public class TestBedViewer : MonoBehaviour
    {
        public Camera Camera { get; set; }

        private void Start()
        {
            Camera ??= Camera.main;
            Camera ??= new GameObject().AddComponent<Camera>();
        }

        private void OnEnable() => InputManager.SwipeOccurred += HandleSwipe;

        private void OnDisable() => InputManager.SwipeOccurred -= HandleSwipe;
        private void HandleSwipe(Swipe swipe)
        {
            // Move camera
        }
    }
}