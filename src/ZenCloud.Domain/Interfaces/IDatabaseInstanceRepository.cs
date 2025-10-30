using ZenCloud.Domain.Entities;
namespace ZenCloud.Domain.Interfaces;

public interface IDatabaseInstanceRepository
{
    Task<DatabaseInstance> CreateAsync(DatabaseInstance instance);
    Task<DatabaseInstance?> GetByIdAsync(Guid instanceId);
    Task<List<DatabaseInstance>> GetByUserIdAsync(Guid userId);
    Task<int> CountByUserAndEngineAsync(Guid userId, Guid engineId);
    Task<DatabaseInstance> UpdateAsync(DatabaseInstance instance);
    Task<bool> DeleteAsync(Guid instanceId);
    Task<bool> IsPortInUseAsync(int port);
}