using ZenCloud.Domain.Entities;
namespace ZenCloud.Domain.Interfaces;

public interface ICredentialGeneratorService
{
    string GenerateUsername(string prefix = "db_user");
    
    string GeneratePassword(int length = 16);
    
    string GenerateDatabaseName(Guid userId, DatabaseEngineType engineType);
}