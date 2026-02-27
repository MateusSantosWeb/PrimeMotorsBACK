using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace PrimeMotorsAPI.DTOs;

public class VendaCreateDTO
{
    [Required(ErrorMessage = "")]
    public int VeiculoId { get; set; }
    [Required(ErrorMessage = "")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "")]
    public int VendedorId { get; set; }
    [Required(ErrorMessage = "")]
    public decimal PrecoFinal { get; set; }
    [Required(ErrorMessage = "")]
    public string FormaDePagamento { get; set; }
    
    public DateTime DataVenda { get; set; }
    
    public string? Descricao { get; set; }
    
    public string Status { get; set; }  
    
}