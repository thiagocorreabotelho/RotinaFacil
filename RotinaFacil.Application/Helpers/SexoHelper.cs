using RotinaFacil.Application.DTOs;

namespace RotinaFacil.Application.Helpers
{
    public class SexoHelper
    {

        /// <summary>
        /// Método responsável por validar propriedades diretamente do DTO
        /// </summary>
        /// <param name="sexoDTO">Parâmetro com dados do DTO.</param>
        /// <returns>retorna uma lista de erros ou a lista zerada.</returns>
        public void ValidarSexoDto(SexoDTO sexoDTO)
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrWhiteSpace(sexoDTO.Nome))
                erros.Add($"O campo {nameof(sexoDTO.Nome)} é obrigatório.");
            else if (sexoDTO.Nome.Length > 15)
                erros.Add($"O campo {nameof(sexoDTO.Nome)} deve ter no máximo 15 caracteres.");

            if (erros.Any())
            {
                Exception ex = new Exception();
                ex.Data["Erros"] = erros;
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por validar o parâmetro ID.
        /// </summary>
        /// <param name="id">Valor do id enviado por parâmetro.</param>
        /// <returns>Retorna a lista de erro.</returns>
        public void ValidarParametroId(int id)
        {

            if (id == 0)
                throw new Exception($"Id é inválido: {id}");
        }

        /// <summary>
        /// Método responsável por validar por nome
        /// </summary>
        /// <param name="nome">Parâmetro com valor do nome para ser validado.</param>
        public void ValidarParametroNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception($"O parâmetro não pode ser nulo ou vazio!");
        }

    }
}
