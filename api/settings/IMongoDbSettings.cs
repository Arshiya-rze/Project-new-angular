namespace api.settings;

public interface IMongoDbSettings
{
    string? ConnectionString { get; init; } 
    string? DatabaseName { get; init; }
}
