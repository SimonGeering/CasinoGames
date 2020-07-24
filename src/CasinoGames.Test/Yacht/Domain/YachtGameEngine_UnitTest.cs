using System;
using FluentAssertions;
using Xunit;

namespace CasinoGames.Test.Yacht
{
    public class YachtGameEngineShould
    {
        [Fact]
        public void StartWithoutError()
        {
            // Arrange

            // Act
            var gameEngine = new CasinoGames.Yacht.YachtGameEngine();

            // Assert
            gameEngine.Should().NotBeNull();
        }
    }
}
