using AutoMapper;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Helpers;
using RotinaFacil.Application.Interface;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
using System;
using System.Diagnostics;

namespace RotinaFacil.Application.Service
{
    public class SexoService : ISexoService
    {
        private ISexoRepository _iSexoRepository;
        private readonly IMapper _iMapper;

        public SexoService(ISexoRepository iSexoRepository, IMapper imapper)
        {
            _iSexoRepository = iSexoRepository;
            _iMapper = imapper;
        }

        /// <summary>
        /// Método para obter lista de todos os sexos cadastrado no banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista de de sexo.</returns>
        public async Task<IEnumerable<SexoDTO>> ObterListaAsync()
        {
            List<string> listaSexoDTO = new List<string>();
            try
            {
                var listaSexo = await _iSexoRepository.ObterListaAsync();
                return _iMapper.Map<IEnumerable<SexoDTO>>(listaSexo);
            }
            catch (Exception ex)
            {
                listaSexoDTO.Add($"Erro SQL: {ex.InnerException?.Message}");
                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }

        }

        /// <summary>
        /// Método responsável por retornar um objeto unico pelo identificador.
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>Retorna o objeto completo com todos os dados da base de dados.</returns>
        public async Task<SexoDTO> ObterPorIdAsync(int id)
        {
            List<string> listaSexoDTO = new List<string>();

            try
            {
                SexoHelper sexoHelper = new SexoHelper();
                sexoHelper.ValidarParametroId(id);
                var sexoPorId = await _iSexoRepository.ObterPorIdAsync(id);
                return _iMapper.Map<SexoDTO>(sexoPorId);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro ao tentar consultar o cliente pelo código de identificação.");
                }
                else if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro na base de dados ao tentar consultar o cliente. Erro: {ex.InnerException.Message}");
                }

                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }
        }

        /// <summary>
        /// Método service responsável por consultar o sexo por nome.
        /// </summary>
        /// <param name="nome">Nome do sexo</param>
        /// <param name="permiteValidacao">Este parâmetro indica que, se sexoPorNome não for encontrado no banco de dados, ele retornará uma mensagem indicando que o item não foi encontrado. 
        /// No entanto, se a consulta estiver sendo feita por um método externo apenas para verificar a existência de sexoPorNome, 
        /// o parametroValidacao deve ser definido como false. Isso fará com que o método retorne null e permitirá que o método de origem realize a validação.</param>
        /// <returns>Retorna o sexo conforme o nome</returns>
        public async Task<SexoDTO> ObterPorNomeAsync(string nome, bool permiteValidacao = false)
        {

            List<string> listaSexoDTO = new List<string>();
            SexoHelper sexoHelper = new SexoHelper();
            Exception ex = new Exception();

            try
            {
                sexoHelper.ValidarParametroNome(nome);
                var sexoPorNome = await _iSexoRepository.ObterPorNomeAsync(nome);
                if (sexoPorNome == null && permiteValidacao)
                {
                    listaSexoDTO.Add($"O sexo {nome} não foi encontrado.");
                    ex.Data["Erros"] = listaSexoDTO;
                    throw ex;
                }

                return _iMapper.Map<SexoDTO>(sexoPorNome);
            }
            catch (Exception exception)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro ao tentar consultar o cliente pelo nome.");
                }
                else if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro na base de dados ao tentar consultar o cliente. Erro: {ex.InnerException.Message}");
                }

                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por realizar o cadastro dos sexo na base de dados.
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        /// <returns>retorna o sexo id</returns>
        public async Task<SexoDTO> NovoAsync(SexoDTO sexoDto)
        {
            SexoHelper sexoHelper = new SexoHelper();
            Exception ex = new Exception();
            List<string> listaSexoDTO = new List<string>();

            sexoHelper.ValidarSexoDto(sexoDto);
            var consultarSexo = await ObterPorNomeAsync(sexoDto.Nome, false);
            if (!string.IsNullOrEmpty(consultarSexo?.Nome))
            {
                listaSexoDTO.Add($"O sexo {consultarSexo.Nome} já consta cadastrado.");
                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }

            try
            {
                sexoDto.Ativo = true;
                var novoSexo = _iMapper.Map<Sexo>(sexoDto);
                await _iSexoRepository.NovoAsync(novoSexo);
                return sexoDto;
            }
            catch (Exception exception)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro ao tentar cadastrar o sexo erro: {exception.Message}.");
                }
                else if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro na base de dados na tentativa de cadastrar o sexo {sexoDto.Nome}. Erro: {ex.InnerException.Message}");
                }

                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por alterar os dados da entidade do sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        /// <param name="sexoId">Código de identificação do objeto.</param>
        /// <returns>Retorna o objeto do sexo.</returns>
        public async Task<SexoDTO> AlterarAsync(int sexoId, SexoDTO sexoDto)
        {
            SexoHelper sexoHelper = new SexoHelper();
            Exception ex = new Exception();
            List<string> listaSexoDTO = new List<string>();

            if (sexoDto.SexoId == 0)
            {
                listaSexoDTO.Add($"Valor inválido do id: {sexoDto.SexoId}.");
                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }

            if (sexoId != sexoDto.SexoId)
            {

                listaSexoDTO.Add($"Ocorreu um erro de integridade de identificadores. Os valores de ‘sexoId’ e ‘sexoDto.SexoId’ não podem ser diferentes. Atualmente, eles são {sexoId} e {sexoDto.SexoId}, respectivamente.");
                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }

            try
            {
                sexoHelper.ValidarSexoDto(sexoDto);
                var alterarSexo = _iMapper.Map<Sexo>(sexoDto);
                await _iSexoRepository.AlterarAsync(alterarSexo);
                return sexoDto;
            }
            catch (Exception exception)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro ao tentar alterar o sexo erro: {exception.Message}.");
                }
                else if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro na base de dados na tentativa de alterar o sexo {sexoDto.Nome}. Erro: {ex.InnerException.Message}");
                }

                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }

        }

        /// <summary>
        /// Método responsável por inativar um restritro ativo
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        /// <param name="sexoId">Código de identificação do objeto.</param>
        public async Task<SexoDTO> ExcluirAsync(int sexoId, SexoDTO sexoDto)
        {
            SexoHelper sexoHelper = new SexoHelper();
            Exception ex = new Exception();
            List<string> listaSexoDTO = new List<string>();

            try
            {
                if (sexoDto.SexoId == 0)
                {
                    listaSexoDTO.Add($"Valor inválido do id: {sexoDto.SexoId}.");
                    ex.Data["Erros"] = listaSexoDTO;
                    throw ex;
                }

                if (sexoId != sexoDto.SexoId)
                {
                    listaSexoDTO.Add($"Ocorreu um erro de integridade de identificadores. Os valores de ‘sexoId’ e ‘sexoDto.SexoId’ não podem ser diferentes. Atualmente, eles são {sexoId} e {sexoDto.SexoId}, respectivamente.");
                    ex.Data["Erros"] = listaSexoDTO;
                    throw ex;
                }

                sexoHelper.ValidarSexoDto(sexoDto);

                sexoDto.Ativo = false;
                var inativarSexo = _iMapper.Map<Sexo>(sexoDto);
                await _iSexoRepository.ExcluirAsync(inativarSexo);
                return sexoDto;

            }
            catch (Exception exception)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro ao tentar inativar o sexo erro: {exception.Message}.");
                }
                else if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    listaSexoDTO.Add($"Ocorreu um erro na base de dados na tentativa de inativar o sexo {sexoDto.Nome}. Erro: {ex.InnerException.Message}");
                }

                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }
        }
    }
}
