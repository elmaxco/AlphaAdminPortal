using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApp.Controllers;


[Route("admin")]
public class AdminController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IClientService _clientService;

    public AdminController(IProjectService projectService, IClientService clientService)
    {
        _projectService = projectService;
        _clientService = clientService;
    }

    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return View();
    }

    [Route("clients")]
    public async Task<IActionResult> Clients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return View();
    }    
}
