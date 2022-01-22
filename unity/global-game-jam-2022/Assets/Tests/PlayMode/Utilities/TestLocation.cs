using UnityEngine;

namespace Tests.PlayMode.Utilities
{
    public static class TestLocation
    {
        private static int _index;
        private static readonly float offset = 10; // in unity units
        public static Transform Next()
        {
            var gameObject = new GameObject();
            gameObject.transform.position = new Vector3(_index++ * offset, offset, 0);
            return gameObject.transform;
        }
    }

}