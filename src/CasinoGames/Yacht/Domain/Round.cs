namespace CasinoGames.Yacht.Domain;

public record Round
{
    public int SequenceNumber { get; init; }
    public bool IsCompleted { get; init; }
}
