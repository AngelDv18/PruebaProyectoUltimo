using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Grupo
    {
        [Key]
        public int PKGrupo { get; set; }
        public string NombreGrupos { get; set; }
    }
}
