using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApp.Controllers;


[Route("admin")]
public class AdminController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IClientService _clientService;
    private readonly IStatusService _statusService;


    public AdminController(IProjectService projectService, IClientService clientService, IStatusService statusService)
    {
        _projectService = projectService;
        _clientService = clientService;
        _statusService = statusService;

    }

    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return View();
    }

    [HttpGet("projects/{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }

    [Route("clients")]
    public async Task<IActionResult> Clients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return View();
    }

    [Route("statuses")]
    public async Task<IActionResult> Statuses()
    {
        var statuses = await _statusService.GetStatusesAsync();
        return View("statuses", statuses);
    }
}
