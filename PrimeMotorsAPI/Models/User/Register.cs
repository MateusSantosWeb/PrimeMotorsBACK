using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.Models.User;

public class Register
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmaSenha { get; set; } = string.Empty;
}