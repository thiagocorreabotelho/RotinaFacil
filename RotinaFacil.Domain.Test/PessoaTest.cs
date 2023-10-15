using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class PessoaTest
    {
        [Theory(DisplayName = "Dados pessoa válido")]
        [InlineData("Thiago", "Gilson Corrêa Botelho", null, "", "01/04/1994", 1, true)]
        public void ConstrutorPessoa_PassarDadosValidos_RetornarSucesso(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Nome Inválido")]
        [InlineData("", "Gilson Corrêa Botelho", "", "", "01/04/1994", 1, true)]
        [InlineData(null, "Gilson Corrêa Botelho", "", "", "01/04/1994", 1, true)]
        [InlineData("    ", "Gilson Corrêa Botelho", "", "", "01/04/1994", 1, true)]
        [InlineData("sd", "Gilson Corrêa Botelho", "", "", "01/04/1994", 1, true)]
        public void ConstrutorPessoa_PassarNomeInvalido(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Sobrenome Inválido")]
        [InlineData("Thiago", "", "", "", "01/04/1994", 1, true)]
        [InlineData("Thiago", " ", "", "", "01/04/1994", 1, true)]
        [InlineData("Thiago", null, "", "", "01/04/1994",1, true)]
        [InlineData("Thiago", "Gil", "", "", "01/04/1994", 1, true)]
        public void ConstrutorPessoa_PassarSobrenomeInvalido(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "CPF Inválido")]
        [InlineData("Thiago", "Gilson", "1234567898543", "", "01/04/1994", 1, true)]
        public void ConstrutorPessoa_PassarCPFInvalido(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Data de nascimento Inválido")]
        [InlineData("Thiago", "Gilson", null, null, "01/04/1994",1, true)]
        public void ConstrutorPessoa_PassarDataNascimentoInvalido(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            dataNascimento = DateTime.MinValue;

            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Sexo id inválido")]
        [InlineData("Thiago", "Gilson", null, null, "01/04/1994", 0, true)]
        public void ConstrutorPessoa_PassarSexoIdInvalido(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, int sexoId, bool ativo)
        {
            Action action = () => new Pessoa(nome, sobrenome, cpf, rg, dataNascimento, sexoId, ativo);
            action.Should().Throw<ArgumentException>();
        }
    }
}