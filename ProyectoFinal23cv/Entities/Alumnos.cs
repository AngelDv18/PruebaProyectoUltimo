using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Alumnos
    {
        [Key]
        public int PkAlumno {get ; set;}
        public string NombreAlumno { get; set;}
        public string ApellidoP { get; set;}
        public string ApellidoM { get; set;}
        public DateTime Fechaqueregistro { get; set;}

        [ForeignKey("Papel")]
        public int? FkPapel { get; set; }
        public Papel Papel { get; set; }

    }
}
