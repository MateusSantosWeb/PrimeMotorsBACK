// 🔥 Relacionamento: Um cliente pode ter várias vendas
using System.ComponentModel.DataAnnotations;
using PrimeMotorsAPI.Models.Venda;


namespace PrimeMotorsAPI.Models.Cliente;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Telefone { get; set; } = string.Empty;

    public string? Endereco { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    // 🔥 Relacionamento: Um cliente pode ter várias vendas
    public ICollection<Venda.Venda> Vendas { get; set; } = [];
}
