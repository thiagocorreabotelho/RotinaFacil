using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");

            builder.HasKey(x => x.EmailId)
             .HasName("EmailId");

            builder.Property(x => x.EmailId)
            .HasColumnName("EmailId")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Coluna destina a chave primária da tabela");

            builder.Property(x => x.TextoEmail)
            .HasColumnName("TextoEmail")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("VARCHAR(150)")
            .HasMaxLength(150)
            .HasComment("Coluna destina para o campo do e-mail");

            builder.Property(x => x.Ativo)
           .HasColumnName("Ativo")
           .HasColumnOrder(3)
           .IsRequired()
           .HasColumnType("bit")
           .HasDefaultValue(1)
           .HasComment("Coluna para controlar o registro ativo");

            builder.HasIndex(p => p.TextoEmail)
           .HasDatabaseName("IX_EMAIL_ENDERECO")
           .IsUnique();
        }
    }
}
