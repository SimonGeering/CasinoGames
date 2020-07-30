using CasinoGames.Yacht.Domain;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class DependencyInjectionExtensions
    {
        public static void AddYacht(this IServiceCollection services)
        {
            // Add Yacht Domain Services ...
            services.AddTransient<IYachtGameEngine, YachtGameEngine>();

            // Add Yacht UI View Models ...
            //services.AddTransient<IYachtGameViewModel, YachtGameViewModel>();
        }
    }
}
