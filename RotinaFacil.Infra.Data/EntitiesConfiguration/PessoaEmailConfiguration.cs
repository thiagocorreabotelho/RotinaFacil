using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class PessoaEmailConfiguration : IEntityTypeConfiguration<PessoaEmail>
    {
        public void Configure(EntityTypeBuilder<PessoaEmail> builder)
        {
            builder.ToTable("PessoaEmail");

            builder.HasKey(e => new { e.PessoaId, e.EmailId });

            // Configurar relacionamento muitos-para-muitos
            builder.HasOne(pe => pe.PessoaRel)
                .WithMany(p => p.PessoaEmailRel)
                .HasForeignKey(pe => pe.PessoaId);

            builder.HasOne(pe => pe.EmailRel)
                .WithMany(e => e.PessoaEmailRel)
                .HasForeignKey(pe => pe.EmailId);
        }
    }
}
