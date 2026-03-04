using Microsoft.AspNetCore.Mvc;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Services;

namespace PrimeMotorsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    public  UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegisterDTO dto)
    {
        var resultado = await _usuarioService.CriarUsuarioAsync(dto);
        if (resultado.Contains("Já cadastrado"))
            return BadRequest(resultado);
        
        return Ok(resultado);
    }

}