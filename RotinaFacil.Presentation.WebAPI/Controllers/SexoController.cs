using Microsoft.AspNetCore.Mvc;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Helpers;
using RotinaFacil.Application.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RotinaFacil.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly ISexoService _iSexoService;

        public SexoController(ISexoService iSexoService)
        {
            _iSexoService = iSexoService;
        }

        /// <summary>
        /// Endpoint para listar todos os sexos cadastrados na base de dados.
        /// </summary>
        /// <returns>Retrona lista de sexo cadastrado.</returns>
        [ProducesResponseType(typeof(List<SexoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexoDTO>>> Get()
        {
            var retornoListSexo = await _iSexoService.ObterListaAsync();

            if (retornoListSexo == null)
                return NotFound("Não foi possível retornar a lista de sexo.");

            return Ok(retornoListSexo);
        }

        /// <summary>
        /// Endpoint responsável por listar sexo pelo código de identificação.
        /// </summary>
        /// <param name="id">Código de identificação</param>
        /// <returns>Retorna o sexo pelo código de identificação</returns>
        [ProducesResponseType(typeof(SexoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SexoDTO>> Get(int id)
        {
            UtilHelper utilHelper = new UtilHelper();

            try
            {
                var retornarSexoPorId = await _iSexoService.ObterPorIdAsync(id);
                return Ok(retornarSexoPorId);
            }
            catch (Exception ex)
            {
                var erro = utilHelper.ErroPersonalizado("Erro ao consultar sexo pelo id", ex, "/api/Sexo/id", HttpContext.Request.Method);
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Endpoint responsável por consultar o sexo pelo nome.
        /// </summary>
        /// <param name="nome">Nome do sexo que deve ser fornecido.</param>
        /// <returns>Retorna o sexo pesquisado</returns>
        [ProducesResponseType(typeof(SexoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet("{nome}")]
        public async Task<ActionResult<SexoDTO>> GetPorNome(string nome)
        {
            UtilHelper utilHelper = new UtilHelper();

            try
            {
                var retornarSexoPorNome = await _iSexoService.ObterPorNomeAsync(nome, false);
                return Ok(retornarSexoPorNome);
            }
            catch (Exception ex)
            {
                var erro = utilHelper.ErroPersonalizado("Não foi possível consultar o sexo pelo nome", ex, "/api/sexo/nome", HttpContext.Request.Method);
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Endpoint resposável por cadastrar novos sexos.
        /// </summary>
        /// <param name="sexoDto">Objeto DTO preenchidos.</param>
        /// <returns>Retorna o sexo cadastrado.</returns>
        [ProducesResponseType(typeof(SexoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SexoDTO sexoDto)
        {
            UtilHelper utilHelper = new UtilHelper();

            try
            {
                await _iSexoService.NovoAsync(sexoDto);
                return Ok(sexoDto);
            }
            catch (Exception ex)
            {
                var erro = utilHelper.ErroPersonalizado("Não foi possível cadastrar o sexo!", ex, "/api/sexo/", HttpContext.Request.Method);
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Endpoint responsável por editar dados do registro.
        /// </summary>
        /// <param name="id">Código de identificação do sexo.</param>
        /// <param name="sexoDTO">Objeto do sexo preenchido para ser alterado.</param>
        /// <returns>Retorna o objeto alterado.</returns>
        [ProducesResponseType(typeof(SexoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] SexoDTO sexoDTO)
        {
            UtilHelper utilHelper = new UtilHelper();

            try
            {
                await _iSexoService.AlterarAsync(id, sexoDTO);
                return Ok(sexoDTO);
            }
            catch (Exception ex)
            {
                var erro = utilHelper.ErroPersonalizado($"Não foi possível alterar o sexo {sexoDTO.Nome}", ex, "/api/sexo/", HttpContext.Request.Method);
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Endpoint responsável por inativar um registro.
        /// </summary>
        /// <remarks>
        /// É importante ressaltar que não excluímos registros de nossa base de dados. Em vez disso, optamos por inativar o registro, mantendo-o preservado em nossa base.
        /// </remarks>
        /// <param name="id">Código de identificação do sexo.</param>
        /// <param name="sexoDTO">Objeto do sexo preenchido para ser alterado.</param>
        /// <returns>Retorna o objeto alterado.</returns>
        [ProducesResponseType(typeof(SexoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id, [FromBody] SexoDTO sexoDTO)
        {
            UtilHelper utilHelper = new UtilHelper();

            try
            {
                await _iSexoService.ExcluirAsync(id, sexoDTO);
                return Ok(sexoDTO);
            }
            catch (Exception ex)
            {
                var erro = utilHelper.ErroPersonalizado($"Não foi possível alterar o sexo {sexoDTO.Nome}", ex, "/api/sexo/", HttpContext.Request.Method);
                return BadRequest(erro);
            }
        }
    }
}
