using AutoMapper;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Interface;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Domain.Interface;

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
            var sexoPorId = await _iSexoRepository.ObterPorIdAsync(id);
            return _iMapper.Map<SexoDTO>(sexoPorId);
        }

        public async Task<SexoDTO> ObterPorNomeAsync(string nome)
        {
            var sexoPorNome = await _iSexoRepository.ObterPorNomeAsync(nome);
            return _iMapper.Map<SexoDTO>(sexoPorNome);
        }

        /// <summary>
        /// Método responsável por realizar o cadastro dos sexo na base de dados.
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        /// <returns>retorna o sexo id</returns>
        public async Task NovoAsync(SexoDTO sexoDto)
        {
            var novoSexo = _iMapper.Map<Sexo>(sexoDto);
            await _iSexoRepository.NovoAsync(novoSexo);
            sexoDto.SexoId = novoSexo.SexoId;
        }

        /// <summary>
        /// Método responsável por alterar os dados da entidade do sexo.
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        /// <returns>Retorna o objeto do sexo.</returns>
        public async Task AlterarAsync(SexoDTO sexoDto)
        {
            var alterarSexo = _iMapper.Map<Sexo>(sexoDto);
            await _iSexoRepository.AlterarAsync(alterarSexo);
        }

        /// <summary>
        /// Método responsável por inativar um restritro ativo
        /// </summary>
        /// <param name="sexoDto">Objeto do sexo</param>
        public async Task ExcluirAsync(SexoDTO sexoDto)
        {
            sexoDto.Ativo = false;
            var inativarSexo = _iMapper.Map<Sexo>(sexoDto);
            await _iSexoRepository.ExcluirAsync(inativarSexo);
        }
    }
}
