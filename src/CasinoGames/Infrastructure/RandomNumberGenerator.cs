using System;

namespace CasinoGames.Infrastructure
{
    public interface IRandomNumberGenerator
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
    }

    internal class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new Random();

#region IRandomNumberGenerator

        public int Next()
        {
            return _random.Next();
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

#endregion
    }
}