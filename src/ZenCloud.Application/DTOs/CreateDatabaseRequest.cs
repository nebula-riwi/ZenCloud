namespace ZenCloud.Application.DTOs;

public class CreateDatabaseRequest
{
    public string EngineType { get; set; } = null!;
    
    public string? CustomName { get; set; }
}