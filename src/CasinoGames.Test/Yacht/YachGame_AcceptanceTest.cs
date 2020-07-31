using System;
using System.Linq;
using System.Threading.Tasks;
using CasinoGames.Yacht.Domain;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CasinoGames.Test.Yacht
{
    /*
        [ ] The object of the game is to score points by rolling five dice to make certain combinations.
        [ ] When a new round begins all five dice are rolled.
        [ ] One or more of the dice can be re-rolled up to two times, for a total of three roles per round.
        [ ] A game consists of twelve rounds.
        [ ] After each round the player chooses which scoring category is to be used for that round.
        [ ] Once a category has been used in the game, it cannot be used again.

        The scoring categories have varying point values, some of which are fixed values:

        [ ] - Little Straight
              1-2-3-4-5 - 30

        [ ] - Big Straight
              2-3-4-5-6	- 30

        [ ] - Yacht - (Highest of any category)
              Five-of-a-kind (All five dice showing the same face) - 50

        Others where the score depends on the value of the dice:

        [ ] - Full House:
            Three of one number and two of another - Sum of all dice.

        [ ] - Four-Of-A-Kind
              At least four dice showing the same face - Sum of those four dice.

        [ ] - Choice
              Any combination - Sum of all dice

        [ ] - Ones
              Any combination - The sum of dice with the number 1

        [ ] - Twos
              Any combination - The sum of dice with the number 2

        [ ] - Threes
              Any combination - The sum of dice with the number 3

        [ ] - Fours
              Any combination - The sum of dice with the number 4

        [ ] - Fives
              Any combination- The sum of dice with the number 5

        [ ] - Sixes
              Any combination - The sum of dice with the number 6

        [ ] If a category is chosen but the dice do not match the requirements of the category
            the player scores 0 in that category.

        [ ] A Yacht cannot be scored on Full House but can be scored on Four of a Kind,
            although the fifth die is not counted in the score.

        [ ] The maximum possible score depends on the scoring rules used, but with the above rules
            and both straights counting 30, the maximum score is 297.
    */
    public class YachtGameShould
    {
        [Fact]
        public void HaveAScoreOfZero_WhenTheGameStarts()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddYacht();

            // Act
            var result = services.BuildServiceProvider().GetRequiredService<IYachtGameEngine>().Start();

            // Assert
            result.Score.Should().Be(0);
        }

        [Fact]
        public void HaveNoneOfTheTwelveTotalRoundsCompleted_WhenTheGameStarts()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddYacht();

            // Act
            var result = services.BuildServiceProvider().GetRequiredService<IYachtGameEngine>().Start();

            // Assert
            result.Rounds.Should().HaveCount(12);
            result.Rounds.Should().OnlyContain(x => x.IsCompleted == false);
        }
    }
}