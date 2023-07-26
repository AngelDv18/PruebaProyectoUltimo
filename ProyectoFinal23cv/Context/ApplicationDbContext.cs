using Microsoft.EntityFrameworkCore;
using ProyectoFinal23cv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("Server = localhost; database=Proyectofinish23; user=root; password= ");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
    }
}
