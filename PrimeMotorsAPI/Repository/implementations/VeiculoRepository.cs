using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Context;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Repository.implementations;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;

    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Veiculo?> GetByIdAsync(int id)
    {
        return await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Veiculo> AddAsync(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        return veiculo;
    }

    public Task<Veiculo> UpdateAsync(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        return Task.FromResult(veiculo);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
