using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class PessoaTelefoneRepository : IPessoaTelefoneRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoaTelefoneRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por cadastrar telefones por pessoa.
        /// </summary>
        /// <param name="pessoaTelefone">Objeto PessoaTelefone</param>
        public async Task<PessoaTelefone> NovoAsync(PessoaTelefone pessoaTelefone)
        {
            _applicationDbContext.Add(pessoaTelefone);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaTelefone;
        }

        /// <summary>
        /// Método responsável por alterar dados de um determinado registro dos telefones por pessoa.
        /// </summary>
        /// <param name="pessoaTelefone">Objeto PessoaTelefone</param>
        public async Task<PessoaTelefone> AlterarAsync(PessoaTelefone pessoaTelefone)
        {
            _applicationDbContext.Update(pessoaTelefone);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaTelefone;
        }
    }
}
