using System;
using UnityEngine;

namespace Core.Touch
{
    [Serializable]
    public class TouchInteraction
    {

        public Vector2 position;

        public float timing;

        private TouchInteraction(Vector2 raw)
        {
            position = raw;
            timing = Time.time;
        }

        public static TouchInteraction Of(Vector2 raw) => new TouchInteraction(raw);
        public override string ToString() => $"Timing: {timing} Position: {position}";
    }
}