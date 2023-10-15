using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "int", nullable: false, comment: "Coluna destina a chave primária da tabela")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextoEmail = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false, comment: "Coluna destina para o campo do e-mail")
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmailId", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false, comment: "Coluna destina a chave primária da tabela")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, comment: "Coluna destina para o nome do endereço"),
                    CEP = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false, comment: "Coluna destina para o CEP do endereço"),
                    Logradouro = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false, comment: "Coluna destina para o logradouro do endereço"),
                    Numero = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false, comment: "Coluna destina para o número do endereço"),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, comment: "Coluna destina para o bairro do endereço"),
                    PontoReferencia = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true, comment: "Coluna destina para o bairro do endereço"),
                    Cidade = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, comment: "Coluna destina para a cidade do endereço"),
                    Estado = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false, comment: "Coluna destina para ao estado do endereço")
                },
                constraints: table =>
                {
                    table.PrimaryKey("EnderecoId", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(type: "int", nullable: false, comment: "Coluna destina a chave primária da tabela")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false, comment: "Coluna destina para o nome do telefone"),
                    Numero = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false, comment: "Coluna destina para o nome do telefone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("TelefoneId", x => x.TelefoneId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                { 
                    PessoaId = table.Column<int>(type: "int", nullable: false, comment: "Coluna destina a chave primária da tabela")
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, comment: "Coluna destina para o nome da pessoa"),
                    Sobrenome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, comment: "Coluna destina para o sobrenome da pessoa"),
                    CPF = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: true, comment: "Coluna destina para o CPF da pessoa"),
                    RG = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: true, comment: "Coluna destina para o CPF da pessoa"),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação da pessoa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PessoaId", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEmail",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEmail", x => new { x.PessoaId, x.EmailId });
                    table.ForeignKey(
                        name: "FK_PessoaEmail_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEmail_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEndereco",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEndereco", x => new { x.PessoaId, x.EnderecoId });
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaTelefone",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTelefone", x => new { x.PessoaId, x.TelefoneId });
                    table.ForeignKey(
                        name: "FK_PessoaTelefone_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaTelefone_Telefone_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "Telefone",
                        principalColumn: "TelefoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "int", nullable: false, comment: "Coluna destina a chave primária da tabela")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false, comment: "Coluna destina para o nome do sexo"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    PessoaRelPessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SexoId", x => x.SexoId);
                    table.ForeignKey(
                        name: "FK_Sexo_Pessoa_PessoaRelPessoaId",
                        column: x => x.PessoaRelPessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_ENDERECO",
                table: "Email",
                column: "TextoEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_NOME",
                table: "Endereco",
                column: "Cidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_NOME",
                table: "Endereco",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_NOME",
                table: "Endereco",
                column: "Estado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEmail_EmailId",
                table: "PessoaEmail",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEndereco_EnderecoId",
                table: "PessoaEndereco",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaTelefone_TelefoneId",
                table: "PessoaTelefone",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_NOME",
                table: "Sexo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sexo_PessoaRelPessoaId",
                table: "Sexo",
                column: "PessoaRelPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_NOME",
                table: "Telefone",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_NUMERO",
                table: "Telefone",
                column: "Numero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_PESSOAS",
                table: "Pessoa",
                column: "PessoaId",
                principalTable: "Sexo",
                principalColumn: "SexoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_PESSOAS",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PessoaEmail");

            migrationBuilder.DropTable(
                name: "PessoaEndereco");

            migrationBuilder.DropTable(
                name: "PessoaTelefone");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
