using System.Text.RegularExpressions;

namespace RotinaFacil.Domain.Entitie
{
    public sealed class Telefone
    {
        #region Construtores
        public Telefone()
        {
                
        }
        public Telefone(string nome, string telefone, bool ativo)
        {
            ValidarTelefone(nome, telefone, ativo);
        }

        #endregion

        #region Propriedades

        public int TelefoneId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public bool Ativo {  get; private set; }

        #region Propriedade Relacional N:N

        public ICollection<PessoaTelefone> PessoaTelefoneRel { get; private set; }

        #endregion

        #endregion

        #region Métodos

        private void ValidarTelefone(string nome, string numero, bool ativo)
        {

            string regexTelefoneCelular = @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$";

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"O campo {nameof(Nome)} é obrigatório.");

            if (nome.Length > 20)
                throw new ArgumentException($"O campo {nameof(Nome)} não pode ser maior que 20 caracteres.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException($"O campo {nameof(Numero)} é obrigatório.");

            if (!Regex.IsMatch(numero, regexTelefoneCelular))
                throw new ArgumentException($"O campo {nameof(Numero)} está em um formato inválido.");

            Nome = nome.Trim();
            Numero = numero.Trim();
            Ativo = ativo;
        }

        #endregion
    }
}