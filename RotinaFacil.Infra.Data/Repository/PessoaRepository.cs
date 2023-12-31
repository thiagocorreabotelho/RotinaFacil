﻿using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;

namespace RotinaFacil.Infra.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Método responsável por listar todas as pessoas cadastrada na base de dados.
        /// Lembrando que a lista só irá trazer dados ativos.
        /// </summary>
        /// <returns>Retorna a lista de pessoas.</returns>
        public async Task<IEnumerable<Pessoa>> ObterListaAsync()
        {
            try
            {
                return await _applicationDbContext.Pessoa.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por consultar um determinado registro da base de dados.
        /// Lembrando que para consultar precisamos consultar com o código de identificação. (ID)
        /// </summary>
        /// <param name="id">Código de identificação</param>
        /// <returns>Retorna uma pessoa única.</returns>
        public async Task<Pessoa> ObterPorIdAsync(int id)
        {
            try
            {
                return await _applicationDbContext.Pessoa.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método do repositório para consultar a pessoa pelo nome.
        /// </summary>
        /// <param name="nome">Nome da pessoa.</param>
        /// <returns>Retorna objeto único da pessoa.</returns>
        public async Task<Pessoa> ObterPorNomeAsync(string nome)
        {
            try
            {
                return await _applicationDbContext.Pessoa.FirstOrDefaultAsync(pessoa => pessoa.Nome == nome);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método do repositório responsável por consultar a pessoa pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF da pessoa.</param>
        /// <returns>Retorna o objeto único da pessoa.</returns>
        public async Task<Pessoa> ObterPorCpfAsync(string cpf)
        {
            try
            {
                return await _applicationDbContext.Pessoa.FirstOrDefaultAsync(pessoa => pessoa.CPF == cpf);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por cadastrar pessoa na base de dados.
        /// </summary>
        /// <param name="pessoa">Objeto Pessoa</param>
        /// <returns>Retorna a pessoa cadastrado.</returns>
        public async Task<Pessoa> NovoAsync(Pessoa pessoa)
        {
            using (var transacao = await _applicationDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _applicationDbContext.Add(pessoa);
                    await _applicationDbContext.SaveChangesAsync();
                    transacao.Commit();
                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
            return pessoa;
        }

        /// <summary>
        /// Método responsável por alterar dados de um objeto na base de dados.
        /// </summary>
        /// <param name="pessoa">Objeto Pessoa.</param>
        /// <returns>Retorna objeto da pessoa alterado.</returns>
        public async Task<Pessoa> AlterarAsync(Pessoa pessoa)
        {
            using (var transacao = await _applicationDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _applicationDbContext.Update(pessoa);
                    await _applicationDbContext.SaveChangesAsync();
                    transacao.Commit();
                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
            return pessoa;
        }

        /// <summary>
        /// Método responsável por inativar registro da base dados.
        /// Lembrando que para inativar, basta passar a propriedade ATIVO = false.
        /// OBS: Lembrando que nunca iremos excluir um registro e sim inativar.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public async Task<Pessoa> ExcluirAsync(Pessoa pessoa)
        {
            using (var transacao = await _applicationDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _applicationDbContext.Remove(pessoa);
                    await _applicationDbContext.SaveChangesAsync();
                    transacao.Commit();
                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
            return null;
        }
    }
}
