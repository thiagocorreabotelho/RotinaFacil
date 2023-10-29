using System.Text.RegularExpressions;

namespace RotinaFacil.Domain.Entitie
{
    public sealed class Email
    {
        #region Contrutores

        public Email()
        {
                
        }

        public Email(string email, bool ativo)
        {
            ValidarEmail(email, ativo);
        }

        #endregion Contrutores

        #region Propriedades

        public int EmailId { get; private set; }
        public string TextoEmail { get; private set; } = string.Empty;
        public bool Ativo { get; private set; }

        // Propriedades Relacional
        public ICollection<PessoaEmail> PessoaEmailRel { get; private set; }

        #endregion Propriedades

        #region Métodos

        private void ValidarEmail(string textoEmail, bool ativo)
        {
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrWhiteSpace(textoEmail))
                throw new ArgumentException($"O campo {nameof(TextoEmail)} é obrigatório.");

            if(!Regex.IsMatch(textoEmail, regex))
                throw new ArgumentException($"O campo {nameof(TextoEmail)} está inválido.");

            TextoEmail = textoEmail.Trim();
            Ativo = ativo;
        }

        #endregion Métodos
    }
}