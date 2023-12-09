using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AguaMariaSolutionsDoNet8.Migrations
{
    /// <inheritdoc />
    public partial class Creado_classe_ParametrosCreados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametrosCreados",
                columns: table => new
                {
                    CreadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParametroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripción = table.Column<string>(type: "TEXT", nullable: true),
                    Mínimo = table.Column<float>(type: "REAL", nullable: false),
                    Máximo = table.Column<float>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosCreados", x => x.CreadoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametrosCreados");
        }
    }
}
