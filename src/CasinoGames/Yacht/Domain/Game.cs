using System.Collections.Generic;

namespace CasinoGames.Yacht.Domain
{
    public class Game
    {
        public int Score { get; private set; }
        public IEnumerable<Round> RoundsRemaining { get; private set; }

        public Game(int score, IEnumerable<Round> roundsRemaining)
        {
            this.Score = score;
            this.RoundsRemaining = roundsRemaining;
        }
    }
}