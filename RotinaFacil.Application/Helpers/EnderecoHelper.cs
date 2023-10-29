using RotinaFacil.Application.DTOs;
using System.Text.RegularExpressions;

namespace RotinaFacil.Application.Helpers
{
    public class EnderecoHelper
    {
        public async Task<List<ErroDTO>> ValidarEndereco(List<EnderecoDTO> enderecoDTO)
        {
            List<ErroDTO> erroDTOs = new List<ErroDTO>();
            string regexCEP = @"^\d{5}-\d{3}$";

            foreach (var item in enderecoDTO)
            {
                if (string.IsNullOrWhiteSpace(item.Nome))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Nome} não pode ser nulo." });

                if (item.Nome.Length > 100)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Nome} não pode ser maior que 100 caracteres." });

                if (item.Nome.Length > 100)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Nome} não pode ser maior que 100 caracteres." });

                if (string.IsNullOrWhiteSpace(item.CEP))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.CEP} não pode ser nulo." });

                if (item.CEP.Length != 9)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.CEP} deve ter 9 digitos." });

                if (!Regex.IsMatch(item.CEP, regexCEP))
                    throw new ArgumentException($"O campo {nameof(item.CEP)} está inválido.");

                if (string.IsNullOrWhiteSpace(item.Logradouro))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Logradouro} não pode ser nulo." });

                if (item.Logradouro.Length < 5)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Logradouro} deve ter no minimo 5 caracteres." });

                if (item.Logradouro.Length > 150)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Logradouro} deve ter no máximo 150 caracteres." });

                if (string.IsNullOrWhiteSpace(item.Numero))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Numero} não pode ser nulo." });

                if (item.Logradouro.Length > 150)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Logradouro} deve ter no máximo 150 caracteres." });

                if (string.IsNullOrWhiteSpace(item.Bairro))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Bairro} não pode ser nulo." });

                if (item.Bairro.Length < 5)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Bairro} deve ter no minimo 5 caracteres." });

                if (item.Bairro.Length > 100)
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Bairro} deve ter no máximo 100 caracteres." });

                if (string.IsNullOrWhiteSpace(item.Cidade))
                    erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {item.Cidade} não pode ser nulo." });

                if (item.Cidade.Length < 5)
                    throw new ArgumentException($"O campo {nameof(item.Cidade)} deve ter pelo menos 5 caracteres.");

                if (item.Cidade.Length > 100)
                    throw new ArgumentException($"O campo {nameof(item.Cidade)} não pode ser maior que 100 caracteres.");

                if (string.IsNullOrWhiteSpace(item.Estado))
                    throw new ArgumentException($"O campo {nameof(item.Estado)} é obrigatório.");

                if (item.Estado.Length != 2)
                    throw new ArgumentException($"O campo {nameof(item.Estado)} deve conter 2 caracteres.");

                if (item.PontoReferencia != null && item.PontoReferencia.Length > 15)
                    throw new ArgumentException($"O campo {nameof(item.PontoReferencia)} não pode ter mais de 15 caracteres.");
            }

            return erroDTOs;
        }
    }
}
