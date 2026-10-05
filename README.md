# HogRider Backend

ASP.NET Core 8 backend for the HogRider application. The API provides endpoints for dishes, categories, dietary tags, users, and related restaurant data. Swagger is available for exploring and testing the API.

## Live API

- [API status](https://hog-backend-qwqa.onrender.com)
- [Swagger UI](https://hog-backend-qwqa.onrender.com/swagger/index.html)

## Requirements

- .NET 8 SDK
- MySQL 8 (for local database access)
- Docker (optional)

## Run locally

From the repository directory:

```bash
dotnet restore HogRider.Backend.sln
dotnet build HogRider.Backend.sln
dotnet run --project src/HogRider.Backend/HogRider.Backend.csproj
```

The API is then available at the URL printed by `dotnet run`, usually `http://localhost:5000` or `https://localhost:5001`. Open `/swagger` to use Swagger UI.

Set the `DB_CONNECTION` environment variable to a MySQL connection string before starting the API. In Development mode, Entity Framework Core applies pending migrations automatically.

PowerShell example:

```powershell
$env:DB_CONNECTION="Server=localhost;Port=3306;Database=hogrider;User=root;Password=your-password;"
$env:ASPNETCORE_ENVIRONMENT="Development"
dotnet run --project src/HogRider.Backend/HogRider.Backend.csproj
```

## Run with Docker

From the repository directory:

```bash
docker build -t hogrider-backend .
docker run --rm -p 8080:8080 \
	-e DB_CONNECTION="Server=host.docker.internal;Port=3306;Database=hogrider;User=root;Password=your-password;" \
	hogrider-backend
```

The container API is available at [http://localhost:8080](http://localhost:8080), with Swagger at [http://localhost:8080/swagger](http://localhost:8080/swagger).

## Tests

Run the test suite with:

```bash
dotnet test HogRider.Backend.sln
```
