using Microsoft.AspNetCore.Mvc;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Services;

namespace PrimeMotorsAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

public class VeiculoController : ControllerBase
{
    private readonly VeiculoService _veiculoService;

    public VeiculoController(VeiculoService veiculo)
    {
        _veiculoService = veiculo;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] VeiculoCreateDTO dto)
    {
        var resultado = await _veiculoService.CriarVeiculoAsync(dto);
        return Ok(resultado);
    }
}
