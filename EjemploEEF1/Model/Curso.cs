using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjemploEEF1.Model
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<ProfesorCurso> ProfesorCurso { get; set; }
    }
}
