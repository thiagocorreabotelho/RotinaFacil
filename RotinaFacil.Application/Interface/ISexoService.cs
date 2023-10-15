using RotinaFacil.Application.DTOs;

namespace RotinaFacil.Application.Interface
{
    public interface ISexoService
    {
        /// <summary>
        /// Contrato de interface para obter lista de sexo.
        /// </summary>
        Task<IEnumerable<SexoDTO>> ObterListaAsync();

        /// <summary>
        /// Método responsável por obter o registro pelo id.
        /// </summary>
        /// <param name="id">Código de identificação do registro.</param>
        Task<SexoDTO> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface para consultar o registro pelo nome do mesmo.
        /// </summary>
        /// <param name="nome">Parâmetro nome do sexo.</param>
        /// <returns>Retorna o objeto do sexo.</returns>
        Task<SexoDTO> ObterPorNomeAsync(string nome); 

        /// <summary>
        /// Contrato de interface para cadastrar novo sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto SexoDTO</param>
        Task NovoAsync(SexoDTO sexoDto);

        /// <summary>
        /// Contrato de interface para alterar dados do sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto SexoDTO.</param>
        Task AlterarAsync(SexoDTO sexoDto);

        /// <summary>
        /// Contrato de interface para inativar registro da base de dados.
        /// </summary>
        /// <param name="sexoDTO">Objeto SexoDTO</param>
        Task ExcluirAsync(SexoDTO sexoDTO);
    }
}
