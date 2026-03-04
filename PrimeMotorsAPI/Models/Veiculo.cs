using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.Models;

public class Veiculo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Marca { get; set; } = string.Empty;

    [Required]
    public string Modelo { get; set; } = string.Empty;

    [Range(1935, 2035)]
    public int Ano { get; set; }

    [Required]
    public string Cor { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Preco { get; set; }

    [Range(0, int.MaxValue)]
    public int Km { get; set; }

    public bool Disponivel { get; set; } = true;

    public string? Descricao { get; set; }

    public string? FotoUrl { get; set; }

    public ICollection<PrimeMotorsAPI.Models.Venda.Venda> Vendas { get; set; } = [];
}
