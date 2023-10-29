namespace RotinaFacil.Domain.Entitie
{
    public sealed class Pessoa
    {
        #region Construtores
        public Pessoa()
        {
                
        }

        public Pessoa(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            ValidarPessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
        }

        #endregion Construtores

        #region Propriedades

        public int PessoaId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Sobrenome { get; private set; } = string.Empty;
        public string? CPF { get; private set; }
        public string? RG { get; private set; } = string.Empty;
        public DateTime DataNascimento { get; private set; }

        public bool Ativo {  get; private set; }

        #region Propriedades Relacional 1:1

        public Sexo SexoRel { get; private set; }
        public int SexoId { get; private set; } 

        #endregion Propriedades Relacional 1:1

        #region Propriedade Relacional N:N

        public ICollection<PessoaEmail> PessoaEmailRel { get; private set; }
        public ICollection<PessoaEndereco> PessoaEnderecoRel { get; private set; }
        public ICollection<PessoaTelefone> PessoaTelefoneRel { get; private set; }

        #endregion Propriedade Relacional N:N

        #endregion Propriedades

        #region Métodos

        /// <summary>
        /// Método responsável por válidar a regra de negócio da entidade de pessoas.
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        /// <param name="sobrenome">Sobrenome da pessoa</param>
        /// <param name="cpf">CPF da pessoa, essa propriedade não é obrigatíra</param>
        /// <param name="rg">RG da pessoa, essa propriedade não é obrigatória.</param>
        /// <param name="dataNascimento">Data de nascimento da pessoa.</param>
        /// <param name="sexoId">O SexoId é um id de identificação do sexo da pessoa</param>
        /// <exception cref="ArgumentException">Caso entre em algum if o mesmo retornará uma exception</exception>
        private void ValidarPessoa(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"O campo {nameof(Nome)} é obrigatório.");

            if (nome.Length < 3)
                throw new ArgumentException($"O campo {nameof(Nome)} deve conter no mínimo 3 caracteres.");

            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException($"O campo {nameof(Sobrenome)} é obrigatório.");

            if (sobrenome.Length < 5)
                throw new ArgumentException($"O campo {nameof(Sobrenome)} deve conter no mínimo 5 caracteres.");

            if (cpf != null && cpf.Length != 14)
                throw new ArgumentException($"O campo {nameof(CPF)} está em um formato inválido.");

            if (dataNascimento == DateTime.MinValue)
                throw new ArgumentException($"O campo {nameof(DataNascimento)} está em um formato inválido.");

            if(sexoId == 0)
                throw new ArgumentException($"O campo {nameof(SexoId)} é obrigatório.");

            Nome = nome.Trim();
            Sobrenome = sobrenome.Trim();
            CPF = cpf?.Trim();
            RG = rg.Trim();
            DataNascimento = dataNascimento;
            SexoId = sexoId;
            Ativo = ativo;
        }

        #endregion Métodos
    }
}