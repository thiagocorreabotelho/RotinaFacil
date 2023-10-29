using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class PessoaEmailTest
    {
        [Theory(DisplayName = "Dados pessoa/email válido")]
        [InlineData(1, 1)]
        public void ConstrutorPessoaEmail_PassarDadosValidos_RetornarSucesso(int pessoaId, int emailId)
        {
            Action action = () => new PessoaEmail(pessoaId, emailId);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "PessoaId e emailId Inválido")]
        [InlineData(0,1)]
        [InlineData(1,0)]
        public void ConstrutorPessoaEmail_PassarPessoaIdEmailIdInvalido(int pessoaId, int emailId)
        {
            Action action = () => new PessoaEmail( pessoaId,  emailId);
            action.Should().Throw<ArgumentException>();
        }
    }
}
