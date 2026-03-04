using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Services;

public class VeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<string> CriarVeiculoAsync(VeiculoCreateDTO dto)
    {
        var veiculo = new Veiculo
        {
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Ano = dto.Ano,
            Cor = dto.Cor,
            Preco = dto.Preco,
            Km = dto.Km,
            Disponivel = true,
            Descricao = dto.Descricao,
            FotoUrl = dto.FotoUrl
        };
        await _veiculoRepository.AddAsync(veiculo);
        await _veiculoRepository.SaveChangesAsync();
        
        return "Veiculo criado com sucesso";
    }
}
