using System.Security.Cryptography;
using System.Text;
using ZenCloud.Domain.Interfaces;
using ZenCloud.Domain.Entities;

namespace ZenCloud.Infrastructure.Services;

/// <summary>
/// Implementación del servicio que genera credenciales seguras
/// </summary>
public class CredentialGeneratorService : ICredentialGeneratorService
{
    private readonly IDatabaseInstanceRepository _repository;
    
    // Caracteres permitidos para contraseñas seguras
    private const string PasswordChars = 
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";

    public CredentialGeneratorService(IDatabaseInstanceRepository repository)
    {
        _repository = repository;
    }

    public string GenerateUsername(string prefix = "db_user")
    {
        // Genera un código aleatorio de 8 caracteres
        var randomPart = GenerateRandomString(8, "abcdefghijklmnopqrstuvwxyz0123456789");
        return $"{prefix}_{randomPart}";
    }

    public string GeneratePassword(int length = 16)
    {
        // Genera una contraseña aleatoria segura
        return GenerateRandomString(length, PasswordChars);
    }

    public string GenerateDatabaseName(Guid userId, DatabaseEngineType engineType)
    {
        // Formato: zencloud_mysql_abc123
        var userPart = userId.ToString().Replace("-", "").Substring(0, 8);
        var engineName = engineType.ToString().ToLower();
        var randomPart = GenerateRandomString(6, "abcdefghijklmnopqrstuvwxyz0123456789");
        
        return $"zencloud_{engineName}_{userPart}_{randomPart}";
    }

    public async Task<int> AssignPortAsync(DatabaseEngineType engineType)
    {
        // Rangos de puertos por motor
        var portRanges = new Dictionary<DatabaseEngineType, (int min, int max)>
        {
            { DatabaseEngineType.MySQL, (13306, 13400) },
            { DatabaseEngineType.PostgreSQL, (15432, 15500) },
            { DatabaseEngineType.MongoDB, (27100, 27200) },
            { DatabaseEngineType.SQLServer, (11433, 11500) },
            { DatabaseEngineType.Redis, (16379, 16450) },
            { DatabaseEngineType.Cassandra, (19042, 19100) }
        };

        var (minPort, maxPort) = portRanges[engineType];

        // Busca un puerto disponible en el rango
        for (int port = minPort; port <= maxPort; port++)
        {
            if (!await _repository.IsPortInUseAsync(port))
            {
                return port;
            }
        }

        throw new InvalidOperationException(
            $"No hay puertos disponibles para {engineType}");
    }

    /// <summary>
    /// Método auxiliar para generar strings aleatorios seguros
    /// </summary>
    private string GenerateRandomString(int length, string allowedChars)
    {
        var result = new StringBuilder(length);
        var buffer = new byte[sizeof(uint)];

        for (int i = 0; i < length; i++)
        {
            RandomNumberGenerator.Fill(buffer);
            var randomNumber = BitConverter.ToUInt32(buffer, 0);
            result.Append(allowedChars[(int)(randomNumber % (uint)allowedChars.Length)]);
        }

        return result.ToString();
    }
}