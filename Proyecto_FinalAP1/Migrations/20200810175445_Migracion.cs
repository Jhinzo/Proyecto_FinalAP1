using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_FinalAP1.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Mesa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    ItbisTotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "Platillos",
                columns: table => new
                {
                    PlatilloId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillos", x => x.PlatilloId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    NivelUsuario = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacturaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Importe = table.Column<double>(nullable: false),
                    Itbis = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Ordenes_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Cedula", "Contraseña", "Email", "Fecha", "NivelUsuario", "Nombre", "Telefono", "UserName" },
                values: new object[] { 1, "Manager", "4028907891", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, new DateTime(2020, 8, 10, 13, 54, 44, 68, DateTimeKind.Local).AddTicks(6930), "Administrador", "Manager", "8099081234", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_FacturaId",
                table: "Ordenes",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Platillos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
