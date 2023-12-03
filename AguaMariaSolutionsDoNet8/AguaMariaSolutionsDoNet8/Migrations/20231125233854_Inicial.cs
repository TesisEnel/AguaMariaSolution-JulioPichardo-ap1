using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AguaMariaSolutionsDoNet8.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
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
                    Clave = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    Valoración = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaDeBotellon = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_ControlCalidadAgua_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
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
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "RecordLavadoraBotellones",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Temperatura = table.Column<float>(type: "REAL", nullable: false),
                    Detergente = table.Column<float>(type: "REAL", nullable: false),
                    AlcalinidadEnjuague = table.Column<string>(type: "TEXT", nullable: false),
                    DesinfectanteConcentración = table.Column<float>(type: "REAL", nullable: false),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcciónTomada = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordLavadoraBotellones", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_RecordLavadoraBotellones_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
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
                    { 2, "Cloro Residual", 0f, 0f },
                    { 3, "STD", 500f, 0f },
                    { 4, "Conductancia", 700f, 0f },
                    { 5, "Dureza", 500f, 0f },
                    { 6, "PH", 8.5f, 6.5f },
                    { 7, "Sulfato", 250f, 0f },
                    { 8, "Nitrato", 10f, 0f },
                    { 9, "Hierro", 0.3f, 0f },
                    { 10, "Color", 5f, 0f },
                    { 11, "Turbidez", 0.5f, 0f },
                    { 12, "Sabor", 1f, 1f },
                    { 13, "Ozono", 0.1f, 0.05f },
                    { 14, "Lamp UV", 1f, 1f },
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidadAgua_EmpleadoId",
                table: "ControlCalidadAgua",
                column: "EmpleadoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RecordLavadoraBotellones_EmpleadoId",
                table: "RecordLavadoraBotellones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClienteId",
                table: "Reviews",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ControlCalidadAguaDetalle");

            migrationBuilder.DropTable(
                name: "EntidadesMuestreoAgua");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "ProductoTerminadosDetalle");

            migrationBuilder.DropTable(
                name: "RecordLavadoraBotellones");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ControlCalidadAgua");

            migrationBuilder.DropTable(
                name: "ControlCalidadProductoTerminado");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
