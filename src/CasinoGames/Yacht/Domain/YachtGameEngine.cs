using System.Collections.Generic;
using System.Linq;

namespace CasinoGames.Yacht.Domain
{
    public interface IYachtGameEngine
    {
        Game Start();
        Game CompleteCurrentRound(Game game);
    }
    internal class YachtGameEngine : IYachtGameEngine
    {
        public const int InitialScore = 0;
        public const int TotalRounds = 12;

        public Game Start()
        {
            // Don't know anything more than that there are 12 rounds at the start yet ...
            SortedList<int, Round> rounds = new SortedList<int, Round>();
            while(rounds.Count < TotalRounds)
            {
                var nextSequenceNumber = rounds.Count + 1;
                rounds.Add(nextSequenceNumber,  new Round { SequenceNumber = nextSequenceNumber });
            };

            return new Game
            {
                Score = InitialScore,
                IsCompleted = false,
                Rounds = rounds
            };
        }

        public Game CompleteCurrentRound(Game game)
        {

            // game.Rounds.OrderBy(x => x.SequenceNumber).ToList();
            //             .First(x => x.IsCompleted == false).IsCompleted == true;

            return game;
        }
    }
}
