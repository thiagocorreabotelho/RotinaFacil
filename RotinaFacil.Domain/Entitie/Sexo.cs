namespace RotinaFacil.Domain.Entitie
{
    public sealed class Sexo
    {
        #region Construtores
        public Sexo()
        {
                
        }
        public Sexo(string nome, bool ativo)
        {
            ValidarSexo(nome, ativo);
        }

        #endregion

        #region Propriedades

        public int SexoId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public bool Ativo { get; private set; }

        #endregion Propriedades

        #region Métodos

        private void ValidarSexo(string nome, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"O campo {nameof(Nome)} é obrigatório.");

            if (nome.Length > 15)
                throw new ArgumentException($"O campo {nameof(Nome)} deve ter no máximo 15 caracteres.");

            Nome = nome.Trim();
            Ativo = ativo;
        }

        #endregion
    }
}