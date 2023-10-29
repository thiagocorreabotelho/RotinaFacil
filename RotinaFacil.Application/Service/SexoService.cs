using AutoMapper;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Helpers;
using RotinaFacil.Application.Interface;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;
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
            var listaSexo = await _iSexoRepository.ObterListaAsync();
            return _iMapper.Map<IEnumerable<SexoDTO>>(listaSexo);
        }

        /// <summary>
        /// Método responsável por retornar um objeto unico pelo identificador.
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>Retorna o objeto completo com todos os dados da base de dados.</returns>
        public async Task<SexoDTO> ObterPorIdAsync(int id)
        {
            SexoHelper sexoHelper = new SexoHelper();
            sexoHelper.ValidarParametroId(id);
            var sexoPorId = await _iSexoRepository.ObterPorIdAsync(id);
            return _iMapper.Map<SexoDTO>(sexoPorId);
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

            sexoDto.Ativo = true;
            var novoSexo = _iMapper.Map<Sexo>(sexoDto);
            await _iSexoRepository.NovoAsync(novoSexo);
            return sexoDto;
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

            sexoHelper.ValidarSexoDto(sexoDto);

            var alterarSexo = _iMapper.Map<Sexo>(sexoDto);
            await _iSexoRepository.AlterarAsync(alterarSexo);
            return sexoDto;
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
                listaSexoDTO.Add($"Erro SQL: {exception.InnerException?.Message}");
                ex.Data["Erros"] = listaSexoDTO;
                throw ex;
            }
        }
    }
}
