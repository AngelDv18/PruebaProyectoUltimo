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
            options.UseMySQL("Server = localhost; database=cachajeje; user=root; password= ");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papel { get; set; }
    }
}
