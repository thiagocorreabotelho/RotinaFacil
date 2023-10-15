using System.ComponentModel.DataAnnotations;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Application.DTOs
{
    public sealed class PessoaDTO
    {
        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Sobrenome { get; set; } = string.Empty;

        [StringLength(14, ErrorMessage = "O campo {0} deve ter {1} caractere.")]
        public string? CPF { get; set; }

        [StringLength(12, ErrorMessage = "O campo {0} deve ter {1} caractere.")]
        public string? RG { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int SexoId { get; set; }

        public IList<EmailDTO> EmailsPessoa {  get; set; } = new List<EmailDTO>();
        public IList<TelefoneDTO> TelefonePessoa {  get; set; } = new List<TelefoneDTO>();
        public IList<Endereco> EnderecoPessoa {  get; set; } = new List<Endereco>();
    }
}
