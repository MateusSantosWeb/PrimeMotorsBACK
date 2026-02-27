using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Context;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Repository.implementations;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
