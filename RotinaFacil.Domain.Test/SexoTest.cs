using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class SexoTest
    {
        [Theory(DisplayName = "Dados pessoa válido")]
        [InlineData("Masculino", true)]
        public void ConstrutorSexo_PassarDadosValidos_RetornarSucesso(string nome, bool ativo)
        {
            Action action = () => new Sexo(nome, ativo);
            action.Should().NotThrow();
        }


        [Theory(DisplayName = "Nome Inválido")]
        [InlineData("Passar texto maior que 15 caracters", true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData(null, true)]
        public void ConstrutorSexo_PassarNomeInvalido(string nome , bool ativo)
        {
            Action action = () => new Sexo(nome, ativo);
            action.Should().Throw<ArgumentException>();
        }
    }
}
