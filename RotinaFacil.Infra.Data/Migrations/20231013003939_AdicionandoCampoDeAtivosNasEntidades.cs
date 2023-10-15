using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoDeAtivosNasEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Telefone",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Coluna para controlar o registro ativo")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pessoa",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Coluna para controlar o registro ativo")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Endereco",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Coluna para controlar o registro ativo")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Email",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Coluna para controlar o registro ativo")
                .Annotation("Relational:ColumnOrder", 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Email");
        }
    }
}
