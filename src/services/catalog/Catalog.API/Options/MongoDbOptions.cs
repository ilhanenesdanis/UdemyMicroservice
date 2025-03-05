
namespace Catalog.API.Options;

public sealed class MongoDbOptions
{

    public MongoDbOptions()
    {
        DatabaseName = string.Empty;
        ConnectionString = string.Empty;
    }
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}
