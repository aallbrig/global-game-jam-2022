using System;
using UnityEngine;

namespace Core.Touch
{
    [Serializable]
    public class TouchInteraction
    {

        private TouchInteraction(Vector2 raw)
        {
            Position = raw;
            Timing = Time.time;
        }

        public Vector2 Position { get; }

        public float Timing { get; }

        public static TouchInteraction Of(Vector2 raw) => new TouchInteraction(raw);
        public override string ToString() => $"Timing: {Timing} Position: {Position}";
    }
}