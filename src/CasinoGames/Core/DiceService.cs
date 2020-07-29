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

        public int Roll(DiceType diceType)
        {
            int result = 0;

            switch (diceType)
            {
                case DiceType.D4:
                    result = this.randomNumberGenerator.Next(1, 4);
                    break;

                case DiceType.D6:
                    result = this.randomNumberGenerator.Next(1, 6);
                    break;

                case DiceType.D10:
                    result = this.randomNumberGenerator.Next(1, 10);
                    break;

                case DiceType.D12:
                    result = this.randomNumberGenerator.Next(1, 12);
                    break;

                case DiceType.D66:
                    string tens = Convert.ToString(this.Roll(DiceType.D6));
                    string units = Convert.ToString(this.Roll(DiceType.D6));
                    string number = string.Concat(tens, units);
                    result = Int32.Parse(number);
                    break;
            }

            return result;
        }
    }
}