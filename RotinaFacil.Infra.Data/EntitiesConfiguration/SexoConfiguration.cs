using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class SexoConfiguration : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable("Sexo");

            builder.HasKey(x => x.SexoId)
             .HasName("SexoId");

            builder.Property(x => x.SexoId)
            .HasColumnName("SexoId")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Coluna destina a chave primária da tabela");

            builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("VARCHAR(15)")
            .HasMaxLength(15)
            .HasComment("Coluna destina para o nome do sexo");

            builder.Property(x => x.Ativo)
           .HasColumnName("Ativo")
           .HasColumnOrder(3)
           .IsRequired()
           .HasColumnType("bit")
           .HasDefaultValue(1)
           .HasComment("Coluna para controlar o registro ativo");

            builder.HasIndex(p => p.Nome)
           .HasDatabaseName("IX_ENDERECO_NOME")
           .IsUnique();
        }
    }
}
