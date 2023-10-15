using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface ITelefoneRepository
    {
        /// <summary>
        /// Interface de contrato para listar todos os registro do telefone.
        /// Lembrando que esses registros é apenas para os registros que estão ativos na base de dados.
        /// </summary>
        Task<IEnumerable<Telefone>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface para obter um registro por por código de identificação.
        /// </summary>
        /// <param name="id">Id do registro de telefone.</param>
        Task<Telefone> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface para registrar dados do telefone.
        /// </summary>
        /// <param name="telefone">Objeto do telefone.</param>
        Task<Telefone> NovoAsync(Telefone telefone);

        /// <summary>
        /// Contrato de interface para alterar dados da entidade de telefone.
        /// </summary>
        /// <param name="telefone">Objeto de telefone.</param>
        Task<Telefone> AlterarAsync(Telefone telefone);

        /// <summary>
        /// Contrato de interface para inativar registro da base de dados.
        /// Lembrando que para inativar um registro, não excluimos apenas setamos a propriedade de Atiivo como false.
        /// </summary>
        /// <param name="telefone">Objeto de telefone.</param>
        Task<Telefone> ExcluirAsync(Telefone telefone);
    }
}
