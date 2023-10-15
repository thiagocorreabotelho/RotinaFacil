using RotinaFacil.Application.DTOs;

namespace RotinaFacil.Application.Interface
{
    public interface IPessoaService
    {
        /// <summary>
        /// Contrato de interface para listar dados das pessoas cadastrada na base de dados.
        /// </summary>
        Task<IEnumerable<PessoaDTO>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface responsável por retornar objeto unico pelo código de identificação.
        /// </summary>
        /// <param name="id">ID = Código de identificação</param>
        Task<PessoaDTO> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface responsável por consultar a pessoa pelo nome do mesmo.
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        Task<PessoaDTO> ObterPorNomeAsync(string nome);

        /// <summary>
        /// Contrato responsável por consultar pessoa pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF da pessoa.</param>
        Task<PessoaDTO> ObterPorCPFAsync(string cpf);

        /// <summary>
        /// Contrato de interface responsável por cadastrar pessooas na base de dados.
        /// </summary>
        /// <param name="pessoaDTO">Objeto da pessoa.</param>
        Task NovoAsync(PessoaDTO pessoaDTO);

        /// <summary>
        /// Controto de interface responsável por alterar dados de um determinado registro.
        /// </summary>
        /// <param name="pessoaDTO">Objeto da pessoa.</param>
        Task AlterarAsync(PessoaDTO pessoaDTO);

        /// <summary>
        /// Contrato de interface responsável por inativar um determinado registro da base.
        /// OBS: Lembrando que não excluimos registro da base de dados, apenas setamos a propriedade ativo como false.
        /// </summary>
        /// <param name="pessoaDTO"></param>
        /// <returns></returns>
        Task ExcluirAsync(PessoaDTO pessoaDTO);
    }
}
