using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal23cv.Migrations
{
    public partial class bb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkMaestros",
                table: "Carreras");

            migrationBuilder.AddColumn<int>(
                name: "FkCarreras",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkGrupos",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkCarreras",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "FkGrupos",
                table: "Alumnos");

            migrationBuilder.AddColumn<int>(
                name: "FkMaestros",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
