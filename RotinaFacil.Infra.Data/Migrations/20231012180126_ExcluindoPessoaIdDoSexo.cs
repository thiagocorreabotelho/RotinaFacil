using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExcluindoPessoaIdDoSexo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Sexo");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa",
                column: "SexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Sexo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SexoId",
                table: "Pessoa",
                column: "SexoId",
                unique: true);
        }
    }
}
