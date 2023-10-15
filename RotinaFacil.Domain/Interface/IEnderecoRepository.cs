using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IEnderecoRepository
    {
        /// <summary>
        /// Contrato de interface para listar objetos do e-mail.
        /// </summary>
        Task<IEnumerable<Endereco>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface para obter um determinado registro da basse de dados.
        /// </summary>
        /// <param name="id">Id identificador.</param>
        Task<Endereco> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface para cadastrar endereços na base.
        /// </summary>
        /// <param name="endereco">Objeto do endereço</param>
        Task<Endereco> NovoAsync(Endereco endereco);

        /// <summary>
        /// Contrato de interface para alterar dados de um determinado registro.
        /// </summary>
        /// <param name="endereco">Objeto de endereço.</param>
        Task<Endereco> AlterarAsync(Endereco endereco);

        /// <summary>
        /// Contrato de interface para inativar um registro, o inativar vai passar o campo ativo como false.
        /// Por regra não iremos excluir dados da base de dados.
        /// </summary>
        /// <param name="endereco">Objeto de endereço.</param>
        Task<Endereco> ExcluirAsync(Endereco endereco);
    }
}
