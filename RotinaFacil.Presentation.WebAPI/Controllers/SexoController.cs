using Microsoft.AspNetCore.Mvc;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Interface;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexoDTO>>> Get()
        {
            var retornoListSexo = await _iSexoService.ObterListaAsync();

            if (retornoListSexo == null)
                return NotFound("Não foi possível retornar a lista de sexo.");

            return Ok(retornoListSexo);
        }

        [HttpGet("{id:int}", Name = "GetSexo")]
        public async Task<ActionResult<SexoDTO>> Get(int id)
        {
            if (id == 0)
                return BadRequest($"O {nameof(id)} não pode ser zero.");

            var retornarSexoPorId = await _iSexoService.ObterPorIdAsync(id);
            if (retornarSexoPorId == null)
                return NotFound("Não foi poss´vel retornar o sexo.");

            return Ok(retornarSexoPorId);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<SexoDTO>> GetPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nameof(nome)))
                return BadRequest($"O {nameof(nome)} é inválido.");

          var retornarSexoPorNome = await _iSexoService.ObterPorNomeAsync(nome);
          if(retornarSexoPorNome == null)
                return BadRequest($"Não foi possível retornar o nome do sexo.");

            return Ok(retornarSexoPorNome);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SexoDTO sexoDto)
        {

            var obterSexoPorNome = await _iSexoService.ObterPorNomeAsync(sexoDto.Nome);

            if (!string.IsNullOrWhiteSpace(obterSexoPorNome?.Nome))
                return BadRequest($"O registro sexo: {obterSexoPorNome.Nome} já existe na base.");

            if (sexoDto == null)
                return BadRequest("Sexo não pode ser nulo");

            await _iSexoService.NovoAsync(sexoDto);

            return new CreatedAtRouteResult("GetSexo", new { id = sexoDto.SexoId},
           sexoDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] SexoDTO sexoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Não foi possível validar sua model.");

            if (sexoDTO.SexoId != id)
                return BadRequest("Erro de integridade de ids.");

            await _iSexoService.AlterarAsync(sexoDTO);

            return Ok(sexoDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id, [FromBody] SexoDTO sexoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Não foi possível validar sua model.");

            if (sexoDTO.SexoId != id)
                return BadRequest("Érro de integridade de ids.");

            await _iSexoService.ExcluirAsync(sexoDTO);

            return Ok(sexoDTO);
        }
    }
}
