using System.Collections.Generic;

namespace CasinoGames.Yacht.Domain
{
    public class Game
    {
        public Game(int score, IEnumerable<Round> rounds)
        {
            this.Score = score;
            this.Rounds = rounds;
        }

        public int Score { get; private set; }
        public IEnumerable<Round> Rounds { get; private set; }
    }
}