#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CasinoGames.Test;

public class ServiceCollection_Should
{
    [Fact]
    [Trait("Category", "Unit")]
    public void BeAbleToInstantiateAllRegisteredTypes()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddYacht();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var result = new List<object>();

        foreach (var serviceDescriptor in services)
        {
            try
            {
                var instance = serviceProvider.GetRequiredService(serviceDescriptor.ServiceType);
                instance.Should().NotBeNull();
                instance.Should().BeAssignableTo(serviceDescriptor.ServiceType);
                result.Add(instance);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to instantiate '{serviceDescriptor.ServiceType.FullName}'", ex);
            }
        }

        // Assert
        result.Should().HaveCount(services.Count);
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
