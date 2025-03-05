

using Microsoft.Extensions.Options;

namespace Catalog.API.Options;

public static class OptionsExtension
{
    public static IServiceCollection AddOptionsExtension(this IServiceCollection services)
    {
        services.AddOptions<MongoDbOptions>()
                .BindConfiguration(nameof(MongoDbOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();
                
        services.AddSingleton<MongoDbOptions>(s=>s.GetRequiredService<IOptions<MongoDbOptions>>().Value);

        return services;
    }
}
