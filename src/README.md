# Crear estructura completa de ZenCloud
mkdir ZenCloud && cd ZenCloud
dotnet new sln -n ZenCloud
mkdir src tests

# Domain
cd src
dotnet new classlib -n ZenCloud.Domain
dotnet sln ../ZenCloud.sln add ZenCloud.Domain/ZenCloud.Domain.csproj
cd ZenCloud.Domain
mkdir Entities ValueObjects Interfaces Exceptions DomainEvents Services
rm Class1.cs
cd ..

# Application
dotnet new classlib -n ZenCloud.Application
dotnet sln ../ZenCloud.sln add ZenCloud.Application/ZenCloud.Application.csproj
cd ZenCloud.Application
mkdir Commands Queries DTOs Validators Common
rm Class1.cs
dotnet add package MediatR
dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
dotnet add reference ../ZenCloud.Domain/ZenCloud.Domain.csproj
cd ..

# Infrastructure
dotnet new classlib -n ZenCloud.Infrastructure
dotnet sln ../ZenCloud.sln add ZenCloud.Infrastructure/ZenCloud.Infrastructure.csproj
cd ZenCloud.Infrastructure
mkdir -p Persistence/Configurations Persistence/Repositories Persistence/Migrations Services
rm Class1.cs
dotnet add package Microsoft.EntityFrameworkCoregi
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add reference ../ZenCloud.Domain/ZenCloud.Domain.csproj
dotnet add reference ../ZenCloud.Application/ZenCloud.Application.csproj
cd ..

# API
dotnet new webapi -n ZenCloud.API
dotnet sln ../ZenCloud.sln add ZenCloud.API/ZenCloud.API.csproj
cd ZenCloud.API
mkdir Middlewares Extensions
mkdir -p Contracts/Requests Contracts/Responses
dotnet add package MediatR
dotnet add reference ../ZenCloud.Application/ZenCloud.Application.csproj
dotnet add reference ../ZenCloud.Infrastructure/ZenCloud.Infrastructure.csproj
cd ../..

echo "✅ Estructura ZenCloud creada exitosamente!"
```

## Estructura Final de ZenCloud
```
ZenCloud/
│
├── ZenCloud.sln
│
├── src/
│   ├── ZenCloud.Domain/
│   │   ├── ZenCloud.Domain.csproj
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   ├── Interfaces/
│   │   ├── Exceptions/
│   │   ├── DomainEvents/
│   │   └── Services/
│   │
│   ├── ZenCloud.Application/
│   │   ├── ZenCloud.Application.csproj
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── DTOs/
│   │   ├── Validators/
│   │   └── Common/
│   │
│   ├── ZenCloud.Infrastructure/
│   │   ├── ZenCloud.Infrastructure.csproj
│   │   ├── Persistence/
│   │   │   ├── Configurations/
│   │   │   ├── Repositories/
│   │   │   └── Migrations/
│   │   └── Services/
│   │
│   └── ZenCloud.API/
│       ├── ZenCloud.API.csproj
│       ├── Controllers/
│       ├── Middlewares/
│       ├── Contracts/
│       │   ├── Requests/
│       │   └── Responses/
│       ├── Extensions/
│       ├── Program.cs
│       └── appsettings.json
│
└── tests/
├── ZenCloud.Domain.Tests/
├── ZenCloud.Application.Tests/
└── ZenCloud.Infrastructure.Tests/