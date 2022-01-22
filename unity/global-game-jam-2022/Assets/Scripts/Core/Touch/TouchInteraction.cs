using System;
using UnityEngine;

namespace Core.Touch
{
    [Serializable]
    public class TouchInteraction
    {

        private TouchInteraction(Vector2 raw)
        {
            position = raw;
            timing = Time.time;
        }

        public Vector2 position;

        public float timing;

        public static TouchInteraction Of(Vector2 raw) => new TouchInteraction(raw);
        public override string ToString() => $"Timing: {timing} Position: {position}";
    }
}