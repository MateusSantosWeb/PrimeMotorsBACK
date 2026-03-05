using PrimeMotorsAPI.Models;

namespace PrimeMotorsAPI.Repository.Interface.User;

public interface IVeiculoRepository
{
    Task<List<Veiculo>> GetAllAsync();
    Task<Veiculo?> GetByIdAsync(int id);
    Task<Veiculo> AddAsync(Veiculo veiculo);
    Task<Veiculo> UpdateAsync(Veiculo veiculo);
    Task DeleteAsync(Veiculo veiculo);
    Task SaveChangesAsync();
}
