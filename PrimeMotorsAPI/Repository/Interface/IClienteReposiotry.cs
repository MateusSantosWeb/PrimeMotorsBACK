using PrimeMotorsAPI.Models.Cliente;

namespace PrimeMotorsAPI.Repository.Interface.User;

public interface IClienteReposiotry
{
    Task AddAsync (Cliente cliente);
    Task<Cliente?> GetByIdAsync(int id);
    Task<Cliente?> GetByCpfAsync(string cpf);
    Task<IEnumerable<Cliente>> GetAllAsync();
    void Update(Cliente cliente);
    void Delete(Cliente cliente);  
    Task SaveChangesAsync();
}