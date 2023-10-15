namespace RotinaFacil.Domain.Entitie
{
    public class PessoaEndereco
    {
        #region Construtores
        public PessoaEndereco()
        {
                
        }
        public PessoaEndereco(int pessoaId, int enderecoId)
        {
            ValidarPessoaEndereco(pessoaId, enderecoId);
        }

        #endregion

        #region Propriedades
        public int PessoaId { get; set; }
        public int EnderecoId { get; set; }
        public Pessoa PessoaRel { get; set; }
        public Endereco EnderecoRel { get; set; }

        #endregion Propriedades

        #region Métodos

        private void ValidarPessoaEndereco(int pessoaId, int enderecoId)
        {
            if (pessoaId == 0)
                throw new ArgumentException($"O campo {nameof(PessoaId)} não pode ser 0.");

            if (enderecoId == 0)
                throw new ArgumentException($"O campo {nameof(EnderecoId)} não pode ser 0.");

            PessoaId = pessoaId;
            EnderecoId = enderecoId;
        }

        #endregion
    }
}