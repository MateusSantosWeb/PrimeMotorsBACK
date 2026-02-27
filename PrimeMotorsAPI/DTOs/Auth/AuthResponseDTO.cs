using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.DTOs;

public class AuthResponseDTO
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime Expiracao { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}