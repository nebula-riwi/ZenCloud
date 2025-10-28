namespace ZenCloud.Domain.Entities;
public class DatabaseEngine
{
    public int EngineId { get; set; }
    public DatabaseEngineType EngineName { get; set; }
    public int DefaultPort { get; set; }
    public bool IsActive { get; set; } = true;
    public string? IconUrl { get; set; }
    public string? Description { get; set; }
    
    public ICollection<DatabaseInstance> DatabaseInstances { get; set; } = new List<DatabaseInstance>();
}