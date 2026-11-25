namespace ProjectManagement.BLL.Projects;

public sealed record ProjectDto(int Id, string Name, string? Description, DateTime CreatedAtUtc);
