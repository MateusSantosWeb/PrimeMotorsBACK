namespace PrimeMotorsAPI.DTOs;

public class VeiculoResponseDTO
{
    public int Id { get; set; }
    
    public string Marca { get; set; } =  string.Empty;
    
    public string Modelo { get; set; } =  string.Empty;
    
    public int Ano { get; set; }
    
    public string Cor { get; set; } =  string.Empty;
    
    public decimal Preco { get; set; }
    
    public int Km { get; set; }
    
    public bool Disponivel { get; set; }
    
    public string? Descricao { get; set; }
    
    public string? FotoUrl { get; set; }
}