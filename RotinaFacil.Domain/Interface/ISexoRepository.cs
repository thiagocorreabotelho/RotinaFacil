using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface ISexoRepository
    {
        /// <summary>
        /// Contrato de interface para listar todos os registro do sexo da base.
        /// A listagem retornará apenas registros ativos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Sexo>> ObterListaAsync();

        /// <summary>
        /// Contrato de interface para obter um registro em especifico pelo código de identificação.
        /// Lembrando que para obter o registro, deve ser informado o id do registro.
        /// </summary>
        /// <param name="id">Id do registro</param>
        Task<Sexo> ObterPorIdAsync(int id);

        /// <summary>
        /// Contrato de interface para obter o registro pelo nome.
        /// </summary>
        /// <param name="nome">Nome do registro</param>
        Task<Sexo> ObterPorNomeAsync(string nome);

        /// <summary>
        /// Contrato de interface para cadastrar novos registro na base de sexo.
        /// </summary>
        /// <param name="sexo">Objeto do sexo</param>
        Task<Sexo> NovoAsync(Sexo sexo);

        /// <summary>
        /// Contrato de interface para alterar registro do sexo.
        /// </summary>
        /// <param name="sexo">Objeto do sexo</param>
        Task<Sexo> AlterarAsync(Sexo sexo);

        /// <summary>
        /// Contrato de interface para inativar um determinado registro.
        /// Para inativar o registro a propriedade de Ativo deve ser passada como false.
        /// </summary>
        /// <param name="sexo">Objeto do sexo.</param>
        Task<Sexo> ExcluirAsync(Sexo sexo);
    }
}
