using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public class SexoDTO
    {
        [Key]
        public int SexoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
