using System.ComponentModel.DataAnnotations;

namespace PrimeMotorsAPI.DTOs;

public class VeiculoCreateDTO
{
     [Required(ErrorMessage = "Coloque o nome da Marca")]
     public string Marca { get; set; } = string.Empty;
     
     [Required(ErrorMessage = "Coloque o Modelo")]
     public string Modelo { get; set; }  = string.Empty;
     
     [Range(1935, 2035)]
     public int Ano { get; set; } 
     
     [Required(ErrorMessage = "Coloque a Cor")]
     public string Cor { get; set;  } = string.Empty ;
     
     [Range(0.01, double.MaxValue)]
     public decimal Preco { get; set; }
     
     [Range(0, double.MaxValue)]
     public int Km { get; set;  }
     
     public bool Disponivel { get; set; }
     
     public string? Descricao { get; set; }
     
     public string? FotoUrl { get; set; }
     
}