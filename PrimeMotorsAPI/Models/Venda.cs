using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrimeMotorsAPI.Models;

namespace PrimeMotorsAPI.Models.Venda;

public class Venda
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int VeiculoId { get; set; }
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int VendedorId { get; set; }
    [Required]
    public decimal PrecoFinal { get; set; }
    [Required]
    public string FormaDePagamento { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; } = DateTime.UtcNow;
    public string? Descricao { get; set; }
    public string Status { get; set; } = "Ativo";

    [ForeignKey("VeiculoId")]
    public Veiculo Veiculo { get; set; } = null!;
    
    [ForeignKey("ClienteId")] 
    public Cliente.Cliente Cliente { get; set; } = null!;

    [ForeignKey("VendedorId")] public Usuario Usuario { get; set; } = null!;

}