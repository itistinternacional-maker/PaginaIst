using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloHistoriaSalario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historia_Salario",
                columns: table => new
                {
                    ID_EMPLEADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SALARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FECHA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_FIN = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia_Salario", x => x.ID_EMPLEADO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historia_Salario");
        }
    }
}
