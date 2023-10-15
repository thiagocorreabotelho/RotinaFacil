namespace RotinaFacil.Domain.Entitie
{
    public sealed class PessoaEmail
    {

        #region Construtores

        public PessoaEmail()
        {
                
        }
        public PessoaEmail(int pessoaId, int emailId)
        {
            ValidarPessoaEmail(pessoaId, emailId);
        }

        #endregion

        #region Propriedades

        public int PessoaId { get; set; }
        public int EmailId { get; set; }
        public Pessoa PessoaRel { get; set; }
        public Email EmailRel { get; set; }

        #endregion

        #region Métodos

        private void ValidarPessoaEmail(int pessoaId, int emailId)
        {
            if (pessoaId == 0)
                throw new ArgumentException($"O campo {nameof(PessoaId)} não pode ser 0.");

            if (emailId == 0)
                throw new ArgumentException($"O campo {nameof(EmailId)} não pode ser 0.");

            PessoaId = pessoaId;
            EmailId = emailId;
        }

        #endregion

    }
}