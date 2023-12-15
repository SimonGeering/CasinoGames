namespace CasinoGames.Yacht.Domain;

public record Game
{
    public int Score { get; init; }
    public bool IsCompleted { get; init; }
    public SortedList<int, Round> Rounds { get; init; } = new();
}
