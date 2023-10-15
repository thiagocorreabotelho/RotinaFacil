using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmailRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por listar objeto de e-mails da base de dados.
        /// </summary>
        /// <returns>Retorna lista de e-mails</returns>
        public async Task<IEnumerable<Email>> ObterListaAsync()
        {
            return await _applicationDbContext.Email.ToListAsync();
        }

        /// <summary>
        /// Método responsável por obter um determinado registro por id.
        /// </summary>
        /// <param name="id">Código de identificação do e-mail.</param>
        /// <returns>Retorna objeto do e-mail.</returns>
        public async Task<Email> ObterPorIdAsync(int id)
        {
            return await _applicationDbContext.Email.FindAsync(id);
        }

        /// <summary>
        /// Método responsável por cadastrar um novo e-mail na base de dados.
        /// </summary>
        /// <param name="email">Objeto de e-mail</param>
        /// <returns>Retrona o ee-mail cadastrado na base.</returns>
        public async Task<Email> NovoAsync(Email email)
        {
            _applicationDbContext.Add(email);
            await _applicationDbContext.SaveChangesAsync();
            return email;
        }

        /// <summary>
        /// Método responsável por alterar dados do e-mail.
        /// </summary>
        /// <param name="email">Objeto de e-mail.</param>
        /// <returns>Retorna o objeto de e-mail alterarado.</returns>
        public async Task<Email> AlterarAsync(Email email)
        {
            _applicationDbContext.Update(email);
            await _applicationDbContext.SaveChangesAsync();
            return email;
        }

        /// <summary>
        /// Métoodo responsável por inativar um determinado registro na base de dados.
        /// Lembrando que para inativar um registro, devemos primeiramente receber a propriedade Ativo como false.
        /// </summary>
        /// <param name="email">Objeto de e-mail</param>
        public async Task<Email> ExcluirAsync(Email email)
        {
            _applicationDbContext.Remove(email);
            await _applicationDbContext.SaveChangesAsync();
            return null;
        }
       
    }
}
