using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.DTOs;

public class RegisterDTO
{
    [Required]
    [MaxLength(50, ErrorMessage = "Coloque só o primeiro nome!")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email obrigatório!")]
    [EmailAddress]
    public string Email { get; set; }   = string.Empty;
    
    [Required(ErrorMessage = "Senha obrigatória")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }   = string.Empty;
    
    [Required(ErrorMessage = "Confirme sua senha!")]
    [DataType(DataType.Password)]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem! Verifique se digitou correto")]
    public string ConfirmarSenha { get; set; } = string.Empty;
}