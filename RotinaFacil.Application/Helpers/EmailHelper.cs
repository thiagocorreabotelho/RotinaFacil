using System.Text.RegularExpressions;
using RotinaFacil.Application.DTOs;

namespace RotinaFacil.Application.Helpers
{
    public class EmailHelper
    {
        public EmailDTO ValidarPropriedadeDTO(EmailDTO emailDTO)
        {
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrWhiteSpace(emailDTO.TextoEmail))
            {
                emailDTO.mensagemErro = $"O e-mail não pode estar em branco; por favor, forneça um endereço de e-mail válido.";
            }

            if (!Regex.IsMatch(emailDTO.TextoEmail, regex))
            {
                emailDTO.mensagemErro = $"E-mail inválido.";
            }
                
            return emailDTO;
        }
    }
}
