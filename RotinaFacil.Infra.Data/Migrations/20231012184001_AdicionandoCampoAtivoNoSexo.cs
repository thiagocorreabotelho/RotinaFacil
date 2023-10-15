using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotinaFacil.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoAtivoNoSexo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Sexo",
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
                table: "Sexo");
        }
    }
}
