using ProjectManagement.DAL.Entities;
using ProjectManagement.DAL.Repositories;

namespace ProjectManagement.BLL.Projects;

internal sealed class ProjectService(IProjectRepository repository) : IProjectService
{
    public IReadOnlyCollection<ProjectDto> GetAll() => repository.GetAll().Select(ToDto).ToArray();

    public ProjectDto? GetById(int id) =>
        id <= 0 ? null : repository.GetById(id) is { } project ? ToDto(project) : null;

    public ProjectDto Create(CreateProjectRequest request)
    {
        var name = request.Name?.Trim();
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name is required.", nameof(request));

        var project = repository.Add(new Project
        {
            Name = name,
            Description = string.IsNullOrWhiteSpace(request.Description)
                ? null
                : request.Description.Trim()
        });

        return ToDto(project);
    }

    public bool Delete(int id) => id > 0 && repository.Delete(id);

    private static ProjectDto ToDto(Project project) =>
        new(project.Id, project.Name, project.Description, project.CreatedAtUtc);
}
