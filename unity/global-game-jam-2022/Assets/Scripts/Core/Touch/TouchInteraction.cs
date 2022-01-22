using System;
using UnityEngine;

namespace Core.Touch
{
    [Serializable]
    public class TouchInteraction
    {

        public Vector2 position;

        public float timing;

        private TouchInteraction(Vector2 position)
        {
            this.position = position;
            timing = Time.time;
        }

        public static TouchInteraction Of(Vector2 position) => new TouchInteraction(position);
        public override string ToString() => $"Timing: {timing} Position: {position}";
    }
}