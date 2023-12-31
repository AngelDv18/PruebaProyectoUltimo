﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProyectoFinal23cv.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    PKCarreras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreCarreras = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.PKCarreras);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    PKGrupos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreGrupos = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.PKGrupos);
                });

            migrationBuilder.CreateTable(
                name: "Papel",
                columns: table => new
                {
                    PKPapel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papel", x => x.PKPapel);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    PkAlumno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreAlumno = table.Column<string>(type: "text", nullable: false),
                    ApellidoP = table.Column<string>(type: "text", nullable: false),
                    ApellidoM = table.Column<string>(type: "text", nullable: false),
                    Fechaqueregistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    FkPapel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.PkAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Papel_FkPapel",
                        column: x => x.FkPapel,
                        principalTable: "Papel",
                        principalColumn: "PKPapel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    PkMaestros = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreMaestros = table.Column<string>(type: "text", nullable: false),
                    Especialidad = table.Column<string>(type: "text", nullable: false),
                    FechasRegistrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    FkPapel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.PkMaestros);
                    table.ForeignKey(
                        name: "FK_Maestros_Papel_FkPapel",
                        column: x => x.FkPapel,
                        principalTable: "Papel",
                        principalColumn: "PKPapel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    FkPapel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Papel_FkPapel",
                        column: x => x.FkPapel,
                        principalTable: "Papel",
                        principalColumn: "PKPapel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_FkPapel",
                table: "Alumnos",
                column: "FkPapel");

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_FkPapel",
                table: "Maestros",
                column: "FkPapel");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkPapel",
                table: "Usuarios",
                column: "FkPapel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Papel");
        }
    }
}
