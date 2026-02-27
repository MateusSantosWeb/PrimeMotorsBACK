namespace PrimeMotorsAPI.DTOs;

public class VeiculoUpdateDTO
{
    
    public string? Marca { get; set; }

    public string? Modelo { get; set; }
    
    public int? Ano { get; set; }
    
    public string? cor { get; set;  }
    
    public decimal? Preco { get; set; }
    
    public int? Km { get; set;  }
     
    public bool? Disponivel { get; set; }
     
    public string? Descricao { get; set; }
     
    public string? FotoUrl { get; set; }
}