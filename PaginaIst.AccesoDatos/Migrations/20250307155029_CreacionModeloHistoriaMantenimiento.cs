using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloHistoriaMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historia_Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_EQUIPO = table.Column<int>(type: "int", nullable: false),
                    ID_MTTO = table.Column<int>(type: "int", nullable: false),
                    Fecha_MTTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_MTTO_FUTURO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia_Mantenimientos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historia_Mantenimientos");
        }
    }
}
