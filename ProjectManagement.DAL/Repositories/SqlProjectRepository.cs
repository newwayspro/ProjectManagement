using Microsoft.EntityFrameworkCore;
using ProjectManagement.DAL.Data;
using ProjectManagement.DAL.Entities;

namespace ProjectManagement.DAL.Repositories;

internal sealed class SqlProjectRepository(ProjectManagementDbContext dbContext) : IProjectRepository
{
    public IReadOnlyCollection<Project> GetAll() =>
        dbContext.Projects.AsNoTracking().OrderBy(project => project.Id).ToArray();

    public Project? GetById(int id) =>
        dbContext.Projects.AsNoTracking().SingleOrDefault(project => project.Id == id);

    public Project Add(Project project)
    {
        dbContext.Projects.Add(project);
        dbContext.SaveChanges();
        return project;
    }

    public bool Delete(int id)
    {
        var project = dbContext.Projects.Find(id);
        if (project is null)
            return false;

        dbContext.Projects.Remove(project);
        dbContext.SaveChanges();
        return true;
    }
}
