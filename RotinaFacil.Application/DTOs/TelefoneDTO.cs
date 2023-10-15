using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public class TelefoneDTO
    {
        [Key]
        public int TelefoneId { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter entre {1} caracteres.")]
        public string Nome { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter entre {1} caracteres.")]
        public string Numero { get; private set; } = string.Empty;

        public bool Ativo { get; private set; }
    }
}
