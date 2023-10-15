namespace RotinaFacil.Domain.Entitie
{
    public sealed class Endereco
    {
        #region Contrutores

        public Endereco()
        {
                
        }
        public Endereco(string nome, string cep, string logradouro, string numero, string bairro, string? referencia, string cidade, string estado, bool ativo)
        {
            ValidarEndereco(nome, cep, logradouro, numero, bairro, referencia, cidade, estado, ativo);
        }

        #endregion

        #region Propriedades
        public int EnderecoId { get; set; }
        public string Nome { get; private set; } = string.Empty;
        public string CEP { get; private set; } = string.Empty;
        public string Logradouro { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string? PontoReferencia { get; private set; }
        public string Cidade { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;
        public bool Ativo { get; private set; }

        // Propriedades Relacional
        public ICollection<PessoaEndereco> PessoaEnderecoRel { get; private set; }

        #endregion Propriedades

        #region Métodos

        private void ValidarEndereco(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"O campo {nameof(Nome)} do endereço é obrigatório.");

            if(nome.Length > 100)
                throw new ArgumentException($"O campo {nameof(Nome)} deve ter até 100 caracteres.");

            if (string.IsNullOrEmpty(cep) || cep.Length != 9)
                throw new ArgumentException($"O campo {nameof(CEP)} deve ter 9 digitos.");

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new ArgumentException($"O campo {nameof(logradouro)} é obrigatório.");

            if (logradouro.Length <= 4)
                throw new ArgumentException($"O campo {nameof(logradouro)} deve conter pelo menos 5 caracateres.");

            if (logradouro.Length > 100)
                throw new ArgumentException($"O campo {nameof(logradouro)} deve ter no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException($"O campo {nameof(Numero)} é obrigatório.");

            if (numero.Length > 5)
                throw new ArgumentException($"O campo {nameof(Numero)} deve ter até 5 caracteres.");

            if (string.IsNullOrWhiteSpace(bairro))
                throw new ArgumentException($"O campo {nameof(Bairro)} é obrigatório.");

            if (bairro.Length < 5)
                throw new ArgumentException($"O campo {nameof(Bairro)} deve ter pelo menos 5 caracteres.");

            if (bairro.Length > 100)
                throw new ArgumentException($"O campo {nameof(Bairro)} não pode ser maior que 100 caracteres.");

            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException($"O campo {nameof(Cidade)} é obrigatório.");

            if (cidade.Length < 5)
                throw new ArgumentException($"O campo {nameof(Cidade)} deve ter pelo menos 5 caracteres.");

            if (cidade.Length > 100)
                throw new ArgumentException($"O campo {nameof(Cidade)} não pode ser maior que 100 caracteres.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException($"O campo {nameof(Estado)} é obrigatório.");

            if (estado.Length != 2)
                throw new ArgumentException($"O campo {nameof(Estado)} deve conter 2 caracteres.");

            if (pontoReferencia != null && pontoReferencia.Length > 15)
                throw new ArgumentException($"O campo {nameof(PontoReferencia)} não pode ter mais de 15 caracteres.");

            Nome = nome.Trim();
            CEP = cep.Trim();
            Logradouro = logradouro.Trim();
            Numero = numero.Trim();
            Bairro = bairro.Trim();
            PontoReferencia = pontoReferencia?.Trim();
            Cidade = cidade.Trim();
            Estado = estado.Trim();
            Ativo = ativo;
        }

        #endregion
    }
}