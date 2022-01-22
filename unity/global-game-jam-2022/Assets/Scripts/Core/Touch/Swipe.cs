using System;
using UnityEngine;

namespace Core.Touch
{
    [Serializable]
    public class Swipe
    {

        public float timing;

        public float distance;

        public Vector2 vector;

        public Vector2 vectorNormalized;
        private readonly TouchInteraction _end;
        private readonly TouchInteraction _start;
        private Swipe(TouchInteraction start, TouchInteraction end)
        {
            _start = start;
            _end = end;
            CalculateSwipeFacts();
        }

        public static Swipe Of(TouchInteraction start, TouchInteraction end) => new Swipe(start, end);

        private void CalculateSwipeFacts()
        {
            vector = _end.position - _start.position;
            vectorNormalized = vector.normalized;
            timing = _end.timing - _start.timing;
            distance = Vector2.Distance(_end.position, _start.position);
        }

        public override string ToString() =>
            $"Timing: {timing} Distance: {distance} Vector: {vector} Vector Normalized {vectorNormalized}";
    }
}