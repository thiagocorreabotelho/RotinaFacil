using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class EmailTest
    {
        [Theory(DisplayName = "Dados e-mail válido")]
        [InlineData("seuemail@dominio.com.br", true)]
        public void ConstrutorEmail_PassarDadosValidos_RetornarSucesso(string email, bool ativo)
        {
            Action action = () => new Email(email, ativo);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "E-mail Inválido")]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData(" ", true)]
        [InlineData("meuemail", true)]
        public void ConstrutorEmail_PassarEmailInvalido(string email, bool ativo)
        {
            Action action = () => new Email(email, ativo);
            action.Should().Throw<ArgumentException>();
        }
    }
}
