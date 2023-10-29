using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class PessoaEmailRepository : IPessoaEmailRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoaEmailRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        /// <summary>
        /// Método responsável por cadastrar e-mails por pessoa. (Vinculo)
        /// </summary>
        /// <param name="pessoaEmail">Objeto PessoaEmail</param>
        /// <returns>Retorna o objeto pessoa e-mail.</returns>
        public async Task<PessoaEmail> NovoAsync(PessoaEmail pessoaEmail)
        {
            _applicationDbContext.Add(pessoaEmail);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaEmail;
        }

        /// <summary>
        /// Método responsável por alterar dados do vinculo do e-mail de pessoas.
        /// </summary>
        /// <param name="pessoaEmail">Objeto PessoaEmail</param>
        /// <returns>Retorna PessoaEmail</returns>
        public async Task<PessoaEmail> AlterarAsync(PessoaEmail pessoaEmail)
        {
            _applicationDbContext.Update(pessoaEmail);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaEmail;
        }
    }
}
