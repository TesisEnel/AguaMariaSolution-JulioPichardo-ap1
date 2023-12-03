using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AguaMariaSolutionsDoNet8.Migrations
{
    /// <inheritdoc />
    public partial class Nuevatablaproductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Imagen = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Botella de Agua" },
                    { 2, null, "5 Galones de Agua" },
                    { 3, null, "1 Galon de Agua" },
                    { 4, null, "Litro y Medio de Agua" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductoId",
                table: "Reviews",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Productos_ProductoId",
                table: "Reviews",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Productos_ProductoId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductoId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });
        }
    }
}
