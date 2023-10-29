using System.ComponentModel.DataAnnotations;

namespace RotinaFacil.Application.DTOs
{
    public class EmailDTO
    {
        [Key]
        public int EmailId { get; set; }
        public string? TextoEmail { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
