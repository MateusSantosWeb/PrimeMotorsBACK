using PrimeMotorsAPI.Models;

namespace PrimeMotorsAPI.Repository.Interface.User;

public interface IVeiculoRepository
{
    Task<Veiculo?> GetByIdAsync(int id);
    Task<Veiculo> AddAsync(Veiculo veiculo);
    Task<Veiculo> UpdateAsync(Veiculo veiculo);
    Task SaveChangesAsync();
}
