using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotinaFacil.Application.Interface;
using RotinaFacil.Application.Mapping;
using RotinaFacil.Application.Service;
using RotinaFacil.Domain.Interface;
using RotinaFacil.Infra.Data.Context;
using RotinaFacil.Infra.Data.Repository;

namespace RotinaFacil.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Conexão com o banco de dados


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #endregion

            #region Repositórios

            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepositoy>();
            services.AddScoped<IPessoaEmailRepository, PessoaEmailRepository>();
            services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaTelefoneRepository, PessoaTelefoneRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            #endregion

            #region Service

            services.AddScoped<ISexoService, SexoService>();
            services.AddScoped<IPessoaService, PessoaService>();

            #endregion

            #region Configuração do AutoMapper

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            #endregion

            return services;
        }
    }
}
