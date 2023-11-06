using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AguaMariaSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlCalidadAgua",
                columns: table => new
                {
                    ControlCalidadAguaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AcciónTomada = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntidadMuestreoAguaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TandaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidadAgua", x => x.ControlCalidadAguaId);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Dirección = table.Column<string>(type: "TEXT", nullable: false),
                    Teléfono = table.Column<string>(type: "TEXT", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "EntidadesMuestreoAgua",
                columns: table => new
                {
                    EntidadesMuestreoAguaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripción = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadesMuestreoAgua", x => x.EntidadesMuestreoAguaId);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    ParametroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripción = table.Column<string>(type: "TEXT", nullable: false),
                    Mínimo = table.Column<float>(type: "REAL", nullable: false),
                    Máximo = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.ParametroId);
                });

            migrationBuilder.CreateTable(
                name: "ControlCalidadAguaDetalle",
                columns: table => new
                {
                    ControlCalidadAguaDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ControlCalidadAguaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParametroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    Pasó = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidadAguaDetalle", x => x.ControlCalidadAguaDetalleId);
                    table.ForeignKey(
                        name: "FK_ControlCalidadAguaDetalle_ControlCalidadAgua_ControlCalidadAguaId",
                        column: x => x.ControlCalidadAguaId,
                        principalTable: "ControlCalidadAgua",
                        principalColumn: "ControlCalidadAguaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlCalidadProductoTerminado",
                columns: table => new
                {
                    ProductoTerminadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AcciónTomada = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TandaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidadProductoTerminado", x => x.ProductoTerminadoId);
                    table.ForeignKey(
                        name: "FK_ControlCalidadProductoTerminado_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTerminadosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoTerminadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParametroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    Pasó = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTerminadosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ProductoTerminadosDetalle_ControlCalidadProductoTerminado_ProductoTerminadoId",
                        column: x => x.ProductoTerminadoId,
                        principalTable: "ControlCalidadProductoTerminado",
                        principalColumn: "ProductoTerminadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EntidadesMuestreoAgua",
                columns: new[] { "EntidadesMuestreoAguaId", "Descripción" },
                values: new object[,]
                {
                    { 1, "Cisterna 1" },
                    { 2, "Cisterna 2" },
                    { 3, "Cisterna 3" },
                    { 4, "INAPA" },
                    { 5, "Filtro Carbón Activado" },
                    { 6, "Ablandadores" },
                    { 7, "Ósmosis" }
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "ParametroId", "Descripción", "Máximo", "Mínimo" },
                values: new object[,]
                {
                    { 1, "Cloruro", 250f, 0f },
                    { 2, "Cloro Residual", 0f, -3.4028235E+38f },
                    { 3, "STD", 500f, 0f },
                    { 4, "Conductancia", 3.4028235E+38f, -3.4028235E+38f },
                    { 5, "Dureza", 500f, 0f },
                    { 6, "PH", 8.5f, 6.5f },
                    { 7, "Sulfato", 250f, 0f },
                    { 8, "Nitrato", 10f, 0f },
                    { 9, "Hierro", 0.3f, -3.4028235E+38f },
                    { 10, "Color", 5f, -3.4028235E+38f },
                    { 11, "Turbidez", 0.5f, -3.4028235E+38f },
                    { 12, "Sabor", 1f, 0f },
                    { 13, "Ozono", 0.1f, 0.05f },
                    { 14, "Lamp UV", 1f, 0f },
                    { 20, "Cloro Residual", 1.5f, 1f },
                    { 21, "Dureza", 500f, 68.4f },
                    { 22, "STD", 1000f, 70f },
                    { 23, "Color", 15f, 5f },
                    { 24, "Turbidez", 25f, 10f },
                    { 25, "Sulfato", 400f, 250f },
                    { 26, "Nitrato", 50f, 10f },
                    { 27, "PH", 8.5f, 6.5f },
                    { 30, "Cloro Residual", 0.05f, 0f },
                    { 31, "Color", 15f, 5f },
                    { 32, "Turbidez", 25f, 10f },
                    { 33, "Olor", 1f, 0f },
                    { 40, "Dureza", 500f, 0f },
                    { 41, "STD", 1000f, 70f },
                    { 42, "PH", 8.5f, 6.5f },
                    { 50, "PH", 8.5f, 6.5f },
                    { 51, "STD", 500f, 2f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidadAguaDetalle_ControlCalidadAguaId",
                table: "ControlCalidadAguaDetalle",
                column: "ControlCalidadAguaId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidadProductoTerminado_EmpleadoId",
                table: "ControlCalidadProductoTerminado",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTerminadosDetalle_ProductoTerminadoId",
                table: "ProductoTerminadosDetalle",
                column: "ProductoTerminadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlCalidadAguaDetalle");

            migrationBuilder.DropTable(
                name: "EntidadesMuestreoAgua");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "ProductoTerminadosDetalle");

            migrationBuilder.DropTable(
                name: "ControlCalidadAgua");

            migrationBuilder.DropTable(
                name: "ControlCalidadProductoTerminado");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
