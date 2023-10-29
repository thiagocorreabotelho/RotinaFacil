using System.Text.RegularExpressions;
using RotinaFacil.Application.DTOs;

namespace RotinaFacil.Application.Helpers
{
    public class EmailHelper
    {
        public async Task<List<ErroDTO>> ValidarEmail(List<EmailDTO> emailDTO)
        {
            List<ErroDTO> erroDTOs = new List<ErroDTO>();
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            foreach (var item in emailDTO)
            {
                if (string.IsNullOrWhiteSpace(item.TextoEmail))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O e-mail não pode estar em branco; por favor, forneça um endereço de e-mail válido." });

                if (!Regex.IsMatch(item.TextoEmail, regex))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"E-mail inválido." });
            }
                
            return erroDTOs;
        }
    }
}
