using RotinaFacil.Application.DTOs;
using System.Threading.Tasks;

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
        /// <param name="permiteValidacao">Este parâmetro indica que, se sexoPorNome não for encontrado no banco de dados, ele retornará uma mensagem indicando que o item não foi encontrado. 
        /// No entanto, se a consulta estiver sendo feita por um método externo apenas para verificar a existência de sexoPorNome, o parametroValidacao deve ser definido como false. 
        /// Isso fará com que o método retorne null e permitirá que o método de origem realize a validação.</param>
        /// <returns>Retorna o objeto do sexo.</returns>
        Task<SexoDTO> ObterPorNomeAsync(string nome, bool permiteValidacao); 

        /// <summary>
        /// Contrato de interface para cadastrar novo sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto SexoDTO</param>
        Task<SexoDTO> NovoAsync(SexoDTO sexoDto);

        /// <summary>
        /// Contrato de interface para alterar dados do sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto SexoDTO.</param>
        /// <param name="sexoId">Código de identificação do sexo.</param>
        Task<SexoDTO> AlterarAsync(int sexoId, SexoDTO sexoDto);

        /// <summary>
        /// Contrato de interface para inativar registro da base de dados.
        /// </summary>
        /// <param name="sexoDTO">Objeto SexoDTO</param>
        /// /// <param name="sexoId">Código de identificação do sexo.</param>
        Task<SexoDTO> ExcluirAsync(int sexoId, SexoDTO sexoDTO);
    }
}
