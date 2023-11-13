using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AguaMariaSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class Segundamigraciondebidoacambiosenelmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TandaId",
                table: "ControlCalidadProductoTerminado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TandaId",
                table: "ControlCalidadProductoTerminado",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
