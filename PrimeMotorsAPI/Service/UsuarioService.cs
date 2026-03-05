using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Services;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public async Task<string> CriarUsuarioAsync(RegisterDTO dto)
    {
        var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        
        if (usuarioExistente != null)
            return "Email ja Cadastrado";
        
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email =  dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
        };

        await _usuarioRepository.AdicionarAsync(usuario);
        await _usuarioRepository.SalvarAlteracoesAsync();

        return "Usuario criado com sucesso";
    }

    public async Task<object?> AutenticarAsync(LoginDTO dto)
    {
        var usuario = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        if (usuario == null)
            return null;

        var senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);
        if (!senhaValida)
            return null;

        var jwtKey = _configuration["Jwt:Key"];
        if (string.IsNullOrWhiteSpace(jwtKey))
            throw new InvalidOperationException("JWT key não configurada.");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, "User")
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new
        {
            token = tokenString,
            usuario = new
            {
                id = usuario.Id,
                email = usuario.Email,
                nome = usuario.Nome,
                role = "User"
            }
        };
    }
}
