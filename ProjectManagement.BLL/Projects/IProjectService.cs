namespace ProjectManagement.BLL.Projects;

public interface IProjectService
{
    IReadOnlyCollection<ProjectDto> GetAll();
    ProjectDto? GetById(int id);
    ProjectDto Create(CreateProjectRequest request);
    bool Delete(int id);
}
