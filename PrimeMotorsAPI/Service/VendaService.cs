using PrimeMotorsAPI.DTOs;
using PrimeMotorsAPI.Models.Venda;
using PrimeMotorsAPI.Repository.Interface;
using PrimeMotorsAPI.Repository.Interface.User;

namespace PrimeMotorsAPI.Services;

public class VendaService
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IVeiculoRepository _veiculoRepository;

    public VendaService(
        IVendaRepository vendaRepository,
        IVeiculoRepository veiculoRepository)
    {
        _vendaRepository = vendaRepository;
        _veiculoRepository = veiculoRepository;
    }

    public async Task<string> CriarVendaAsync(VendaCreateDTO dto)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(dto.VeiculoId);

        if (veiculo == null)
            return "Veículo não encontrado.";

        if (!veiculo.Disponivel)
            return "Veículo já foi vendido.";

        var venda = new Venda
        {
            VeiculoId = dto.VeiculoId,
            ClienteId = dto.ClienteId,
            VendedorId = dto.VendedorId,
            PrecoFinal = dto.PrecoFinal,
            FormaDePagamento = dto.FormaDePagamento,
            Descricao = dto.Descricao
        };

        await _vendaRepository.AddAsync(venda);

        veiculo.Disponivel = false;

        await _vendaRepository.SaveChangesAsync();

        return "Venda realizada com sucesso!";
    }
}