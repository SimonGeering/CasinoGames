using CasinoGames.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
        => services.AddTransient<IDiceService, DiceService>();
}
