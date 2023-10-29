using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TelefoneRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por listar dados do telefone.
        /// Lembrando que os dados listados, são apenas os dados com o ativo = true.
        /// </summary>
        /// <returns>Retorna lista de telefone.</returns>
        public async Task<IEnumerable<Telefone>> ObterListaAsync()
        {
            return await _applicationDbContext.Telefone.ToListAsync();
        }

        /// <summary>
        /// Método responsável por consultar um registro pelo código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação (ID)</param>
        /// <returns>Retorna objeto único.</returns>
        public async Task<Telefone> ObterPorIdAsync(int id)
        {
            return await _applicationDbContext.Telefone.FindAsync(id);
        }

        /// <summary>
        /// Método responsável por cadastrar novos telefones na base de dados.
        /// </summary>
        /// <param name="telefone">Objeto Telefone</param>
        /// <returns>Retorna objeto telefone cadastrado na base de dados.</returns>
        public async Task<Telefone> NovoAsync(Telefone telefone)
        {
            _applicationDbContext.Add(telefone);
            await _applicationDbContext.SaveChangesAsync();
            return telefone;
        }

        /// <summary>
        /// Método responsável por alterar dados do registro telefone.
        /// </summary>
        /// <param name="telefone">Objeto telefone.</param>
        /// <returns>Retorna telefone.</returns>
        public async Task<Telefone> AlterarAsync(Telefone telefone)
        {
            _applicationDbContext.Update(telefone);
            await _applicationDbContext.SaveChangesAsync();
            return telefone;
        }

        /// <summary>
        /// Método responsável por inativar registros de telefone da base de dados.
        /// Lembrando que não iremos excluir um registro e sim inativar.
        /// </summary>
        /// <param name="telefone">Objeto Telefone</param>
        public async Task<Telefone> ExcluirAsync(Telefone telefone)
        {
            _applicationDbContext.Remove(telefone);
            await _applicationDbContext.SaveChangesAsync();
            return null;
        }
       
    }
}
