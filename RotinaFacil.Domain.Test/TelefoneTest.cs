using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class TelefoneTest
    {
        [Theory(DisplayName = "Dados telefone válido")]
        [InlineData("Número Principal", "12997627158", true)]
        public void ConstrutorTelefone_PassarDadosValidos_RetornarSucesso(string nome, string numero, bool ativo)
        {
            Action action = () => new Telefone(nome, numero, ativo);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Nome Inválido")]
        [InlineData("Teste de nome maior que 20 caracteres", "12997627158", true)]
        [InlineData("", "12997627158", true)]
        [InlineData(" ", "12997627158", true)]
        [InlineData(null, "12997627158", true)]
        public void ConstrutorTelefone_PassarNomeInvalido(string nome, string numero, bool ativo)
        {
            Action action = () => new Telefone(nome, numero, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Nome Inválido")]
        [InlineData("Número Principal", "aaaaa")]
        [InlineData("Número Principal", " ")]
        [InlineData("Número Principal", "")]
        [InlineData("Número Principal", null)]
        public void ConstrutorTelefone_PassarNumeroInvalido(string nome, string numero)
        {
            Action action = () => new Telefone(nome, numero, true);
            action.Should().Throw<ArgumentException>();
        }
    }
}
