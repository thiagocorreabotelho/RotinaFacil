using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IPessoaRepository
    {
        /// <summary>
        /// Contrato de interface para listar pessoas atividas cadastrada na base de dados.
        /// </summary>
        Task<IEnumerable<Pessoa>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface responsável por retornar um registro em especifico pelo código de identificação.
        /// </summary>
        /// <param name="id">Id de identificação do registro.</param>
        /// <returns></returns>
        Task<Pessoa> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface do repositório para consultar a pessoa pelo nome do mesmo.
        /// </summary>
        /// <param name="nome">Nome da pessoa que deseja consultar.</param>
        /// <returns></returns>
        Task<Pessoa> ObterPorNomeAsync(string nome);

        /// <summary>
        /// Contrato de interface do repositório para consultar a pessoa pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF da pessoa que deseja ser consultada.</param>
        Task<Pessoa> ObterPorCpfAsync(string cpf);

        /// <summary>
        /// Contrato de interface para cadastrar registro na base de dados da pessoa.
        /// </summary>
        /// <param name="pessoa">Objeto pessoa</param>
        /// <returns></returns
        Task<Pessoa> NovoAsync(Pessoa pessoa);

        /// <summary>
        /// Contrato de interface para alterar dados de um registro do banco pessoa.
        /// </summary>
        /// <param name="pessoa">Objeto da pessoa.</param>
        /// <returns></returns>
        Task<Pessoa> AlterarAsync(Pessoa pessoa);

        /// <summary>
        /// Contrato de interface para inativar registro de dentro da base de dados pessoa.
        /// Um registro nunca será excluido e sim inativado passando a propriedade Ativo como false.
        /// </summary>
        /// <param name="pessoa">Objeto pessoa.</param>
        Task<Pessoa> ExcluirAsync(Pessoa pessoa);
    }
}
