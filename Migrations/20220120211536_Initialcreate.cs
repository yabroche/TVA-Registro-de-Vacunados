using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TVA_Registro_de_Vacunados.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    IdTrabajador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreTrabajador = table.Column<string>(type: "TEXT", nullable: true),
                    ApellidosTrabajador = table.Column<string>(type: "TEXT", nullable: true),
                    EdadTrabajador = table.Column<string>(type: "TEXT", nullable: true),
                    CarneITrabajador = table.Column<string>(type: "TEXT", nullable: true),
                    DepartamentoTrabajador = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.IdTrabajador);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    CorreoUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreadoUsuario = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    IdVacuna = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreVacuna = table.Column<string>(type: "TEXT", nullable: true),
                    DosisVacuna = table.Column<string>(type: "TEXT", nullable: true),
                    LoteVacuna = table.Column<string>(type: "TEXT", nullable: true),
                    FechaVacuna = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.IdVacuna);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vacunas");
        }
    }
}
