using PrimeMotorsAPI.Models.Venda;

namespace PrimeMotorsAPI.Repository.Interface.User;

public interface IVendaRepository
{
  Task AddAsync(Venda venda);
  Task<Venda?> GetByIdAsync(int id);
  Task SaveChangesAsync();  
}