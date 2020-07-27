using System.Collections.Generic;

namespace CasinoGames.Yacht.Domain
{
    public interface IYachtGameEngine
    {
        Game Start();
    }
    internal class YachtGameEngine : IYachtGameEngine
    {
        public Game Start()
        {
            // Don't know anything more than that there are 12 rounds at the start yet ...
            var rounds = new List<Round>()
            {
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round(),
                new Round()
            };
            return new Game(score: 0, rounds);
        }
    }
}
