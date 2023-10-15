
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RotinaFacil.Domain.Entitie;
using RotinaFacil.Infra.Data.Identity;

namespace RotinaFacil.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<PessoaEmail> PessoaEmail { get; set; }
        public DbSet<PessoaEndereco> PessoaEndereco { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // Seta a configuração das entidades.
        }
    }
}
