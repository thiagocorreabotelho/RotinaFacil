using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class PessoaTelefoneConfiguration : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("PessoaTelefone");

            builder.HasKey(e => new { e.PessoaId, e.TelefoneId });

            // Configurar relacionamento muitos-para-muitos
            builder.HasOne(pe => pe.PessoaRel)
                .WithMany(p => p.PessoaTelefoneRel)
                .HasForeignKey(pe => pe.PessoaId);

            builder.HasOne(pe => pe.TelefoneRel)
                .WithMany(e => e.PessoaTelefoneRel)
                .HasForeignKey(pe => pe.TelefoneId);
        }
    }
}
