using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaIst.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloEquipoSoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo_Software",
                columns: table => new
                {
                    ID_EQÚIPO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SOFTWARE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo_Software", x => x.ID_EQÚIPO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo_Software");
        }
    }
}
