using ZenCloud.Domain.Entities;
namespace ZenCloud.Domain.Interfaces;

public interface IDatabaseEngine
{
    Task<bool> CreateDatabaseAsync(
        DatabaseEngineType engineType, 
        string databaseName, 
        string username, 
        string password);
    
    Task<bool> DeleteDatabaseAsync(
        DatabaseEngineType engineType, 
        string databaseName, 
        string username);
    
    Task<bool> DatabaseExistsAsync(
        DatabaseEngineType engineType, 
        string databaseName);
}