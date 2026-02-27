using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.DTOs;

public class ClientesCreateDTO
{
    [Required(ErrorMessage = "Coloque o nome do Cliente")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Coloque o cpf do Cliente")]
    [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}")]
    public string Cpf { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Coloque o Email do Cliente")]
    public string Email { get; set; }  = string.Empty;
    
    [Required(ErrorMessage = "Coloque o Telfone do Cliente")]
    public string Telefone { get; set; }  = string.Empty;
    
    public string? Endereco { get; set; }
    
    public DateTime Data_Cadastro { get; set; }
    
}