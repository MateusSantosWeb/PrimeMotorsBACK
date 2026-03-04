using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Context;
using PrimeMotorsAPI.Models.Venda;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Repository.implementations;

public class VendaRepository : IVendaRepository
{
    
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }
        
    public async Task AddAsync(Venda venda)
    {
        await _context.Vendas.AddAsync(venda);
    }

    public async Task<Venda?> GetByIdAsync(int id)
    {
        return await _context.Vendas.
            Include(v => v.Cliente)
            .Include(v => v.Veiculo)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}