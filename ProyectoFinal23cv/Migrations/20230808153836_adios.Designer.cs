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
    [Migration("20230808153836_adios")]
    partial class adios
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

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Carreras", b =>
                {
                    b.Property<int>("PKCarreras")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FkMaestros")
                        .HasColumnType("int");

                    b.Property<string>("NombreCarreras")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKCarreras");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("ProyectoFinal23cv.Entities.Grupos", b =>
                {
                    b.Property<int>("PKGrupos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreGrupos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKGrupos");

                    b.ToTable("Grupos");
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

                    b.Property<int>("FkCarreras")
                        .HasColumnType("int");

                    b.Property<int>("FkGrupos")
                        .HasColumnType("int");

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
