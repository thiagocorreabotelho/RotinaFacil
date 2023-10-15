using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Domain.Interface
{
    public interface IPessoaTelefoneRepository
    {
        /// <summary>
        /// Contrato de interface para criar vinculo da pessoa com telefone
        /// Uma pessoa pode ter Ns telefones.
        /// </summary>
        /// <param name="pessoaTelefone"></param>
        Task<PessoaTelefone> NovoAsync(PessoaTelefone pessoaTelefone);

        /// <summary>
        /// Contrato de interface para alterar vinculo de telefone da pessoa.
        /// Uma pessoa poderá ter Ns números cadastrado na base.
        /// </summary>
        /// <param name="pessoaTelefone"></param>
        /// <returns></returns>
        Task<PessoaTelefone> AlterarAsync(PessoaTelefone pessoaTelefone);
    }
}
