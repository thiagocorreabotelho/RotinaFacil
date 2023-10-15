using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class PessoaEnderecoConfiguration : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.ToTable("PessoaEndereco");

            builder.HasKey(e => new { e.PessoaId, e.EnderecoId });

            // Configurar relacionamento muitos-para-muitos
            builder.HasOne(pe => pe.PessoaRel)
                .WithMany(p => p.PessoaEnderecoRel)
                .HasForeignKey(pe => pe.PessoaId);

            builder.HasOne(pe => pe.EnderecoRel)
               .WithMany(e => e.PessoaEnderecoRel)
               .HasForeignKey(pe => pe.EnderecoId);
        }
    }
}
