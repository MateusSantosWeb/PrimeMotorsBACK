using System.Net.Mail;
using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Services;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
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
}
