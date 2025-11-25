using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloEquiposIst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<int>(type: "int", nullable: false),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Inicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Final = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Tipoequipo = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nit_Proveedor = table.Column<int>(type: "int", nullable: false),
                    Garantia = table.Column<int>(type: "int", nullable: false),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad_Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procesador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clase_DiscoN1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad_Disco_N1 = table.Column<int>(type: "int", nullable: false),
                    Clase_Disco_N2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad_Disco_N2 = table.Column<int>(type: "int", nullable: false),
                    MEMORIA_RAM_N1 = table.Column<int>(type: "int", nullable: false),
                    MEMORIA_RAM_N2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
