using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AguaMariaSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class Nuevamigraciondebidoacambiosenelcontexto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 2,
                column: "Mínimo",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 4,
                columns: new[] { "Máximo", "Mínimo" },
                values: new object[] { 700f, 0f });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 9,
                column: "Mínimo",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 10,
                column: "Mínimo",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 11,
                column: "Mínimo",
                value: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 2,
                column: "Mínimo",
                value: -3.4028235E+38f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 4,
                columns: new[] { "Máximo", "Mínimo" },
                values: new object[] { 3.4028235E+38f, -3.4028235E+38f });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 9,
                column: "Mínimo",
                value: -3.4028235E+38f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 10,
                column: "Mínimo",
                value: -3.4028235E+38f);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParametroId",
                keyValue: 11,
                column: "Mínimo",
                value: -3.4028235E+38f);
        }
    }
}
