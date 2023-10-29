using FluentAssertions;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Test
{
    public class EnderecoTest
    {

        [Theory(DisplayName = "Dados endereço válido")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "Apt 404 bl 10", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", " ", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEmail_PassarDadosValidos_RetornarSucesso(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Nome do endereço inválido")]
        [InlineData(null, "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("Teste para colocar uma string com um número maior que 100 caracteres para testar se vai passar no mesmo.", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarNomeInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "CEP inválido")]
        [InlineData("Apartamento no Crispim", null, "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", " ", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-0101", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarCEPInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Logradouro válido")]
        [InlineData("Apartamento no Crispim", "12402-010", " ", "430", "Crispim", "Apt 404 bl 10", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "", "430", "Crispim", "", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", null, "430", "Crispim", " ", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Teste para colocar uma string com um número maior que 100 caracteres para testar se vai passar no mesmo.Teste para colocar uma string com um número maior que 100 caracteres para testar se vai passar no mesmo.", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Tes", "430", "Crispim", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarLogradouroInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Número inválido")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", " ", "Crispim", "Apt 404 bl 10", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "", "Crispim", "", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", null, "Crispim", " ", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "1234567", "Crispim", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarNumeroInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Cidade Inválida.")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "Apt 404 bl 10", " ", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "", "", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", " ", null, "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pin", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Teste para colocar uma string com um número maior que 100 caracteres para testar se vai passar no mesmo.", "SP", true)]

        public void ConstrutorEndereco_PassarBairroInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Cidade Inválida")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Cr", "Apt 404 bl 10", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "", "", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", " ", " ", "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", null, null, "Pindamonhagaba", "SP", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Teste para colocar uma string com um número maior que 100 caracteres para testar se vai passar no mesmo.", null, "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarCidadeInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Estado Inválido")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "Apt 404 bl 10", "Pindamonhagaba", " ", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "", "Pindamonhagaba", "", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", " ", "Pindamonhagaba", null, true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "S", true)]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", null, "Pindamonhagaba", "Sdd", true)]
        public void ConstrutorEndereco_PassarEstadoInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Dados endereço válido")]
        [InlineData("Apartamento no Crispim", "12402-010", "Avenida Monsenhor João José de Azevedo", "430", "Crispim", "Apt 404 bl 10Apt 404 bl 10Apt 404 bl 10Apt 404 bl 10", "Pindamonhagaba", "SP", true)]
        public void ConstrutorEndereco_PassarPontoReferenciaInvalido(string nome, string cep, string logradouro, string numero, string bairro, string? pontoReferencia, string cidade, string estado, bool ativo)
        {
            Action action = () => new Endereco(nome, cep, logradouro, numero, bairro, pontoReferencia, cidade, estado, ativo);
            action.Should().Throw<ArgumentException>();
        }
    }
}
