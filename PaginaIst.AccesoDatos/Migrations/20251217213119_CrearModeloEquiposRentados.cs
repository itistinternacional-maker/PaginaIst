using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CrearModeloEquiposRentados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquiposRentados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<int>(type: "int", nullable: false),
                    Id_Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Inicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Final = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Tipoequipo = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nit_Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Garantia = table.Column<int>(type: "int", nullable: false),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad_Fuente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clase_DiscoN1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad_Disco_N1 = table.Column<int>(type: "int", nullable: false),
                    Clase_Disco_N2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad_Disco_N2 = table.Column<int>(type: "int", nullable: false),
                    MEMORIA_RAM_N1 = table.Column<int>(type: "int", nullable: false),
                    MEMORIA_RAM_N2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposRentados", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquiposRentados");
        }
    }
}
