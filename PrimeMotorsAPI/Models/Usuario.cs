using PrimeMotorsAPI.Models.User;

namespace PrimeMotorsAPI.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string SenhaHash { get; set; }  = string.Empty;
    
    public virtual ICollection<UsuarioToken> Tokens { get; set; } = new List<UsuarioToken>();
    
}