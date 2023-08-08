using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using ProyectoFinal23cv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("Server = localhost; database=Proyectofinal23cv; user=root; password= ");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Grupos> Grupos { get; set; }


       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
       //     modelBuilder.Entity<Usuario>().HasData(
       //     new Usuario { PkUsuario = 1, Nombre = "Azrael", UserName = "azra@32", Password = "8942", FkPapel = 1 },
       //     new Usuario { PkUsuario = 2, Nombre = "Camilo", UserName = "Ceon21", Password = "4856", FkPapel = 2 }
       //     );
       //     modelBuilder.Entity<Papel>().HasData(
       //new Papel { PKPapel = 1, Nombre = "SA" },
       //new Papel { PKPapel = 2, Nombre = "Admin" }
       // // Agregar más roles aquí
       //      );


       // }

    }
            
          
}

