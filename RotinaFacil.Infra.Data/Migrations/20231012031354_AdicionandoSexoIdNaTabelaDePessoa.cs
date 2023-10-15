using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoSexoIdNaTabelaDePessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_PESSOAS",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Sexo_Pessoa_PessoaRelPessoaId",
                table: "Sexo");

            migrationBuilder.DropIndex(
                name: "IX_Sexo_PessoaRelPessoaId",
                table: "Sexo");

            migrationBuilder.DropColumn(
                name: "PessoaRelPessoaId",
                table: "Sexo");

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa",
                column: "SexoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Sexo_SexoId",
                table: "Pessoa",
                column: "SexoId",
                principalTable: "Sexo",
                principalColumn: "SexoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Sexo_SexoId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Pessoa");

            migrationBuilder.AddColumn<int>(
                name: "PessoaRelPessoaId",
                table: "Sexo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Pessoa",
                type: "int",
                nullable: false,
                comment: "Coluna destina a chave primária da tabela",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Coluna destina a chave primária da tabela")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Sexo_PessoaRelPessoaId",
                table: "Sexo",
                column: "PessoaRelPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_PESSOAS",
                table: "Pessoa",
                column: "PessoaId",
                principalTable: "Sexo",
                principalColumn: "SexoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sexo_Pessoa_PessoaRelPessoaId",
                table: "Sexo",
                column: "PessoaRelPessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
