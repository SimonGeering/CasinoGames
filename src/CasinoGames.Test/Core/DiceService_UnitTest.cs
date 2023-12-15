using CasinoGames.Core;
using static CasinoGames.Core.DiceType;

namespace CasinoGames.Test.Core;

public class DiceServiceShould
{
    private readonly ServiceProvider _serviceProvider;

    public DiceServiceShould()
    {
        var services = new ServiceCollection();
        services.AddInfrastructure();
        services.AddCoreServices();
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void ReturnARandomNumberBetween_1_and_4_WhenIRollASingle_D4()
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(D4);

        // Assert
        result.Should().BeInRange(1, 4);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void ReturnARandomNumberBetween_1_and_6_WhenIRollASingle_D6()
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(D6);

        // Assert
        result.Should().BeInRange(1, 6);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void ReturnARandomNumberBetween_1_and_10_WhenIRollASingle_D10()
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(D10);

        // Assert
        result.Should().BeInRange(1, 10);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void ReturnARandomNumberBetween_1_and_12_WhenIRollASingle_D12()
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(D12);

        // Assert
        result.Should().BeInRange(1, 12);
    }

    [Theory]
    [InlineData("11,12,13,14,15,16,21,22,23,24,25,26,31,32,33,34,35,36,41,42,43,44,45,46,51,52,53,54,55,56,61,62,63,64,65,66")]
    [Trait("Category", "Unit")]
    public void ReturnARandomNumberInTheD66Sequence_WhenIRollASingle_D66(string sequenceCSV)
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(D66);

        // Assert
        var validValues = sequenceCSV.Trim().Split(',').Select(value => int.Parse(value)).ToList();
        validValues.Should().Contain(result);
    }

    [Theory]
    [InlineData(1 , D4, 1, 4 )]
    [InlineData(2 , D4, 2, 8 )]
    [InlineData(3 , D4, 3, 12)]
    [InlineData(4 , D4, 4, 16)]
    [InlineData(5 , D4, 5, 20)]
    [InlineData(6 , D4, 6, 24)]
    [InlineData(7 , D4, 7, 28)]
    [InlineData(8 , D4, 8, 32)]
    [InlineData(9 , D4, 9, 38)]
    [InlineData(10, D4, 10, 40)]
    [InlineData(1 , D6, 1, 6 )]
    [InlineData(2 , D6, 2, 12)]
    [InlineData(3 , D6, 3, 18)]
    [InlineData(4 , D6, 4, 24)]
    [InlineData(5 , D6, 5, 30)]
    [InlineData(6 , D6, 6, 36)]
    [InlineData(7 , D6, 7, 42)]
    [InlineData(8 , D6, 8, 48)]
    [InlineData(9 , D6, 9, 54)]
    [InlineData(10, D6, 10, 60)]
    [InlineData(1 , D10, 1, 10)]
    [InlineData(2 , D10, 2, 20)]
    [InlineData(3 , D10, 3, 30)]
    [InlineData(4 , D10, 4, 40)]
    [InlineData(5 , D10, 5, 50)]
    [InlineData(6 , D10, 6, 60)]
    [InlineData(7 , D10, 7, 70)]
    [InlineData(8 , D10, 8, 80)]
    [InlineData(9 , D10, 9, 90)]
    [InlineData(10, D10, 10, 100)]
    [InlineData(1 , D12, 1, 12)]
    [InlineData(2 , D12, 2, 24)]
    [InlineData(3 , D12, 3, 36)]
    [InlineData(4 , D12, 4, 48)]
    [InlineData(5 , D12, 5, 60)]
    [InlineData(6 , D12, 6, 72)]
    [InlineData(7 , D12, 7, 84)]
    [InlineData(8 , D12, 8, 96)]
    [InlineData(9 , D12, 9, 108)]
    [InlineData(10, D12, 10, 120)]
    [Trait("Category", "Unit")]
    public void ReturnA_Total_Between_MinRoll_and_MaxRoll_WhenISumTheRolls_OfThe_Quantity_of_DiceType_Dice(int quantity, DiceType diceType, int minRole, int maxRoll)
    {
        // Arrange
        var diceService = _serviceProvider.GetRequiredService<IDiceService>();

        // Act
        var result = diceService.Roll(diceType, quantity);

        // Assert
        result.Should().BeInRange(minRole, maxRoll);
    }
}
