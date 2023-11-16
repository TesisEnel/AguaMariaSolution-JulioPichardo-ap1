using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AguaMariaSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class Nuevamigraciondebidoacambiosenelcontexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 12,
                column: "Mínimo",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 14,
                column: "Mínimo",
                value: 1f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 12,
                column: "Mínimo",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 14,
                column: "Mínimo",
                value: 0f);
        }
    }
}
