namespace RotinaFacil.Domain.Entitie
{
    public sealed class PessoaTelefone
    {
        #region Construtores
        public PessoaTelefone()
        {
                
        }
        public PessoaTelefone(int pessoaId, int telefoneId)
        {
            ValidarPessoaTelefone(pessoaId, telefoneId);
        }

        #endregion

        #region Propriedades

        public int PessoaId { get; private set; }
        public int TelefoneId { get; private set; }
        public Pessoa PessoaRel { get; private set; }
        public Telefone TelefoneRel { get; private set; }

        #endregion Propriedades

        #region Métodos

        private void ValidarPessoaTelefone(int pessoaId, int telefoneId)
        {
            if (pessoaId == 0)
                throw new ArgumentException($"O campo {nameof(PessoaId)} não pode ser 0.");

            if (telefoneId == 0)
                throw new ArgumentException($"O campo {nameof(TelefoneId)} não pode ser 0.");

            PessoaId = pessoaId;
            TelefoneId = telefoneId;
        }

        #endregion
    }
}