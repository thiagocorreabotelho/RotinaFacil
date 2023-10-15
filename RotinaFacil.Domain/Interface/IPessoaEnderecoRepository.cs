using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IPessoaEnderecoRepository
    {
        /// <summary>
        /// Contrato de interface para cadastrar um novo vinculo de endereço da pessoa ou seja, uma pessoa poderá ter N endereços.
        /// </summary>
        /// <param name="pessoaEndereco">Objeto de endereço pessoa</param>
        Task<PessoaEndereco> NovoAsync(PessoaEndereco pessoaEndereco);

        /// <summary>
        /// Contrato de interface para alterar o vínculo de endereço dos e-mails.
        /// </summary>
        /// <param name="pessoaEndereco">Objeto de endereço de e-mail.</param>
        Task<PessoaEndereco> AlterarAsync(PessoaEndereco pessoaEndereco);
    }
}
