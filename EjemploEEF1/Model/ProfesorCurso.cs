using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploEEF1.Model
{
    public class ProfesorCurso
    {
        //[Key,Column(Order = 0)]
        //[ForeignKey("Curso")]
        public int CursoId { get; set; }
        //[Key, Column(Order = 1)]
        //[ForeignKey("Profesor")]
        public int ProfesorId { get; set; }
        public string Tutor { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
