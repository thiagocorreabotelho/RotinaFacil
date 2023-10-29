﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RotinaFacil.Infra.Data.Context;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231021003316_AlteracaoBanco")]
    partial class AlteracaoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmailId")
                        .HasColumnOrder(1)
                        .HasComment("Coluna destina a chave primária da tabela");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailId"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo")
                        .HasColumnOrder(3)
                        .HasComment("Coluna para controlar o registro ativo");

                    b.Property<string>("TextoEmail")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("TextoEmail")
                        .HasColumnOrder(2)
                        .HasComment("Coluna destina para o campo do e-mail");

                    b.HasKey("EmailId")
                        .HasName("EmailId");

                    b.HasIndex("TextoEmail")
                        .IsUnique()
                        .HasDatabaseName("IX_EMAIL_ENDERECO");

                    b.ToTable("Email", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EnderecoId")
                        .HasColumnOrder(1)
                        .HasComment("Coluna destina a chave primária da tabela");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo")
                        .HasColumnOrder(10)
                        .HasComment("Coluna para controlar o registro ativo");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Bairro")
                        .HasColumnOrder(6)
                        .HasComment("Coluna destina para o bairro do endereço");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("VARCHAR(9)")
                        .HasColumnName("CEP")
                        .HasColumnOrder(3)
                        .HasComment("Coluna destina para o CEP do endereço");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Cidade")
                        .HasColumnOrder(8)
                        .HasComment("Coluna destina para a cidade do endereço");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)")
                        .HasColumnName("Estado")
                        .HasColumnOrder(9)
                        .HasComment("Coluna destina para ao estado do endereço");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("Logradouro")
                        .HasColumnOrder(4)
                        .HasComment("Coluna destina para o logradouro do endereço");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome")
                        .HasColumnOrder(2)
                        .HasComment("Coluna destina para o nome do endereço");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)")
                        .HasColumnName("Numero")
                        .HasColumnOrder(5)
                        .HasComment("Coluna destina para o número do endereço");

                    b.Property<string>("PontoReferencia")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("PontoReferencia")
                        .HasColumnOrder(7)
                        .HasComment("Coluna destina para o bairro do endereço");

                    b.HasKey("EnderecoId")
                        .HasName("EnderecoId");

                    b.HasIndex("Cidade")
                        .IsUnique()
                        .HasDatabaseName("IX_CIDADE_NOME");

                    b.HasIndex("Estado")
                        .IsUnique()
                        .HasDatabaseName("IX_ESTADO_NOME");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("IX_ENDERECO_NOME");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PessoaId")
                        .HasColumnOrder(1)
                        .HasComment("Coluna destina a chave primária da tabela");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo")
                        .HasColumnOrder(7)
                        .HasComment("Coluna para controlar o registro ativo");

                    b.Property<string>("CPF")
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)")
                        .HasColumnName("CPF")
                        .HasColumnOrder(4)
                        .HasComment("Coluna destina para o CPF da pessoa");

                    b.Property<DateTime>("DataNascimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("DataNascimento")
                        .HasColumnOrder(6)
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Data de criação da pessoa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome")
                        .HasColumnOrder(2)
                        .HasComment("Coluna destina para o nome da pessoa");

                    b.Property<string>("RG")
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR(12)")
                        .HasColumnName("RG")
                        .HasColumnOrder(5)
                        .HasComment("Coluna destina para o CPF da pessoa");

                    b.Property<int>("SexoId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Sobrenome")
                        .HasColumnOrder(3)
                        .HasComment("Coluna destina para o sobrenome da pessoa");

                    b.HasKey("PessoaId")
                        .HasName("PessoaId");

                    b.HasIndex("SexoId");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaEmail", b =>
                {
                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.HasKey("PessoaId", "EmailId");

                    b.HasIndex("EmailId");

                    b.ToTable("PessoaEmail", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaEndereco", b =>
                {
                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("PessoaId", "EnderecoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("PessoaEndereco", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaTelefone", b =>
                {
                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TelefoneId")
                        .HasColumnType("int");

                    b.HasKey("PessoaId", "TelefoneId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("PessoaTelefone", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Sexo", b =>
                {
                    b.Property<int>("SexoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SexoId")
                        .HasColumnOrder(1)
                        .HasComment("Coluna destina a chave primária da tabela");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SexoId"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo")
                        .HasColumnOrder(3)
                        .HasComment("Coluna para controlar o registro ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("Nome")
                        .HasColumnOrder(2)
                        .HasComment("Coluna destina para o nome do sexo");

                    b.HasKey("SexoId")
                        .HasName("SexoId");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("IX_ENDERECO_NOME");

                    b.ToTable("Sexo", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TelefoneId")
                        .HasColumnOrder(1)
                        .HasComment("Coluna destina a chave primária da tabela");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelefoneId"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo")
                        .HasColumnOrder(4)
                        .HasComment("Coluna para controlar o registro ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("Nome")
                        .HasColumnOrder(2)
                        .HasComment("Coluna destina para o nome do telefone");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("Numero")
                        .HasColumnOrder(3)
                        .HasComment("Coluna destina para o nome do telefone");

                    b.HasKey("TelefoneId")
                        .HasName("TelefoneId");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("IX_TELEFONE_NOME");

                    b.HasIndex("Numero")
                        .IsUnique()
                        .HasDatabaseName("IX_TELEFONE_NUMERO");

                    b.ToTable("Telefone", (string)null);
                });

            modelBuilder.Entity("RotinaFacil.Infra.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RotinaFacil.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RotinaFacil.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotinaFacil.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RotinaFacil.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Pessoa", b =>
                {
                    b.HasOne("RotinaFacil.Domain.Entitie.Sexo", "SexoRel")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SexoRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaEmail", b =>
                {
                    b.HasOne("RotinaFacil.Domain.Entitie.Email", "EmailRel")
                        .WithMany("PessoaEmailRel")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotinaFacil.Domain.Entitie.Pessoa", "PessoaRel")
                        .WithMany("PessoaEmailRel")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailRel");

                    b.Navigation("PessoaRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaEndereco", b =>
                {
                    b.HasOne("RotinaFacil.Domain.Entitie.Endereco", "EnderecoRel")
                        .WithMany("PessoaEnderecoRel")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotinaFacil.Domain.Entitie.Pessoa", "PessoaRel")
                        .WithMany("PessoaEnderecoRel")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnderecoRel");

                    b.Navigation("PessoaRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.PessoaTelefone", b =>
                {
                    b.HasOne("RotinaFacil.Domain.Entitie.Pessoa", "PessoaRel")
                        .WithMany("PessoaTelefoneRel")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotinaFacil.Domain.Entitie.Telefone", "TelefoneRel")
                        .WithMany("PessoaTelefoneRel")
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaRel");

                    b.Navigation("TelefoneRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Email", b =>
                {
                    b.Navigation("PessoaEmailRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Endereco", b =>
                {
                    b.Navigation("PessoaEnderecoRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Pessoa", b =>
                {
                    b.Navigation("PessoaEmailRel");

                    b.Navigation("PessoaEnderecoRel");

                    b.Navigation("PessoaTelefoneRel");
                });

            modelBuilder.Entity("RotinaFacil.Domain.Entitie.Telefone", b =>
                {
                    b.Navigation("PessoaTelefoneRel");
                });
#pragma warning restore 612, 618
        }
    }
}
