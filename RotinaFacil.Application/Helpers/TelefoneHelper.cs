using RotinaFacil.Application.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace RotinaFacil.Application.Helpers
{
    public class TelefoneHelper
    {
        public List<ErroDTO> ValidarTelefone(TelefoneDTO telefoneDTO)
        {
            List<ErroDTO> erroDTOs = new List<ErroDTO>();
            string regexCelularOuTelefone = @"^\(\d{2}\)\s?(9\d{4}-\d{4}|\d{4}-\d{4})$";

            if (string.IsNullOrWhiteSpace(telefoneDTO.Nome))
                throw new ArgumentException($"O campo {nameof(telefoneDTO.Nome)} é obrigatório.");

            if (telefoneDTO.Nome.Length > 20)
                throw new ArgumentException($"O campo {nameof(telefoneDTO.Nome)} não pode ser maior que 20 caracteres.");

            if (string.IsNullOrWhiteSpace(telefoneDTO.Numero))
                throw new ArgumentException($"O campo {nameof(telefoneDTO.Numero)} é obrigatório.");

            if (!Regex.IsMatch(telefoneDTO.Numero, regexCelularOuTelefone))
                throw new ArgumentException($"O campo {nameof(telefoneDTO.Numero)} está em um formato inválido.");

            return erroDTOs;
        }
    }
}
