namespace ZenCloud.Application.DTOs;

public class DatabaseInstanceDto
{
        public Guid InstanceId { get; set; }
        public string DatabaseName { get; set; } = null!;
        public string EngineName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DatabaseCredentialsDto? Credentials { get; set; }
}