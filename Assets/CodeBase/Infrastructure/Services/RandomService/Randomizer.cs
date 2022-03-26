using UnityEngine;
using Random = System.Random;

namespace CodeBase.Infrastructure.Services.RandomService
{
    public class Randomizer : IRandomizer
    {
        private readonly Random _randomizer;

        public Randomizer()
        {
            _randomizer = new Random();
        }

        public int GetRandomInt(int min, int max)
        {
            return _randomizer.Next(min, max);
        }

        public float GetRandomFloat(float min, float max)
        {
            return _randomizer.Next(Mathf.RoundToInt(min), Mathf.RoundToInt(max));
        }
    }
}