namespace RotinaFacil.Application.DTOs
{
    public class EnderecoDTO
    {
        public int EnderecoId { get; set; }
        public string? Nome { get;  set; } = string.Empty;
        public string? CEP { get;  set; } = string.Empty;
        public string? Logradouro { get;  set; } = string.Empty;
        public string? Numero { get;  set; } = string.Empty;
        public string? Bairro { get;  set; } = string.Empty;
        public string? PontoReferencia { get;  set; }
        public string? Cidade { get;  set; } = string.Empty;
        public string? Estado { get;  set; } = string.Empty;
        public bool Ativo { get;  set; }
    }
}
