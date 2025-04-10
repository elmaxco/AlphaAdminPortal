using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Controllers;

public class ClientsController : Controller
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService) => _clientService = clientService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return View("~/Views/Admin/clients.cshtml", clients);
    }


    [HttpPost]
    public async Task<IActionResult> Add(AddClientForm form)
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

        var result = await _clientService.CreateClientAsync(form);
        if (result == 200)
            return Ok();

        return StatusCode(result);
    }
}
