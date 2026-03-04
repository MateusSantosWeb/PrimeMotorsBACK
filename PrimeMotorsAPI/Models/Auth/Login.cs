using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.Models.User;

public class Login
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; } = string.Empty;
}