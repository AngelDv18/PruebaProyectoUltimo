using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Carrera
    {
        [Key]
        public int PKCarrera { get; set; }
        public string NombreCarrera { get; set; }

    }
}
