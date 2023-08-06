using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Carreras
    {
        [Key]
        public int PKCarreras { get; set; }
        public string NombreCarreras { get; set; }

    }
}
