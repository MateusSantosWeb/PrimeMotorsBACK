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

    public async Task<List<VeiculoResponseDTO>> ListarAsync()
    {
        var veiculos = await _veiculoRepository.GetAllAsync();
        return veiculos.Select(v => new VeiculoResponseDTO
        {
            Id = v.Id,
            Marca = v.Marca,
            Modelo = v.Modelo,
            Ano = v.Ano,
            Cor = v.Cor,
            Preco = v.Preco,
            Km = v.Km,
            Disponivel = v.Disponivel,
            Descricao = v.Descricao,
            FotoUrl = v.FotoUrl
        }).ToList();
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        if (veiculo == null) return false;

        await _veiculoRepository.DeleteAsync(veiculo);
        await _veiculoRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AtualizarAsync(int id, VeiculoUpdateDTO dto)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        if (veiculo == null) return false;

        if (!string.IsNullOrWhiteSpace(dto.Marca)) veiculo.Marca = dto.Marca;
        if (!string.IsNullOrWhiteSpace(dto.Modelo)) veiculo.Modelo = dto.Modelo;
        if (dto.Ano.HasValue) veiculo.Ano = dto.Ano.Value;
        if (!string.IsNullOrWhiteSpace(dto.cor)) veiculo.Cor = dto.cor;
        if (dto.Preco.HasValue) veiculo.Preco = dto.Preco.Value;
        if (dto.Km.HasValue) veiculo.Km = dto.Km.Value;
        if (dto.Disponivel.HasValue) veiculo.Disponivel = dto.Disponivel.Value;
        if (dto.Descricao != null) veiculo.Descricao = dto.Descricao;
        if (dto.FotoUrl != null) veiculo.FotoUrl = dto.FotoUrl;

        await _veiculoRepository.UpdateAsync(veiculo);
        await _veiculoRepository.SaveChangesAsync();
        return true;
    }
}
