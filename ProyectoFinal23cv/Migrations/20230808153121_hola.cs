using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal23cv.Migrations
{
    public partial class hola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkCarreras",
                table: "Maestros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkGrupos",
                table: "Maestros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkCarreras",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "FkGrupos",
                table: "Maestros");
        }
    }
}
