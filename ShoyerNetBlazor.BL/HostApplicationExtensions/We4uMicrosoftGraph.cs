using Microsoft.Extensions.DependencyInjection;

namespace ShoyerNetBlazor.BL.HostApplicationExtensions
{
    public static class We4uMicrosoftGraph
    {
        public static IHostApplicationBuilder AddWE4UMicrosoftGraph(this IHostApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IMicrosoftService>(sp =>
            {
                // Resolve the dependency that was registered earlier.
                var googleService = sp.GetRequiredService<IServiceProvider>();
                return new MicrosoftServices(googleService);
            });

            return builder;

        }
    }
}
