using Microsoft.OpenApi.Models;
using System.Reflection;

namespace RotinaFacil.Presentation.WebAPI.SwaggerSetup
{
    public static class SwaggerSetup
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Web API de rotinas diárias",

                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Projeto de rotinas diárias.",
                        //Url = new Uri("https://github.com/POS-NET/BoletoAPI")

                    },
                    Description = "Este projeto tem como objetivo gerenciar todos os gastos pessoais, fornecendo uma lista detalhada de todas as despesas mensais. Isso nos permitirá ter um controle financeiro mais eficaz e bem organizado."
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "RotinaFacil.Presentation.WebAPI");
            });
        }
    }
}
