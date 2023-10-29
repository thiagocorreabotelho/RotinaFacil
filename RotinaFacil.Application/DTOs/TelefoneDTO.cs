using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public class TelefoneDTO
    {
        [Key]
        public int TelefoneId { get; set; }
        public string? Nome { get; set; } 
        public string? Numero { get; set; } 
        public bool Ativo { get; set; }
    }
}
