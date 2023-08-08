using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Maestros
    {
        [Key]
        public int PkMaestros { get; set; }
        public string NombreMaestros { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechasRegistrada { get; set; }

        [ForeignKey("Papel")]
        public int? FkPapel { get; set; }
        public Papel Papel { get; set; }


        public int FkCarreras { get; set; }
        public int FkGrupos { get; set; }

    }
}
