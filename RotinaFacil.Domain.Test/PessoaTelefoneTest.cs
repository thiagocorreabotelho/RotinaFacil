using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class PessoaTelefoneTest
    {
        [Theory(DisplayName = "Dados pessoa/telefone válido")]
        [InlineData(1, 1)]
        public void ConstrutorPessoaTelefone_PassarDadosValidos_RetornarSucesso(int pessoaId, int telefoneId)
        {
            Action action = () => new PessoaTelefone(pessoaId, telefoneId);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "PessoaId e telefoneId Inválido")]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void ConstrutorPessoaTelefone_PassarPessoaIdTelefoneIdInvalido(int pessoaId, int telefoneId)
        {
            Action action = () => new PessoaTelefone(pessoaId, telefoneId);
            action.Should().Throw<ArgumentException>();
        }
    }
}
