using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotinaFacil.Domain.Entitie;

namespace RotinaFacil.Infra.Data.EntitiesConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.EnderecoId)
            .HasName("EnderecoId");

            builder.Property(x => x.EnderecoId)
            .HasColumnName("EnderecoId")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Coluna destina a chave primária da tabela");

            builder.Property(x => x.Nome)
           .HasColumnName("Nome")
           .HasColumnOrder(2)
           .IsRequired()
           .HasColumnType("VARCHAR(100)")
           .HasMaxLength(100)
           .HasComment("Coluna destina para o nome do endereço");

            builder.Property(x => x.CEP)
           .HasColumnName("CEP")
           .HasColumnOrder(3)
           .IsRequired()
           .HasColumnType("VARCHAR(9)")
           .HasMaxLength(9)
           .HasComment("Coluna destina para o CEP do endereço");

            builder.Property(x => x.Logradouro)
           .HasColumnName("Logradouro")
           .HasColumnOrder(4)
           .IsRequired()
           .HasColumnType("VARCHAR(150)")
           .HasMaxLength(150)
           .HasComment("Coluna destina para o logradouro do endereço");

            builder.Property(x => x.Numero)
           .HasColumnName("Numero")
           .HasColumnOrder(5)
           .IsRequired()
           .HasColumnType("VARCHAR(5)")
           .HasMaxLength(5)
           .HasComment("Coluna destina para o número do endereço");

            builder.Property(x => x.Bairro)
           .HasColumnName("Bairro")
           .HasColumnOrder(6)
           .IsRequired()
           .HasColumnType("VARCHAR(100)")
           .HasMaxLength(100)
           .HasComment("Coluna destina para o bairro do endereço");

            builder.Property(x => x.PontoReferencia)
           .HasColumnName("PontoReferencia")
           .HasColumnOrder(7)
           .HasColumnType("VARCHAR(50)")
           .HasMaxLength(50)
           .HasComment("Coluna destina para o bairro do endereço");

            builder.Property(x => x.Cidade)
            .HasColumnName("Cidade")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("VARCHAR(100)")
            .HasMaxLength(100)
            .HasComment("Coluna destina para a cidade do endereço");

            builder.Property(x => x.Estado)
           .HasColumnName("Estado")
           .HasColumnOrder(9)
           .IsRequired()
           .HasColumnType("VARCHAR(2)")
           .HasMaxLength(2)
           .HasComment("Coluna destina para ao estado do endereço");

            builder.Property(x => x.Ativo)
           .HasColumnName("Ativo")
           .HasColumnOrder(10)
           .IsRequired()
           .HasColumnType("bit")
           .HasDefaultValue(1)
           .HasComment("Coluna para controlar o registro ativo");

            builder.HasIndex(p => p.Nome)
           .HasDatabaseName("IX_ENDERECO_NOME")
           .IsUnique();

            builder.HasIndex(p => p.Cidade)
           .HasDatabaseName("IX_CIDADE_NOME")
           .IsUnique();

            builder.HasIndex(p => p.Estado)
            .HasDatabaseName("IX_ESTADO_NOME")
            .IsUnique();
        }
    }
}
