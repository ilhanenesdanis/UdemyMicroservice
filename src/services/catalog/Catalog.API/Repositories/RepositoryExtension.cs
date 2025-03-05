
using Catalog.API.Options;
using MongoDB.Driver;

namespace Catalog.API.Repositories;

public static class RepositoryExtension
{
    public static IServiceCollection AddDatabaseServiceExtension(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(opt =>
        {
            var options = opt.GetRequiredService<MongoDbOptions>();
            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped<AppDbContext>(s =>
        {
            var mongoClient = s.GetRequiredService<IMongoClient>();
            var options = s.GetRequiredService<MongoDbOptions>();

            return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
        });

        return services;
    }
}
