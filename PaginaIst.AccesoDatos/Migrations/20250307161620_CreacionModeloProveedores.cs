using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    NIT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIRECCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FECHA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_FIN = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.NIT);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
