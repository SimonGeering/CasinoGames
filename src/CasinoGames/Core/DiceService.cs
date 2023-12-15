using CasinoGames.Infrastructure;

namespace CasinoGames.Core;

public interface IDiceService
{
    int Roll(DiceType diceType, int quantity);
    int Roll(DiceType diceType);
}
internal class DiceService(IRandomNumberGenerator randomNumberGenerator) : IDiceService
{
    public int Roll(DiceType diceType, int quantity)
    {
        var result = 0;

        for (var i = 1; i <= quantity; i++)
        {
            result += Roll(diceType);
        }
        return result;
    }

    public int Roll(DiceType diceType) => diceType switch
    {
        DiceType.D4 => randomNumberGenerator.Next(1, 4),
        DiceType.D6 => randomNumberGenerator.Next(1, 6),
        DiceType.D10 => randomNumberGenerator.Next(1, 10),
        DiceType.D12 => randomNumberGenerator.Next(1, 12),
        DiceType.D66 => GetD66Value(),
        _ => throw new ArgumentOutOfRangeException(nameof(diceType))
    };

    private int GetD66Value()
    {
        var tens = Convert.ToString(Roll(DiceType.D6));
        var units = Convert.ToString(Roll(DiceType.D6));
        var number = string.Concat(tens, units);
        return int.Parse(number);
    }
}
