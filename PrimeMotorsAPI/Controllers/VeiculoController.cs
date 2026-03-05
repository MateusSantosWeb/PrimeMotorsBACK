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

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var veiculos = await _veiculoService.ListarAsync();
        return Ok(veiculos);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var removido = await _veiculoService.DeletarAsync(id);
        if (!removido) return NotFound("Veiculo não encontrado");
        return Ok("Veiculo removido com sucesso");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] VeiculoUpdateDTO dto)
    {
        var atualizado = await _veiculoService.AtualizarAsync(id, dto);
        if (!atualizado) return NotFound("Veiculo não encontrado");
        return Ok("Veiculo atualizado com sucesso");
    }
}
