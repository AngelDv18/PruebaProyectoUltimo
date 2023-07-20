﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal23cv.Context;

namespace ProyectoFinal23cv.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

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
