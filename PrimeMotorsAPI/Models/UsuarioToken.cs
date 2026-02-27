using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrimeMotorsAPI.DTOs;

namespace PrimeMotorsAPI.Models
{
    public class UsuarioToken
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Token { get; set; }
        
        public bool IsRevoked { get; set; }
        public bool IsUsed { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        [ForeignKey("UsuarioId")]
        public virtual LoginDTO Usuario { get; set; }
    }
}

    