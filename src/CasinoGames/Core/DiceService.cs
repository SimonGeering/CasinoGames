using System;
using CasinoGames.Infrastructure;

namespace CasinoGames.Core
{
    public interface IDiceService
    {
        int Roll(DiceType diceType, int quantity);
        int Roll(DiceType diceType);
    }
    internal class DiceService : IDiceService
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public DiceService(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public int Roll(DiceType diceType, int quantity)
        {
            int result = 0;

            for (int i = 1; i <= quantity; i++)
            {
                result += this.Roll(diceType);
            }
            return result;
        }

        public int Roll(DiceType diceType) => diceType switch
        {
            DiceType.D4 => this.randomNumberGenerator.Next(1, 4),
            DiceType.D6 => this.randomNumberGenerator.Next(1, 6),
            DiceType.D10 => this.randomNumberGenerator.Next(1, 10),
            DiceType.D12 => this.randomNumberGenerator.Next(1, 12),
            DiceType.D66 => this.GetD66Value(),
            _ => throw new ArgumentOutOfRangeException(nameof(diceType))
        };

        private int GetD66Value()
        {
            string tens = Convert.ToString(this.Roll(DiceType.D6));
            string units = Convert.ToString(this.Roll(DiceType.D6));
            string number = string.Concat(tens, units);
            return Int32.Parse(number);
        }
    }
}