using System;
using CasinoGames.Yacht.Domain;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CasinoGames.Test.Yacht
{
    public class YachtGameShould
    {
        [Fact]
        public void StartWithoutError()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddYacht();

            // Act
            var gameEngine = services.BuildServiceProvider().GetRequiredService<IYachtGameEngine>();

            // Assert
            gameEngine.Should().NotBeNull();
        }
    }
}
