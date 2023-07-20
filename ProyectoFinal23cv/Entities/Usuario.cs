using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("Papel")]
        public int? FkPapel { get; set; }
        public Papel Papel { get; set; }
    }
}
