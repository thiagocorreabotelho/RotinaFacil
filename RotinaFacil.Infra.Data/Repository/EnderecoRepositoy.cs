using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class EnderecoRepositoy : IEnderecoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EnderecoRepositoy(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por listar todos os endereço que estão cadastrado na base de dados.
        /// Vai ser exibido apenas os registros que estão ativos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Endereco>> ObterListaAsync()
        {
            return await _applicationDbContext.Endereco.ToListAsync();
        }
        /// <summary>
        /// Método responsável por retornar um registro unico polo código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação do registro</param>
        /// <returns>Retorna objeto da base</returns>
        public async Task<Endereco> ObterPorIdAsync(int id)
        {
            return await _applicationDbContext.Endereco.FindAsync(id);
        }

        /// <summary>
        /// Método responsável por cadastrar endereços na base
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<Endereco> NovoAsync(Endereco endereco)
        {
            _applicationDbContext.Add(endereco);
            await _applicationDbContext.SaveChangesAsync();
            return endereco;
        }

        /// <summary>
        /// Método responsável por alterar dados de um determinado registro do endereço.
        /// </summary>
        /// <param name="endereco">Objeto de endereço</param>
        /// <returns>Retorna o objeto de endereço preenchido.</returns>
        public async Task<Endereco> AlterarAsync(Endereco endereco)
        {
            _applicationDbContext.Update(endereco);
            await _applicationDbContext.SaveChangesAsync();
            return endereco;
        }

        /// <summary>
        /// Método responsável por inativar registros.
        /// Lembrando que para inativar registro é preciso passar o ATIVO = false.
        /// </summary>
        /// <param name="endereco">Objeto do endereço.</param>
        public async Task<Endereco> ExcluirAsync(Endereco endereco)
        {
            _applicationDbContext.Remove(endereco);
            await _applicationDbContext.SaveChangesAsync();
            return null;
        }

        

       

        
    }
}
