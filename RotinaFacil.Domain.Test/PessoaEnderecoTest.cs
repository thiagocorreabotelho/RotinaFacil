using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class PessoaEnderecoTest
    {
        [Theory(DisplayName = "Dados pessoa/endereço válido")]
        [InlineData(1, 1)]
        public void ConstrutorPessoaEndereco_PassarDadosValidos_RetornarSucesso(int pessoaId, int enderecoId)
        {
            Action action = () => new PessoaEndereco(pessoaId, enderecoId);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "PessoaId e enderecoId Inválido")]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void ConstrutorPessoaEndereco_PassarPessoaIdEnderecoIdInvalido(int pessoaId, int enderecoId)
        {
            Action action = () => new PessoaEndereco(pessoaId, enderecoId);
            action.Should().Throw<ArgumentException>();
        }
    }
}
