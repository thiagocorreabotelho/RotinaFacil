using Microsoft.AspNetCore.Mvc;
using RotinaFacil.Application.DTOs;
using RotinaFacil.Application.Interface;

namespace RotinaFacil.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoasService;
        public PessoasController(IPessoaService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> Get()
        {
            var consultarListaPessoas = await _pessoasService.ObterListaAsync();

            if (consultarListaPessoas == null)
                return BadRequest("Não foi possível processar a lista de pessoas.");

            return Ok(consultarListaPessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDTO>> GetPorId(int id)
        {
            if (id == 0)
                return BadRequest($"Erro do {nameof(id)}: {id}");

            var consultarPessoaPorId = await _pessoasService.ObterPorIdAsync(id);
            if (consultarPessoaPorId == null)
                return BadRequest($"Não foi possível retornar a pessoa.");

            return Ok(consultarPessoaPorId);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<PessoaDTO>> GetPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest($"Formato do nome inválido.");

            var consultarPessoaPorNome = await _pessoasService.ObterPorNomeAsync(nome);
            if (consultarPessoaPorNome == null)
                return BadRequest($"Não foi possível retornar pessoa. Valor retornado: {consultarPessoaPorNome}");

            return Ok(consultarPessoaPorNome);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<PessoaDTO>> GetPorCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return BadRequest($"Formato do CPF é inválido.");

            var consultarPessoaPorCPF = await _pessoasService.ObterPorCPFAsync(cpf);
            if (consultarPessoaPorCPF == null)
                return BadRequest($"Não foi possível retornar a pessoa. Valor retornado: {consultarPessoaPorCPF}");

            return Ok(consultarPessoaPorCPF);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDTO pessoaDTO)
        {
            await _pessoasService.NovoAsync(pessoaDTO);
            return Ok(pessoaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PessoaDTO pessoaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Não foi possível validar sua model.");

            if (pessoaDTO.PessoaId != id)
                return BadRequest("Erro de integridade de ids.");

            await _pessoasService.AlterarAsync(pessoaDTO);

            return Ok(pessoaDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id, [FromBody] PessoaDTO pessoaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Não foi possível validar sua model.");

            if (pessoaDTO.PessoaId != id)
                return BadRequest("Érro de integridade de ids.");

            await _pessoasService.ExcluirAsync(pessoaDTO);

            return Ok(pessoaDTO);
        }

    }
}
