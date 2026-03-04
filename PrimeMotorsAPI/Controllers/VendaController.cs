using Microsoft.AspNetCore.Mvc;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Services;

namespace PrimeMotorsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VendaController : ControllerBase
{
 private readonly VendaService _vendaService;

 public VendaController(VendaService vendaService)
 {
  _vendaService = vendaService;
 }

 [HttpPost]
 public async Task<IActionResult> Criar([FromBody] VendaCreateDTO dto)
 {
  var resultado = await _vendaService.CriarVendaAsync(dto);

  if (resultado.Contains("Não")) 
   return BadRequest(resultado);
  
  return Ok(resultado);
 }
 
}
