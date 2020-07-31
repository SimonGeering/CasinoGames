namespace CasinoGames.Yacht.Domain
{
    public class Round
    {
        public Round(int sequenceNumber)
        {
            this.SequenceNumber = sequenceNumber;
        }

        public int SequenceNumber { get; private set;}
        public bool IsCompleted { get; private set; } = false;
    }
}