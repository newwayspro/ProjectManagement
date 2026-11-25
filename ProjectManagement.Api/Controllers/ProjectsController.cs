using Microsoft.AspNetCore.Mvc;
using ProjectManagement.BLL.Projects;

namespace ProjectManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyCollection<ProjectDto>> GetAll() => Ok(projectService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<ProjectDto> GetById(int id)
    {
        var project = projectService.GetById(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public ActionResult<ProjectDto> Create(CreateProjectRequest request)
    {
        try
        {
            var project = projectService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { error = exception.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) => projectService.Delete(id) ? NoContent() : NotFound();
}
