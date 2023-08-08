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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Alumnos>().HasData(
        //        new Alumnos
        //        {

        //        }

        //        );
        //}
        //{  modelBuilder.Entity<Cliente>().HasData(
        //        new Cliente
        //                {
        //                    PkCliente = 1,
        //                    NombreCliente = "Juan",
        //                    ApellidoCliente = "Perez",
        //                    PasswordCliente = "123",
        //                    CorreoCliente = "arriba@gmail.com",
        //                    FkRol = 1
        //                }
        //                );
        //            modelBuilder.Entity<Vendedor>().HasData(
        //                new Vendedor
        //                {
        //                    PkVendedor = 1,
        //                    NombreVendedor = "Juan",
        //                    ApellidoVendedor = "Gonzalez",
        //                    CorreoV = "juan.gonzalez@gmail.com",
        //                    ContraseñaVendedor = "546546",
        //                    FkRol = 2
        //                },
        //                new Vendedor
        //                {
        //                    PkVendedor = 2,
        //                    NombreVendedor = "Maria",
        //                    ApellidoVendedor = "Silva",
        //                    CorreoV = "maria.silva@gmail.com",
        //                    ContraseñaVendedor = "564643",
        //                    FkRol = 2
        //                },
        //                new Vendedor
        //                {
        //                    PkVendedor = 3,
        //                    NombreVendedor = "Cristian",
        //                    ApellidoVendedor = "Rojas",
        //                    CorreoV = "cristian.rojas@gmail.com",
        //                    ContraseñaVendedor = "234324",
        //                    FkRol = 2
        //                },
        //                new Vendedor
        //                {
        //                    PkVendedor = 4,
        //                    NombreVendedor = "Leonardo",
        //                    ApellidoVendedor = "Perez",
        //                    CorreoV = "diablo@gmail.com",
        //                    ContraseñaVendedor = "123",
        //                    FkRol = 3
        //                    //
        //                }
        //                ) ;
        //modelBuilder.Entity<SuperAdmin>().HasData(
        //    new SuperAdmin
        //    {
        //        PkSuperAdmin = 1,
        //        NombreSuperAdmin = "Felipe",
        //        ApellidoSuperAdmin = "Gutierrez",
        //        CorreoSuperAdmin = "Felipe@gmail.com",
        //        ContraseñaSuperAdmin = "123",
        //        FkRol = 3
        //    });
        //modelBuilder.Entity<Rol>().HasData(
        //    new Rol
        //    {
        //        PkRol = 1,
        //        RolName = "Cliente"
        //    },
        //    new Rol
        //    {
        //        PkRol = 2,
        //        RolName = "Vendedor",

        //    },
        //    new Rol
        //    {
        //        PkRol = 3,
        //        RolName = "SA",
        //    }
        //    );
        //modelBuilder.Entity<Tamano>().HasData(
        //    new Tamano
        //    {
        //        PkTamano = 1,
        //        TamanoP = "Chico"
        //    },
        //    new Tamano
        //    {
        //        PkTamano = 2,
        //        TamanoP = "Mediano"
        //    },
        //    new Tamano
        //    {
        //        PkTamano = 3,
        //        TamanoP = "Grande"
        //    }
        //    );
        //modelBuilder.Entity<Lote>().HasData(
        //    new Lote
        //    {
        //        PkLote = 1,
        //        NomLote = 1
        //    },
        //    new Lote
        //    {
        //        PkLote = 2,
        //        NomLote = 2
        //    },
        //    new Lote
        //    {
        //        PkLote = 3,
        //        NomLote = 3
        //    },
        //    new Lote
        //    {
        //        PkLote = 4,
        //        NomLote = 4
        //    },
        //    new Lote
        //    {
        //        PkLote = 5,
        //        NomLote = 5
        //    },
        //    new Lote
        //    {
        //        PkLote = 6,
        //        NomLote = 6
        //    },
        //    new Lote
        //    {
        //        PkLote = 7,
        //        NomLote = 7
        //    },
        //    new Lote
        //    {
        //        PkLote = 8,
        //        NomLote = 8
        //    },
        //    new Lote
        //    {
        //        PkLote = 9,
        //        NomLote = 9
        //    }
        //    );
        //modelBuilder.Entity<Sabor>().HasData(
        //    new Sabor
        //    {
        //        PkSabor = 1,
        //        NameSabor = "Natural",
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 2,
        //        NameSabor = "Cola"
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 3,
        //        NameSabor = "Naranja"
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 4,
        //        NameSabor = "Limon"
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 5,
        //        NameSabor = "Negro"
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 6,
        //        NameSabor = "Lager",
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 7,
        //        NameSabor = "Fresa",
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 8,
        //        NameSabor = "Merlot"
        //    },
        //    new Sabor
        //    {
        //        PkSabor = 9,
        //        NameSabor = "Pina"
        //    }
        //    );
    }
}
