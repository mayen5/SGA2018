using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjemploEEF1.Model
{
    public class Profesor
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int NumeroCursos { get; set; }
        public int PuestoId { get; set; }
        public virtual Puesto Puesto { get; set; }

        public virtual ICollection<Clase> Clase { get; set; }
        public virtual ICollection<ProfesorCurso> ProfesorCurso { get; set; }

    }
}
