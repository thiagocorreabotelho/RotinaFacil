using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.PessoaId)
            .HasName("PessoaId");

            builder.Property(x => x.PessoaId)
           .HasColumnName("PessoaId")
           .HasColumnOrder(1)
           .ValueGeneratedOnAdd()
           .HasComment("Coluna destina a chave primária da tabela");

            builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("VARCHAR(100)")
            .HasMaxLength(100)
            .HasComment("Coluna destina para o nome da pessoa");

            builder.Property(x => x.Sobrenome)
            .HasColumnName("Sobrenome")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("VARCHAR(100)")
            .HasMaxLength(100)
            .HasComment("Coluna destina para o sobrenome da pessoa");

            builder.Property(x => x.CPF)
           .HasColumnName("CPF")
           .HasColumnOrder(4)
           .HasColumnType("VARCHAR(14)")
           .HasMaxLength(14)
           .HasComment("Coluna destina para o CPF da pessoa");

            builder.Property(x => x.RG)
           .HasColumnName("RG")
           .HasColumnOrder(5)
           .HasColumnType("VARCHAR(12)")
           .HasMaxLength(12)
           .HasComment("Coluna destina para o CPF da pessoa");

            builder.Property(p => p.DataNascimento)
            .HasColumnName("DataNascimento")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação da pessoa");

            builder.Property(x => x.Ativo)
           .HasColumnName("Ativo")
           .HasColumnOrder(7)
           .IsRequired()
           .HasColumnType("bit")
           .HasDefaultValue(1)
           .HasComment("Coluna para controlar o registro ativo");
        }
    }
}
