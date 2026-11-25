using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.BLL.Projects;

namespace ProjectManagement.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        return services;
    }
}
