using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IEmailRepository
    {
        /// <summary>
        /// Contrato de interface para geerar lista de e-mails.
        /// </summary>
        Task<IEnumerable<Email>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface para retornar um objeto único.
        /// </summary>
        /// <param name="id">Id para identificar um registro em especifico.</param>
        Task<Email> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface para criar registros de e-mails na base de dados.
        /// </summary>
        /// <param name="email">Objeto da entidade de e-mail.</param>
        /// <returns></returns>
        Task<Email> NovoAsync(Email email);

        /// <summary>
        /// Contrato de interface para alterar dados do objeto do e-mail.
        /// </summary>
        /// <param name="email">Objeto do e-mail.</param>
        Task<Email> AlterarAsync(Email email);

        /// <summary>
        /// Contrato de interface para inativar um registro. Sempre a ação de inativar irá inativar um registro e nunca exclui-lo.
        /// </summary>
        /// <param name="email">Objeto de e-mail, mandar o ativo = false.</param>
        Task<Email> ExcluirAsync(Email email);
    }
}
