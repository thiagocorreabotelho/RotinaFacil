using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public class SexoDTO
    {
        [Key]
        public int SexoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
    }
}
