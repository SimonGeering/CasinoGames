using System.Collections.Generic;
using System.Linq;

namespace CasinoGames.Yacht.Domain
{
    public interface IYachtGameEngine
    {
        Game Start();
    }
    internal class YachtGameEngine : IYachtGameEngine
    {
        public const int InitialScore = 0;
        public const int TotalRounds = 12;

        public Game Start()
        {
            // Don't know anything more than that there are 12 rounds at the start yet ...
            var rounds = new List<Round>();
            while(rounds.Count < TotalRounds)
            {
                rounds.Add(new Round(rounds.Count + 1));
            };
            return new Game(score: InitialScore, rounds);
        }
    }
}
