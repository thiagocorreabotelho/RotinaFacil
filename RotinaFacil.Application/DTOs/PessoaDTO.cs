using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public sealed class PessoaDTO
    {
        [Key]
        public int PessoaId { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Sobrenome { get; set; } = string.Empty;
        public string? CPF { get; set; } = null;
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? SexoId { get; set; }
        public bool Ativo { get; set; }
        public List<EmailDTO>? EmailsPessoa { get; set; } 
        public List<TelefoneDTO>? TelefonePessoa { get; set; } 
        public List<EnderecoDTO>? EnderecoPessoa { get; set; } 
        public List<ErroDTO>? ListaErro { get; set; } 
    }
}
