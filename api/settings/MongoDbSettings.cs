namespace api.settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string? ConnectionString { get; init; }
    public string? DatabaseName { get; init; }
}    

