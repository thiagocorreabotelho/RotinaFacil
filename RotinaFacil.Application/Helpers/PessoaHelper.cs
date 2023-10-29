using RotinaFacil.Application.DTOs;
using System.Text.RegularExpressions;

namespace RotinaFacil.Application.Helpers
{
    public class PessoaHelper
    {
        public async Task<List<ErroDTO>> ValidarPessoa(PessoaDTO pessoaDTO)
        {
            List<ErroDTO> erroDTOs = new List<ErroDTO>();
            string regexCPF = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

            if (string.IsNullOrWhiteSpace(pessoaDTO.Nome))
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {pessoaDTO.Nome} não pode ser nulo." });

            if (pessoaDTO.Nome.Length < 3)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.Nome)} deve conter no mínimo 3 caracteres." });

            if (pessoaDTO.Nome.Length > 100)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.Nome)} deve conter no máximo 100 caracteres." });

            if (string.IsNullOrWhiteSpace(pessoaDTO.Sobrenome))
                throw new ArgumentException($"");
            erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.Sobrenome)} é obrigatório." });

            if (pessoaDTO.Sobrenome.Length < 5)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.Sobrenome)} deve conter no mínimo 5 caracteres." });

            if (pessoaDTO.Sobrenome.Length > 100)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.Sobrenome)} deve conter no máximo 100 caracteres." });

            if (pessoaDTO.CPF != null && pessoaDTO.CPF.Length != 14)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.CPF)} está em um formato inválido." });

            if (pessoaDTO.CPF != null && !Regex.IsMatch(pessoaDTO.CPF, regexCPF))
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.CPF)} está inválido." });

            if (pessoaDTO.DataNascimento == DateTime.MinValue)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.DataNascimento)} está em um formato inválido." });

            if (pessoaDTO.SexoId == 0)
                erroDTOs.Add(new ErroDTO { MensagemErro = $"O campo {nameof(pessoaDTO.SexoId)} é obrigatório." });

            return erroDTOs;
        }
    }
}
