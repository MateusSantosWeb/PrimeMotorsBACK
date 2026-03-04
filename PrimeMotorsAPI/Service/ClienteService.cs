using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Models.Cliente;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Services;

public class ClienteService
{
    private readonly IClienteReposiotry _clienteRepository;

    public ClienteService(IClienteReposiotry clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<string> CriarClienteAsync(ClientesCreateDTO dto)
    {
        var clienteExistente = await _clienteRepository.GetByCpfAsync(dto.Cpf);

        if (clienteExistente != null)
            return "Cliente com este CPF ja cadastrado.";

        var cliente = new Cliente
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Endereco = dto.Endereco
        };

        await _clienteRepository.AddAsync(cliente);
        await _clienteRepository.SaveChangesAsync();

        return "Cliente criado com sucesso.";
    }

    public async Task<Cliente?> BuscarPorIdAsync(int id)
    {
        return await _clienteRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Cliente>> ListarAsync()
    {
        return await _clienteRepository.GetAllAsync();
    }
}
