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
        private readonly System.Random random = new System.Random();

        public int Next() => this.random.Next();
        public int Next(int maxValue) => this.random.Next(maxValue);
        public int Next(int minValue, int maxValue) => this.random.Next(minValue, maxValue);
    }
}