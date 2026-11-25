# ProjectManagement backend

Backend built with .NET 11 and split into three layers:

- `ProjectManagement.Api`: HTTP controllers and Angular CORS configuration.
- `ProjectManagement.BLL`: business rules and DTOs.
- `ProjectManagement.DAL`: Entity Framework Core and SQL Server data access.

Dependency direction is `API -> BLL -> DAL`. The SQL Server connection uses Windows Authentication and connects to the local default instance (`localhost`, `MSSQLSERVER`). Run the API as a Windows account that has permission to create databases; the account shown as a SQL administrator in the installer already has that permission. At startup, the API creates `ProjectManagementDb` and its initial schema if they do not exist.

## Run

From this folder:

```powershell
dotnet run --project .\ProjectManagement.Api
```

The API listens on the local URL shown by `dotnet run`. The Angular dev server at `http://localhost:4200` is allowed by CORS.

## Sample endpoints

- `GET /api/projects`
- `GET /api/projects/{id}`
- `POST /api/projects` with JSON such as `{"name":"Website","description":"First project"}`
- `DELETE /api/projects/{id}`

The projects and ASP.NET Identity tables are stored in SQL Server. The sample connection string is in `ProjectManagement.Api/appsettings.json`; change it if you use another SQL Server instance or authentication mode. Encryption is disabled for this local development connection because SQL Server is on the same machine and its installer did not configure forced encryption. EF Core migrations create and update the schema.
