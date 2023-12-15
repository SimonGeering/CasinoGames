namespace CasinoGames.Infrastructure;

public interface IRandomNumberGenerator
{
    int Next();
    int Next(int maxValue);
    int Next(int minValue, int maxValue);
}

internal class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new();

    public int Next() => _random.Next();
    public int Next(int maxValue) => _random.Next(maxValue);
    public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
}
