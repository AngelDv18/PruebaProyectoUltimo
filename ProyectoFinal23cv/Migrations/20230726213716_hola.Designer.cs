﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal23cv.Context;

namespace ProyectoFinal23cv.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230726213716_hola")]
    partial class hola
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Alumnos", b =>
                {
                    b.Property<int>("PkAlumno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fechaqueregistro")
                        .HasColumnType("datetime");

                    b.Property<int?>("FkPapel")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NombreAlumno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkAlumno");

                    b.HasIndex("FkPapel");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Carrera", b =>
                {
                    b.Property<int>("PKCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKCarrera");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Grupo", b =>
                {
                    b.Property<int>("PKGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreGrupos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKGrupo");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Maestros", b =>
                {
                    b.Property<int>("PkMaestros")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechasRegistrada")
                        .HasColumnType("datetime");

                    b.Property<int?>("FkPapel")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NombreMaestros")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkMaestros");

                    b.HasIndex("FkPapel");

                    b.ToTable("Maestros");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Papel", b =>
                {
                    b.Property<int>("PKPapel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKPapel");

                    b.ToTable("Papel");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime");

                    b.Property<int?>("FkPapel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkPapel");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Alumnos", b =>
                {
                    b.HasOne("ProyectoFinal23cv.Entities.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("FkPapel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Maestros", b =>
                {
                    b.HasOne("ProyectoFinal23cv.Entities.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("FkPapel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal23cv.Entities.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("FkPapel");

                    b.Navigation("Papel");
                });
#pragma warning restore 612, 618
        }
    }
}