using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class SexoRepository : ISexoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SexoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por listar dados do sexo.
        /// Lembrando que a listagem é exibida apenas para registros ativos.
        /// </summary>
        /// <returns>Retorna lista de sexos.</returns>
        public async Task<IEnumerable<Sexo>> ObterListaAsync()
        {
            return await _applicationDbContext.Sexo.Where(sexo => sexo.Ativo == true)
                .ToListAsync();
        }

        /// <summary>
        /// Método responsável por obter um sexo por código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação (ID)</param>
        /// <returns>Retorna o registro único.</returns>
        public async Task<Sexo> ObterPorIdAsync(int id)
        {
            return await _applicationDbContext.Sexo.FindAsync(id);
        }

        /// <summary>
        /// Método responsável por pesquisar registro pelo nome do mesmo.
        /// </summary>
        /// <param name="nome">Nome do registro</param>
        /// <returns>Retorna objeto completo</returns>
        public async Task<Sexo> ObterPorNomeAsync(string nome)
        {
            return await _applicationDbContext.Sexo.FirstOrDefaultAsync(s => s.Nome == nome);
        }

        /// <summary>
        /// Método responsável por cadastrar novos sexo na base de dados.
        /// </summary>
        /// <param name="sexo">Objeto do sexo.</param>
        /// <returns>Retorna objeto do registro criado na base.</returns>
        public async Task<Sexo> NovoAsync(Sexo sexo)
        {
            _applicationDbContext.Add(sexo);
            await _applicationDbContext.SaveChangesAsync();
            return sexo;
        }

        /// <summary>
        /// Método responsável por alterar dados de um determinado registro.
        /// </summary>
        /// <param name="sexo">Objeto de sexo</param>
        /// <returns>Retorna o objeto alterado.</returns>
        public async Task<Sexo> AlterarAsync(Sexo sexo)
        {
            _applicationDbContext.Update(sexo);
            await _applicationDbContext.SaveChangesAsync();
            return sexo;
        }

        /// <summary>
        /// Método responsável por inativar sexo da base de dados.
        /// Lembrando que não excluimos registros, apenas passamos o campo Ativo = false.
        /// </summary>
        /// <param name="sexo">Objeto de sexo.</param>
        public async Task<Sexo> ExcluirAsync(Sexo sexo)
        {
            _applicationDbContext.Update(sexo);
            await _applicationDbContext.SaveChangesAsync();
            return sexo;
        }
    }
}
