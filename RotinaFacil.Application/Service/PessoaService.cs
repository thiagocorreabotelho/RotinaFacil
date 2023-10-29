using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Helpers;
using RotinaFacil.Application.Interface;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;

namespace RotinaFacil.Application.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _iPessoaRepository;
        private readonly IMapper _iMapper;

        public PessoaService(IPessoaRepository iPessoaRepository, IMapper iMapper)
        {
            _iPessoaRepository = iPessoaRepository;
            _iMapper = iMapper;
        }

        /// <summary>
        /// Método service responsável por listar todos os registros cadastrado na base de pessoas.
        /// Lembrando que vai ser exibido apenas os registros ativos.
        /// </summary>
        /// <returns>Retorna uma lista de pessoas.</returns>
        public async Task<IEnumerable<PessoaDTO>> ObterListaAsync()
        {
            var listaPessoas = await _iPessoaRepository.ObterListaAsync();
            return _iMapper.Map<IEnumerable<PessoaDTO>>(listaPessoas);
        }

        /// <summary>
        /// Método service por consultar um registro pelo código de identificação da pessoa.
        /// </summary>
        /// <param name="id">ID = Código de identificação</param>
        /// <returns>Retorna o objeto pessoa em especifico.</returns>
        public async Task<PessoaDTO> ObterPorIdAsync(int id)
        {
            var consultarPessoaPorId = await _iPessoaRepository.ObterPorIdAsync(id);
            return _iMapper.Map<PessoaDTO>(consultarPessoaPorId);
        }

        /// <summary>
        /// Método service responsável por consultar uma pessoa pelo nome do mesmo.
        /// </summary>
        /// <param name="nome">Nome da pessoa que vai ser pesquisado.</param>
        /// <returns>Retorna a pessoa conforme o nome do mesmo.</returns>
        public async Task<PessoaDTO> ObterPorNomeAsync(string nome)
        {
            var consultarPessoaNome = await _iPessoaRepository.ObterPorNomeAsync(nome);
            return _iMapper.Map<PessoaDTO>(consultarPessoaNome);
        }

        /// <summary>
        /// Método service responsável por consultar uma pessoa especifica pelo CPF do mesmo.
        /// </summary>
        /// <param name="cpf">CPF da pessoa</param>
        /// <returns>Retorna a pessoa conforme o CPF do mesmo.</returns>
        public async Task<PessoaDTO> ObterPorCPFAsync(string cpf)
        {
            var consultarPessoaCPF = await _iPessoaRepository.ObterPorCpfAsync(cpf);
            return _iMapper.Map<PessoaDTO>(consultarPessoaCPF);
        }

        /// <summary>
        /// Método de interface para cadastrar um nova pessoa no banco de dados.
        /// </summary>
        /// <param name="pessoaDTO">Objeto da pessoa</param>
        /// <returns>Retorna o objeto pessoa cadastrada na base de dados.</returns>
        public async Task<PessoaDTO> NovoAsync(PessoaDTO pessoaDTO)
        {
            #region Pessoa

            PessoaHelper pessoaHelper = new PessoaHelper();
            var validarPropriedadesPessoa = await pessoaHelper.ValidarPessoa(pessoaDTO);
            if (validarPropriedadesPessoa.Any())
                 return pessoaDTO;

            #endregion

            #region Endereco

            EnderecoHelper enderecoHelper = new EnderecoHelper();
            if (pessoaDTO.EnderecoPessoa.Any())
            {
                var validarPropriedadesEndereco = await enderecoHelper.ValidarEndereco(pessoaDTO.EnderecoPessoa);
                if (validarPropriedadesEndereco.Any())
                    return pessoaDTO;
            }

            #endregion

            #region Email

            EmailHelper emailHelper = new EmailHelper();
            if (pessoaDTO.EmailsPessoa.Any())
            {
                var validarPropriedadesEmail = await emailHelper.ValidarEmail(pessoaDTO.EmailsPessoa);
                if (validarPropriedadesEmail.Any()) 
                    return pessoaDTO;
            }

            #endregion

            var consultarPessoaPorNome = await ObterPorNomeAsync(pessoaDTO.Nome);
            if (string.IsNullOrWhiteSpace(consultarPessoaPorNome.Nome))
            {
                pessoaDTO.ListaErro.Add(new ErroDTO { MensagemErro = $"Pessoa {consultarPessoaPorNome.Nome} já existe na base." });
                return pessoaDTO;
            }

            var consultarPessoaPorCPF = await ObterPorCPFAsync(pessoaDTO.CPF);
            if (string.IsNullOrWhiteSpace(consultarPessoaPorCPF.CPF))
            {
                pessoaDTO.ListaErro.Add(new ErroDTO { MensagemErro = $"Pessoa {pessoaDTO.Nome} com o CPF: {pessoaDTO.CPF} já existe na base." });
                return pessoaDTO;
            }

            var novaPessoa = _iMapper.Map<Pessoa>(pessoaDTO);
            await _iPessoaRepository.NovoAsync(novaPessoa);
            return pessoaDTO;
        }

        /// <summary>
        /// Método de interface responsável por alterar dados de um determinado registro.
        /// </summary>
        /// <param name="pessoaDTO">Objeto da pessoa</param>
        /// <returns>Retorna o objeto alterado.</returns>
        public async Task AlterarAsync(PessoaDTO pessoaDTO)
        {
            var alterarPessoa = _iMapper.Map<Pessoa>(pessoaDTO);
            await _iPessoaRepository.AlterarAsync(alterarPessoa);
        }

        /// <summary>
        /// Método de interface responsável por inativar um registro na base de dados.
        /// OBS: Não excluimos registro da base, apenas inativamos passando o ativo = false.
        /// </summary>
        /// <param name="pessoaDTO">Objeto pessoa</param>
        public async Task ExcluirAsync(PessoaDTO pessoaDTO)
        {
            var inativarPessoa = _iMapper.Map<Pessoa>(pessoaDTO);
            await _iPessoaRepository.ExcluirAsync(inativarPessoa);
        }
    }
}
