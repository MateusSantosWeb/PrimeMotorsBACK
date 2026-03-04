using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Context;
using PrimeMotorsAPI.Models.Cliente;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Repository.implementations;

public class ClienteRepository : IClienteReposiotry
{
    private readonly AppDbContext _context;
    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> GetByCpfAsync(string cpf)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public void Update(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
    }

    public void Delete(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
