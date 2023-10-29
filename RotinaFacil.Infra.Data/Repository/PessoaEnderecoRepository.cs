using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class PessoaEnderecoRepository : IPessoaEnderecoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoaEnderecoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por cadastrar endereco pessoa (vinculo).
        /// </summary>
        /// <param name="pessoaEndereco">Objeto PessoaEndereco.</param>
        public async Task<PessoaEndereco> NovoAsync(PessoaEndereco pessoaEndereco)
        {
            _applicationDbContext.Add(pessoaEndereco);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaEndereco;
        }

        /// <summary>
        /// Método responsável por alterar dados do endereço da pessoa.
        /// </summary>
        /// <param name="pessoaEndereco">Objeto PessoaEndereco</param>
        public async Task<PessoaEndereco> AlterarAsync(PessoaEndereco pessoaEndereco)
        {
            _applicationDbContext.Update(pessoaEndereco);
            await _applicationDbContext.SaveChangesAsync();
            return pessoaEndereco;
        }
    }
}
