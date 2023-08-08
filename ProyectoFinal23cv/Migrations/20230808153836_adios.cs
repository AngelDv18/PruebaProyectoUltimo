using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal23cv.Migrations
{
    public partial class adios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkMaestros",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkMaestros",
                table: "Carreras");
        }
    }
}
