using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RotinaFacil.Application.Helpers
{
    public class UtilHelper
    {
        /// <summary>
        /// Método encarregado de personalizar os erros no Swagger para proporcionar um detalhamento mais preciso.
        /// </summary>
        /// <param name="titulo">Titulo do Erro</param>
        /// <param name="exception">Objeto da excepetion que foi gerado no catch.</param>
        /// <param name="rota">Rota da endpoint que gerou o erro.</param>
        /// <returns></returns>
        public ProblemDetails ErroPersonalizado(string titulo, Exception exception, string rota, string verbo)
        {
            var erros = exception.Data["Erros"] as List<string>;

            return new ProblemDetails
            {
                Title = titulo,
                Status = StatusCodes.Status400BadRequest,
                Detail = erros != null ? string.Join("- ", $"{verbo.ToUpper()} - {string.Join(", ", erros)}") : "null",
                Instance = rota,
            };
        }

       
    }
}
