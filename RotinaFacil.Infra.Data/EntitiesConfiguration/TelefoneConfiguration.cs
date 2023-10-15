using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");

            builder.HasKey(x => x.TelefoneId)
             .HasName("TelefoneId");

            builder.Property(x => x.TelefoneId)
            .HasColumnName("TelefoneId")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Coluna destina a chave primária da tabela");

            builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("VARCHAR(20)")
            .HasMaxLength(20)
            .HasComment("Coluna destina para o nome do telefone");

            builder.Property(x => x.Numero)
            .HasColumnName("Numero")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("VARCHAR(20)")
            .HasMaxLength(20)
            .HasComment("Coluna destina para o nome do telefone");

            builder.Property(x => x.Ativo)
           .HasColumnName("Ativo")
           .HasColumnOrder(4)
           .IsRequired()
           .HasColumnType("bit")
           .HasDefaultValue(1)
           .HasComment("Coluna para controlar o registro ativo");

            builder.HasIndex(p => p.Nome)
          .HasDatabaseName("IX_TELEFONE_NOME")
          .IsUnique();

           builder.HasIndex(p => p.Numero)
          .HasDatabaseName("IX_TELEFONE_NUMERO")
          .IsUnique();
        }
    }
}
