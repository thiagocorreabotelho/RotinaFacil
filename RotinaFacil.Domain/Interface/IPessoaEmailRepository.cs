using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IPessoaEmailRepository
    {
        /// <summary>
        /// Contrato de interface para criar um vinculo de N e-mails para as pessoas, basicamente esse contrato vai cadastrar dados na base.
        /// </summary>
        /// <param name="pessoaEmail">Objeto de e-mail das pessoas.</param>
        Task<PessoaEmail> NovoAsync(PessoaEmail pessoaEmail);

        /// <summary>
        /// Contrato de interface para alterar o vinculo de e-mails.
        /// </summary>
        /// <param name="pessoaEmail">Objeto de e-mail pessoa</param>
        Task<PessoaEmail> AlterarAsync(PessoaEmail pessoaEmail);
    }
}
