using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;

    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetProjectsAsync();
        return View("~/Views/Admin/projects.cshtml",projects);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }



    [HttpPost]
    public async Task<IActionResult> Add(AddProjectForm form)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return BadRequest(new { errors });
        }
        var result = await _projectService.CreateProjectAsync(form);
        return Ok();
    }

    [HttpPost("admin/projects/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectUpdateDto dto)
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return Json(new { success = false, errors });

        }

        var result = await _projectService.UpdateProjectAsync(dto, id);

        if (result)
            return Json(new { success = true });

        return Json(new { success = false });


    }

    [HttpDelete("admin/projects/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);

        if (project == null)
            return NotFound();

        var deleted = await _projectService.DeleteProjectAsync(project);
        return deleted ? Ok() : BadRequest();
    }
}
