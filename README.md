# SV.Project - ASP.NET Core Web API

A simple ASP.NET Core Web API project with Entity Framework Core and MySQL (via MAMP/phpMyAdmin).

## Technologies

- .NET 9.0
- Entity Framework Core 9.0.0
- MySQL Database (MAMP)
- Pomelo.EntityFrameworkCore.MySql 9.0.0
- ASP.NET Core OpenAPI

## One-Line Setup (Run in Terminal)

```bash
dotnet tool install --global dotnet-ef && export PATH="$PATH:$HOME/.dotnet/tools" && cd SV.Project && dotnet restore && dotnet ef migrations add InitialCreate && dotnet ef database update && dotnet run
```

## Prerequisites

Before running this project, ensure you have the following installed:

### Required Software

| Software | Version | Download |
|----------|---------|----------|
| [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) | 9.0+ | [Download](https://dotnet.microsoft.com/download/dotnet/9.0) |
| [MAMP](https://www.mamp.info/) | Latest | [Download](https://www.mamp.info/) |

### Install dotnet-ef Tool

```bash
dotnet tool install --global dotnet-ef
```

> Note: After installation, add to PATH by running: `export PATH="$PATH:$HOME/.dotnet/tools"`

## Project Structure

```
SV.Project/
├── Data/
│   └── AppDbContext.cs          # Entity Framework database context
├── Migrations/                  # EF Core database migrations
├── Model/
│   └── Category.cs              # Category entity model
├── Properties/
│   └── launchSettings.json      # Application launch configuration
├── Service/
│   ├── CategoryService.cs       # Category business logic service
│   └── ICategoryService.cs      # Category service interface
├── Program.cs                   # Application entry point
├── appsettings.json             # Application configuration
└── SV.Project.csproj           # Project file
```

## Setup and Installation

### 1. Restore Dependencies

```bash
cd SV.Project
dotnet restore
```

### 2. Configure Database Connection

The connection string is already configured in `Program.cs` for MAMP:

```csharp
// MAMP MySQL: Server=localhost;Port=8889;Database=SV35POS;User=root;Password=root;
// Fallback (Local MySQL): Server=localhost;Port=3306;Database=SV35POS;User=root;Password=;
var connectionString = @"Server=localhost;Port=8889;Database=SV35POS;User=root;Password=root;";
```

**MAMP MySQL Default Credentials:**
- Server: `localhost`
- Port: `8889`
- User: `root`
- Password: `root`

**Fallback MySQL Credentials (if port 8889 is already in use):**
- Server: `localhost`
- Port: `3306`
- User: `root`
- Password: (empty)

### 3. Create Database in phpMyAdmin

1. Open MAMP and start MySQL
2. Access phpMyAdmin at `http://localhost:8888/phpMyAdmin/`
3. Create a new database named `SV35POS`

### 4. Create and Run Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5218`
- HTTPS: `https://localhost:7258`

## Connection String Options

| Environment | Connection String |
|-------------|-------------------|
| MAMP (default) | `Server=localhost;Port=8889;Database=SV35POS;User=root;Password=root;` |
| Local MySQL | `Server=localhost;Port=3306;Database=SV35POS;User=root;Password=;` |

To switch connection strings, edit line 8 in `Program.cs`.

## API Endpoints

The API exposes standard CRUD endpoints for `Category`. Use Swagger at `/swagger` (in Development mode) to explore the API.

## Configuration

Configuration is managed through `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Environment-specific settings can be added to `appsettings.Development.json`.

## Build

```bash
dotnet build
```

## Run Tests

```bash
dotnet test
```

## Troubleshooting

### dotnet-ef not found
```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```

### Port 8889 already in use
Change connection string to use port `3306` with empty password in `Program.cs` line 8.

### Database connection failed
1. Ensure MAMP MySQL is running
2. Verify database `SV35POS` exists in phpMyAdmin
3. Check credentials in connection string

## License

Private project.
