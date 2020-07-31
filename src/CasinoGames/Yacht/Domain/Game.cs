using System.Collections.Generic;

namespace CasinoGames.Yacht.Domain
{
    public class Game
    {
        public Game(int score, bool isCompleted, IEnumerable<Round> rounds)
        {
            this.Score = score;
            this.IsCompleted = isCompleted;
            this.Rounds = rounds;
        }

        public int Score { get; private set; }
        public bool IsCompleted { get; private set; }
        public IEnumerable<Round> Rounds { get; private set; }
    }
}