using ProjectManagement.DAL.Entities;

namespace ProjectManagement.DAL.Repositories;

public interface IProjectRepository
{
    IReadOnlyCollection<Project> GetAll();
    Project? GetById(int id);
    Project Add(Project project);
    bool Delete(int id);
}
