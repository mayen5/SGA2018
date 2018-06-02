using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjemploEEF1.Model
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }

        public override string ToString()
        {
            return $"{this.CarreraId} | {this.Descripcion}";
        }
    }
}
