using Microsoft.AspNetCore.Mvc;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Services;

namespace PrimeMotorsAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] ClientesCreateDTO dto)
    {
        var resultado = await _clienteService.CriarClienteAsync(dto);

        if (resultado.Contains("já"))
            return BadRequest(resultado);

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var clientes = await _clienteService.ListarAsync();
        return Ok(clientes);
    }
    
    
}
