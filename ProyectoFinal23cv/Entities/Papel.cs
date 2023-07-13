using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23cv.Entities
{
    public class Papel
    {
        [Key]
        public int PKPapel { get; set; }
        public string Nombre { get; set; }
    }
}
