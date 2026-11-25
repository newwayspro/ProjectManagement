using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManagement.DAL.Data;
using ProjectManagement.DAL.Repositories;

namespace ProjectManagement.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<ProjectManagementDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddScoped<IProjectRepository, SqlProjectRepository>();
        return services;
    }
}
